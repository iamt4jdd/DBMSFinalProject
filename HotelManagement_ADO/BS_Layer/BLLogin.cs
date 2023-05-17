using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement_ADO.DB_Layer;

namespace HotelManagement_ADO.BS_Layer
{
    public class BLLogin
    {
        DBMain db = null;
        public BLLogin()
        {
            db = new DBMain();
        }
        public bool CheckLogin(string username, string password)
        {
            bool result = false;
            string strSql = "SELECT Email, password FROM Users";
            SqlDataReader read = null;
            read = db.ExecuteQueryDataReader(strSql, CommandType.Text);
            while (read.Read())
            {
                string email = read.GetValue(0).ToString().Trim();
                string storedPassword = read.GetValue(1).ToString().Trim();
                string storedUsername = email.Substring(0, email.IndexOf("@"));

                if (email == username && storedPassword == password)
                {
                    result = true;
                    string newConnect = "Data Source=DESKTOP-EP66OTM\\MSSQLSERVER01;Initial Catalog=HotelManagementSystem;User ID=" + storedUsername + ";Password=" + password;
                    DBMain.SetConnStr(newConnect, username, password);
                    break;
                }
            }
            return result;
        }

    }
}
