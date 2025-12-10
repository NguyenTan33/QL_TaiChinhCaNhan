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
                SaveIdUser.AccountUserName = TK ;
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
