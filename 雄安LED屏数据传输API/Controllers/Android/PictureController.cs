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
using 雄安LED屏数据传输API.Models.PICTURE;

namespace 雄安LED屏数据传输API.Controllers
{
    public class PictureController : ApiController
    {
        //安卓端数据请求指令
        [HttpGet]
        public dynamic getData(string ID)
        {

            string strDSN = "SERVER=senlinxunjian.mysql.rds.aliyuncs.com; DATABASE=nurnsery;UID=dbadmin;PWD=ccbfu6233";        /*************定义数据库连接字符串****************/

            MySqlConnection myConn = new MySqlConnection(strDSN);


            string command = "select * from XionganPicture where ID =  '" + ID + "'";    //数据库发送口令

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
                string P2id = dt.Rows[0][7].ToString(); string P2obN = dt.Rows[0][8].ToString(); string P2fN = dt.Rows[0][9].ToString(); string P2fS = dt.Rows[0][10].ToString(); string P2MD5 = dt.Rows[0][11].ToString();
                string P3id = dt.Rows[0][12].ToString(); string P3obN = dt.Rows[0][13].ToString(); string P3fN = dt.Rows[0][14].ToString(); string P3fS = dt.Rows[0][15].ToString(); string P3MD5 = dt.Rows[0][16].ToString();
                string P4id = dt.Rows[0][17].ToString(); string P4obN = dt.Rows[0][18].ToString(); string P4fN = dt.Rows[0][19].ToString(); string P4fS = dt.Rows[0][20].ToString(); string P4MD5 = dt.Rows[0][21].ToString();
                string P5id = dt.Rows[0][22].ToString(); string P5obN = dt.Rows[0][23].ToString(); string P5fN = dt.Rows[0][24].ToString(); string P5fS = dt.Rows[0][25].ToString(); string P5MD5 = dt.Rows[0][26].ToString();


                PictureContent content = new PictureContent();
                content.meta = new PictureMeta();
                content.response = new List<PictureResponse>();
                content.response.Add(new PictureResponse());
                content.response[0].picture = new List<Picture>();
                content.response[0].picture.Add(new Picture());
                content.response[0].picture.Add(new Picture());
                content.response[0].picture.Add(new Picture());
                content.response[0].picture.Add(new Picture());
                content.response[0].picture.Add(new Picture());
                content.error = new List<PictureError>();
                content.error.Add(new PictureError());


                if (P1id != null && P1fS != null && P1obN != null)
                {
                    content.meta.status = 200;
                    content.meta.msg = "OK";
                    content.response[0].id = id; content.response[0].number = number;
                    content.response[0].picture[0].id = P1id; content.response[0].picture[0].objectName = P1obN; content.response[0].picture[0].fileName = P1fN; content.response[0].picture[0].fileSize = P1fS; content.response[0].picture[0].MD5 = P1MD5;
                    content.response[0].picture[1].id = P2id; content.response[0].picture[1].objectName = P2obN; content.response[0].picture[1].fileName = P2fN; content.response[0].picture[1].fileSize = P2fS; content.response[0].picture[1].MD5 = P2MD5;
                    content.response[0].picture[2].id = P3id; content.response[0].picture[2].objectName = P3obN; content.response[0].picture[2].fileName = P3fN; content.response[0].picture[2].fileSize = P3fS; content.response[0].picture[2].MD5 = P3MD5;
                    content.response[0].picture[3].id = P4id; content.response[0].picture[3].objectName = P4obN; content.response[0].picture[3].fileName = P4fN; content.response[0].picture[3].fileSize = P4fS; content.response[0].picture[3].MD5 = P4MD5;
                    content.response[0].picture[4].id = P5id; content.response[0].picture[4].objectName = P5obN; content.response[0].picture[4].fileName = P5fN; content.response[0].picture[4].fileSize = P5fS; content.response[0].picture[4].MD5 = P5MD5;
                    content.error[0].title = "";
                    content.error[0].code = 0;
                    content.error[0].detail = "";
                }
                else
                {
                    content.meta.status = 404;
                    content.meta.msg = "ERROR";
                    content.response[0].id = id; content.response[0].number = number;
                    content.response[0].picture[0].id = P1id; content.response[0].picture[0].objectName = P1obN; content.response[0].picture[0].fileName = P1fN; content.response[0].picture[0].fileSize = P1fS; content.response[0].picture[0].MD5 = P1MD5;
                    content.response[0].picture[1].id = P2id; content.response[0].picture[1].objectName = P2obN; content.response[0].picture[1].fileName = P2fN; content.response[0].picture[1].fileSize = P2fS; content.response[0].picture[1].MD5 = P2MD5;
                    content.response[0].picture[2].id = P3id; content.response[0].picture[2].objectName = P3obN; content.response[0].picture[2].fileName = P3fN; content.response[0].picture[2].fileSize = P3fS; content.response[0].picture[2].MD5 = P3MD5;
                    content.response[0].picture[3].id = P4id; content.response[0].picture[3].objectName = P4obN; content.response[0].picture[3].fileName = P4fN; content.response[0].picture[3].fileSize = P4fS; content.response[0].picture[3].MD5 = P4MD5;
                    content.response[0].picture[4].id = P5id; content.response[0].picture[4].objectName = P5obN; content.response[0].picture[4].fileName = P5fN; content.response[0].picture[4].fileSize = P5fS; content.response[0].picture[4].MD5 = P5MD5;
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
