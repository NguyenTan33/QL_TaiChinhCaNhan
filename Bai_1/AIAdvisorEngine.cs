using System;
using System.Data;
using System.Text;

namespace Bai_1
{
    public class AIAdvisorEngine
    {
        private DataModel _dataModel = new DataModel();

        public string AnalyzeFinancialHealth(int walletId)
        {
            DataTable dtBaoCao = _dataModel.TruyVan($"EXEC sp_BaoCaoChuyenSau @WalletID = {walletId};");
            if (dtBaoCao == null || dtBaoCao.Rows.Count == 0)
            {
                return "⚠️ Chưa có đủ dữ liệu thu chi để phân tích tài chính.";
            }

            DataRow row = dtBaoCao.Rows[0];
            decimal tienBanDau = Convert.ToDecimal(row["TienBanDau"]);
            decimal tienHienCo = Convert.ToDecimal(row["TienHienCo"]);
            decimal tongThu = Convert.ToDecimal(row["TongThu"]);
            decimal tongChi = Convert.ToDecimal(row["TongChi"]);
            decimal thangDu = Convert.ToDecimal(row["ThangDu"]);
            decimal thangNayThu = Convert.ToDecimal(row["ThangNayThu"]);
            decimal thangNayChi = Convert.ToDecimal(row["ThangNayChi"]);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("🤖 === BÁO CÁO PHÂN TÍCH TÀI CHÍNH TỪ AI ADVISOR ===");
            sb.AppendLine($"💰 Số dư khởi tạo: {tienBanDau:N0} VNĐ");
            sb.AppendLine($"💵 Số dư khả dụng hiện tại: {tienHienCo:N0} VNĐ");
            sb.AppendLine($"📊 Tổng Thu từ trước tới nay: {tongThu:N0} VNĐ | Tổng Chi: {tongChi:N0} VNĐ");
            sb.AppendLine($"📈 Thặng dư tích lũy: {thangDu:N0} VNĐ");
            sb.AppendLine("-------------------------------------------------------");

            // Phân tích tháng hiện tại
            sb.AppendLine($"🗓️ Trong tháng này: Thu = {thangNayThu:N0} VNĐ | Chi = {thangNayChi:N0} VNĐ");
            if (thangNayThu > 0)
            {
                decimal tyLeChi = (thangNayChi / thangNayThu) * 100;
                sb.AppendLine($"📊 Tỷ lệ Chi/Thu tháng này: {tyLeChi:F1}%");
                if (tyLeChi > 100)
                {
                    sb.AppendLine("⚠️ CẢNH BÁO: Tháng này bạn đang CHI VƯỢT THU! Hãy thắt chặt chi tiêu ngay lập tức.");
                }
                else if (tyLeChi > 70)
                {
                    sb.AppendLine("⚠️ BÁO ĐỘNG NHẸ: Bạn đã chi hơn 70% thu nhập tháng này. Cần cẩn trọng các khoản phát sinh.");
                }
                else
                {
                    sb.AppendLine("✅ TỐT: Chi tiêu tháng này nằm trong mức an toàn (<70% thu nhập).");
                }
            }

            // Phân tích danh mục chi nhiều nhất
            DataTable dtCategory = _dataModel.TruyVan($@"
                SELECT TOP 3 DanhMuc, SUM(SoTien) AS TongChi 
                FROM ChiTieu 
                WHERE WalletID = {walletId} 
                GROUP BY DanhMuc 
                ORDER BY TongChi DESC;");

            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                sb.AppendLine("\n🔥 Top 3 danh mục tiêu tốn tiền nhất:");
                foreach (DataRow r in dtCategory.Rows)
                {
                    sb.AppendLine($"   • {r["DanhMuc"]}: {Convert.ToDecimal(r["TongChi"]):N0} VNĐ");
                }
            }

            // Dự đoán Burn rate
            DataTable dtDuDoan = _dataModel.TruyVan($"EXEC sp_DuDoanChiTieu @WalletID = {walletId};");
            if (dtDuDoan != null && dtDuDoan.Rows.Count > 0)
            {
                DataRow rPredict = dtDuDoan.Rows[0];
                decimal chiTB = Convert.ToDecimal(rPredict["ChiTrungBinhNgay"]);
                int soNgay = Convert.ToInt32(rPredict["SoNgayDuyTri"]);
                decimal duDoanCuoiThang = Convert.ToDecimal(rPredict["DuDoanChiCuoiThang"]);

                sb.AppendLine("\n🔮 Dự báo & Lời khuyên:");
                sb.AppendLine($"   • Chi tiêu trung bình mỗi ngày (30 ngày qua): {chiTB:N0} VNĐ/ngày");
                if (soNgay < 999)
                {
                    sb.AppendLine($"   • ⏳ Số ngày dự kiến duy trì được với số dư hiện tại: {soNgay} ngày");
                    if (soNgay < 10)
                    {
                        sb.AppendLine("   🔥 NGUY HIỂM: Bạn có nguy cơ cạn tiền trong dưới 10 ngày nữa!");
                    }
                }
                sb.AppendLine($"   • 📈 Chi tiêu dự kiến đến cuối tháng: {duDoanCuoiThang:N0} VNĐ");
            }

            return sb.ToString();
        }

