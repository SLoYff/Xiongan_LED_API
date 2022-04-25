using System;
using System.Web;
using System.Collections.Generic;

namespace 雄安LED屏数据传输API.Models.PICTURE
{
    public class PictureResponse
    {
        public string id { get; set; }
        public string number { get; set; }
        public List<Picture> picture{ get; set; }
    }
}
