using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using 雄安LED屏数据传输API.Models;
using MySql.Data.MySqlClient;
using System.Data;
using Newtonsoft.Json;

namespace 雄安LED屏数据传输API.Controllers
{
    public class ScreenOpenController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            string strDSN = "SERVER=senlinxunjian.mysql.rds.aliyuncs.com; DATABASE=nurnsery;UID=dbadmin;PWD=ccbfu6233";        /*************定义数据库连接字符串****************/
            string strSQL = "";

            MySqlConnection myConn = new MySqlConnection(strDSN);
            MySqlCommand myCmd = new MySqlCommand(strSQL, myConn);

            string command = "select * from XionganisScreenopen ";    //数据库发送口令

            MySqlDataAdapter dap = new MySqlDataAdapter(command, myConn);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            int length = dt.Rows.Count;
            if (length == 0)
            {
                dt.Dispose();
                dap.Dispose();
                myConn.Dispose();
                return "NO DATA";
            }


            else
            {

                string response = dt.Rows[0][0].ToString();
                
                dap.Dispose();
                myConn.Dispose();
                return response;

                //返回json格式
                //isScreenOpen ScreenOpen = new isScreenOpen();
                //ScreenOpen.IsScreenOpen = Convert.ToBoolean(response);
                //string a = JsonConvert.SerializeObject(ScreenOpen);
                //return a;


            }
        }


        // POST api/<controller>
        [HttpPost]
        public dynamic Post([FromBody]isScreenOpen data)
        {

            string strDSN = "SERVER=senlinxunjian.mysql.rds.aliyuncs.com; DATABASE=nurnsery;UID=dbadmin;PWD=ccbfu6233";        /*************定义数据库连接字符串****************/
            string strSQL = "";

            MySqlConnection myConn = new MySqlConnection(strDSN);
            MySqlCommand myCmd = new MySqlCommand(strSQL, myConn);

            string command = "update XionganisScreenopen set isscreenopen = '" + data.IsScreenOpen + "'";    //数据库发送口令
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