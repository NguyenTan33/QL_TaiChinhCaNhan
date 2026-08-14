using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class FormPhanTichDuLieu : Form
    {
        private DataModel _dt = new DataModel();

        public FormPhanTichDuLieu()
        {
            InitializeComponent();
        }

        private void FormPhanTichDuLieu_Load(object sender, EventArgs e)
        {
            _dt.EnsureUserDefaultWallet(SaveIdUser.AccountID);
            lblViInfo.Text = $"Ví đang phân tích: {SaveIdUser.CurrentWalletName} ({SaveIdUser.CurrentWalletRole}) - Mã ví: {SaveIdUser.CurrentWalletCode}";

            Load6Charts();
        }

        private void Load6Charts()
        {
            int walletId = SaveIdUser.CurrentWalletID;

            // 1. Biểu đồ 1: Tỷ trọng Chi tiêu
            DataTable dt1 = _dt.GetAnalyticsCategoryBreakdown(walletId);
            ResultStyle.ApplyStyle(dgvChart1);
            dgvChart1.DataSource = dt1;
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                DataRow topRow = dt1.Rows[0];
                string topCat = topRow["Danh Mục"].ToString();
                string topPct = topRow["Tỷ Trọng (%)"].ToString();
                lblInsight1.Text = $"💡 AI NHẬN XÉT: Danh mục '{topCat}' chiếm tỷ trọng lớn nhất ({topPct}). Bạn nên chú ý cắt giảm các khoản chi không cần thiết ở danh mục này!";
            }
            else
            {
                lblInsight1.Text = "💡 AI NHẬN XÉT: Chưa có dữ liệu chi tiêu để phân tích cơ cấu danh mục.";
            }

            // 2. Biểu đồ 2: Thu Nhập vs Chi Tiêu theo Tháng
            DataTable dt2 = _dt.GetAnalyticsIncomeVsExpense(walletId);
            ResultStyle.ApplyStyle(dgvChart2);
            dgvChart2.DataSource = dt2;
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                DataRow r2 = dt2.Rows[0];
                decimal thu = Convert.ToDecimal(r2["Tổng Thu (VNĐ)"]);
                decimal chi = Convert.ToDecimal(r2["Tổng Chi (VNĐ)"]);
                decimal thangDu = Convert.ToDecimal(r2["Thặng Dư (VNĐ)"]);
                lblInsight2.Text = $"💡 AI NHẬN XÉT: Trong tháng gần nhất, tổng thu là {thu:N0} đ, chi là {chi:N0} đ, thặng dư dòng tiền đạt {thangDu:N0} đ. Tỷ lệ tích lũy tốt!";
            }
            else
            {
                lblInsight2.Text = "💡 AI NHẬN XÉT: Chưa ghi nhận dữ liệu thu chi theo tháng.";
            }

            // 3. Biểu đồ 3: Burn Rate & Số Ngày Sống Sót
            DataTable dt3 = _dt.GetAnalyticsBurnRate(walletId);
            ResultStyle.ApplyStyle(dgvChart3);
            dgvChart3.DataSource = dt3;
            if (dt3 != null && dt3.Rows.Count > 0)
            {
                DataRow r3 = dt3.Rows[0];
                decimal burnRate = Convert.ToDecimal(r3["ChiTrungBinhNgay"]);
                int ngayConLai = Convert.ToInt32(r3["SoNgayDuyTri"]);
                lblInsight3.Text = $"💡 AI NHẬN XÉT: Mức đốt tiền trung bình {burnRate:N0} đ/ngày. Với số dư ví hiện tại, bạn có thể sống sót duy trì trong khoảng {ngayConLai} ngày nữa!";
            }
            else
            {
                lblInsight3.Text = "💡 AI NHẬN XÉT: Chưa có dữ liệu tính toán Burn Rate.";
            }

            // 4. Biểu đồ 4: Ngân Sách Utilization
            DataTable dt4 = _dt.GetAnalyticsBudgetUsage(walletId);
            ResultStyle.ApplyStyle(dgvChart4);
            dgvChart4.DataSource = dt4;
            if (dt4 != null && dt4.Rows.Count > 0)
            {
                int totalCat = dt4.Rows.Count;
                int warningCat = 0;
                foreach (DataRow r4 in dt4.Rows)
                {
                    string canhBao = r4["Trạng Thái Cảnh Báo"].ToString() ?? "";
                    if (canhBao.Contains("⚠️") || canhBao.Contains("⚡")) warningCat++;
                }
                lblInsight4.Text = $"💡 AI NHẬN XÉT: Có {totalCat} danh mục đang được theo dõi ngân sách, trong đó {warningCat} danh mục chạm mốc cảnh báo/vượt mốc hạn mức.";
            }
            else
            {
                lblInsight4.Text = "💡 AI NHẬN XÉT: Bạn chưa thiết lập hạn mức ngân sách tháng này. Hãy vào mục Ngân Sách để cài đặt!";
            }

            // 5. Biểu đồ 5: Phân Phối Dòng Tiền 50/30/20
            DataTable dt5 = _dt.GetAnalytics503020Rule(walletId);
            ResultStyle.ApplyStyle(dgvChart5);
            dgvChart5.DataSource = dt5;
            if (dt5 != null && dt5.Rows.Count >= 3)
            {
                string pctThietYeu = dt5.Rows[0]["Tỷ Lệ Thực Tế (%)"].ToString();
                string pctSoThich = dt5.Rows[1]["Tỷ Lệ Thực Tế (%)"].ToString();
                string pctTietKiem = dt5.Rows[2]["Tỷ Lệ Thực Tế (%)"].ToString();
                lblInsight5.Text = $"💡 AI NHẬN XÉT: Phân bổ hiện tại: Thiết yếu = {pctThietYeu} (Chuẩn 50%), Sở thích = {pctSoThich} (Chuẩn 30%), Tiết kiệm/Đầu tư = {pctTietKiem} (Chuẩn 20%).";
            }
            else
            {
                lblInsight5.Text = "💡 AI NHẬN XÉT: Đang tổng hợp phân bổ 50/30/20...";
            }

            // 6. Biểu đồ 6: Hiệu Suất Đầu Tư & ROI
            DataTable dt6 = _dt.GetAnalyticsInvestmentROI(walletId);
            ResultStyle.ApplyStyle(dgvChart6);
            dgvChart6.DataSource = dt6;
            if (dt6 != null && dt6.Rows.Count > 0)
            {
                decimal tongVon = 0;
                decimal tongGiaTri = 0;
                foreach (DataRow r6 in dt6.Rows)
                {
                    tongVon += Convert.ToDecimal(r6["Vốn Ban Đầu (VNĐ)"]);
                    tongGiaTri += Convert.ToDecimal(r6["Giá Trị Hiện Tại (VNĐ)"]);
                }
                decimal tongLai = tongGiaTri - tongVon;
                decimal roiTong = tongVon > 0 ? (tongLai / tongVon) * 100 : 0;
                lblInsight6.Text = $"💡 AI NHẬN XÉT: Tổng vốn đầu tư: {tongVon:N0} đ, Giá trị danh mục hiện tại: {tongGiaTri:N0} đ. Lãi/Lỗ: {tongLai:N0} đ (Tỷ suất ROI tổng: {roiTong:N2}%).";
            }
            else
            {
                lblInsight6.Text = "💡 AI NHẬN XÉT: Bạn chưa nhập tài sản đầu tư nào. Hãy vào mục 'Đầu Tư & Vay Nợ' để thêm danh mục đầu tư!";
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
