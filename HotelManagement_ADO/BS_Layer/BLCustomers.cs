using HotelManagement_ADO.DB_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagement_ADO.BS_Layer
{
    class BLCustomer
    {
        DBMain db = null;
        public BLCustomer()
        {
            db = new DBMain();
        }
        public DataSet TakeCustomers()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM View_Customers", CommandType.Text);
        }

        public bool AddCustomers(string name, DateTime birth, bool gender, string phoneNo, string address, string identify_number, ref string err)
        {
            try
            {
                string sql = $"EXEC SP_ADD_CUSTOMERS '{name}', '{birth.Date.ToString()}', '{gender}', '{phoneNo}', '{address}', '{identify_number}'";
                db.MyExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.InnerException.Message);
                return false;
            }
        }

        public bool DeleteCustomers(ref string err, int cID)
        {
            try
            {
                string sql = $"EXEC SP_DELETE_CUSTOMERS '{cID}'";
                db.MyExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.InnerException.Message);
                return false;
            }
        }

        public bool UpdateCustomers(int cID, string name, DateTime birth, bool gender, string phoneNo, string address, string identify_number, ref string err)
        {
            try
            {
                string sql = $"EXEC SP_UPDATE_CUSTOMERS '{cID}', '{name}', '{birth.Date}', '{gender}', '{phoneNo}', '{address}', '{identify_number}'";
                db.MyExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.InnerException.Message);
                return false;
            }
        }
    }

}
