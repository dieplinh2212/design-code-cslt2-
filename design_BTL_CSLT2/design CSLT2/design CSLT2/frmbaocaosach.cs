using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;


namespace design_CSLT2
{
    public partial class frmbaocaosach : Form
    {
        DataTable bcao;
        public frmbaocaosach()
        {
            Functions.Connect();
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmbaocaosach_Load(object sender, EventArgs e)
        {
            btnboqua.Enabled = false;
            btninbaocao.Enabled = false;

            ResetValues();
        }
        private void ResetValues()
        {
            txtnam.Text = "";
            txtthang.Text = "";
            txtthang.Focus();
            txtthang.Enabled = true;
            txtnam.Enabled = true;



        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.Masach,a.Tensach,b.tinhtrang,c.ngaymuon, a.TenTG,a.manxb, a.NamXB, a.KhoSach,a.GiaSach, a.LanTaiBan,a.matheloai,a.mangonngu, a.Sotrang, a.TomTatND, a.Soluong,a.DonGiaThue" +
                   "FROM DMSach a join chitiethsm b on a.Masach=b.Masach JOIN hosomuon c on c.Mahsm=b.Mahsm" +
                   " WHERE b.tinhtrang = N'Chưa trả' and 1=1";
            bcao = Functions.GetDataToTable(sql);
            dataGridViewbcsach.DataSource = bcao;
            dataGridViewbcsach.Columns[0].HeaderText = "Mã sách";
            dataGridViewbcsach.Columns[1].HeaderText = "Tên sách";
            dataGridViewbcsach.Columns[2].HeaderText = "Tình trạng";
            dataGridViewbcsach.Columns[3].HeaderText = "Ngày mượn";

            dataGridViewbcsach.Columns[4].HeaderText = "Tên tác giả";

            dataGridViewbcsach.Columns[5].HeaderText = "Mã NXB";
            dataGridViewbcsach.Columns[6].HeaderText = "Năm XB";
            dataGridViewbcsach.Columns[7].HeaderText = "Khổ sách";
            dataGridViewbcsach.Columns[8].HeaderText = "Giá sách";
            dataGridViewbcsach.Columns[9].HeaderText = "Lần tái bản";
            dataGridViewbcsach.Columns[1].HeaderText = "Mã thể loại";
            dataGridViewbcsach.Columns[11].HeaderText = "Mã ngôn ngữ";
            dataGridViewbcsach.Columns[12].HeaderText = "Số trang";
            dataGridViewbcsach.Columns[13].HeaderText = "Tóm tắt ND";
            dataGridViewbcsach.Columns[14].HeaderText = "Số lượng";
            dataGridViewbcsach.Columns[15].HeaderText = "Đơn giá thuê";
            dataGridViewbcsach.Columns[0].Width = 150;
            dataGridViewbcsach.Columns[1].Width = 150;
            dataGridViewbcsach.Columns[2].Width = 150;
            dataGridViewbcsach.Columns[3].Width = 150;
            dataGridViewbcsach.Columns[4].Width = 150;
            dataGridViewbcsach.Columns[5].Width = 150;
            dataGridViewbcsach.Columns[6].Width = 150;
            dataGridViewbcsach.Columns[7].Width = 150;
            dataGridViewbcsach.Columns[8].Width = 150;
            dataGridViewbcsach.Columns[9].Width = 150;
            dataGridViewbcsach.Columns[10].Width = 150;
            dataGridViewbcsach.Columns[11].Width = 150;
            dataGridViewbcsach.Columns[12].Width = 150;
            dataGridViewbcsach.Columns[13].Width = 150;
            dataGridViewbcsach.Columns[14].Width = 150;
            dataGridViewbcsach.Columns[15].Width = 150;
            dataGridViewbcsach.AllowUserToAddRows = false;
            dataGridViewbcsach.EditMode = DataGridViewEditMode.EditProgrammatically;


        }

        private void btnbaocao_Click(object sender, EventArgs e)
        {
            if (txtthang.Text == "")
            {
                MessageBox.Show("Hãy nhập 1 tháng cụ thể .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtthang.Focus();
                return;

            }
            if (txtnam.Text == "")
            {
                MessageBox.Show("Hãy nhập 1 năm cụ thể.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnam.Focus();
                return;
            }
            string sql;
            sql = "SELECT a.Masach,Tensach,b.tinhtrang,c.ngaymuon,a.TenTG,a.manxb, a.NamXB, a.KhoSach,a.GiaSach, a.LanTaiBan,a.matheloai,a.mangonngu, a.Sotrang, a.TomTatND, a.Soluong,a.DonGiaThue FROM DMSach a join chitiethsm b on a.Masach=b.Masach JOIN hosomuon c on c.Mahsm=b.Mahsm" +
                   " WHERE b.tinhtrang like N'Chưa trả' and " +
                "  Year(c.Ngaymuon)='" + txtnam.Text + "' And Month(c.Ngaymuon)='" + txtthang.Text + "'";
            bcao = Functions.GetDataToTable(sql);
            if (bcao.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Có " + bcao.Rows.Count + " bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            dataGridViewbcsach.DataSource = bcao;
            txtthang.Enabled = false;
            txtnam.Enabled = false;
            btnbaocao.Enabled = false;
            btnboqua.Enabled = true;
            btninbaocao.Enabled = true;

        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            txtthang.Enabled = true;
            txtnam.Enabled = true;
            btnboqua.Enabled = false;
            btninbaocao.Enabled = false;
            btnbaocao.Enabled = true;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Bạn có chắc chắn muốn thoát không  ?",
                "Cảnh báo !", MessageBoxButtons.OKCancel) == DialogResult.OK) ;
            this.Close();


        }

        private void btninbaocao_Click(object sender, EventArgs e)
        {
            if ((txtthang.Text == "") || (txtnam.Text == ""))
            {
                MessageBox.Show("Hãy chọn 1 tháng hoặc năm cụ thể ",
                "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;


            string sql;
            int hang = 0, cot = 0;
            DataTable tblBC;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];


            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Thư viện Cầu Vồng";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đống Đa - Hà Nội";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)37562222";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "DANH SÁCH CÁC SÁCH ĐANG ĐƯỢC THUÊ CHƯA TRẢ";



            //Lấy thông tin các sách
            sql = "SELECT  a.MASACH, a.TENSACH, C.NGAYMUON FROM dmSACH AS a, CHITIETHSM AS b, HOSOMUON AS c  WHERE b.tinhtrang like N'Chưa trả' and " +
                 "  Year(c.Ngaymuon)='" + txtnam.Text + "' And Month(c.Ngaymuon)='" + txtthang.Text + "' AND a.MaSACH = b.MaSACH AND " +
                 "B.Mahsm =c.Mahsm";
            tblBC = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 30;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Mã sách";
            exRange.Range["C11:C11"].Value = "Tên sách";
            exRange.Range["D11:D11"].Value = "Ngày thuê";


            for (hang = 0; hang <= tblBC.Rows.Count - 1; hang++)
            {

                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblBC.Columns.Count; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblBC.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[4][hang + 17];
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = DateTime.Now;
            exRange.Range["A1:C1"].Value = "Chùa Bộc - Đống Đa - Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

            exSheet.Name = "1";
            exApp.Visible = true;
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Bạn có chắc chắn muốn huỷ không  ?",
               "Cảnh báo !", MessageBoxButtons.OKCancel) == DialogResult.OK) ;
            LoadDataGridView();

        }

        private void txtthang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}