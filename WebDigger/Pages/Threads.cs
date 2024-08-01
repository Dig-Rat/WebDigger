using System.Text.Json.Serialization;

namespace WebDigger.Pages
{
    public class Threads
    {
        public Threads()
        {
        }
        private Posts[] _Posts;
        [JsonPropertyName("posts")]
        public Posts[] Posts { get => _Posts; set => _Posts = value; }
        //private List<Posts> _Posts = new List<Posts>();
        //[JsonPropertyName("posts")]
        //public List<Posts> Posts { get => _Posts; set => _Posts = value; }
    }

    public class Posts
    {
        // The numeric post ID
        private int _PostId = 0;
        // For replies: this is the ID of the thread being replied to. For OP: this value is zero
        private int _ReplyCount = 0;
        // If the thread is being pinned to the top of the page
        private int _Sticky = 0;
        // If the thread is closed to replies
        private int _Closed = 0;
        // MM/DD/YY(Day)HH:MM (:SS on some boards), EST/EDT timezone
        private string _Now;
        // UNIX timestamp the post was created
        private int _UnixTime = 0;
        // Name user posted with. Defaults to Anonymous
        private string _Name = "";
        // The user's tripcode, in format: !tripcode or !!securetripcode
        private string _Trip = "";
        // The poster's ID
        private string _Id = "";
        // The capcode identifier for a post
        private string _CapCode = "";
        // Poster's ISO 3166-1 alpha-2 country code
        private string _Country = "";
        // Poster's country name
        private string _CountryName = "";
        // Poster's board flag code 
        private string _BoardFlag = "";
        // Poster's board flag name
        private string _FlagName = "";
        // OP Subject text
        private string _Subject = "";
        // Comment (HTML escaped)
        private string _Comment = "";
        // Unix timestamp + microtime that an image was uploaded
        private long _Time = 0;
        // Filename as it appeared on the poster's device
        private string _FileName = "";
        // Filetype
        private string _FileType = "";
        // Size of uploaded file in bytes
        private int _FileSize = 0;
        // 24 character, packed base64 MD5 hash of file
        private string _Md5 = "";
        // Image width dimension
        private int _ImageWidth = 0;
        // Image height dimension
        private int _ImageHeight = 0;
        // Thumbnail image width dimension
        private int _ThumbnailWidth = 0;
        // Thumbnail image height dimension
        private int _ThumbnailHeight = 0;
        // If the file was deleted from the post
        private int _FileDeleted = 0;
        // If the image was spoilered or not
        private int _Spoiler = 0;
        // The custom spoiler ID for a spoilered image
        private int _CustomSpoiler = 0;
        // Total number of replies to a thread
        private int _Replies = 0;
        // Total number of image replies to a thread
        private int _Images = 0;
        // If a thread has reached bumplimit, it will no longer bump
        private int _BumpLimit = 0;
        // If an image has reached image limit, no more image replies can be made
        private int _ImageLimit = 0;
        // The category of .swf upload
        private string _Tag = "";
        // SEO URL slug for thread
        private string _SemantinUrl = "";
        // Year 4chan pass bought 	
        private int _Since4Pass = 0;
        // Number of unique posters in a thread
        private int _UniqueIps = 0;
        // Mobile optimized image exists for post
        private int _Mobile = 0;
        // Thread has reached the board's archive
        private int _Archived = 0;
        // UNIX timestamp the post was archived
        private int _ArchivedTime = 0;



