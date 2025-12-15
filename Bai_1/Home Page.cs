using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class Home_Page : Form
    {
        DataModel dt = new DataModel();
        SaveDLReport Dl = new SaveDLReport();


        public Home_Page()
        {
            InitializeComponent();
            PhanQuyen();
            LoadBaoCao();
        }
        public void PhanQuyen()
        {
            if (SaveIdUser.AccountID != 1)
            {
                QL_User.Visible = false;
            }
        }
        private void Home_Page_Load(object sender, EventArgs e)
        {

        }

        private void ThuNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thu_Nhap ThuNhap = new Thu_Nhap();
            ThuNhap.ShowDialog();
            this.Close();
        }

        private void ChiTieu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Chi_Tieu ChiTieu = new Chi_Tieu();
            ChiTieu.ShowDialog();
            this.Close();
        }

        private void Out_Click(object sender, EventArgs e)
        {
            DialogResult Ok = MessageBox.Show("Bạn có chắc muốn thoát ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Ok == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void QL_User_Click(object sender, EventArgs e)
        {
            this.Hide();
            QL_User QL_User = new QL_User();
            QL_User.ShowDialog();
            this.Close();

        }

        private void DoiMk_Click(object sender, EventArgs e)
        {
            this.Hide();
            DoiMatKhau DoiMK = new DoiMatKhau();
            DoiMK.ShowDialog();
            this.Close();
        }
        private void LoadBaoCao()
        {
            DataModel dataModel = new DataModel();
            SaveDLReport report = dataModel.GetBaoCaoTongQuat(SaveIdUser.AccountID);

            if (report != null)
            {
                string format = "N0";
                txtTT.Text = report.TongThu.ToString(format);
                txtTNTB.Text = report.ThuTrungBinh.ToString(format);
                txtTNNN.Text = report.ThuNhieuNhat.ToString(format);
                txtTNTN.Text = report.ThuItNhat.ToString(format);
                txtTC.Text = report.TongChi.ToString(format);
                txtCTTB.Text = report.ChiTrungBinh.ToString(format);
                txtCTNN.Text = report.ChiNhieuNhat.ToString(format);
                txtCTTN.Text = report.ChiItNhat.ToString(format);
                txtTienCon.Text = report.TienHienCo.ToString(format);
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu báo cáo cho tài khoản này.");
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            PrintDocument printer = new PrintDocument();

            printer.DefaultPageSettings.PaperSize =
                new PaperSize("A6", 378, 567);

            printer.DefaultPageSettings.Margins =
                new Margins(0, 0, 0, 0);
            printer.PrintPage += In;

            PrintDialog dlg = new PrintDialog();
            dlg.Document = printer;
            dlg.AllowSomePages = false;
            dlg.AllowSelection = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                printer.Print();
            }
        }
        private void In(object sender, PrintPageEventArgs e)
        {
            DataModel dataModel = new DataModel();
            SaveDLReport report = dataModel.GetBaoCaoTongQuat(SaveIdUser.AccountID);

            DateTime now = DateTime.Now;
            string format = "N0";

            Graphics g = e.Graphics;

            Font f1 = new Font("Times New Roman", 14, FontStyle.Bold);
            Font f2 = new Font("Times New Roman", 10);

            float x = 15, y = 10, line = 24;

            string title = "Báo Cáo Thu Chi";
            float pageWidth = e.PageBounds.Width;
            SizeF titleSize = g.MeasureString(title, f1);
            float xTitle = (pageWidth - titleSize.Width) / 2;

            g.DrawString($"{now}", f2, Brushes.Black, x*18, y);
            y += line;

            g.DrawString(title, f1, Brushes.Black, xTitle, y);
            y += line * 2;

            g.DrawString($"Thu Nhiều Nhất: {report.ThuNhieuNhat.ToString(format)} VNĐ", f2, Brushes.Black, x, y);
            y += line;

            g.DrawString($"Thu Trung Bình: {report.ThuTrungBinh.ToString(format)} VNĐ", f2, Brushes.Black, x, y);
            y += line;

            g.DrawString($"Thu Ít Nhất: {report.ThuItNhat.ToString(format)} VNĐ", f2, Brushes.Black, x, y);
            y += line;

            g.DrawString($"Chi Nhiều Nhất: {report.ChiNhieuNhat.ToString(format)} VNĐ", f2, Brushes.Black, x, y);
            y += line;

            g.DrawString($"Chi Trung Bình: {report.ChiTrungBinh.ToString(format)} VNĐ", f2, Brushes.Black, x, y);
            y += line;

            g.DrawString($"Chi Ít Nhất: {report.ChiItNhat.ToString(format)} VNĐ", f2, Brushes.Black, x, y);
            y += line;

            g.DrawString($"----------------------------------------------------------------------------------", f2, Brushes.Black, x, y);
            y += line;

            g.DrawString($"Tổng thu: {report.TongThu.ToString(format)} VNĐ", f2, Brushes.Black, x, y);
            y += line;

            g.DrawString($"Tổng Chi: {report.TongChi.ToString(format)} VNĐ", f2, Brushes.Black, x, y);
            y += line;

            g.DrawString($"Tiền Còn Lại: {report.TienHienCo.ToString(format)} VNĐ", f2, Brushes.Black, x, y);
            y += line;

            g.DrawString($"----------------------------------------------------------------------------------", f2, Brushes.Black, x, y);
        }
        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void thuChiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DKVSD_Click(object sender, EventArgs e)
        {
            this.Hide();
            DSHySu DsHySu = new DSHySu();
            DsHySu.ShowDialog();
            this.Close();
        }

        private void khóaMànHìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Dnhap = new Form1();
            Dnhap.ShowDialog();
            this.Close();
        }
    }
}
