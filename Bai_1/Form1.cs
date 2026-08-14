namespace Bai_1
{
    public partial class Form1 : Form
    {
        DataModel dt = new DataModel();
        public Form1()
        {
            InitializeComponent();
            txtMK.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string TK = txtTK.Text;
            string MK = txtMK.Text;
            int Passed = dt.CheckLogin(TK, MK);
            if (CheckValidation.TaiKhoan(TK) && CheckValidation.MatKhau(MK) && Passed != -1)
            {
                SaveIdUser.AccountID = Passed;
                SaveIdUser.AccountUserName = TK;
                dt.EnsureUserDefaultWallet(Passed);
                
                this.Hide();
                Home_Page TrangChu = new Home_Page();
                TrangChu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài Khoản Hoặc Mật Khẩu không chính xác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDk_Click(object sender, EventArgs e)
        {
            string TK = txtTK.Text.Trim();
            string MK = txtMK.Text.Trim();

            if (!CheckValidation.TaiKhoan(TK))
            {
                MessageBox.Show("Tài khoản phải dài từ 3-50 ký tự và chỉ chứa chữ cái, chữ số!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CheckValidation.MatKhau(MK))
            {
                MessageBox.Show("Mật khẩu không hợp lệ!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = dt.Register(TK, MK);
            if (success)
            {
                MessageBox.Show("Đăng ký tài khoản thành công! Vui lòng nhấn Đăng nhập.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại! Tài khoản có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuenMK_Click(object sender, EventArgs e)
        {
            FormQuenMatKhau qmk = new FormQuenMatKhau();
            qmk.ShowDialog();
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
