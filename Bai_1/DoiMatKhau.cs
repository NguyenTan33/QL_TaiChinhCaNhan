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
    public partial class DoiMatKhau : Form
    {
        DataModel dt = new DataModel();
        public DoiMatKhau()
        {
            InitializeComponent();
            txtMKcu.PasswordChar = '*';
            txtMKmoi.PasswordChar = '*';
            txtMKmoi2.PasswordChar = '*';
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            string MKcu = txtMKcu.Text;
            string Mkmoi = txtMKmoi.Text;
            string MKmoi2 = txtMKmoi2.Text;
            if (dt.CheckLogin(SaveIdUser.AccountUserName ,MKcu) != -1)
            {
                if (CheckValidation.SameMK(Mkmoi, MKmoi2))
                {
                    if (CheckValidation.DoiMK(Mkmoi))
                    {
                        DialogResult YN = MessageBox.Show("Bạn có chắc muốn đổi mật khẩu", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (YN == DialogResult.Yes)
                        {
                            string sql = $@"EXEC sp_Account_Sua 
                                                @ID = {SaveIdUser.AccountID},
                                                @MatKhau = '{Mkmoi}';
                                            ";
                            dt.ExecuteNonQuery(sql);
                            this.Hide();
                            Home_Page TrangChu = new Home_Page();
                            TrangChu.ShowDialog();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật Khẩu Mới Cần Có:\nĐộ dài 6–12 ký tự,\nCó ít nhất 1 chữ in hoa,\nCó ít nhất 1 chữ số,\nCó ít nhất 1 ký tự đặc biệt.",
                                        "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không khớp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page TrangChu = new Home_Page();
            TrangChu.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
