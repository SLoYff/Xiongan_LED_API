using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 雄安LED屏数据传输API.Models.PICTURE
{
    public class PictureContent
    {
        public PictureMeta meta { get; set; }
        public List<PictureResponse> response { get; set; }
        public List<PictureError> error { set; get; } 
    }
}
