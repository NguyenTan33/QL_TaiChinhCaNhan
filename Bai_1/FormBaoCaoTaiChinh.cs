using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class FormBaoCaoTaiChinh : Form
    {
        private DataModel _dt = new DataModel();

        public FormBaoCaoTaiChinh()
        {
            InitializeComponent();
        }

        private void FormBaoCaoTaiChinh_Load(object sender, EventArgs e)
        {
            _dt.EnsureUserDefaultWallet(SaveIdUser.AccountID);
            lblViInfo.Text = $"Đang báo cáo ví: {SaveIdUser.CurrentWalletName} ({SaveIdUser.CurrentWalletRole}) - Mã ví: {SaveIdUser.CurrentWalletCode}";

            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            LoadBaoCaoTongQuan();
            LoadCoCauDanhMuc();
            LoadDanhSachGiaoDich();
        }

        private void LoadBaoCaoTongQuan()
        {
            DataTable dtBaoCao = _dt.TruyVan($"EXEC sp_BaoCaoChuyenSau @WalletID = {SaveIdUser.CurrentWalletID};");
            if (dtBaoCao != null && dtBaoCao.Rows.Count > 0)
            {
                DataRow r = dtBaoCao.Rows[0];
                lblValTienBanDau.Text = $"{Convert.ToDecimal(r["TienBanDau"]):N0} đ";
                lblValTienHienCo.Text = $"{Convert.ToDecimal(r["TienHienCo"]):N0} đ";
                lblValTongThu.Text = $"{Convert.ToDecimal(r["TongThu"]):N0} đ";
                lblValTongChi.Text = $"{Convert.ToDecimal(r["TongChi"]):N0} đ";
                lblValThangDu.Text = $"{Convert.ToDecimal(r["ThangDu"]):N0} đ";
            }
        }

        private void LoadCoCauDanhMuc()
        {
            string fromDate = dtpTuNgay.Value.ToString("yyyy-MM-dd");
            string toDate = dtpDenNgay.Value.ToString("yyyy-MM-dd");

            string sql = $@"
                SELECT 
                    DanhMuc AS [Danh Mục Chi Tiêu],
                    SUM(SoTien) AS [Tổng Số Tiền],
                    COUNT(*) AS [Số Lần Chi]
                FROM ChiTieu
                WHERE WalletID = {SaveIdUser.CurrentWalletID}
                  AND Ngay >= '{fromDate}' AND Ngay <= '{toDate}'
                GROUP BY DanhMuc
                ORDER BY [Tổng Số Tiền] DESC;";

            DataTable dt = _dt.TruyVan(sql);
            ResultStyle.ApplyStyle(dgvCoCauDanhMuc);
            dgvCoCauDanhMuc.DataSource = dt;
        }

        private void LoadDanhSachGiaoDich()
        {
            string fromDate = dtpTuNgay.Value.ToString("yyyy-MM-dd");
            string toDate = dtpDenNgay.Value.ToString("yyyy-MM-dd");

            string sql = $@"
                SELECT 
                    'Chi Tiêu' AS [Loại],
                    c.DanhMuc AS [Danh Mục],
                    c.SoTien AS [Số Tiền],
                    c.NoiDung AS [Nội Dung],
                    c.Ngay AS [Ngày],
                    a.TaiKhoan AS [Người Thực Hiện]
                FROM ChiTieu c
                LEFT JOIN Account a ON c.AccountID = a.ID
                WHERE c.WalletID = {SaveIdUser.CurrentWalletID}
                  AND c.Ngay >= '{fromDate}' AND c.Ngay <= '{toDate}'

                UNION ALL

                SELECT 
                    'Thu Nhập' AS [Loại],
                    N'Thu Nhập Tổng' AS [Danh Mục],
                    (t.Luong + t.Thuong + t.Khac) AS [Số Tiền],
                    N'Lương/Thưởng/Khác' AS [Nội Dung],
                    t.Ngay AS [Ngày],
                    a.TaiKhoan AS [Người Thực Hiện]
                FROM ThuNhap t
                LEFT JOIN Account a ON t.AccountID = a.ID
                WHERE t.WalletID = {SaveIdUser.CurrentWalletID}
                  AND t.Ngay >= '{fromDate}' AND t.Ngay <= '{toDate}'

                ORDER BY [Ngày] DESC;";

            DataTable dt = _dt.TruyVan(sql);
            ResultStyle.ApplyStyle(dgvAllGiaoDich);
            dgvAllGiaoDich.DataSource = dt;
        }

        private void btnLocData_Click(object sender, EventArgs e)
        {
            LoadCoCauDanhMuc();
            LoadDanhSachGiaoDich();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtExport = (DataTable)dgvAllGiaoDich.DataSource;
                if (dtExport == null || dtExport.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu giao dịch nào để xuất!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV File (*.csv)|*.csv";
                sfd.FileName = $"BaoCaoThuChi_{SaveIdUser.CurrentWalletName}_{DateTime.Now:yyyyMMdd}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _dt.ExportToCsv(dtExport, sfd.FileName);
                    MessageBox.Show($"Xuất báo cáo thành công ra file:\n{sfd.FileName}", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
