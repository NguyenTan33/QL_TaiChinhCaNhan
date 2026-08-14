using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class FormDauTuVayNo : Form
    {
        private DataModel _dt = new DataModel();

        public FormDauTuVayNo()
        {
            InitializeComponent();
        }

        private void FormDauTuVayNo_Load(object sender, EventArgs e)
        {
            _dt.EnsureUserDefaultWallet(SaveIdUser.AccountID);
            lblViInfo.Text = $"Đang quản lý danh mục ví: {SaveIdUser.CurrentWalletName} ({SaveIdUser.CurrentWalletRole})";

            cboLoaiVayNo.SelectedIndex = 0;
            cboLoaiDauTu.SelectedIndex = 0;

            LoadVayNo();
            LoadDauTu();
        }

        private void LoadVayNo()
        {
            DataTable dtVayNo = _dt.GetVayNoList(SaveIdUser.CurrentWalletID);
            ResultStyle.ApplyStyle(dgvVayNo);
            dgvVayNo.DataSource = dtVayNo;
        }

        private void LoadDauTu()
        {
            DataTable dtDauTu = _dt.GetDauTuList(SaveIdUser.CurrentWalletID);
            ResultStyle.ApplyStyle(dgvDauTu);
            dgvDauTu.DataSource = dtDauTu;
        }

        private void btnThemVayNo_Click(object sender, EventArgs e)
        {
            string loai = cboLoaiVayNo.SelectedItem?.ToString() ?? "Cho Mượn (Người khác nợ)";
            string doiTac = txtDoiTac.Text.Trim();
            if (string.IsNullOrEmpty(doiTac))
            {
                MessageBox.Show("Vui lòng nhập tên đối tác / người mượn / ngân hàng!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSoTienGoc.Text.Replace(",", "").Replace(".", ""), out decimal soTienGoc) || soTienGoc <= 0)
            {
                MessageBox.Show("Số tiền gốc phải là số hợp lệ > 0!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(txtLaiSuat.Text, out decimal laiSuat);
            string ghiChu = txtGhiChuVayNo.Text.Trim();

            bool ok = _dt.SaveVayNo(SaveIdUser.AccountID, SaveIdUser.CurrentWalletID, loai, doiTac, soTienGoc, laiSuat, DateTime.Now, null, ghiChu);
            if (ok)
            {
                MessageBox.Show("Đã thêm khoản vay/mượn thành công!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDoiTac.Clear();
                txtSoTienGoc.Clear();
                txtGhiChuVayNo.Clear();
                LoadVayNo();
            }
            else
            {
                MessageBox.Show("Thêm khoản vay/mượn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToanVayNo_Click(object sender, EventArgs e)
        {
            if (dgvVayNo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng khoản nợ cần cập nhật thanh toán!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvVayNo.SelectedRows[0];
            int id = Convert.ToInt32(row.Cells["ID"].Value);
            decimal duNo = Convert.ToDecimal(row.Cells["Dư Nợ Còn Lại (VNĐ)"].Value);

            if (duNo <= 0)
            {
                MessageBox.Show("Khoản nợ này đã được thanh toán xong!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool ok = _dt.ThanhToanVayNo(id, duNo);
            if (ok)
            {
                MessageBox.Show("Đã cập nhật thanh toán xong khoản nợ!", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVayNo();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemDauTu_Click(object sender, EventArgs e)
        {
            string loai = cboLoaiDauTu.SelectedItem?.ToString() ?? "Chứng Khoán";
            string tenTaiSan = txtTenTaiSan.Text.Trim();
            if (string.IsNullOrEmpty(tenTaiSan))
            {
                MessageBox.Show("Vui lòng nhập tên tài sản / mã chứng khoán / loại vàng!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGiaVon.Text.Replace(",", "").Replace(".", ""), out decimal giaVon) || giaVon <= 0)
            {
                MessageBox.Show("Giá vốn ban đầu phải là số hợp lệ > 0!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtGiaTriHienTai.Text.Replace(",", "").Replace(".", ""), out decimal giaTriHienTai) || giaTriHienTai < 0)
            {
                MessageBox.Show("Giá trị hiện tại phải là số hợp lệ >= 0!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(txtSoLuong.Text, out decimal soLuong);
            if (soLuong <= 0) soLuong = 1;

            string ghiChu = txtGhiChuDauTu.Text.Trim();

            bool ok = _dt.SaveDauTu(SaveIdUser.AccountID, SaveIdUser.CurrentWalletID, loai, tenTaiSan, soLuong, giaVon, giaTriHienTai, DateTime.Now, ghiChu);
            if (ok)
            {
                decimal roi = giaVon > 0 ? ((giaTriHienTai - giaVon) / giaVon) * 100 : 0;
                MessageBox.Show($"Đã lưu danh mục đầu tư '{tenTaiSan}'!\nTỷ suất sinh lời ROI: {roi:N2}%", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTaiSan.Clear();
                txtGiaVon.Clear();
                txtGiaTriHienTai.Clear();
                txtGhiChuDauTu.Clear();
                LoadDauTu();
            }
            else
            {
                MessageBox.Show("Thêm khoản đầu tư thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
