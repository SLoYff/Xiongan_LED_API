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
using Newtonsoft.Json.Converters;
using MySql.Data.MySqlClient;
using 雄安LED屏数据传输API.Models;

namespace 雄安LED屏数据传输API.Controllers
{
    public class UpdateVideoController : ApiController
    {
        //PC端数据插入指令
        [HttpPost]
        public string updateData(VideoResponse response)
        {
            string strDSN = "SERVER=senlinxunjian.mysql.rds.aliyuncs.com; DATABASE=nurnsery;UID=dbadmin;PWD=ccbfu6233";        /*************定义数据库连接字符串****************/
            string strSQL = "";

            MySqlConnection myConn = new MySqlConnection(strDSN);
            MySqlCommand myCmd = new MySqlCommand(strSQL, myConn);

            string command = "update XionganVideo set number = '" + response.number + "'," +
                "Video1id = '" + response.video[0].id + "',Video1objectName = '" + response.video[0].objectName + "',Video1fileName = '" + response.video[0].fileName + "',Video1fileSize = '" + response.video[0].fileSize + "',Video1MD5 = '" + response.video[0].MD5 + "'" +
                "where ID = '" + response.id + "'";    //数据库发送口令



            try
            {
                myConn.Open();
                myCmd.CommandText = command;
                myCmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //MessageBox.Show(ee.Message);
                return "Failed";
            }
            finally
            {
                myConn.Close();
            }
            return "Successed";

        }
    }
}
