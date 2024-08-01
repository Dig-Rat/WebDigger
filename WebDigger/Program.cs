using System;
using System.IO;

namespace WebDigger
{
    class Program
    {
        // Primary entry point of program.
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;
            //Console.WriteLine("Start");
            Diglet.DigContent();
            //Console.WriteLine("beep beep");
            //Console.WriteLine("Finish");
            DateTime endTime = DateTime.Now;
            TimeSpan timeSpan = endTime - startTime;
            Console.WriteLine($"Working time: {timeSpan.Seconds} Seconds");
        }


        // Write string to logfile.
        private static void Log(string msg)
        {
            // Check dir exist, create if not.
            string fileDir = "C:/Logs/";
            if (!System.IO.Directory.Exists(path: fileDir))
            {
                System.IO.Directory.CreateDirectory(path: fileDir);
            }
            DateTime now = DateTime.Now;
            // Prepare file name.
            string datestamp = now.ToString("yyyy-MM-dd");
            //datestamp = string.Format(format: "yyyy-MM-dd", arg0: now);
            string fileName = "WebDigLog" + datestamp + ".txt";
            // Prepare file path.
            string filePath = Path.Join(path1: fileDir, path2: fileName);
            // Prepend message with timestamp.            
            string timestamp = now.ToString("[yyyy.MM.dd_HH:mm:ss] ");
            msg = timestamp + msg;
            // Write to file.
            System.Text.Encoding fileEncoding = System.Text.Encoding.UTF8;
            StreamWriter writer = new StreamWriter(path: filePath, append: true, encoding: fileEncoding);
            try
            {
                using (writer)
                {
                    writer.WriteLine(msg);
                }
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex}"); ;
            }            
        }



    }
}
