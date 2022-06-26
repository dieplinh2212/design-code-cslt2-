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
    public partial class Thủ_Thư : Form
    {
        DataTable tblTHUTHU;
        public Thủ_Thư()
        {
            InitializeComponent();
        }

        private void frmthuthu_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            txtMathuthu.Enabled = false;
            thuthuLuu.Enabled = false;
            thuthuBoqua.Enabled = false;
            Load_DataGridView();
            ResetValues();
            Functions.FillCombo("SELECT Maque, Tenque FROM que", cboMaque, "Maque", "Tenque");
            cboMaque.SelectedIndex = -1;
        }
        private void ResetValues()
        {
            txtMathuthu.Text = "";
            txtTenThuThu6.Text = "";
            txtDiaChi6.Text = "";
            mskDienthoaiCD.Text = "";
            mskDienthoaiDD.Text = "";
            cboMaque.Text = "";

        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * from thuthu";

            tblTHUTHU = Functions.GetDataToTable(sql);
            dataGridViewthuthu.DataSource = tblTHUTHU;
            dataGridViewthuthu.Columns[0].HeaderText = "Mã thủ thư";
            dataGridViewthuthu.Columns[1].HeaderText = "Tên thủ thư";
            dataGridViewthuthu.Columns[2].HeaderText = "Địa chỉ";
            dataGridViewthuthu.Columns[3].HeaderText = "Điện thoại DD";
            dataGridViewthuthu.Columns[4].HeaderText = "Điện thoại CĐ";
            dataGridViewthuthu.Columns[5].HeaderText = "Mã quê";
            dataGridViewthuthu.Columns[0].Width = 150;
            dataGridViewthuthu.Columns[1].Width = 150;
            dataGridViewthuthu.Columns[2].Width = 150;
            dataGridViewthuthu.Columns[3].Width = 150;
            dataGridViewthuthu.Columns[4].Width = 150;
            dataGridViewthuthu.Columns[5].Width = 150;
            dataGridViewthuthu.AllowUserToAddRows = false;
            dataGridViewthuthu.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void txtMathuthu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txtTenThuThu6_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtDiaChi6_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void mskDienthoaiCD_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void mskDienthoaiDD_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }



        private void thuthuLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMathuthu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã thủ thư", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtMathuthu.Focus();
                return;
            }
            if (txtTenThuThu6.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên thủ thư", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenThuThu6.Focus();
                return;
            }
            if (txtDiaChi6.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtDiaChi6.Focus();
                return;
            }
            if (mskDienthoaiCD.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại cố định", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoaiCD.Focus();
                return;
            }
            if (mskDienthoaiDD.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại di động", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoaiDD.Focus();
                return;
            }
            if (cboMaque.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập quê", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaque.Focus();
                return;
            }


            sql = "SELECT mathuthu FROM thuthu WHERE Mathuthu=N'" + txtMathuthu.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã thủ thư này đã có, bạn phải nhập mã khác", "Thông báo",
 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMathuthu.Focus();
                txtMathuthu.Text = "";
                return;
            }

            sql = "INSERT INTO thuthu(Mathuthu,Tenthuthu,Diachithuthu,sdtcdthuthu,sdtddthuthu,maque) VALUES (N'" +
txtMathuthu.Text.Trim() + "',N'" + txtTenThuThu6.Text.Trim() + "',N'" +
txtDiaChi6.Text.Trim() + "','" + mskDienthoaiCD.Text + "','" + mskDienthoaiDD.Text + "',N'" + cboMaque.SelectedValue.ToString() + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            thuthuXoa.Enabled = true;
            thuthuThem.Enabled = true;
            thuthuSua.Enabled = true;
            thuthuBoqua.Enabled = false;
            thuthuLuu.Enabled = false;
            txtMathuthu.Enabled = false;

        }

        private void thuthuThem_Click(object sender, EventArgs e)
        {
            thuthuSua.Enabled = false;
            thuthuXoa.Enabled = false;
            thuthuBoqua.Enabled = true;
            thuthuLuu.Enabled = true;
            thuthuThem.Enabled = false;
            ResetValues();
            txtMathuthu.Enabled = true;
            txtMathuthu.Focus();


        }

        private void dataGridViewthuthu_Click(object sender, EventArgs e)
        {
            if (thuthuThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMathuthu.Focus();
                return;
            }
            if (tblTHUTHU.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            txtMathuthu.Text = dataGridViewthuthu.CurrentRow.Cells["Mathuthu"].Value.ToString();
            txtTenThuThu6.Text = dataGridViewthuthu.CurrentRow.Cells["Tenthuthu"].Value.ToString();
            txtDiaChi6.Text = dataGridViewthuthu.CurrentRow.Cells["Diachithuthu"].Value.ToString();
            mskDienthoaiCD.Text = dataGridViewthuthu.CurrentRow.Cells["sdtCDthuthu"].Value.ToString();
            mskDienthoaiDD.Text = dataGridViewthuthu.CurrentRow.Cells["sdtdDthuthu"].Value.ToString();
            //ma = dataGridViewthuthu.CurrentRow.Cells["Maque"].Value.ToString();
            //cboMaque.Text = Functions.GetFieldValues("SELECT Tenque FROM que WHERE Maque = N'" + ma + "'");

            thuthuSua.Enabled = true;
            thuthuXoa.Enabled = true;
            thuthuBoqua.Enabled = true;

        }


        private void thuthuXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTHUTHU.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtMathuthu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE thuthu WHERE Mathuthu=N'" + txtMathuthu.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();


            }
        }

        private void thuthuDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Bạn có chắc chắn muốn thoát không  ?",
               "Cảnh báo !", MessageBoxButtons.OKCancel) == DialogResult.OK) ;
            this.Close();

        }



        private void thuthuSua_Click(object sender, EventArgs e)
        {

            string sql;
            if (tblTHUTHU.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txtMathuthu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenThuThu6.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên thủ thư", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenThuThu6.Focus();
                return;
            }

            if (txtDiaChi6.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txtDiaChi6.Focus();
                return;
            }
            if (mskDienthoaiCD.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại cố định", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoaiCD.Focus();
                return;
            }
            if (mskDienthoaiDD.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại di động", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoaiDD.Focus();
                return;
            }
            if (cboMaque.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập quê", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaque.Focus();
                return;

            }

            sql = "UPDATE thuthu SET  Tenthuthu=N'" + txtTenThuThu6.Text.Trim().ToString()
                  + "',Diachi=N'" + txtDiaChi6.Text.Trim().ToString() + "',SDTCDTHUTHU='" +
                mskDienthoaiCD.Text.ToString() + "',SDTDDTHUTHU=N'" + mskDienthoaiDD.Text.Trim().ToString() + "',Maque=N'" + cboMaque.SelectedValue.ToString() + "' WHERE MATHUTHU =N'" + txtMathuthu.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            thuthuBoqua.Enabled = false;

        }

        private void thuthuBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            thuthuBoqua.Enabled = false;
            thuthuThem.Enabled = true;
            thuthuXoa.Enabled = true;
            thuthuSua.Enabled = true;
            thuthuLuu.Enabled = false;
            txtMathuthu.Enabled = false;

        }

        private void cboMaque_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }

        private void txtMathuthu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

   

   