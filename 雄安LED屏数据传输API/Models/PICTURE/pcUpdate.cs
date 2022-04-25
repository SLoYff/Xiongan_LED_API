using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 雄安LED屏数据传输API.Models.PICTURE
{
    public class pcUpdate
    {
        public string number { get; set; }
        public string objectname { get; set; }
        public string filename { get; set; }
        public string filesize { get; set; }
        public string MD5 { get; set; }
    }
}