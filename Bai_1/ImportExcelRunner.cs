using System;
using System.Data;
using System.IO;
using Microsoft.Data.SqlClient;

namespace Bai_1
{
    public class ImportExcelRunner
    {
        public static void RunImport()
        {
            string connStr = "Data Source=localhost;Initial Catalog=QL_ChiTieu;Integrated Security=True;TrustServerCertificate=True";

            // 1. Tạo hoặc lấy Tài Khoản Tân (Admin) & Trang
            int idTan = EnsureAccount(connStr, "Tan", "admin", "Tân Admin");
            int idTrang = EnsureAccount(connStr, "Trang", "123456", "Trang");

            // 2. Tạo Ví Chung Gia Đình giữa Tân và Trang
            int sharedWalletId = EnsureSharedWallet(connStr, idTan, idTrang, "Ví Gia Đình Tân & Trang");

            // 3. Tìm file Excel
            string oneDrivePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OneDrive", "Documents", "Tài Chính Cá Nhân.xlsx");
            string docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Tài Chính Cá Nhân.xlsx");

            string excelFile = File.Exists(oneDrivePath) ? oneDrivePath : docPath;
            if (!File.Exists(excelFile))
            {
                Console.WriteLine("File Excel không tồn tại: " + excelFile);
                return;
            }

            Type excelType = Type.GetTypeFromProgID("Excel.Application");
            if (excelType == null)
            {
                Console.WriteLine("Khởi tạo Excel COM thất bại!");
                return;
            }

            dynamic excel = Activator.CreateInstance(excelType);
            excel.Visible = false;

            try
            {
                dynamic wb = excel.Workbooks.Open(excelFile);

                foreach (dynamic sheet in wb.Sheets)
                {
                    string sheetName = sheet.Name;
                    Console.WriteLine($"=== SHEET: {sheetName} ===");

                    dynamic usedRange = sheet.UsedRange;
                    int rows = usedRange.Rows.Count;
                    int cols = usedRange.Columns.Count;

                    for (int r = 1; r <= rows; r++)
                    {
                        string[] vals = new string[cols];
                        for (int c = 1; c <= cols; c++)
                        {
                            vals[c - 1] = Convert.ToString(sheet.Cells.Item(r, c).Text).Trim();
                        }

                        string line = string.Join(" | ", vals);
                        if (!string.IsNullOrWhiteSpace(line.Replace("|", "")))
                        {
                            Console.WriteLine($"R{r}: {line}");
                            InsertDataFromExcelRow(connStr, sharedWalletId, idTan, idTrang, sheetName, vals);
                        }
                    }
                }

                wb.Close(false);
                Console.WriteLine("=== IMPORT EXCEL HOÀN TẤT THÀNH CÔNG ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
            finally
            {
                excel.Quit();
            }
        }

        private static int EnsureAccount(string connStr, string tk, string mk, string ten)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmdCheck = new SqlCommand("SELECT ID FROM Account WHERE TaiKhoan = @TK", conn);
                cmdCheck.Parameters.AddWithValue("@TK", tk);
                object res = cmdCheck.ExecuteScalar();
                if (res != null && res != DBNull.Value)
                {
                    return Convert.ToInt32(res);
                }

                SqlCommand cmdIns = new SqlCommand(@"
                    INSERT INTO Account (TaiKhoan, MatKhau, CauHoiBaoMat, DapAnBaoMat)
                    VALUES (@TK, CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MK), 2), N'Tên thú cưng đầu tiên của bạn là gì?', 'admin');
                    SELECT SCOPE_IDENTITY();", conn);
                cmdIns.Parameters.AddWithValue("@TK", tk);
                cmdIns.Parameters.AddWithValue("@MK", mk);
                return Convert.ToInt32(cmdIns.ExecuteScalar());
            }
        }

