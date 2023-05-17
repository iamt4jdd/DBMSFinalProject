using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HotelManagement_ADO.DB_Layer;

namespace HotelManagement_ADO.BS_Layer
{
    public class BLUsers
    {
        DBMain db = null;
        public BLUsers()
        {
            db = new DBMain();
        }
        public DataSet TakeUser()
        {
            return db.ExecuteQueryDataSet("Select * from Users", CommandType.Text);
        }
        public DataSet FindUser(int ID, string Name)
        {
            string query = "SELECT * FROM Users WHERE userID = @ID AND Fullname = @Name";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ID", ID),
                new SqlParameter("@Name", Name)
            };
            return db.ExecuteQueryDataSet3(query, CommandType.Text, parameters);
        }


        public bool AddUser(int userID, string Fullname, string password, DateTime Birthday, bool Gender, string Email, string Phone_Number, string Address, int role_id, ref string err)
        {
            try
            {
                string sql = $"exec SP_ADD_USER '{Fullname}', '{Birthday}', '{Gender}', '{Email}', '{Phone_Number}', '{Address}', '{role_id}', '{password}";
                db.MyExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.InnerException.Message);
                return false;
            }
            return true;

        }
        public bool DeleteUser(ref string err, int userID)
        {
            try
            {
                string sql = $"exec SP_DELETE_USER '{userID}";
                db.MyExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.InnerException.Message);
                return false;
            }
            return true;
        }
        public bool UpdateUser(int userID, string Fullname, string password, DateTime Birthday, bool Gender, string Email, string Phone_Number, string Address, int role_id, ref string err)
        {
            try
            {
                string sql = $"exec SP_UPDATE_USER '{userID}', '{Fullname}', '{Birthday}', '{Gender}', '{Email}', '{Phone_Number}', '{Address}', '{role_id}', '{password}";
                db.MyExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.InnerException.Message);
                return false;
            }
            return true;
        }
    }
}
