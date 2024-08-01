using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebDigger.Pages
{
    public class ThreadList
    {
        public ThreadList()
        {
        }

        // The page number that the following threads array is on
        private int _Page = 0;
        // The array of thread objects
        //private ThreadListThread[] _Threads;
        private List<ThreadListThread> _ThreadsList = new List<ThreadListThread>();

        [JsonPropertyName("page")]
        public int Page { get => _Page; set => _Page = value; }
        //[JsonPropertyName("threads")]
        //public ThreadListThread[] Threads { get => _Threads; set => _Threads = value; }
        [JsonPropertyName("threads")]
        public List<ThreadListThread> ThreadsList { get => _ThreadsList; set => _ThreadsList = value; }
    }

    public class ThreadListThread
    {
        // The OP ID of a thread
        private int _OpId = 0;
        // The UNIX timestamp marking the last time the thread was modified (post added/modified/deleted, thread closed/sticky settings modified)
        private long _LastModified = 0;
        // A numeric count of the number of replies in the thread
        private int _Replies = 0;

        [JsonPropertyName("no")]
        public int OpId { get => _OpId; set => _OpId = value; }
        [JsonPropertyName("last_modified")]
        public long LastModified { get => _LastModified; set => _LastModified = value; }
        [JsonPropertyName("replies")]
        public int Replies { get => _Replies; set => _Replies = value; }

    }

}