        [JsonPropertyName("no")]
        public int PostId { get => _PostId; set => _PostId = value; }
        [JsonPropertyName("resto")]
        public int ReplyCount { get => _ReplyCount; set => _ReplyCount = value; }
        [JsonPropertyName("sticky")]
        public int Sticky { get => _Sticky; set => _Sticky = value; }
        [JsonPropertyName("closed")]
        public int Closed { get => _Closed; set => _Closed = value; }
        [JsonPropertyName("now")]
        public string Now { get => _Now; set => _Now = value; }
        [JsonPropertyName("time")]
        public int UnixTime { get => _UnixTime; set => _UnixTime = value; }
        [JsonPropertyName("name")]
        public string Name { get => _Name; set => _Name = value; }
        [JsonPropertyName("trip")]
        public string Trip { get => _Trip; set => _Trip = value; }
        [JsonPropertyName("id")]
        public string Id { get => _Id; set => _Id = value; }
        [JsonPropertyName("capcode")]
        public string CapCode { get => _CapCode; set => _CapCode = value; }
        [JsonPropertyName("country")]
        public string Country { get => _Country; set => _Country = value; }
        [JsonPropertyName("country_name")]
        public string CountryName { get => _CountryName; set => _CountryName = value; }
        [JsonPropertyName("board_flag")]
        public string BoardFlag { get => _BoardFlag; set => _BoardFlag = value; }
        [JsonPropertyName("flag_name")]
        public string FlagName { get => _FlagName; set => _FlagName = value; }
        [JsonPropertyName("sub")]
        public string Subject { get => _Subject; set => _Subject = value; }
        [JsonPropertyName("com")]
        public string Comment { get => _Comment; set => _Comment = value; }
        [JsonPropertyName("tim")]
        public long Time { get => _Time; set => _Time = value; }
        [JsonPropertyName("filename")]
        public string FileName { get => _FileName; set => _FileName = value; }
        [JsonPropertyName("ext")]
        public string FileType { get => _FileType; set => _FileType = value; }
        [JsonPropertyName("fsize")]
        public int FileSize { get => _FileSize; set => _FileSize = value; }
        [JsonPropertyName("md5")]
        public string Md5 { get => _Md5; set => _Md5 = value; }
        [JsonPropertyName("w")]
        public int ImageWidth { get => _ImageWidth; set => _ImageWidth = value; }
        [JsonPropertyName("h")]
        public int ImageHeight { get => _ImageHeight; set => _ImageHeight = value; }
        [JsonPropertyName("tn_w")]
        public int ThumbnailWidth { get => _ThumbnailWidth; set => _ThumbnailWidth = value; }
        [JsonPropertyName("tn_h")]
        public int ThumbnailHeight { get => _ThumbnailHeight; set => _ThumbnailHeight = value; }
        [JsonPropertyName("filedeleted")]
        public int FileDeleted { get => _FileDeleted; set => _FileDeleted = value; }
        [JsonPropertyName("spoiler")]
        public int Spoiler { get => _Spoiler; set => _Spoiler = value; }
        [JsonPropertyName("custom_spoiler")]
        public int CustomSpoiler { get => _CustomSpoiler; set => _CustomSpoiler = value; }
        [JsonPropertyName("replies")]
        public int Replies { get => _Replies; set => _Replies = value; }
        [JsonPropertyName("images")]
        public int Images { get => _Images; set => _Images = value; }
        [JsonPropertyName("bumplimit")]
        public int BumpLimit { get => _BumpLimit; set => _BumpLimit = value; }
        [JsonPropertyName("imagelimit")]
        public int ImageLimit { get => _ImageLimit; set => _ImageLimit = value; }
        [JsonPropertyName("tag")]
        public string Tag { get => _Tag; set => _Tag = value; }
        [JsonPropertyName("semantic_url")]
        public string SemantinUrl { get => _SemantinUrl; set => _SemantinUrl = value; }
        [JsonPropertyName("since4pass")]
        public int Since4Pass { get => _Since4Pass; set => _Since4Pass = value; }
        [JsonPropertyName("unique_ips")]
        public int UniqueIps { get => _UniqueIps; set => _UniqueIps = value; }
        [JsonPropertyName("m_img")]
        public int Mobile { get => _Mobile; set => _Mobile = value; }
        [JsonPropertyName("archived")]
        public int Archived { get => _Archived; set => _Archived = value; }
        [JsonPropertyName("archived_on")]
        public int ArchivedTime { get => _ArchivedTime; set => _ArchivedTime = value; }
    }

}
