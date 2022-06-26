using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace design_CSLT2
{
    public partial class frmNXB : Form
    {
        DataTable tblNXB;
        public frmNXB()
        {
            InitializeComponent();
        }

        private void frmNXB_Load(object sender, EventArgs e)
        {
            txtMaNXB5.Enabled = false;
            nxbLuu.Enabled = false;
            nxbBoQua.Enabled = false;
            Load_DataGridView();
            ResetValues();
        }
        private void ResetValues()
        {

            txtMaNXB5.Text = "";
            txtTenNXB5.Text = "";
            txtDiaChi5.Text = "";
            maskedDienthoai.Text = "";
            txtEmail5.Text = "";
            txtMaNXB5.Focus();

        }


        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM NHAXUATBAN";

            tblNXB = Functions.GetDataToTable(sql);
            nxbDataGrid.DataSource = tblNXB;
            nxbDataGrid.Columns[0].HeaderText = "Mã NXB";
            nxbDataGrid.Columns[1].HeaderText = "Tên NXB";
            nxbDataGrid.Columns[2].HeaderText = "Địa chỉ";
            nxbDataGrid.Columns[3].HeaderText = "Điện thoại";
            nxbDataGrid.Columns[4].HeaderText = "Email";

            nxbDataGrid.Columns[0].Width = 100;
            nxbDataGrid.Columns[1].Width = 150;
            nxbDataGrid.Columns[2].Width = 150;
            nxbDataGrid.Columns[3].Width = 150;
            nxbDataGrid.Columns[4].Width = 150;

            nxbDataGrid.AllowUserToAddRows = false;
            nxbDataGrid.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void nxbThem_Click(object sender, EventArgs e)
        {
            nxbSua.Enabled = false;
            nxbXoa.Enabled = false;
            nxbBoQua.Enabled = true;
            nxbLuu.Enabled = true;
            nxbThem.Enabled = false;
            ResetValues();
            txtMaNXB5.Enabled = true;
            txtMaNXB5.Focus();

        }

        private void nxbLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaNXB5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã NXB", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNXB5.Focus();
                return;
            }
            if (txtTenNXB5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên NXB", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNXB5.Focus();
                return;
            }
            if (txtDiaChi5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ NXB", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi5.Focus();
                return;
            }
            if (maskedDienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại NXB", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedDienthoai.Focus();
                return;
            }
            if (txtEmail5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email NXB", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail5.Focus();
                return;
            }

            sql = "SELECT Manxb FROM nhaxuatban WHERE Manxb=N'" +
txtMaNXB5.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã NXB này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNXB5.Focus();
                txtMaNXB5.Text = "";
                return;
            }

            sql = "INSERT INTO Nhaxuatban(MaNXB,TenNXB,diachinxb,sdtnxb,EMAILnxb) VALUES(N'" +
txtMaNXB5.Text + "',N'" + txtTenNXB5.Text + "',N'" +
txtDiaChi5.Text + "',N'" +
maskedDienthoai.Text + "',N'" +
txtEmail5.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            nxbXoa.Enabled = true;
            nxbThem.Enabled = true;
            nxbSua.Enabled = true;
            nxbBoQua.Enabled = false;
            nxbLuu.Enabled = false;
            txtMaNXB5.Enabled = false;



        }

        private void nxbSua_Click(object sender, EventArgs e)
        {

            string sql;
            if (tblNXB.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtMaNXB5.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNXB5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên NXB", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNXB5.Focus();
                return;
            }
            if (txtDiaChi5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ NXB", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi5.Focus();
                return;
            }
            if (maskedDienthoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại của NXB", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedDienthoai.Focus();
                return;
            }
            if (txtEmail5.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập email của NXB", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail5.Focus();
                return;
            }
            sql = "UPDATE nhaxuatban SET  Tennxb=N'" + txtTenNXB5.Text.Trim().ToString() + "',Diachi=N'" + txtDiaChi5.Text.Trim().ToString() + "',Dienthoai=N'" + maskedDienthoai.Text.Trim().ToString() + "',Email=N'" + txtEmail5.Text.Trim().ToString() + "'where Manxb=N'" + txtMaNXB5.Text.Trim() + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            nxbBoQua.Enabled = false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void nxbDataGrid_Click(object sender, EventArgs e)

        {
            if (nxbThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNXB5.Focus();
                return;
            }
            if (tblNXB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
        MessageBoxIcon.Information);
                return;
            }
            txtMaNXB5.Text = nxbDataGrid.CurrentRow.Cells["MaNXB"].Value.ToString();
            txtTenNXB5.Text = nxbDataGrid.CurrentRow.Cells["TenNXB"].Value.ToString();

            txtDiaChi5.Text = nxbDataGrid.CurrentRow.Cells["Diachi"].Value.ToString();
            maskedDienthoai.Text = nxbDataGrid.CurrentRow.Cells["Dienthoai"].Value.ToString();
            txtEmail5.Text = nxbDataGrid.CurrentRow.Cells["Email"].Value.ToString();
            nxbSua.Enabled = true;
            nxbXoa.Enabled = true;
            nxbBoQua.Enabled = true;


        }

        private void nxbXoa_Click(object sender, EventArgs e)
        {

            string sql;
            if (tblNXB.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtMaNXB5.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE NHAXUATBAN WHERE MaNXB=N'" + txtMaNXB5.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();

            }

        }

        private void nxbBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            nxbBoQua.Enabled = false;
            nxbThem.Enabled = true;
            nxbXoa.Enabled = true;
            nxbSua.Enabled = true;
            nxbLuu.Enabled = false;
            txtMaNXB5.Enabled = false;

        }

        private void txtMaNXB5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txtTenNXB5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDiaChi5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDienThoai5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtMail5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void nxbDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Bạn có chắc chắn muốn thoát không  ?",
               "Cảnh báo !", MessageBoxButtons.OKCancel) == DialogResult.OK) ;
            this.Close();
        }
    }
}

