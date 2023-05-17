using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement_ADO.EmployeeForms
{
    public partial class Receipt : Form
    {
        public int currentCustomerID { get; set; }
        public DataSet dataSet { get; set; }

        public Receipt()
        {
            InitializeComponent();
        }

        public void LoadReceipt()
        {
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                DataTable table = dataSet.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    txtCustomer.Text = row["CustomerName"].ToString();
                    break;
                    // Display other receipt information
                }
            }
        }
    }
}