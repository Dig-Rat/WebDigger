using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebDigger.Pages;

namespace WebDigger
{
    internal class Diglet
    {
        // Main entry point for the logic here.
        public static void DigContent()
        {
            List<Board> boards = GetBoards();
#if RELEASE
            if (!FilterNsfw())
            {
                // if false, only allow 'safe for work' content.
                boards = new List<Board>(boards.AsEnumerable().Where(x => x.WorkSafe == 1));
                //boards = boards.AsEnumerable().Where(x => x.WorkSafe == 1).ToList(); 
            }
            // Have user select a board to search.
            Board board = SelectBoard(boards: boards);
#elif DEBUG
            //string boardDebug = "g";
            //Board board = boards.AsEnumerable().Where(x => x.Directory == boardDebug).First();
            Board board = SelectBoard(boards: boards);
#endif
            DateTime startTime = DateTime.Now;

            // Get the board thread ids.
            List<int> threadIds = new List<int>();
            // For every page, get the thread Ids on it.
            ThreadList[] boardPages = GetThreadList(board: board.Directory);
            for (int i = 0; i < boardPages.Length; i++)
            {
                Console.WriteLine($"Page: {i + 1}");
                int[] pageThreadIds = boardPages[i].ThreadsList.AsEnumerable().Select(x => x.OpId).ToArray();
                threadIds.AddRange(pageThreadIds);
            }
            // For each thread Id, load the entire thread.
            for (int i = 0; i < threadIds.Count; i++)
            {
                Console.WriteLine($"Thread: {i + 1} of {threadIds.Count}\tThread Id: {threadIds[i]}");
                SearchThreadPosts(boardDir: board.Directory, threadId: threadIds[i]);                
            }
            
            // Search the board archive if it has one.
            if (board.Archived == 1)
            {
                int[] archiveThreadIds = GetArchiveThreadIds(board: board.Directory);
                for (int i = 0; i < archiveThreadIds.Length; i++)
                {
                    Console.WriteLine($"Archive Thread: {i + 1} of {archiveThreadIds.Length}");
                    SearchThreadPosts(boardDir: board.Directory, threadId: archiveThreadIds[i]);
                }
            }

            Console.WriteLine($"BEEP");
        }

        // --
        private static void SearchThreadPosts(string boardDir, int threadId)
        {
            Posts[] posts = GetThreadPosts(board: boardDir, threadId: threadId);
            Console.WriteLine($"Thread Posts: {posts.Length}");
            for (int i = 0; i < posts.Length; i++)
            {
                Posts post = posts[i];

                // Calculate percentage completion
                double progressPercentage = (double)i / posts.Length;
                // Update the progress bar
                UpdateProgressBar(progressPercentage);

                if (post.FileSize > 0)
                {
                    string localFilePath = LocalFilePathBuilder(board: boardDir, threadId: threadId, fileName: post.FileName, fileExt: post.FileType);
                    string remoteFilePath = RemoteFilePathBuilder(board: boardDir, imageId: post.Time, fileExt: post.FileType);
                    Task task = HttpDownload(url: remoteFilePath, filePath: localFilePath);
                    task.Wait(millisecondsTimeout: 1000);
                }
            }
            ClearProgressBar();            
        }

        #region "Http Client"

        // Instance of http client
        static readonly HttpClient client = new HttpClient();

        // Http Request via httpclient
        private static async Task<string> SendHttpRequest(string url)
        {
            string responseBody = null;
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                using HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();                
                // Wait 1 second.
                ThrottleRequest();
                // Above three lines can be replaced with new helper method below
                //string responseBody2 = await client.GetStringAsync(uri);
                //Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return responseBody;
        }

        // Simulate a 1 second wait for API requests.
        private static void ThrottleRequest()
        {
            System.Threading.Thread.Sleep(1000);
        }

        // Builds the hosted file path to be used for downloading.
        private static string RemoteFilePathBuilder(string board, long imageId, string fileExt)
        {
            // https://github.com/4chan/4chan-API/blob/master/pages/User_images_and_static_content.md
            // Example url
            // https://i.4cdn.org/g/1594686780709.png
            const string HttpPrefix = @"https://i.4cdn.org";
            string url = $"{HttpPrefix}/{board}/{imageId}{fileExt}";
            return url;
        }        
        
        // Builds the hosted file path to be used for downloading.
        private static Uri RemoteFileUriBuilder(string board, long imageId, string fileExt)
        {
            // https://github.com/4chan/4chan-API/blob/master/pages/User_images_and_static_content.md
            // https://i.4cdn.org/g/1594686780709.png
            const string HttpPrefix = @"https://i.4cdn.org";
            string urlString = $"{HttpPrefix}/{board}/{imageId}{fileExt}";
            // https://learn.microsoft.com/en-us/dotnet/api/system.uri?view=net-8.0
            Uri uri = new Uri(uriString: urlString);
            //Console.WriteLine(uri.AbsolutePath);
            return uri;
        }

