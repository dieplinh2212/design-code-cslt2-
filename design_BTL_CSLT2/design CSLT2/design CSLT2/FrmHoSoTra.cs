using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace design_CSLT2
{
    public partial class FrmHoSoTra : Form
    {
        public FrmHoSoTra()
        {
     
            InitializeComponent();
        }
        DataTable tbltrasach;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void cbMaHSM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNgayMuon_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmHoSoTra_Load(object sender, EventArgs e)
        {

        }

        private void dgridtrasach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbltrasach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //txtmathue.Text = dgirdtrasach.CurrentRow.Cells["Mathue"].Value.ToString();
                cbomakhach.Text = Functions.GetFieldValues("select Mathemuon from themuon where Mathemuon=N'" + cbomathue.Text + "'");
                txttenkhach.Text = Functions.GetFieldValues("select hoten from themuon where Mathemuon=N'" + cbomakhach.Text + "'");
                txtmasach.Text = dgridtrasach.CurrentRow.Cells["Masach"].Value.ToString();
                txtmatinhtrang.Text = Functions.GetFieldValues("select tinhtrang from chitiethsm where Masach=N'" + txtmasach.Text + "' and Mahsm=N'" + cbomathue.Text + "'");
                txtngaythue.Text = dgridtrasach.CurrentRow.Cells["Ngaymuon"].Value.ToString();
                txtdongiathue.Text = Functions.GetFieldValues("select Dongiathue from dmSach where Masach=N'" + txtmasach.Text + "'");
                if (btntra.Enabled == false)
                {
                    demngay();
                    tinhtienthanhtoan();
                    double dgt, tphat, thanhtien, songay;
                    double sttt, tt, tu;
                    dgt = Convert.ToDouble(txtdongiathue.Text);
                    tphat = Convert.ToDouble(txttienphat.Text);
                    songay = Convert.ToDouble(txtsongaythue.Text);

                    tt = Convert.ToDouble(txttongtien.Text);
                    tu = Convert.ToDouble(txtTAMUNG.Text);
                    thanhtien = dgt * songay + tphat;
                    sttt = tt - tu;
                    txtthanhtien.Text = thanhtien.ToString();
                    txtSoTienThanhToan.Text = sttt.ToString();
                }
            }
        }
        private void cbomavipham_SelectedValueChanged(object sender, EventArgs e)
        {
            txttienphat.Text = Functions.GetFieldValues("select Tienphat from Vipham where MaViPham=N'" + cbomavipham.SelectedValue + "'");

        }

        private void cbomathue_SelectedValueChanged(object sender, EventArgs e)
        {
            txtTAMUNG.Text = Functions.GetFieldValues("select tamung from hosomuon where mahsm=N'" + cbomathue.SelectedValue + "'");
        }





        private void demngay()
        {
            try
            {

                DateTime thue = new DateTime();
                thue = DateTime.ParseExact(txtngaythue.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime tra = new DateTime();
                tra = DateTime.Parse(txtngaytra.Text);
                TimeSpan songay = tra - thue;
                int sn = songay.Days;
                txtsongaythue.Text = Convert.ToString(sn);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void tinhtienthanhtoan()
        {
            double TONGTIEN = new double();
            TONGTIEN = Convert.ToDouble(txttongtien.Text);
            double TAMUNG = new double();
            TAMUNG = Convert.ToDouble(txtTAMUNG.Text);
            double Sotienthanhtoan = TONGTIEN - TAMUNG;
            txtSoTienThanhToan.Text = Convert.ToString(Sotienthanhtoan);
        }

        private void txtngaytra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                demngay();
            }

        }





        private void Load_Datagridview()
        {
            string sql;
            sql = "select b.Mahsm, a.Masach, b.Ngaymuon, a.Dongiathue, c.tinhtrang from dmSach a, hosomuon b,chitiethsm c where a.Masach=c.Masach and b.Mahsm = c.Mahsm and c.tinhtrang = N'Chưa trả' " +
                "and b.Mahsm='" + cbomathue.Text + "'  ";
            tbltrasach = Functions.GetDataToTable(sql);
            dgridtrasach.DataSource = tbltrasach;
            //DataTable ChiTietHST = new DataTable();
            //ChiTietHST = Functions.GetDataToTable(sql);
            dgridtrasach.Columns[0].HeaderText = "Mã HSM";
            dgridtrasach.Columns[1].HeaderText = "Mã sách";
            dgridtrasach.Columns[2].HeaderText = "Ngày mượn";
            dgridtrasach.Columns[3].HeaderText = "Đơn giá thuê";
            dgridtrasach.Columns[4].HeaderText = "Tình trạng";
            dgridtrasach.AllowUserToAddRows = false;
            dgridtrasach.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void Load_ttHD()
        {
            string str;
            str = "select Ngaymuon from Hosomuon where Mahsm=N'" + cbomathue.Text + "'";
            cbomathue.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "select Mathemuon from themuon where Mahsm=N'" + cbomathue.Text + "'";
            cbomakhach.Text = Functions.GetFieldValues(str);
            str = "select hoten from themuon where Mathemuon=N'" + cbomakhach.Text + "'";
            txttenkhach.Text = Functions.GetFieldValues(str);
            str = "select tamung from hosomuon where Mahsm=N'" + cbomathue.Text + "'";
            txtTAMUNG.Text = Functions.GetFieldValues(str);
            //Console.WriteLine(txtngaythue.Text);   
        }



        private void cbomathue_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT Mahsm FROM hosomuon", cbomathue, "Mahsm", "Mahsm");
            cbomathue.SelectedIndex = -1;

        }


        private void ResetValues()
        {
            cbomathue.Text = "";
            txtmasach.Text = "";
            cbomakhach.Text = "";
            txtmatinhtrang.Text = "";
            txttienphat.Text = "0";
            txtdongiathue.Text = "0";
            txtthanhtien.Text = "0";
            txtTAMUNG.Text = "0";
            txtngaythue.Text = "";
            txttenkhach.Text = "";
            txtdongiathue.Text = "";
            cbomanhanvien.Text = "";
            cbomavipham.Text = "";
            txtSoTienThanhToan.Text = "";
        }
        private void ResetValuesSach()
        {
            txtmasach.Text = "";
            txtdongiathue.Text = "0";
            txtthanhtien.Text = "0";
            txtsongaythue.Text = "0";
            txttienphat.Text = "0";

        }

        private void HoSoTra_Load_1(object sender, EventArgs e)

        {

            txtmasach.Enabled = false;
            txttenkhach.Enabled = false;
            cbomathue.Enabled = true;
            txtmatinhtrang.Enabled = false;
            txtngaythue.Enabled = false;
            txtmatra.Enabled = false;
            txtdongiathue.Enabled = false;
            txtTAMUNG.Enabled = false;
            cbomakhach.Enabled = false;

            txttongtien.Enabled = false;
            txttienphat.Enabled = false;
            txtthanhtien.Enabled = false;
            txttienphat.Text = "0";
            txttongtien.Text = "0";
            Functions.FillCombo("select Mathemuon,hoten from themuon ", cbomakhach, "Mathemuon", "hoten");
            cbomakhach.SelectedIndex = -1;
            Functions.FillCombo("select Mathuthu from thuthu", cbomanhanvien, "Mathuthu", "mathuthu");
            cbomanhanvien.SelectedIndex = -1;
            Functions.FillCombo("select Mavipham,Tenvipham from Vipham", cbomavipham, "MaViPham", "TenViPham");
            cbomavipham.SelectedIndex = -1;
            Functions.FillCombo("select mahsm from hosomuon", cbomathue, "Mahsm", "Mahsm");
            cbomathue.SelectedIndex = -1;

            if (cbomathue.Text != "")
            {
                Load_ttHD();
                btnIn.Enabled = true;
            }


        }





        private void btntra_Click_1(object sender, EventArgs e)
        {
            demngay();
            tinhtienthanhtoan();
            btnluu.Enabled = true;
            btnIn.Enabled = false;
            btntra.Enabled = false;
            // ResetValues();
            string a;
            a = "select mahst from hosotra where mahst=N'" + txtmatra.Text + "'";
            txtmatra.Text = Functions.GetFieldValues(a);


            txtngaytra.Text = DateTime.Now.ToShortDateString();
            dgridtrasach.DataSource = null;
            //Load_Datagridview();
            Load_ttHD();


        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {

        }
    }
}


