using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class Home_Page : Form
    {
        private DataModel _dt = new DataModel();

        public Home_Page()
        {
            InitializeComponent();
        }

        private void Home_Page_Load(object sender, EventArgs e)
        {
            _dt.EnsureUserDefaultWallet(SaveIdUser.AccountID);
            PhanQuyen();
            LoadDashboard();
        }

        public void PhanQuyen()
        {
            if (SaveIdUser.AccountID != 1)
            {
                QL_User.Visible = false;
            }
        }

        private void LoadDashboard()
        {
            _dt.EnsureUserDefaultWallet(SaveIdUser.AccountID);

            lblWelcome.Text = $"🏠 CHÀO MỪNG {SaveIdUser.AccountUserName.ToUpper()} TRỞ LẠI!";
            lblViActive.Text = $"Ví đang chọn: {SaveIdUser.CurrentWalletName} ({SaveIdUser.CurrentWalletRole}) - Mã ví chung: {SaveIdUser.CurrentWalletCode}";

            // Tải số liệu Dashboard Cards từ Stored Procedure sp_BaoCaoChuyenSau
            DataTable dtBaoCao = _dt.TruyVan($"EXEC sp_BaoCaoChuyenSau @WalletID = {SaveIdUser.CurrentWalletID};");
            if (dtBaoCao != null && dtBaoCao.Rows.Count > 0)
            {
                DataRow r = dtBaoCao.Rows[0];
                decimal tienBanDau = Convert.ToDecimal(r["TienBanDau"]);
                decimal tienHienCo = Convert.ToDecimal(r["TienHienCo"]);
                decimal tongThu = Convert.ToDecimal(r["TongThu"]);
                decimal tongChi = Convert.ToDecimal(r["TongChi"]);
                decimal thangDu = Convert.ToDecimal(r["ThangDu"]);

                lblV1.Text = $"{tienBanDau:N0} đ";
                lblV2.Text = $"{tienHienCo:N0} đ";
                lblV3.Text = $"{tongThu:N0} đ";
                lblV4.Text = $"{tongChi:N0} đ";
                lblV5.Text = $"{thangDu:N0} đ";

                // Alert Banner
                if (tongThu > 0 && (tongChi / tongThu) > 0.8m)
                {
                    lblAlertBanner.Text = "⚠️ CẢNH BÁO: Bạn đã chi hơn 80% thu nhập!";
                    lblAlertBanner.ForeColor = Color.OrangeRed;
                }
                else if (tienHienCo < 1000000)
                {
                    lblAlertBanner.Text = "🔥 NGUY HIỂM: Số dư ví dưới 1 triệu VNĐ!";
                    lblAlertBanner.ForeColor = Color.Red;
                }
                else
                {
                    lblAlertBanner.Text = "✅ TRẠNG THÁI: Tài chính khả quan!";
                    lblAlertBanner.ForeColor = Color.Gold;
                }
            }

            // Load Biểu Đồ Thống Kê Chi Tiêu Tỷ Trọng Theo Danh Mục
            LoadVisualCategoryChart();
        }

        private void LoadVisualCategoryChart()
        {
            string sql = $@"
                SELECT 
                    c.DanhMuc AS [Danh Mục Chi Tiêu],
                    SUM(c.SoTien) AS [Tổng Tiền Chi (VNĐ)],
                    COUNT(*) AS [Số Lần Chi],
                    CAST(ROUND(SUM(c.SoTien) * 100.0 / NULLIF((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = {SaveIdUser.CurrentWalletID}), 0), 1) AS NVARCHAR(20)) + '%' AS [Tỷ Trọng (%)],
                    REPLICATE('█', CAST(ROUND(SUM(c.SoTien) * 20.0 / NULLIF((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = {SaveIdUser.CurrentWalletID}), 0), 0) AS INT)) AS [Biểu Đồ Trực Quan]
                FROM ChiTieu c
                WHERE c.WalletID = {SaveIdUser.CurrentWalletID}
                GROUP BY c.DanhMuc
                ORDER BY [Tổng Tiền Chi (VNĐ)] DESC;";

            DataTable dt = _dt.TruyVan(sql);
            ResultStyle.ApplyStyle(dgvVisualChart);
            dgvVisualChart.DataSource = dt;
        }

        private void ThuNhap_Click(object sender, EventArgs e)
        {
            Thu_Nhap ThuNhapForm = new Thu_Nhap();
            ThuNhapForm.ShowDialog();
            LoadDashboard();
        }

        private void ChiTieu_Click(object sender, EventArgs e)
        {
            Chi_Tieu ChiTieuForm = new Chi_Tieu();
            ChiTieuForm.ShowDialog();
            LoadDashboard();
        }

        private void Out_Click(object sender, EventArgs e)
        {
            DialogResult Ok = MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Ok == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void QL_User_Click(object sender, EventArgs e)
        {
            QL_User QL_UserForm = new QL_User();
            QL_UserForm.ShowDialog();
            LoadDashboard();
        }

        private void DoiMk_Click(object sender, EventArgs e)
        {
            DoiMatKhau DoiMKForm = new DoiMatKhau();
            DoiMKForm.ShowDialog();
        }

        private void DKVSD_Click(object sender, EventArgs e)
        {
            DSHySu DsHySuForm = new DSHySu();
            DsHySuForm.ShowDialog();
        }

        private void khóaMànHìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Dnhap = new Form1();
            Dnhap.ShowDialog();
            this.Close();
        }

        private void khoiTaoViToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhoiTaoVi formVi = new FormKhoiTaoVi();
            formVi.ShowDialog();
            LoadDashboard();
        }

        private void baoCaoXinXoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBaoCaoTaiChinh formBaoCao = new FormBaoCaoTaiChinh();
            formBaoCao.ShowDialog();
            LoadDashboard();
        }

        private void aiAdvisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAIChatbox formAI = new FormAIChatbox();
            formAI.ShowDialog();
        }

        private void nganSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLyNganSach formNS = new FormQuanLyNganSach();
            formNS.ShowDialog();
            LoadDashboard();
        }

        private void dauTuVayNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDauTuVayNo formDTVN = new FormDauTuVayNo();
            formDTVN.ShowDialog();
            LoadDashboard();
        }

        private void phanTichToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhanTichDuLieu formPT = new FormPhanTichDuLieu();
            formPT.ShowDialog();
            LoadDashboard();
        }
    }
}
