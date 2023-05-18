using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelManagement_ADO.BS_Layer;

namespace HotelManagement_ADO.AdminForms
{
    public partial class CustomerDetail : Form
    {
        bool Them;
        string err;
        BLCustomerDetail dbCD = new BLCustomerDetail();
        public CustomerDetail()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            try
            {

                // Đưa dữ liệu lên DataGridView
                DataSet dataSet = dbCD.TakeCustomerDetail();
                DataTable dataTable = dataSet.Tables[0];
                dgvCUSTOMERDETAIL.DataSource = dataTable;

                // Change the column name
                dataTable.Columns["book_ID"].ColumnName = "Booking ID";
                dataTable.Columns["room_ID"].ColumnName = "Room ID";
                dataTable.Columns["customerID"].ColumnName = "Customer ID";
                // Set the DataSource of the DataGridView
                dgvCUSTOMERDETAIL.DataSource = dataTable;
                // Xóa trống các đối tượng trong Panel
                this.txtbook_ID.ResetText();
                this.txtroom_ID.ResetText();
                this.txtcustomerID.ResetText();
                // Không cho thao tác trên các nút Lưu / Hủy
                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;
                this.panel.Enabled = false;
                // Cho thao tác trên các nút Thêm / Sửa / Xóa /Thoát
                this.btnAdd.Enabled = true;
                this.btnDelete.Enabled = true;

                //
                dgvCUSTOMERDETAIL_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không lấy được nội dung trong table CUSTOMERDETAIL. Lỗi rồi!!!");
            }
        }
        private void FormCustomerDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.txtbook_ID.Enabled = true;

            // Kich hoạt biến Them
            Them = true;
            // Xóa trống các đối tượng trong Panel
            this.txtbook_ID.ResetText();
            this.txtroom_ID.ResetText();
            this.txtcustomerID.ResetText();
            // Cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.panel.Enabled = true;
            // Không cho thao tác trên các nút Thêm / Xóa / Thoát
            this.btnAdd.Enabled = false;
            this.btnDelete.Enabled = false;

            // Đưa con trỏ đến TextField txtbook_ID
            this.txtbook_ID.Focus();
        }
        private void dgvCUSTOMERDETAIL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Thứ tự dòng hiện hành
            int r = dgvCUSTOMERDETAIL.CurrentCell.RowIndex;
            // Chuyển thông tin lên panel
            this.txtbook_ID.Text =
            dgvCUSTOMERDETAIL.Rows[r].Cells[0].Value.ToString();
            this.txtroom_ID.Text =
            dgvCUSTOMERDETAIL.Rows[r].Cells[1].Value.ToString();
            this.txtcustomerID.Text =
            dgvCUSTOMERDETAIL.Rows[r].Cells[2].Value.ToString();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Khai báo biến traloi
            DialogResult traloi;
            // Hiện hộp thoại hỏi đáp
            traloi = MessageBox.Show("Chắc không?", "Trả lời",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // Kiểm tra có nhắp chọn nút Ok không?
            if (traloi == DialogResult.OK) this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Xóa trống các đối tượng trong Panel
            this.txtbook_ID.ResetText();
            this.txtroom_ID.ResetText();
            this.txtcustomerID.ResetText();
            // Cho thao tác trên các nút Thêm / Sửa / Xóa / Thoát
            this.btnAdd.Enabled = true;
            this.btnDelete.Enabled = true;

            // Không cho thao tác trên các nút Lưu / Hủy / Panel
            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.panel.Enabled = false;
            dgvCUSTOMERDETAIL_CellClick(null, null);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Mở kết nối
            // Thêm dữ liệu
            if (Them)
            {
                BLCustomerDetail blCD = new BLCustomerDetail();
                if (blCD.AddCustomerDetail(Convert.ToInt32(this.txtbook_ID.Text), Convert.ToInt32(this.txtroom_ID.Text), Convert.ToInt32(this.txtcustomerID.Text), ref err))
                    MessageBox.Show("Add successfully!");
                LoadData();
            }
            // Đóng kết nối
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
