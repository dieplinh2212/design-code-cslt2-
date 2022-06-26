using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace design_CSLT2
{
    public partial class frmtimkiemthuthu : Form
    {
        DataTable tbltimkiemthuthu;
        public frmtimkiemthuthu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmtimkiemthuthu_Load(object sender, EventArgs e)
        {

        }
        private void ResetValues()
        {

            txttenthuthu.Text = "";
            txttenthuthu.Focus();
            ckbhsma.Checked = false;
            ckbhsma.Checked = false;
            ckbhsmb.Checked = false;
            ckbhsmc.Checked = false;
            ckbhsmd.Checked = false;
            ckbhsme.Checked = false;
            btntimkiem1.Enabled = true;
            btnthoat1.Enabled = true;
            btnTimlai1.Enabled = true;
        }

        private void btntimkiem1_Click(object sender, EventArgs e)
        {

            string sql;

            if ((ckbhsma.Checked == false) && (ckbhsmb.Checked == false)
                && (ckbhsmc.Checked == false)
                 && (ckbhsmd.Checked == false)
                  && (ckbhsme.Checked == false)

               && (txttenthuthu.Text == ""))

            {
                MessageBox.Show("Hãy nhập và chọn điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            sql = " select tenthuthu,mahsm From thuthu a join hosomuon b on a.Mathuthu=b.Mathuthu WHERE 1=1 ";
            if (txttenthuthu.Text != "")
                sql = sql + " and Tenthuthu Like N'%" + txttenthuthu.Text + "%'";
            if ((ckbhsma.Checked == true))
                sql = sql + " and mahsm Like N'%" + ckbhsma.Text + "%'";
            if ((ckbhsmb.Checked == true))
                sql = sql + "and mahsm Like N'%" + ckbhsmb.Text + "%'";
            if ((ckbhsmc.Checked == true))
                sql = sql + " and mahsm Like N'%" + ckbhsmc.Text + "%'";
            if ((ckbhsmd.Checked == true))
                sql = sql + " and mahsm Like N'%" + ckbhsmd.Text + "%'";
            if ((ckbhsme.Checked == true))
                sql = sql + " and mahsm Like N'%" + ckbhsme.Text + "%'";
            tbltimkiemthuthu = Functions.GetDataToTable(sql);
            if (tbltimkiemthuthu.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tbltimkiemthuthu.Rows.Count + " bản ghi thỏa mãn điều kiện!!!",
"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dataGridViewthuthu.DataSource = tbltimkiemthuthu;

            btntimkiem1.Enabled = false;

            txttenthuthu.Enabled = true;
            ckbhsma.Enabled = true;
            ckbhsmb.Enabled = true;
            ckbhsmc.Enabled = true;
            ckbhsmd.Enabled = true;
            ckbhsme.Enabled = true;

        }
        private void LoadDatatoGridView()
        {

            string sql;
            sql = "select tenthuthu,mahsm From thuthu a join hosomuon b on a.Mathuthu=b.Mathuthu WHERE 1=1 ";
            tbltimkiemthuthu = Functions.GetDataToTable(sql);
            dataGridViewthuthu.DataSource = tbltimkiemthuthu;
            dataGridViewthuthu.Columns[0].HeaderText = "Tên thủ thư";
            dataGridViewthuthu.Columns[1].HeaderText = "Danh sách hồ sơ cho mượn sách";


            dataGridViewthuthu.Columns[0].Width = 150;
            dataGridViewthuthu.Columns[1].Width = 150;


            dataGridViewthuthu.AllowUserToAddRows = false;
            dataGridViewthuthu.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimlai1_Click(object sender, EventArgs e)
        {
            ResetValues();
            dataGridViewthuthu.DataSource = null;

        }

        private void btnthoat1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Bạn có chắc chắn muốn thoát không  ?",
               "Cảnh báo !", MessageBoxButtons.OKCancel) == DialogResult.OK) ;
            this.Close();

        }



        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewthuthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewthuthu_Click(object sender, EventArgs e)
        {

        }

        private void btnhuy_Click_1(object sender, EventArgs e)
        {

            LoadDatatoGridView();

        }

        private void ckbhsma_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}


