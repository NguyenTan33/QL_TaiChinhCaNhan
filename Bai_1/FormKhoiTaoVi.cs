using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class FormKhoiTaoVi : Form
    {
        private DataModel _dt = new DataModel();

        public FormKhoiTaoVi()
        {
            InitializeComponent();
        }

        private void FormKhoiTaoVi_Load(object sender, EventArgs e)
        {
            _dt.EnsureUserDefaultWallet(SaveIdUser.AccountID);
            CapNhatThongTinViHienTai();
            LoadDanhSachVi();
        }

        private void CapNhatThongTinViHienTai()
        {
            lblViHienTai.Text = $"Ví đang chọn: {SaveIdUser.CurrentWalletName} ({SaveIdUser.CurrentWalletRole})";
            lblMaChiaSe.Text = $"Mã ví chung: {SaveIdUser.CurrentWalletCode}";

            DataTable dtBaoCao = _dt.TruyVan($"EXEC sp_BaoCaoChuyenSau @WalletID = {SaveIdUser.CurrentWalletID};");
            if (dtBaoCao != null && dtBaoCao.Rows.Count > 0)
            {
                decimal tienBanDau = Convert.ToDecimal(dtBaoCao.Rows[0]["TienBanDau"]);
                txtTienBanDau.Text = tienBanDau.ToString("N0");
            }
        }

        private void LoadDanhSachVi()
        {
            DataTable dtWallets = _dt.GetWalletsByAccount(SaveIdUser.AccountID);
            ResultStyle.ApplyStyle(dgvDanhSachVi);
            dgvDanhSachVi.DataSource = dtWallets;
        }

        private void btnCapNhatTien_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTienBanDau.Text.Replace(",", "").Replace(".", ""), out decimal tienBanDau) || tienBanDau < 0)
            {
                MessageBox.Show("Số tiền ban đầu phải là một số hợp lệ >= 0!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = _dt.SetInitialBalance(SaveIdUser.CurrentWalletID, tienBanDau);
            if (success)
            {
                MessageBox.Show($"Cập nhật thành công số tiền ban đầu cho '{SaveIdUser.CurrentWalletName}' là {tienBanDau:N0} VNĐ!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDanhSachVi();
                CapNhatThongTinViHienTai();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChonVi_Click(object sender, EventArgs e)
        {
            if (dgvDanhSachVi.CurrentRow != null)
            {
                SaveIdUser.CurrentWalletID = Convert.ToInt32(dgvDanhSachVi.CurrentRow.Cells["WalletID"].Value);
                SaveIdUser.CurrentWalletName = dgvDanhSachVi.CurrentRow.Cells["TenVi"].Value?.ToString() ?? "Ví";
                SaveIdUser.CurrentWalletRole = dgvDanhSachVi.CurrentRow.Cells["VaiTro"].Value?.ToString() ?? "Thành Viên";
                SaveIdUser.CurrentWalletCode = dgvDanhSachVi.CurrentRow.Cells["MaChiaSe"].Value?.ToString() ?? "";

                CapNhatThongTinViHienTai();
                MessageBox.Show($"Đã chuyển sang sử dụng: '{SaveIdUser.CurrentWalletName}'!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaoVi_Click(object sender, EventArgs e)
        {
            string tenVi = txtTenViMoi.Text.Trim();
            string loaiVi = cboLoaiVi.SelectedItem?.ToString() ?? "Cá Nhân";
            if (string.IsNullOrEmpty(tenVi))
            {
                MessageBox.Show("Vui lòng nhập tên ví!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtTienKhoiTaoMoi.Text.Replace(",", "").Replace(".", ""), out decimal tienBanDau))
            {
                tienBanDau = 0;
            }

            bool success = _dt.CreateWallet(SaveIdUser.AccountID, tenVi, loaiVi, tienBanDau, out string maChiaSe, out int newWalletId);
            if (success)
            {
                MessageBox.Show($"Tạo ví mới thành công!\nTên ví: {tenVi}\nMã Chia Sẻ Ví Gia Đình: {maChiaSe}", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenViMoi.Clear();
                txtTienKhoiTaoMoi.Text = "0";

                SaveIdUser.CurrentWalletID = newWalletId;
                SaveIdUser.CurrentWalletName = tenVi;
                SaveIdUser.CurrentWalletRole = "Chủ Ví";
                SaveIdUser.CurrentWalletCode = maChiaSe;

                LoadDanhSachVi();
                CapNhatThongTinViHienTai();
            }
            else
            {
                MessageBox.Show("Tạo ví thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThamGiaVi_Click(object sender, EventArgs e)
        {
            string maChiaSe = txtMaChiaSeThamGia.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(maChiaSe))
            {
                MessageBox.Show("Vui lòng nhập mã chia sẻ ví!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool success = _dt.JoinWalletByCode(SaveIdUser.AccountID, maChiaSe, out string tenVi, out int joinedWalletId);
            if (success)
            {
                MessageBox.Show($"Bạn đã tham gia thành công vào Ví Gia Đình: '{tenVi}'!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaChiaSeThamGia.Clear();

                SaveIdUser.CurrentWalletID = joinedWalletId;
                SaveIdUser.CurrentWalletName = tenVi;
                SaveIdUser.CurrentWalletRole = "Thành Viên";
                SaveIdUser.CurrentWalletCode = maChiaSe;

                LoadDanhSachVi();
                CapNhatThongTinViHienTai();
            }
            else
            {
                MessageBox.Show("Mã chia sẻ không chính xác hoặc bạn đã là thành viên ví này rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
