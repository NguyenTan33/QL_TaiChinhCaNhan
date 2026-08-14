using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class FormQuanLyNganSach : Form
    {
        private DataModel _dt = new DataModel();

        public FormQuanLyNganSach()
        {
            InitializeComponent();
        }

        private void FormQuanLyNganSach_Load(object sender, EventArgs e)
        {
            _dt.EnsureUserDefaultWallet(SaveIdUser.AccountID);
            lblViInfo.Text = $"Đang đặt ngân sách ví: {SaveIdUser.CurrentWalletName} ({SaveIdUser.CurrentWalletRole})";
            cboDanhMuc.SelectedIndex = 0;
            LoadNganSach();
        }

        private void LoadNganSach()
        {
            int thang = dtpThangNam.Value.Month;
            int nam = dtpThangNam.Value.Year;

            DataTable dt = _dt.GetBudgets(SaveIdUser.CurrentWalletID, thang, nam);
            ResultStyle.ApplyStyle(dgvNganSach);
            dgvNganSach.DataSource = dt;
        }

        private void btnLuuNganSach_Click(object sender, EventArgs e)
        {
            string danhMuc = cboDanhMuc.SelectedItem?.ToString() ?? "Ăn Uống";
            if (!decimal.TryParse(txtGioiHan.Text.Replace(",", "").Replace(".", ""), out decimal gioiHan) || gioiHan < 0)
            {
                MessageBox.Show("Hạn mức ngân sách phải là số hợp lệ >= 0!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int thang = dtpThangNam.Value.Month;
            int nam = dtpThangNam.Value.Year;

            bool ok = _dt.UpsertBudget(SaveIdUser.CurrentWalletID, danhMuc, gioiHan, thang, nam);
            if (ok)
            {
                MessageBox.Show($"Đã lưu ngân sách danh mục '{danhMuc}' tháng {thang}/{nam} là {gioiHan:N0} VNĐ!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGioiHan.Clear();
                LoadNganSach();
            }
            else
            {
                MessageBox.Show("Lưu ngân sách thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpThangNam_ValueChanged(object sender, EventArgs e)
        {
            LoadNganSach();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
