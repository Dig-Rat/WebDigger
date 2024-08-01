using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebDigger.Pages
{
    internal class Index
    {
        public Index()
        {
        }
        // index | threads(15?) | posts(5?)
        private List<Threads> threads = new List<Threads>();
        [JsonPropertyName("threads")]
        public List<Threads> Threads { get => threads; set => threads = value; }

        //// The numeric post ID
        //private int _PostId = 0;
        //// For replies: this is the ID of the thread being replied to. For OP: this value is zero
        //private int _ReplyId = 0;
        //// If the thread is being pinned to the top of the page
        //private int _Sticky = 0;
        //// If the thread is closed to replies
        //private int _Closed = 0;
        //// MM/DD/YY(Day)HH:MM (:SS on some boards), EST/EDT timezone
        //private string _Now = "";
        //// UNIX timestamp the post was created
        //private int _UnixTime = 0;
        //// Name user posted with. Defaults to Anonymous
        //private string _Name = "";
        //// The user's tripcode, in format: !tripcode or !!securetripcode
        //private string _Trip = "";
        //// The poster's ID
        //private string _Id = "";
        //// The capcode identifier for a post
        //private string _CapCode = "";
        //// Poster's ISO 3166-1 alpha-2 country code
        //private string _Country = "";
        //// Poster's country name
        //private string _CountryCode = "";
        //// OP only, if subject was included
        //private string _Subject = "";
        //// Comment (HTML escaped)
        //private string _Comment = "";
        //// Unix timestamp + microtime that an image was uploaded
        //private int _Time = 0;
        //// Filename as it appeared on the poster's device
        //private string _FileName = "";
        //// Filetype
        //private string _FileType = "";
        //// Size of uploaded file in bytes
        //private int _FileSize = 0;
        //// 24 character, packed base64 MD5 hash of file
        //private string _Md5 = "";
        //// Image width dimension
        //private int _ImageWidth = 0;
        //// Image height dimension
        //private int _ImageHeight = 0;
        //// Thumbnail image width dimension
        //private int _ThumbnailWidth = 0;
        //// Thumbnail image height dimension
        //private int _ThumbnailHeight = 0;
        //// If the file was deleted from the post
        //private int _FileDeleted = 0;
        //// If the image was spoilered or not
        //private int _Spoiler = 0;
        //// The custom spoiler ID for a spoilered image
        //private int _CustomSpoiler = 0;
        //// Number of replies minus the number of previewed replies
        //private int _OmittedPosts = 0;
        //// Number of image replies minus the number of previewed image replies
        //private int _OmittedImages = 0;
        //// Total number of replies to a thread
        //private int _Replies = 0;
        //// Total number of image replies to a thread
        //private int _Images = 0;
        //// If a thread has reached bumplimit, it will no longer bump
        //private int _BumpLimit = 0;
        //// If an image has reached image limit, no more image replies can be made
        //private int _ImageLimit = 0;
        //// The UNIX timestamp marking the last time the thread was modified (post added/modified/deleted, thread closed/sticky settings modified)
        //private int _LastModified = 0;
        //// The category of .swf upload
        //private string _Tag = "";
        //// SEO URL slug for thread
        //private string _Semanticurl = "";
        //// Year 4chan pass bought
        //private int _Since4Pass = 0;
        //// Number of unique posters in a thread
        //private int _UniqueIps = 0;
        //// Mobile optimized image exists for post
        //private int _MobileImage = 0;

        //[JsonPropertyName("no")]
        //public int PostId { get => _PostId; set => _PostId = value; }
        //[JsonPropertyName("resto")]
        //public int ReplyId { get => _ReplyId; set => _ReplyId = value; }
        //[JsonPropertyName("sticky")]
        //public int Sticky { get => _Sticky; set => _Sticky = value; }
        //[JsonPropertyName("closed")]
        //public int Closed { get => _Closed; set => _Closed = value; }
        //[JsonPropertyName("now")]
        //public string Now { get => _Now; set => _Now = value; }
        //[JsonPropertyName("time")]
        //public int UnixTime { get => _UnixTime; set => _UnixTime = value; }
        //[JsonPropertyName("name")]
        //public string Name { get => _Name; set => _Name = value; }
        //[JsonPropertyName("trip")]
        //public string Trip { get => _Trip; set => _Trip = value; }
        //[JsonPropertyName("id")]
        //public string Id { get => _Id; set => _Id = value; }
        //[JsonPropertyName("capcode")]
        //public string CapCode { get => _CapCode; set => _CapCode = value; }
        //[JsonPropertyName("country")]
        //public string Country { get => _Country; set => _Country = value; }
        //[JsonPropertyName("country_name")]
        //public string CountryCode { get => _CountryCode; set => _CountryCode = value; }
        //[JsonPropertyName("sub")]
        //public string Subject { get => _Subject; set => _Subject = value; }
        //[JsonPropertyName("com")]
        //public string Comment { get => _Comment; set => _Comment = value; }
        //[JsonPropertyName("tim")]
        //public int Time { get => _Time; set => _Time = value; }
        //[JsonPropertyName("filename")]
        //public string FileName { get => _FileName; set => _FileName = value; }
        //[JsonPropertyName("ext")]
        //public string FileType { get => _FileType; set => _FileType = value; }
        //[JsonPropertyName("fsize")]
        //public int FileSize { get => _FileSize; set => _FileSize = value; }
        //[JsonPropertyName("md5")]
        //public string Md5 { get => _Md5; set => _Md5 = value; }
        //[JsonPropertyName("w")]
        //public int ImageWidth { get => _ImageWidth; set => _ImageWidth = value; }
        //[JsonPropertyName("h")]
        //public int ImageHeight { get => _ImageHeight; set => _ImageHeight = value; }
        //[JsonPropertyName("tn_w")]
        //public int ThumbnailWidth { get => _ThumbnailWidth; set => _ThumbnailWidth = value; }
        //[JsonPropertyName("tn_h")]
        //public int ThumbnailHeight { get => _ThumbnailHeight; set => _ThumbnailHeight = value; }
        //[JsonPropertyName("filedeleted")]
        //public int FileDeleted { get => _FileDeleted; set => _FileDeleted = value; }
        //[JsonPropertyName("spoiler")]
        //public int Spoiler { get => _Spoiler; set => _Spoiler = value; }
        //[JsonPropertyName("custom_spoiler")]
        //public int CustomSpoiler { get => _CustomSpoiler; set => _CustomSpoiler = value; }
        //[JsonPropertyName("omitted_posts")]
        //public int OmittedPosts { get => _OmittedPosts; set => _OmittedPosts = value; }        
        //[JsonPropertyName("omitted_images")]
        //public int OmittedImages { get => _OmittedImages; set => _OmittedImages = value; }
        //[JsonPropertyName("replies")]
        //public int Replies { get => _Replies; set => _Replies = value; }
        //[JsonPropertyName("images")]
        //public int Images { get => _Images; set => _Images = value; }
        //[JsonPropertyName("bumplimit")]
        //public int BumpLimit { get => _BumpLimit; set => _BumpLimit = value; }
        //[JsonPropertyName("imagelimit")]
        //public int ImageLimit { get => _ImageLimit; set => _ImageLimit = value; }
        //[JsonPropertyName("last_modified")]
        //public int LastModified { get => _LastModified; set => _LastModified = value; }
        //[JsonPropertyName("tag")]
        //public string Tag { get => _Tag; set => _Tag = value; }
        //[JsonPropertyName("semantic_url")]
        //public string Semanticurl { get => _Semanticurl; set => _Semanticurl = value; }
        //[JsonPropertyName("since4pass")]
        //public int Since4Pass { get => _Since4Pass; set => _Since4Pass = value; }
        //[JsonPropertyName("unique_ips")]
        //public int UniqueIps { get => _UniqueIps; set => _UniqueIps = value; }
        //[JsonPropertyName("m_img")]
        //public int MobileImage { get => _MobileImage; set => _MobileImage = value; }

    }
}
