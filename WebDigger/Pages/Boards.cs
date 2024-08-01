using System.Collections.Generic;
using System.Text.Json.Serialization;

// integer 1 = (on) or 0 (off)

namespace WebDigger.Pages
{
    public class Boards
    {
        private List<Board> _BoardList = new List<Board>();

        public Boards()
        {
        }

        [JsonPropertyName("boards")]
        public List<Board> BoardList { get => _BoardList; set => _BoardList = value; }
    }

}
