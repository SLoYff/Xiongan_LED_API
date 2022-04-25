using System;
using System.Web;
using System.Collections.Generic;


namespace 雄安LED屏数据传输API.Models
{
    public class Video
    {
        public string id { get; set; }
        public string objectName { get; set; }
        public string fileName { get; set; }
        public string fileSize { get; set; }
        public string MD5 { get; set; }
    }
}