        // Download files served from requests.
        private static async Task HttpDownload(string url, string filePath)
        {
            // need to ensure exclusive lock for file.            
            if (File.Exists(filePath) && IsFileLocked(file: new FileInfo(filePath)))
            {
                // append timestamp to file name, new file name.
                string fileExt = Path.GetExtension(filePath);
                filePath = filePath.Replace(fileExt, "");
                filePath += DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff") + fileExt;
                //Console.WriteLine($"New Path: {filePath}");
            }
            try
            {
                using (var response = await client.GetAsync(requestUri: url, completionOption: HttpCompletionOption.ResponseHeadersRead))
                {
                    // Throw if not a success code.            
                    response.EnsureSuccessStatusCode();
                    // Read the content into a MemoryStream and then write to file
                    using (Stream ms = await response.Content.ReadAsStreamAsync())
                    using (FileStream fs = File.Create(path: filePath))
                    {
                        await ms.CopyToAsync(fs);
                        fs.Flush();
                    }
                }
                ThrottleRequest();
            }
            catch(IOException ex)
            {
                string pError = $"IO Error: {ex.Message}";
                pError += $"{Environment.NewLine}url: {url}";
                pError += $"{Environment.NewLine}file: {filePath}";
                Console.WriteLine(pError);
            }            
            catch (Exception ex)
            {
                string pError = $"Error: {ex.Message}";                
                Console.WriteLine(pError);
            }            
            return;
        }

        #endregion

        #region "IO"

        // progress bar for console.
        private static void UpdateProgressBar(double progress)
        {
            const int totalProgressBarWidth = 50;
            int progressBarWidth = (int)(progress * totalProgressBarWidth);

            // Draw the progress bar
            Console.Write("[");
            for (int i = 0; i < totalProgressBarWidth; i++)
            {
                if (i < progressBarWidth)
                    Console.Write("=");
                else
                    Console.Write(" ");
            }
            // \r moves cursor to the beginning of the line
            Console.Write($"] {progress:P0}\r"); 
        }        

        // Reset line used for progress bar.
        private static void ClearProgressBar()
        {
            Console.Write($"{new string(c: ' ', count: 100)}\r");
        }

