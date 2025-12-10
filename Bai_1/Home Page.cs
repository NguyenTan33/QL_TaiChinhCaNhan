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



        public Home_Page()
        {
            InitializeComponent();
            PhanQuyen();
            LoadBaoCao(SaveIdUser.AccountID);
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
        private void LoadBaoCao(int accountId)
        {
            DataModel dataModel = new DataModel();

            // Lấy đối tượng báo cáo từ DataModel
            SaveDLReport report = dataModel.GetBaoCaoTongQuat(accountId);

            // Kiểm tra xem có dữ liệu trả về không
            if (report != null)
            {
                // Định dạng tiền tệ (Ví dụ: "N0" là định dạng số nguyên có dấu phân cách hàng nghìn)
                string format = "N0";

                // --- Cột THU ---
                txtTT.Text = report.TongThu.ToString(format);
                txtTNTB.Text = report.ThuTrungBinh.ToString(format);
                txtTNNN.Text = report.ThuNhieuNhat.ToString(format);
                txtTNTN.Text = report.ThuItNhat.ToString(format);

                // --- Cột CHI ---
                txtTC.Text = report.TongChi.ToString(format);
                txtCTTB.Text = report.ChiTrungBinh.ToString(format);
                txtCTNN.Text = report.ChiNhieuNhat.ToString(format);
                txtCTTN.Text = report.ChiItNhat.ToString(format);

                // --- Tiền còn lại ---
                txtTienCon.Text = report.TienHienCo.ToString(format);
            }
            else
            {
                // Xử lý khi không có dữ liệu (ví dụ: người dùng mới)
                MessageBox.Show("Không tìm thấy dữ liệu báo cáo cho tài khoản này.");
                // Bạn có thể đặt tất cả các TextBox về "0" hoặc "" ở đây
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
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
    }
}
