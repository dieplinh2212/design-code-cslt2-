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
    public partial class frmtimkiemsachtruyen : Form
    {
        DataTable tbltimsach;
        public frmtimkiemsachtruyen()
        {
            InitializeComponent();
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txttensach.Focus();
            cboNXB.Text = "";
            cboTheloai.Text = "";
            cboNXB.Enabled = true;
            cboTheloai.Enabled = true;
            txttensach.Enabled = true;
            btntimkiem.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void frmtimkiemsachtruyen_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            ResetValues();
            DataGridView.DataSource = null;

            Functions.FillCombo("SELECT Matheloai,Tentheloai FROM theloai", cboTheloai, "Matheloai", "Tentheloai");
            cboTheloai.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaNXB,TenNXB FROM NHAXUATBAN", cboNXB, "MaNXB", "TenNXB");
            cboNXB.SelectedIndex = -1;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            Functions.Connect();
            string sql;

            if ((cboNXB.Text == "") && (cboTheloai.Text == "") && (txttensach.Text == ""))
            {
                MessageBox.Show("Hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            sql = "select Tensach,tentheloai,tennxb From DMsach join theloai " +
                "on DMsach.Matheloai=theloai.Matheloai join nhaxuatban " +
                "on nhaxuatban.Manxb=DMsach.Manxb WHERE 1=1 ";
            if (txttensach.Text != "")
                sql = sql + " AND Tensach Like N'%" + txttensach.Text + "%'";
            if (cboTheloai.Text != "")
                sql = sql + " AND  theloai.matheloai Like N'%" + cboTheloai.SelectedValue + "%'";
            if (cboNXB.Text != "")
                sql = sql + " AND nhaxuatban.manxb Like N'%" + cboNXB.SelectedValue + "%'";
            tbltimsach = Functions.GetDataToTable(sql);
            if (tbltimsach.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tbltimsach.Rows.Count + " bản ghi thỏa mãn điều kiện!!!",
"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DataGridView.DataSource = tbltimsach;

            btntimkiem.Enabled = false;

            txttensach.Enabled = false;
            cboNXB.Enabled = false;
            cboTheloai.Enabled = false;
        }
        private void LoadDatatoGridView()
        {
            Functions.Connect();
            string sql;
            sql = "select Tensach,tentheloai,tennxb From DMsach join theloai " +
            "on DMsach.Matheloai=theloai.Matheloai join nhaxuatban " +
            "on nhaxuatban.Manxb=DMsach.Manxb ";
            tbltimsach = Functions.GetDataToTable(sql);
            DataGridView.DataSource = tbltimsach;
            DataGridView.Columns[0].HeaderText = "Tên sách";
            DataGridView.Columns[1].HeaderText = "Thể loại sách";
            DataGridView.Columns[2].HeaderText = "Nhà xuất bản";

            DataGridView.Columns[0].Width = 150;
            DataGridView.Columns[1].Width = 150;
            DataGridView.Columns[2].Width = 150;

            DataGridView.AllowUserToAddRows = false;
            DataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btntimlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            DataGridView.DataSource = null;
        }
        private void btndong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Bạn có chắc chắn muốn thoát không  ?",
                           "Cảnh báo !", MessageBoxButtons.OKCancel) == DialogResult.OK) ;
            this.Close();
        }
    }
}