        public string GetChatbotResponse(string userQuestion, int walletId)
        {
            if (string.IsNullOrWhiteSpace(userQuestion))
                return "🤖 Bạn hãy đặt câu hỏi để tôi hỗ trợ nhé!";

            string q = userQuestion.ToLower().Trim();

            if (q.Contains("phân tích") || q.Contains("tài chính") || q.Contains("sức khỏe") || q.Contains("tình hình"))
            {
                return AnalyzeFinancialHealth(walletId);
            }
            else if (q.Contains("dự đoán") || q.Contains("bao giờ hết tiền") || q.Contains("sống được") || q.Contains("mấy ngày"))
            {
                DataTable dtDuDoan = _dataModel.TruyVan($"EXEC sp_DuDoanChiTieu @WalletID = {walletId};");
                if (dtDuDoan != null && dtDuDoan.Rows.Count > 0)
                {
                    DataRow r = dtDuDoan.Rows[0];
                    decimal tienHienCo = Convert.ToDecimal(r["TienHienCo"]);
                    decimal chiTB = Convert.ToDecimal(r["ChiTrungBinhNgay"]);
                    int soNgay = Convert.ToInt32(r["SoNgayDuyTri"]);

                    if (chiTB == 0)
                        return "🤖 Bạn chưa có khoản chi nào trong 30 ngày qua nên chưa có dữ liệu nguy cơ hết tiền!";

                    string alert = soNgay < 15 ? "⚠️ Nguy cơ thiếu hụt ngân sách!" : "✅ Trạng thái tài chính tạm thời ổn định.";
                    return $"🤖 Với số dư hiện tại ({tienHienCo:N0} VNĐ) và tốc độ tiêu bình quân {chiTB:N0} VNĐ/ngày, dự kiến bạn sẽ duy trì được khoảng {soNgay} ngày nữa. {alert}";
                }
            }
            else if (q.Contains("iphone") || q.Contains("mua") || q.Contains("xe") || q.Contains("đồ đắt"))
            {
                DataTable dtBaoCao = _dataModel.TruyVan($"EXEC sp_BaoCaoChuyenSau @WalletID = {walletId};");
                if (dtBaoCao != null && dtBaoCao.Rows.Count > 0)
                {
                    decimal tienHienCo = Convert.ToDecimal(dtBaoCao.Rows[0]["TienHienCo"]);
                    return $"🤖 Lời khuyên khi muốn mua sắm tài sản lớn:\n" +
                           $"• Số dư hiện tại của bạn là {tienHienCo:N0} VNĐ.\n" +
                           $"• Quy tắc tài chính: Đừng mua món đồ đắt tiền nếu số tiền đó vượt quá 30% quỹ dự phòng của bạn.\n" +
                           $"• Nếu khoản mua này ảnh hưởng đến sinh hoạt 3-6 tháng tới, bạn nên hoãn lại hoặc trả góp hợp lý!";
                }
            }
            else if (q.Contains("tiết kiệm") || q.Contains("mẹo") || q.Contains("lời khuyên"))
            {
                return "🤖 Lời khuyên tiết kiệm tài chính hiệu quả:\n" +
                       "1. Áp dụng quy tắc 50/30/20: 50% Nhu cầu thiết yếu, 30% Sở thích cá nhân, 20% Tiết kiệm / Đầu tư.\n" +
                       "2. Trích ngay 20% thu nhập gửi tiết kiệm/đầu tư ngay khi nhận lương.\n" +
                       "3. Ghi chép thu chi hàng ngày đầy đủ (App này giúp bạn làm điều đó!).\n" +
                       "4. Đánh giá lại các khoản đăng ký hàng tháng (Netflix, Gym, Spotify...) nếu không sử dụng thường xuyên.";
            }
            else if (q.Contains("tiêu nhiều nhất") || q.Contains("danh mục"))
            {
                DataTable dtCat = _dataModel.TruyVan($@"
                    SELECT TOP 1 DanhMuc, SUM(SoTien) AS Tong 
                    FROM ChiTieu 
                    WHERE WalletID = {walletId} 
                    GROUP BY DanhMuc 
                    ORDER BY Tong DESC;");

                if (dtCat != null && dtCat.Rows.Count > 0)
                {
                    string topCat = dtCat.Rows[0]["DanhMuc"].ToString();
                    decimal tong = Convert.ToDecimal(dtCat.Rows[0]["Tong"]);
                    return $"🤖 Danh mục ngốn tiền nhiều nhất của bạn hiện tại là '{topCat}' với tổng số tiền {tong:N0} VNĐ. Bạn nên rà soát lại các khoản chi trong danh mục này!";
                }
            }

            return "🤖 Cảm ơn câu hỏi của bạn! Tôi có thể giúp bạn:\n" +
                   "• Phân tích tình hình thu chi & sức khỏe tài chính\n" +
                   "• Dự đoán số ngày duy trì được tiền\n" +
                   "• Đưa ra lời khuyên mua sắm & tiết kiệm theo quy tắc 50/30/20\n" +
                   "Hãy gõ: 'phân tích', 'dự đoán', 'lời khuyên tiết kiệm' hoặc 'mua đồ' nhé!";
        }
    }
}
