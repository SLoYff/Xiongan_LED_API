using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Configuration;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.Odbc;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using 雄安LED屏数据传输API.Models;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Runtime.Serialization.Json;

namespace 雄安LED屏数据传输API.Controllers
{
    public class VideoController : ApiController
    {
        //安卓端数据请求指令
        [HttpGet]
        public dynamic getData(string ID)
        {
            
            string strDSN = "SERVER=senlinxunjian.mysql.rds.aliyuncs.com; DATABASE=nurnsery;UID=dbadmin;PWD=ccbfu6233";        /*************定义数据库连接字符串****************/

            MySqlConnection myConn = new MySqlConnection(strDSN);

            
                string command = "select * from xionganvideo where ID =  '" + ID + "'";    //数据库发送口令

                MySqlDataAdapter dap = new MySqlDataAdapter(command, myConn);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                int length = dt.Rows.Count;
                if (length == 0)
                {
                    dt.Dispose();
                    dap.Dispose();
                    myConn.Dispose();
                    return "ID is UNexist";
                }
                

                else
                {
                string id = dt.Rows[0][0].ToString(); string number = dt.Rows[0][1].ToString();
                string P1id = dt.Rows[0][2].ToString(); string P1obN = dt.Rows[0][3].ToString(); string P1fN = dt.Rows[0][4].ToString(); string P1fS = dt.Rows[0][5].ToString(); string P1MD5 = dt.Rows[0][6].ToString();


                VideoContent content = new VideoContent();
                content.meta = new VideoMeta();
                content.response = new List<VideoResponse>();
                content.response.Add(new VideoResponse());
                content.response[0].video = new List<Video>();
                content.response[0].video.Add(new Video());
                content.error = new List<VideoError>();
                content.error.Add(new VideoError());


                if (P1id != null && P1fS != null && P1obN != null)
                {
                    content.meta.status = 200;
                    content.meta.msg = "OK";
                    content.response[0].id = id; content.response[0].number = number;
                    content.response[0].video[0].id = P1id; content.response[0].video[0].objectName = P1obN; content.response[0].video[0].fileName = P1fN; content.response[0].video[0].fileSize = P1fS; content.response[0].video[0].MD5 = P1MD5;
                    content.error[0].title = "";
                    content.error[0].code = 0;
                    content.error[0].detail = "";
                }
                else
                {
                    content.meta.status = 404;
                    content.meta.msg = "ERROR";
                    content.response[0].id = id; content.response[0].number = number;
                    content.response[0].video[0].id = P1id; content.response[0].video[0].objectName = P1obN; content.response[0].video[0].fileName = P1fN; content.response[0].video[0].fileSize = P1fS; content.response[0].video[0].MD5 = P1MD5;
                    content.error[0].title = "";
                    content.error[0].code = 0;
                    content.error[0].detail = "";

                }



                dap.Dispose();
                myConn.Dispose();



                return Json(content);
                }
            

        }

    }
}