        private static int EnsureSharedWallet(string connStr, int idTan, int idTrang, string tenVi)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmdCheck = new SqlCommand(@"
                    SELECT TOP 1 w.ID 
                    FROM Wallet w
                    JOIN WalletMember wm1 ON w.ID = wm1.WalletID AND wm1.AccountID = @Tan
                    JOIN WalletMember wm2 ON w.ID = wm2.WalletID AND wm2.AccountID = @Trang
                    WHERE w.LoaiVi = N'Gia Đình'", conn);
                cmdCheck.Parameters.AddWithValue("@Tan", idTan);
                cmdCheck.Parameters.AddWithValue("@Trang", idTrang);
                object res = cmdCheck.ExecuteScalar();
                if (res != null && res != DBNull.Value)
                {
                    return Convert.ToInt32(res);
                }

                string code = "W" + idTan + idTrang + DateTime.Now.ToString("mmss");
                SqlCommand cmdInsW = new SqlCommand(@"
                    INSERT INTO Wallet (TenVi, LoaiVi, MaChiaSe, TienBanDau)
                    VALUES (@TenVi, N'Gia Đình', @Code, 0);
                    SELECT SCOPE_IDENTITY();", conn);
                cmdInsW.Parameters.AddWithValue("@TenVi", tenVi);
                cmdInsW.Parameters.AddWithValue("@Code", code);
                int walletId = Convert.ToInt32(cmdInsW.ExecuteScalar());

                SqlCommand cmdM1 = new SqlCommand("INSERT INTO WalletMember (WalletID, AccountID, VaiTro) VALUES (@W, @A, N'Chủ Ví')", conn);
                cmdM1.Parameters.AddWithValue("@W", walletId);
                cmdM1.Parameters.AddWithValue("@A", idTan);
                cmdM1.ExecuteNonQuery();

                SqlCommand cmdM2 = new SqlCommand("INSERT INTO WalletMember (WalletID, AccountID, VaiTro) VALUES (@W, @A, N'Thành Viên')", conn);
                cmdM2.Parameters.AddWithValue("@W", walletId);
                cmdM2.Parameters.AddWithValue("@A", idTrang);
                cmdM2.ExecuteNonQuery();

                SqlCommand cmdTien = new SqlCommand("INSERT INTO Tien (TienHienCo, AccountID, WalletID) VALUES (0, @A, @W)", conn);
                cmdTien.Parameters.AddWithValue("@A", idTan);
                cmdTien.Parameters.AddWithValue("@W", walletId);
                cmdTien.ExecuteNonQuery();

                return walletId;
            }
        }

