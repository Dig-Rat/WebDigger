using System.Text.Json.Serialization;

// integer 1 = (on) or 0 (off)

namespace WebDigger.Pages
{
    public class BoardCooldowns
    {
        private int _Threads = 0;
        private int _Replies = 0;
        private int _Images = 0;

        public BoardCooldowns()
        {
        }

        [JsonPropertyName("threads")]
        public int Threads { get => _Threads; set => _Threads = value; }
        [JsonPropertyName("replies")]
        public int Replies { get => _Replies; set => _Replies = value; }
        [JsonPropertyName("images")]
        public int Images { get => _Images; set => _Images = value; }
    }

}
