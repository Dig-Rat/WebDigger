using System.Text.Json.Serialization;

// integer 1 = (on) or 0 (off)

namespace WebDigger.Pages
{
    public class Board
    {
        // The directory the board is located in.
        private string _Directory = "";
        // The readable title at the top of the board.
        private string _Title = "";
        // Is the board worksafe
        private int _WorkSafe = 0;
        // How many threads are on a single index page
        private int _ThreadPerPage = 0;
        // How many index pages does the board have
        private int _Pages = 0;
        // Maximum file size allowed for non .webm attachments (in KB)
        private int _MaxFileSize = 0;
        // Maximum file size allowed for .webm attachments (in KB)
        private int _MaxWebmFileSize = 0;
        // Maximum number of characters allowed in a post comment
        private int _MaxCommentChars = 0;
        // Maximum duration of a .webm attachment (in seconds)
        private int _MaxwebmDuration = 0;
        // Maximum number of replies allowed to a thread before the thread stops bumping
        private int _BumpLimit = 0;
        // Maximum number of image replies per thread before image replies are discarded
        private int _ImageLimit = 0;
        // Array of int board limits.
        private BoardCooldowns _BoardCooldowns = new BoardCooldowns();
        // SEO meta description content for a board
        private string _MetaDescription = "";
        // Are spoilers enabled
        private int _Spoilers = 0;
        // How many custom spoilers does the board have
        private int _SpoilersEnabled = 0;
        // Are archives enabled for the board
        private int _Archived = 0;
        // Array of flag codes mapped to flag names
        private BoardFlags _BoardFlags = new BoardFlags();
        // Are flags showing the poster's country enabled on the board
        private int _CountryFlags = 0;
        // Are poster ID tags enabled on the board 	        
        private int _UserIds = 0;
        // Can users submit drawings via browser the Oekaki app
        private int _Oekaki = 0;
        // Can users submit sjis drawings using the [sjis] tags
        private int _SjisTags = 0;
        // Board supports code syntax highlighting using the [code] tags
        private int _CodeTags = 0;
        // Board supports [math] TeX and [eqn] tags
        private int _MathTags = 0;
        // Is image posting disabled for the board
        private int _TextOnly = 0;
        // Is the name field disabled on the board
        private int _ForcedAnon = 0;
        // Are webms with audio allowed?
        private int _WebmAudio = 0;
        // Do OPs require a subject
        private int _RequireSubject = 0;
        // What is the minimum image width (in pixels)
        private int _MinImageWidth = 0;
        // What is the minimum image height (in pixels)
        private int _MinImageHeight = 0;

        public Board()
        {
        }

        [JsonPropertyName("board")]
        public string Directory { get => _Directory; set => _Directory = value; }
        [JsonPropertyName("title")]
        public string Title { get => _Title; set => _Title = value; }
        [JsonPropertyName("ws_board")]
        public int WorkSafe { get => _WorkSafe; set => _WorkSafe = value; }
        [JsonPropertyName("per_page")]
        public int ThreadPerPage { get => _ThreadPerPage; set => _ThreadPerPage = value; }
        [JsonPropertyName("pages")]
        public int Pages { get => _Pages; set => _Pages = value; }
        [JsonPropertyName("max_filesize")]
        public int MaxFileSize { get => _MaxFileSize; set => _MaxFileSize = value; }
        [JsonPropertyName("max_webm_filesize")]
        public int MaxWebmFileSize { get => _MaxWebmFileSize; set => _MaxWebmFileSize = value; }
        [JsonPropertyName("max_comment_chars")]
        public int MaxCommentChars { get => _MaxCommentChars; set => _MaxCommentChars = value; }
        [JsonPropertyName("max_webm_duration")]
        public int MaxwebmDuration { get => _MaxwebmDuration; set => _MaxwebmDuration = value; }
        [JsonPropertyName("bump_limit")]
        public int BumpLimit { get => _BumpLimit; set => _BumpLimit = value; }
        [JsonPropertyName("image_limit")]
        public int ImageLimit { get => _ImageLimit; set => _ImageLimit = value; }
        [JsonPropertyName("cooldowns")]
        public BoardCooldowns BoardCooldowns { get => _BoardCooldowns; set => _BoardCooldowns = value; }
        [JsonPropertyName("meta_description")]
        public string MetaDescription { get => _MetaDescription; set => _MetaDescription = value; }
        [JsonPropertyName("spoilers")]
        public int Spoilers { get => _Spoilers; set => _Spoilers = value; }
        [JsonPropertyName("custom_spoilers")]
        public int SpoilersEnabled { get => _SpoilersEnabled; set => _SpoilersEnabled = value; }
        [JsonPropertyName("is_archived")]
        public int Archived { get => _Archived; set => _Archived = value; }
        [JsonPropertyName("board_flags")]
        public BoardFlags BoardFlags { get => _BoardFlags; set => _BoardFlags = value; }
        [JsonPropertyName("country_flags")]
        public int CountryFlags { get => _CountryFlags; set => _CountryFlags = value; }
        [JsonPropertyName("user_ids")]
        public int UserIds { get => _UserIds; set => _UserIds = value; }
        [JsonPropertyName("oekaki")]
        public int Oekaki { get => _Oekaki; set => _Oekaki = value; }
        [JsonPropertyName("sjis_tags")]
        public int SjisTags { get => _SjisTags; set => _SjisTags = value; }
        [JsonPropertyName("code_tags")]
        public int CodeTags { get => _CodeTags; set => _CodeTags = value; }
        [JsonPropertyName("math_tags")]
        public int MathTags { get => _MathTags; set => _MathTags = value; }
        [JsonPropertyName("text_only")]
        public int TextOnly { get => _TextOnly; set => _TextOnly = value; }
        [JsonPropertyName("forced_anon")]
        public int ForcedAnon { get => _ForcedAnon; set => _ForcedAnon = value; }
        [JsonPropertyName("webm_audio")]
        public int WebmAudio { get => _WebmAudio; set => _WebmAudio = value; }
        [JsonPropertyName("require_subject")]
        public int RequireSubject { get => _RequireSubject; set => _RequireSubject = value; }
        [JsonPropertyName("min_image_width")]
        public int MinImageWidth { get => _MinImageWidth; set => _MinImageWidth = value; }
        [JsonPropertyName("min_image_height")]
        public int MinImageHeight { get => _MinImageHeight; set => _MinImageHeight = value; }
    }

}