        private static void InsertDataFromExcelRow(string connStr, int walletId, int idTan, int idTrang, string sheetName, string[] vals)
        {
            // Row parsing logic for ChiTieu, ThuNhap, NganSach, DauTu, VayNo
            if (vals.Length < 2) return;

            string col0 = vals[0].Trim();
            string col1 = vals[1].Trim();
            if (string.IsNullOrEmpty(col0) && string.IsNullOrEmpty(col1)) return;

            // Skips header row
            if (col0.Equals("Ngày", StringComparison.OrdinalIgnoreCase) || 
                col0.Equals("Danh Mục", StringComparison.OrdinalIgnoreCase) || 
                col0.Equals("Loại", StringComparison.OrdinalIgnoreCase) ||
                col0.Equals("STT", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 1. Phán đoán loại dữ liệu dựa trên cột
                // Trường hợp Chi Tiêu: Cột 0: Ngày (hoặc Danh Mục), Cột 1: Danh Mục (hoặc Số Tiền), v.v.
                // Thử parse Ngày & Số tiền
                DateTime ngay = DateTime.Now;
                decimal soTien = 0;

                // Parse Ngày từ vals[0] hoặc vals[1]
                bool hasNgay = DateTime.TryParse(vals[0], out ngay) || DateTime.TryParse(vals[1], out ngay);
                
                // Parse Số tiền từ các cột
                for (int i = 0; i < vals.Length; i++)
                {
                    string cleaned = vals[i].Replace("VNĐ", "").Replace("đ", "").Replace(",", "").Replace(".", "").Trim();
                    if (decimal.TryParse(cleaned, out decimal parsedMoney) && parsedMoney > 1000)
                    {
                        soTien = parsedMoney;
                        break;
                    }
                }

                if (soTien <= 0) return;

                // Xác định Người Thực Hiện (Tân hay Trang)
                int accountId = idTan;
                string rowText = string.Join(" ", vals);
                if (rowText.IndexOf("Trang", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    accountId = idTrang;
                }

                // Nếu Sheet tên hoặc nội dung mang ý nghĩa Thu Nhập (Lương, Thưởng)
                if (sheetName.IndexOf("Thu", StringComparison.OrdinalIgnoreCase) >= 0 || rowText.IndexOf("Lương", StringComparison.OrdinalIgnoreCase) >= 0 || rowText.IndexOf("Thưởng", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    SqlCommand cmd = new SqlCommand("EXEC sp_ThuNhap_InsertV2 @Luong = @ST, @Thuong = 0, @Khac = 0, @Ngay = @Ngay, @AccountID = @AID, @WalletID = @WID", conn);
                    cmd.Parameters.AddWithValue("@ST", soTien);
                    cmd.Parameters.AddWithValue("@Ngay", ngay);
                    cmd.Parameters.AddWithValue("@AID", accountId);
                    cmd.Parameters.AddWithValue("@WID", walletId);
                    cmd.ExecuteNonQuery();
                }
                else if (sheetName.IndexOf("Đầu Tư", StringComparison.OrdinalIgnoreCase) >= 0 || rowText.IndexOf("Vàng", StringComparison.OrdinalIgnoreCase) >= 0 || rowText.IndexOf("Cổ Phiếu", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    string tenTaiSan = vals[0].Length > 2 ? vals[0] : (vals.Length > 1 ? vals[1] : "Tài Sản Đầu Tư");
                    SqlCommand cmd = new SqlCommand("EXEC sp_DauTu_Upsert @AccountID = @AID, @WalletID = @WID, @LoaiDauTu = N'Chứng Khoán', @TenTaiSan = @Ten, @SoLuong = 1, @GiaVonBanDau = @ST, @GiaTriHienTai = @ST, @NgayDauTu = @Ngay, @GhiChu = N'Nhập từ Excel'", conn);
                    cmd.Parameters.AddWithValue("@AID", accountId);
                    cmd.Parameters.AddWithValue("@WID", walletId);
                    cmd.Parameters.AddWithValue("@Ten", tenTaiSan);
                    cmd.Parameters.AddWithValue("@ST", soTien);
                    cmd.Parameters.AddWithValue("@Ngay", ngay);
                    cmd.ExecuteNonQuery();
                }
                else if (sheetName.IndexOf("Vay", StringComparison.OrdinalIgnoreCase) >= 0 || rowText.IndexOf("Mượn", StringComparison.OrdinalIgnoreCase) >= 0 || rowText.IndexOf("Nợ", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    string doiTac = vals[0].Length > 2 ? vals[0] : "Đối Tác";
                    SqlCommand cmd = new SqlCommand("EXEC sp_VayNo_Upsert @AccountID = @AID, @WalletID = @WID, @LoaiVayNo = N'Cho Mượn', @DoiTac = @DoiTac, @SoTienGoc = @ST, @LaiSuatThang = 0, @NgayVay = @Ngay, @HanTra = NULL, @GhiChu = N'Nhập từ Excel'", conn);
                    cmd.Parameters.AddWithValue("@AID", accountId);
                    cmd.Parameters.AddWithValue("@WID", walletId);
                    cmd.Parameters.AddWithValue("@DoiTac", doiTac);
                    cmd.Parameters.AddWithValue("@ST", soTien);
                    cmd.Parameters.AddWithValue("@Ngay", ngay);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // Chi tiêu mặc định
                    string danhMuc = "Ăn Uống";
                    if (rowText.IndexOf("Ăn", StringComparison.OrdinalIgnoreCase) >= 0) danhMuc = "Ăn Uống";
                    else if (rowText.IndexOf("Xe", StringComparison.OrdinalIgnoreCase) >= 0 || rowText.IndexOf("Xăng", StringComparison.OrdinalIgnoreCase) >= 0) danhMuc = "Di Chuyển";
                    else if (rowText.IndexOf("Điện", StringComparison.OrdinalIgnoreCase) >= 0 || rowText.IndexOf("Nước", StringComparison.OrdinalIgnoreCase) >= 0) danhMuc = "Hóa Đơn & Tiện Ích";
                    else if (rowText.IndexOf("Giải trí", StringComparison.OrdinalIgnoreCase) >= 0 || rowText.IndexOf("Phim", StringComparison.OrdinalIgnoreCase) >= 0) danhMuc = "Giải Trí";
                    else if (rowText.IndexOf("Mua", StringComparison.OrdinalIgnoreCase) >= 0 || rowText.IndexOf("Áo", StringComparison.OrdinalIgnoreCase) >= 0) danhMuc = "Mua Sắm";

                    string moTa = rowText.Length > 100 ? rowText.Substring(0, 100) : rowText;

                    SqlCommand cmd = new SqlCommand("EXEC sp_ChiTieu_InsertV2 @DanhMuc = @DM, @SoTien = @ST, @NoiDung = @MoTa, @Ngay = @Ngay, @AccountID = @AID, @WalletID = @WID", conn);
                    cmd.Parameters.AddWithValue("@DM", danhMuc);
                    cmd.Parameters.AddWithValue("@ST", soTien);
                    cmd.Parameters.AddWithValue("@MoTa", moTa);
                    cmd.Parameters.AddWithValue("@Ngay", ngay);
                    cmd.Parameters.AddWithValue("@AID", accountId);
                    cmd.Parameters.AddWithValue("@WID", walletId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
