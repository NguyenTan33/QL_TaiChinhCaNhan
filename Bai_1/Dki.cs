using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class Dki : Form
    {
        DataModel dt = new DataModel();
        public Dki()
        {
            InitializeComponent();
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txtTK.Text;
            string MatKhau = txtMK.Text;
            string MatKhauMoi = txtMKmoi.Text;
            string Gmail = txtGmail.Text;
            if (CheckValidation.SameMK(MatKhau, MatKhauMoi))
            {
                if (CheckValidation.DoiMK(MatKhau))
                {
                    DialogResult YN = MessageBox.Show("Bạn có chắc muốn đăng ký", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (YN == DialogResult.Yes)
                    {
                        string sql = $@"EXEC sp_Account_Them
                                    @TaiKhoan = '{TaiKhoan}',
                                    @MatKhau = '{MatKhau}',
                                    @Gmail = '{Gmail}';";
                        dt.TruyVan(sql);
                        this.Hide();
                        Home_Page TrangChu = new Home_Page();
                        TrangChu.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Mật Khẩu Cần Có:\nĐộ dài 6–12 ký tự,\nCó ít nhất 1 chữ in hoa,\nCó ít nhất 1 chữ số,\nCó ít nhất 1 ký tự đặc biệt.",
                                    "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu mới không khớp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Có Chắc Muốn Quay Về ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form1 DNhap = new Form1();
                DNhap.ShowDialog();
                this.Close();
            }
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
