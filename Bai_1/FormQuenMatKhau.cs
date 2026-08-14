using System;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class FormQuenMatKhau : Form
    {
        private DataModel _dt = new DataModel();

        public FormQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnTimTK_Click(object sender, EventArgs e)
        {
            string tk = txtTK.Text.Trim();
            if (string.IsNullOrEmpty(tk))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string q = _dt.GetSecurityQuestion(tk);
            txtCauHoiBaoMat.Text = q;
        }

        private void btnDatLaiMK_Click(object sender, EventArgs e)
        {
            string tk = txtTK.Text.Trim();
            string answer = txtDapAn.Text.Trim();
            string newPassword = txtMK.Text.Trim();

            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng điền đầy đủ tài khoản và mật khẩu mới!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CheckValidation.MatKhau(newPassword))
            {
                MessageBox.Show("Mật khẩu mới không hợp lệ!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ok = _dt.ResetPassword(tk, answer, newPassword, out string msg);
            if (ok)
            {
                MessageBox.Show("Đặt lại mật khẩu thành công! Bạn có thể đăng nhập ngay bây giờ.", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show($"Thất bại: {msg}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
