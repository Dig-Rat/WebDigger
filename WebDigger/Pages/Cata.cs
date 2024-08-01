using System.Collections.Generic;
using System.Text.Json.Serialization;
//using System.Threading.Tasks;

namespace WebDigger.Pages
{
    public class Cata
    {
        public Cata()
        {
        }

        private int _Page = 0;
        private List<Pages.Threads> _ThreadList = new List<Pages.Threads>();

        [JsonPropertyName("page")]
        public int Page { get => _Page; set => _Page = value; }
        //[JsonPropertyName("threads")]
        //public List<Thread> ThreadList { get => _ThreadList; set => _ThreadList = value; }



    }
}