        // Checks if the file is locked by another process.
        protected static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException ex)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                //Console.WriteLine("Locked: " + file.FullName);
                Console.WriteLine($"File Locked: {ex}");
                return true;
            }

            //file is not locked
            return false;
        }

        // Builds the target file path for files to be streamed to.
        private static string LocalFilePathBuilder(string board, int threadId, string fileName, string fileExt)
        {
            // Do NOT allow for file names to exceed 64 char.
            int maxLength = 64;
            if (fileName.Length > maxLength)
            {
                fileName = fileName.Substring(0, maxLength);
            }
            // Cleanse the file name of invalid chars.
            char[] invalidChars = Path.GetInvalidFileNameChars();
            fileName = string.Concat(fileName.Split(invalidChars));

            // Should use relative pathing instead.
            const string dirPathBase = @"C:/WebDiggerYield/";
            string filePath = Path.Combine(dirPathBase, board + "/", threadId.ToString() + "/", fileName + fileExt);
            FileInfo file = new FileInfo(filePath);
            // check if dir exist, create if not.
            // base -> board -> thread -> file
            Directory.CreateDirectory(path: file.Directory.FullName);
            // Check is path is valid.
            if (!Path.IsPathFullyQualified(path: file.FullName))
            {
                Console.WriteLine($"Bad Path: {file.FullName}");
            }
            // If total path is over twice the size of the [max]file name, something may be screwy...
            if (filePath.Length > maxLength * 2)
            {
                throw new Exception($"Check your file path:{Environment.NewLine}{filePath}");
            }
            return filePath;
        }

        // Write the thread topic and comments to a text file.
        private static void WriteThreadToFile(string board, int threadId)
        {
            // temp/to do
            string commentStr = "";
            commentStr = HttpUtility.HtmlDecode(s: commentStr);
        }


        #endregion

        #region "Boards"        

        // Get an array of board objects from json API.
        private static List<Board> GetBoards()
        {
            const string boardsUrl = "https://a.4cdn.org/boards.json";
            string jsonStr = SendHttpRequest(boardsUrl).Result;            
            Boards boards = System.Text.Json.JsonSerializer.Deserialize<Boards>(json: jsonStr);
            //List<Board> boardList = boards.BoardList;
            return boards.BoardList;
        }

        // prompt user for including nsfw boards.        
        private static bool FilterNsfw()
        {
            bool allowNsfw;
            Console.WriteLine("Include Nsfw? (y/n)");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                allowNsfw = true;
            }
            else if (input.ToLower() == "n")
            {
                allowNsfw = false;
            }
            else
            {
                // default if false if user cant answer correctly.
                allowNsfw = false;
            }
            return allowNsfw;
        }

        // Select a board to search based on user input.
        private static Board SelectBoard(List<Board> boards)
        {
            Console.WriteLine("Enter the board you want to search.");
            for (int i = 0; i < boards.Count; i++)
            {
                Console.WriteLine($"{i + 1}:{boards.Count}:{boards[i].Directory}\t{boards[i].Title}");
            }
            string[] boardDirs = boards.AsEnumerable().Select(x => x.Directory).ToArray();
            Board board = null;
            bool loopBoard = true;
            while (loopBoard)
            {
                string boardInput = Console.ReadLine();
                boardInput = boardInput.Trim();
                boardInput = boardInput.ToLower();
                if (boardDirs.Contains(boardInput))
                {
                    for (int i = 0; i < boards.Count; i++)
                    {
                        if (boards[i].Directory == boardInput)
                        {
                            board = boards[i];
                            break;
                        }
                    }
                    //board = boards.Where(x => x.Directory == boardInput).Single();
                    if (board != null)
                    {
                        loopBoard = false;
                    }
                }
            }
            return board;
        }

        #endregion
        #region "Thread List"

        // Get basic info about threads on a board.
        private static ThreadList[] GetThreadList(string board)
        {
            // example: https://a.4cdn.org/po/threads.json
            string requestUrl = $"https://a.4cdn.org/{board}/threads.json";
            string jsonStr = SendHttpRequest(url: requestUrl).Result;
            List<ThreadList> threadLists = new List<ThreadList>();
            JsonDocument jsonDoc = JsonDocument.Parse(json: jsonStr);
            using (jsonDoc)
            {
                // NOTE: root ele is array!
                JsonElement rootEle = jsonDoc.RootElement;
                for (int i = 0; i < rootEle.GetArrayLength() - 1; i++)
                {
                    JsonElement threadsListEle = rootEle[i];
                    ThreadList threadList = System.Text.Json.JsonSerializer.Deserialize<Pages.ThreadList>(json: threadsListEle.ToString());
                    threadLists.Add(threadList);
                }
            }
            return threadLists.ToArray();
        }

        #endregion
        #region "Thread Posts"

        // Process json data on a thread/post.
        private static Posts[] GetThreadPosts(string board, int threadId)
        {
            // example: https://a.4cdn.org/po/thread/570368.json            
            string catalogUrl = $"https://a.4cdn.org/{board}/thread/{threadId}.json";
            string jsonStr = SendHttpRequest(url: catalogUrl).Result;
            try
            {
                Pages.Threads threadObj = System.Text.Json.JsonSerializer.Deserialize<Pages.Threads>(jsonStr);
                Pages.Posts[] posts = threadObj.Posts;
                return posts;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // If the thread dies.
                // if jsonStr == null
                return new Posts[0];
            }
        }

        #endregion
        #region "Archive"

        // Get the thread Ids of archived threads for a board.
        private static int[] GetArchiveThreadIds(string board)
        {
            // example: https://a.4cdn.org/po/archive.json
            string requestUrl = $"https://a.4cdn.org/{board}/archive.json";
            string jsonStr = SendHttpRequest(url: requestUrl).Result;
            int[] threadIds = System.Text.Json.JsonSerializer.Deserialize<int[]>(json: jsonStr);
            return threadIds;
        }

        #endregion

        #region "Index"

        // Get info about threads given a board and page number.
        private static Pages.Threads[] GetIndex(string board, int page)
        {
            // example: https://a.4cdn.org/po/2.json
            string requestUrl = $"https://a.4cdn.org/{board}/{page}.json";
            string jsonStr = SendHttpRequest(url: requestUrl).Result;
            Pages.Index index = System.Text.Json.JsonSerializer.Deserialize<Pages.Index>(json: jsonStr);
            return index.Threads.ToArray();
        }

        #endregion
        
        #region "Catalog"

        // Request the catalog data data from the json API. [ FIX ]
        private static void GetCatalogThreads(string board)
        {
            // example: https://a.4cdn.org/po/catalog.json            
            string requestUrl = $"https://a.4cdn.org/{board}/catalog.json";
            string jsonStr = SendHttpRequest(url: requestUrl).Result;

            Dictionary<int, List<Thread>> keyValuePairs = new Dictionary<int, List<Thread>>();


            JsonDocument jsonDoc = JsonDocument.Parse(json: jsonStr);
            using (jsonDoc)
            {
                // Root element is array!!
                JsonElement rootEle = jsonDoc.RootElement;
                Console.WriteLine("beep");
                for (int i = 0; i < rootEle.GetArrayLength() - 1; i++)
                {
                    //Console.WriteLine($"{i+1}:{rootEle.GetArrayLength()}");
                    JsonElement threads = rootEle[i].GetProperty(propertyName: "threads");
                    foreach (JsonElement thread in threads.EnumerateArray())
                    {
                        JsonElement id = thread.GetProperty(propertyName: "no");
                        int idVal = Convert.ToInt32(id.ToString());
                        //id.Clone();
                    }
                }

            }

            Catalog catalog = System.Text.Json.JsonSerializer.Deserialize<Pages.Catalog>(json: jsonStr);
            //var threadList = System.Text.Json.JsonSerializer.Deserialize<ThreadList>(json: jsonStr);
            //var breads = System.Text.Json.JsonSerializer.Deserialize<Cata>(json: jsonStr);
            return;
        }

        #endregion

    }
}
