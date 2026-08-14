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

        private bool _isInitializingFilter = true;

        private void Home_Page_Load(object sender, EventArgs e)
        {
            _dt.EnsureUserDefaultWallet(SaveIdUser.AccountID);
            PhanQuyen();
            InitFilterControls();
            _isInitializingFilter = false;
            LoadDashboard();
        }

        private void InitFilterControls()
        {
            cboNam.Items.Clear();
            cboNam.Items.Add("Tất Cả Các Năm");
            cboNam.Items.Add("Năm 2026");
            cboNam.Items.Add("Năm 2025");
            cboNam.Items.Add("Năm 2024");
            cboNam.SelectedIndex = 1; // Default: 2026

            cboThang.Items.Clear();
            cboThang.Items.Add("Tất Cả Các Tháng (Cả Năm)");
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add($"Tháng {i}");
            }
            cboThang.SelectedIndex = 0; // Default: Tất cả các tháng
        }

        private void cboDateFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializingFilter) return;
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

            // Đọc thông số lọc Tháng & Năm
            int? selectedNam = cboNam.SelectedIndex > 0 ? (2027 - cboNam.SelectedIndex) : (int?)null;
            int? selectedThang = cboThang.SelectedIndex > 0 ? cboThang.SelectedIndex : (int?)null;

            string strFilterText = "";
            if (selectedNam.HasValue && selectedThang.HasValue)
            {
                strFilterText = $"📢 Đang lọc: Tháng {selectedThang.Value} / {selectedNam.Value}";
            }
            else if (selectedNam.HasValue)
            {
                strFilterText = $"📢 Đang lọc: Cả Năm {selectedNam.Value}";
            }
            else
            {
                strFilterText = "📢 Đang lọc: Tất cả các tháng / năm";
            }
            lblFilterStatus.Text = strFilterText;

            // Tải số liệu Dashboard Cards từ Stored Procedure sp_BaoCaoChuyenSauV2
            DataTable dtBaoCao = _dt.GetBaoCaoDashboard(SaveIdUser.CurrentWalletID, selectedThang, selectedNam);
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
                    lblAlertBanner.Text = "⚠️ CẢNH BÁO: Bạn đã chi hơn 80% thu nhập trong thời gian này!";
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

            // Load Biểu Đồ Thống Kê Chi Tiêu Tỷ Trọng Theo Danh Mục Lọc Theo Thời Gian
            LoadVisualCategoryChart(selectedThang, selectedNam);
        }

        private void LoadVisualCategoryChart(int? thang, int? nam)
        {
            DataTable dt = _dt.GetVisualCategoryChartFiltered(SaveIdUser.CurrentWalletID, thang, nam);
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

        private void chotSoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDoiSoatChotSo formCS = new FormDoiSoatChotSo();
            formCS.ShowDialog();
            LoadDashboard();
        }
    }
}
