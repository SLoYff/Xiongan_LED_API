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
using 雄安LED屏数据传输API.Models.PICTURE;

namespace 雄安LED屏数据传输API.Controllers
{
    public class UpdatePictureController : ApiController
    {
        //PC端数据插入指令
        [HttpPost]
        public dynamic updateData(PictureResponse response)
        {
            string strDSN = "SERVER=senlinxunjian.mysql.rds.aliyuncs.com; DATABASE=nurnsery;UID=dbadmin;PWD=ccbfu6233";        /*************定义数据库连接字符串****************/
            string strSQL = "";

            MySqlConnection myConn = new MySqlConnection(strDSN);
            MySqlCommand myCmd = new MySqlCommand(strSQL, myConn);

            Convert.ToInt32(response.number);
            int length = Convert.ToInt32(response.number);
            StringBuilder com = new StringBuilder();
            com.Append("update XionganPicture set number = '5',");

            for (int i=1;i<length+1;i++)
            {
                
                com.Append("picture"+i+"id = '" + response.picture[i-1].id + "',Picture" + i + "objectName = '" + response.picture[i-1].objectName + "',Picture" + i + "fileName = '" + response.picture[i-1].fileName + "',Picture" + i + "fileSize = '" + response.picture[i-1].fileSize + "',Picture" + i + "MD5 = '" + response.picture[i-1].MD5 + "',");
                
            }
            com.Remove(com.Length - 1,1);
            com.Append("where ID = '" + response.id + "'");

            //string command = "update XionganPicture set number = '"+ response.number +"'," +
            //    "picture1id = '" + response.picture[0].id + "',Picture1objectName = '" + response.picture[0].objectName + "',Picture1fileName = '" + response.picture[0].fileName + "',Picture1fileSize = '" + response.picture[0].fileSize + "',Picture1MD5 = '" + response.picture[0].MD5 + "'," +
            //    "picture2id = '" + response.picture[1].id + "',Picture2objectName = '" + response.picture[1].objectName + "',Picture2fileName = '" + response.picture[1].fileName + "',Picture2fileSize = '" + response.picture[1].fileSize + "',Picture2MD5 = '" + response.picture[1].MD5 + "'," +
            //    "picture3id = '" + response.picture[2].id + "',Picture3objectName = '" + response.picture[2].objectName + "',Picture3fileName = '" + response.picture[2].fileName + "',Picture3fileSize = '" + response.picture[2].fileSize + "',Picture3MD5 = '" + response.picture[2].MD5 + "'," +
            //    "picture4id = '" + response.picture[3].id + "',Picture4objectName = '" + response.picture[3].objectName + "',Picture4fileName = '" + response.picture[3].fileName + "',Picture4fileSize = '" + response.picture[3].fileSize + "',Picture4MD5 = '" + response.picture[3].MD5 + "'," +
            //    "picture5id = '" + response.picture[4].id + "',Picture5objectName = '" + response.picture[4].objectName + "',Picture5fileName = '" + response.picture[4].fileName + "',Picture5fileSize = '" + response.picture[4].fileSize + "',Picture5MD5 = '" + response.picture[4].MD5 + "' " +
            //    "where ID = '" + response.id + "'";    //数据库发送口令


            try
            {
                myConn.Open();
                myCmd.CommandText = Convert.ToString(com);
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
