using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HotelManagement_ADO.DB_Layer;

namespace HotelManagement_ADO.BS_Layer
{
    public class BLUserDetail
    {
        DBMain db = null;
        public BLUserDetail()
        {
            db = new DBMain();
        }
        public DataSet TakeUserDetail()
        {
            return db.ExecuteQueryDataSet("Select * from UserDetail", CommandType.Text);
        }
        public bool AddUserDetail(int book_ID, int room_ID, int customerID, ref string err)
        {
            try
            {
                string sql = $"exec SP_ADD_USER_DETAIL '{book_ID}', '{room_ID}', '{customerID}";
                db.MyExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.InnerException.Message);
                return false;
            }
            return true;

        }
        public bool DeleteUserDetail(ref string err, int book_ID, int room_ID, int customerID)
        {
            try
            {
                string sql = $"exec SP_DELETE_USER_DETAIL '{book_ID}', '{room_ID}', '{customerID}";
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
