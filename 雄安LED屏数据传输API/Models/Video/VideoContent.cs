using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 雄安LED屏数据传输API.Models
{
    public class VideoContent
    {
        public VideoMeta meta { get; set; }
        public List<VideoResponse> response { get; set; }
        public List<VideoError> error { set; get; } 
    }
}
