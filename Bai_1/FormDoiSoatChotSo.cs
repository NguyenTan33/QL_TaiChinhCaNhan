using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class FormDoiSoatChotSo : Form
    {
        private DataModel _dt = new DataModel();
        private decimal _tienHeThong = 0;

        public FormDoiSoatChotSo()
        {
            InitializeComponent();
        }

        private void FormDoiSoatChotSo_Load(object sender, EventArgs e)
        {
            _dt.EnsureUserDefaultWallet(SaveIdUser.AccountID);
            lblViInfo.Text = $"Ví đang kiểm đếm: {SaveIdUser.CurrentWalletName} ({SaveIdUser.CurrentWalletRole}) - Mã ví: {SaveIdUser.CurrentWalletCode}";

            LoadData();
        }

        private void LoadData()
        {
            int walletId = SaveIdUser.CurrentWalletID;

            // 1. Nạp số dư hệ thống
            SaveDLReport report = _dt.GetBaoCaoTongQuat(SaveIdUser.AccountID);
            _tienHeThong = report.TienHienCo;
            lblTienHeThong.Text = $"{_tienHeThong:N0} đ";

            // Nếu người dùng chưa nhập số dư thực tế, đặt bằng tiền hệ thống làm mặc định
            if (string.IsNullOrWhiteSpace(txtTienThucTe.Text) || txtTienThucTe.Text == "0")
            {
                txtTienThucTe.Text = _tienHeThong.ToString("N0");
            }

            TinhChenhLech();

            // 2. Nạp nhật ký lịch sử chốt sổ
            DataTable dtHistory = _dt.GetLichSuChotSo(walletId);
            ResultStyle.ApplyStyle(dgvHistory);
            dgvHistory.DataSource = dtHistory;
        }

        private void TinhChenhLech()
        {
            string rawStr = txtTienThucTe.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(rawStr, out decimal tienThucTe))
            {
                decimal chenhLech = tienThucTe - _tienHeThong;
                lblChenhLech.Text = $"{chenhLech:N0} đ";

                if (chenhLech == 0)
                {
                    cardChenhLech.BackColor = Color.SeaGreen;
                    lblChenhLech.ForeColor = Color.White;
                    lblStatusAlert.ForeColor = Color.DarkGreen;
                    lblStatusAlert.Text = "✅ CÂN BẰNG TÀI CHÍNH: Số dư thực tế kiểm đếm trùng khớp 100% với sổ sách!";
                }
                else if (chenhLech < 0)
                {
                    cardChenhLech.BackColor = Color.Firebrick;
                    lblChenhLech.ForeColor = Color.Yellow;
                    lblStatusAlert.ForeColor = Color.DarkRed;
                    lblStatusAlert.Text = $"⚠️ LỆCH THIẾU: Thực tế THIẾU {Math.Abs(chenhLech):N0} đ so với hệ thống! (Có thể có khoản chi quên chưa ghi).";
                }
                else
                {
                    cardChenhLech.BackColor = Color.DarkOrange;
                    lblChenhLech.ForeColor = Color.White;
                    lblStatusAlert.ForeColor = Color.DarkOrange;
                    lblStatusAlert.Text = $"💡 LỆCH THỪA: Thực tế THỪA {chenhLech:N0} đ so với hệ thống! (Có thể có khoản thu/thưởng quên chưa ghi).";
                }
            }
        }

        private void txtTienThucTe_TextChanged(object sender, EventArgs e)
        {
            TinhChenhLech();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            TinhChenhLech();
            MessageBox.Show(lblStatusAlert.Text, "Thông Báo Kết Quả Phân Tích Chênh Lệch", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnChotSo_Click(object sender, EventArgs e)
        {
            string rawStr = txtTienThucTe.Text.Replace(",", "").Replace(".", "").Trim();
            if (!decimal.TryParse(rawStr, out decimal tienThucTe))
            {
                MessageBox.Show("Vui lòng nhập số tiền thực tế hợp lệ!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal chenhLech = tienThucTe - _tienHeThong;
            string alertMsg = chenhLech == 0 
                ? "Số dư thực tế đã khớp với hệ thống. Bạn có muốn chốt sổ lần này không?"
                : $"Số dư thực tế lệch {chenhLech:N0} đ so với hệ thống.\n\nHệ thống sẽ tự động thêm khoản {(chenhLech < 0 ? "Chi" : "Thu")} điều chỉnh để đưa số dư ví về {tienThucTe:N0} đ.\n\nBạn có chắc chắn muốn CHỐT SỔ & CÂN BẰNG VÍ?";

            DialogResult dr = MessageBox.Show(alertMsg, "Xác Nhận Chốt Sổ Tài Chính", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                bool ok = _dt.PerformChotSo(
                    SaveIdUser.CurrentWalletID,
                    SaveIdUser.AccountID,
                    tienThucTe,
                    txtGhiChu.Text.Trim(),
                    out decimal tienHeThongOut,
                    out decimal chenhLechOut,
                    out string thongBao
                );

                if (ok)
                {
                    MessageBox.Show(thongBao, "Chốt Sổ Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thao tác chốt sổ thất bại: " + thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
