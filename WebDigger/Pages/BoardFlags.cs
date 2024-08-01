using System.Text.Json.Serialization;

// integer 1 = (on) or 0 (off)

namespace WebDigger.Pages
{
    public class BoardFlags
    {
        private string _AB = "";
        private string _XY = "";

        public BoardFlags()
        {
        }

        [JsonPropertyName("AB")]
        public string AB { get => _AB; set => _AB = value; }
        [JsonPropertyName("XY")]
        public string XY { get => _XY; set => _XY = value; }
    }

}
