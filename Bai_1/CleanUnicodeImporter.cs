using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;

namespace Bai_1
{
    public class CleanUnicodeImporter
    {
        public static void RunReimport()
        {
            string connStr = "Data Source=localhost;Initial Catalog=QL_ChiTieu;Integrated Security=True;TrustServerCertificate=True";

            // 1. Xóa toàn bộ dữ liệu chi tiêu / thu nhập cũ để nạp lại chuẩn 100% từ Excel
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                new SqlCommand("DELETE FROM ChiTieu;", conn).ExecuteNonQuery();
                new SqlCommand("DELETE FROM ThuNhap;", conn).ExecuteNonQuery();
                new SqlCommand("UPDATE Tien SET TienHienCo = 0;", conn).ExecuteNonQuery();
            }

            // 2. Tìm file Excel
            string oneDrivePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OneDrive", "Documents", "Tài Chính Cá Nhân.xlsx");
            string docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Tài Chính Cá Nhân.xlsx");
            string excelFile = File.Exists(oneDrivePath) ? oneDrivePath : docPath;

            if (!File.Exists(excelFile))
            {
                Console.WriteLine("Không tìm thấy file Excel: " + excelFile);
                return;
            }

            Console.WriteLine("Đang trích xuất dữ liệu từ các sheet 'Tân' và 'Trang'...");

            // 3. Đảm bảo Tài Khoản Admin & Trang
            int idAdmin = EnsureAccount(connStr, "Admin", "Tanheo123@@");
            int idTrang = EnsureAccount(connStr, "Trang", "Changchang123@@");

            int walletAdminPersonal = EnsurePersonalWallet(connStr, idAdmin, "Ví Cá Nhân Admin");
            int walletTrangPersonal = EnsurePersonalWallet(connStr, idTrang, "Ví Cá Nhân Trang");
            int walletShared = EnsureSharedWallet(connStr, idAdmin, idTrang, "Ví Gia Đình Tân & Trang");

            // 4. Trích xuất chuẩn xác Sheet 'Tân' và Sheet 'Trang'
            List<ExcelRow> tanRows = ParseSheetByName(excelFile, "Tân");
            List<ExcelRow> trangRows = ParseSheetByName(excelFile, "Trang");

            Console.WriteLine($"Trích xuất Sheet 'Tân': {tanRows.Count} giao dịch cho Admin.");
            Console.WriteLine($"Trích xuất Sheet 'Trang': {trangRows.Count} giao dịch cho Trang.");

            int countAdmin = 0;
            int countTrang = 0;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Nạp giao dịch của Tân (Admin)
                foreach (var r in tanRows)
                {
                    if (r.Loai.Equals("Chi", StringComparison.OrdinalIgnoreCase))
                    {
                        InsertChiTieu(conn, r.DanhMuc, r.SoTien, r.NoiDung, r.Ngay, idAdmin, walletShared);
                        InsertChiTieu(conn, r.DanhMuc, r.SoTien, r.NoiDung, r.Ngay, idAdmin, walletAdminPersonal);
                    }
                    else
                    {
                        InsertThuNhap(conn, r.SoTien, r.Ngay, idAdmin, walletShared);
                        InsertThuNhap(conn, r.SoTien, r.Ngay, idAdmin, walletAdminPersonal);
                    }
                    countAdmin++;
                }

                // Nạp giao dịch của Trang
                foreach (var r in trangRows)
                {
                    if (r.Loai.Equals("Chi", StringComparison.OrdinalIgnoreCase))
                    {
                        InsertChiTieu(conn, r.DanhMuc, r.SoTien, r.NoiDung, r.Ngay, idTrang, walletShared);
                        InsertChiTieu(conn, r.DanhMuc, r.SoTien, r.NoiDung, r.Ngay, idTrang, walletTrangPersonal);
                    }
                    else
                    {
                        InsertThuNhap(conn, r.SoTien, r.Ngay, idTrang, walletShared);
                        InsertThuNhap(conn, r.SoTien, r.Ngay, idTrang, walletTrangPersonal);
                    }
                    countTrang++;
                }
            }

            // 5. Cập nhật số dư cuối cùng cho các ví
            UpdateWalletBalance(connStr, walletAdminPersonal);
            UpdateWalletBalance(connStr, walletTrangPersonal);
            UpdateWalletBalance(connStr, walletShared);

            Console.WriteLine($"=== NẠP THÀNH CÔNG: Admin ({countAdmin} GD) | Trang ({countTrang} GD) | Ví Gia Đình ({countAdmin + countTrang} GD) ===");
        }

        private static void InsertChiTieu(SqlConnection conn, string danhMuc, decimal soTien, string noiDung, DateTime ngay, int accId, int walletId)
        {
            using (SqlCommand cmd = new SqlCommand("sp_ChiTieu_InsertV2", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DanhMuc", danhMuc);
                cmd.Parameters.AddWithValue("@SoTien", soTien);
                cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                cmd.Parameters.AddWithValue("@Ngay", ngay);
                cmd.Parameters.AddWithValue("@AccountID", accId);
                cmd.Parameters.AddWithValue("@WalletID", walletId);
                cmd.ExecuteNonQuery();
            }
        }

        private static void InsertThuNhap(SqlConnection conn, decimal soTien, DateTime ngay, int accId, int walletId)
        {
            using (SqlCommand cmd = new SqlCommand("sp_ThuNhap_InsertV2", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Luong", soTien);
                cmd.Parameters.AddWithValue("@Thuong", 0);
                cmd.Parameters.AddWithValue("@Khac", 0);
                cmd.Parameters.AddWithValue("@Ngay", ngay);
                cmd.Parameters.AddWithValue("@AccountID", accId);
                cmd.Parameters.AddWithValue("@WalletID", walletId);
                cmd.ExecuteNonQuery();
            }
        }

        private static void UpdateWalletBalance(string connStr, int walletId)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    DECLARE @TongThu DECIMAL(18,2) = ISNULL((SELECT SUM(Luong + Thuong + Khac) FROM ThuNhap WHERE WalletID = @W), 0);
                    DECLARE @TongChi DECIMAL(18,2) = ISNULL((SELECT SUM(SoTien) FROM ChiTieu WHERE WalletID = @W), 0);
                    DECLARE @TienBanDau DECIMAL(18,2) = ISNULL((SELECT TienBanDau FROM Wallet WHERE ID = @W), 0);
                    UPDATE Tien SET TienHienCo = @TienBanDau + @TongThu - @TongChi WHERE WalletID = @W;";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@W", walletId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static int EnsureAccount(string connStr, string tk, string mk)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmdCheck = new SqlCommand("SELECT ID FROM Account WHERE TaiKhoan = @TK", conn);
                cmdCheck.Parameters.AddWithValue("@TK", tk);
                object res = cmdCheck.ExecuteScalar();
                if (res != null && res != DBNull.Value)
                {
                    int id = Convert.ToInt32(res);
                    SqlCommand cmdUpdatePass = new SqlCommand("UPDATE Account SET MatKhau = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @MK), 2) WHERE ID = @ID", conn);
                    cmdUpdatePass.Parameters.AddWithValue("@MK", mk);
                    cmdUpdatePass.Parameters.AddWithValue("@ID", id);
                    cmdUpdatePass.ExecuteNonQuery();
                    return id;
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

        private static int EnsurePersonalWallet(string connStr, int accId, string tenVi)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmdCheck = new SqlCommand("SELECT TOP 1 w.ID FROM Wallet w JOIN WalletMember wm ON w.ID = wm.WalletID WHERE wm.AccountID = @A AND w.LoaiVi = N'Cá Nhân'", conn);
                cmdCheck.Parameters.AddWithValue("@A", accId);
                object res = cmdCheck.ExecuteScalar();
                if (res != null && res != DBNull.Value) return Convert.ToInt32(res);

                SqlCommand cmdIns = new SqlCommand("INSERT INTO Wallet (TenVi, LoaiVi, MaChiaSe, TienBanDau) VALUES (@T, N'Cá Nhân', @C, 0); SELECT SCOPE_IDENTITY();", conn);
                cmdIns.Parameters.AddWithValue("@T", tenVi);
                cmdIns.Parameters.AddWithValue("@C", "W" + accId + DateTime.Now.ToString("mmss"));
                int wId = Convert.ToInt32(cmdIns.ExecuteScalar());

                SqlCommand cmdWm = new SqlCommand("INSERT INTO WalletMember (WalletID, AccountID, VaiTro) VALUES (@W, @A, N'Chủ Ví')", conn);
                cmdWm.Parameters.AddWithValue("@W", wId);
                cmdWm.Parameters.AddWithValue("@A", accId);
                cmdWm.ExecuteNonQuery();

                SqlCommand cmdTien = new SqlCommand("INSERT INTO Tien (TienHienCo, AccountID, WalletID) VALUES (0, @A, @W)", conn);
                cmdTien.Parameters.AddWithValue("@A", accId);
                cmdTien.Parameters.AddWithValue("@W", wId);
                cmdTien.ExecuteNonQuery();

                return wId;
            }
        }

        private static int EnsureSharedWallet(string connStr, int idAdmin, int idTrang, string tenVi)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmdCheck = new SqlCommand(@"
                    SELECT TOP 1 w.ID FROM Wallet w 
                    JOIN WalletMember wm1 ON w.ID = wm1.WalletID AND wm1.AccountID = @A1 
                    JOIN WalletMember wm2 ON w.ID = wm2.WalletID AND wm2.AccountID = @A2 
                    WHERE w.LoaiVi = N'Gia Đình'", conn);
                cmdCheck.Parameters.AddWithValue("@A1", idAdmin);
                cmdCheck.Parameters.AddWithValue("@A2", idTrang);
                object res = cmdCheck.ExecuteScalar();
                if (res != null && res != DBNull.Value) return Convert.ToInt32(res);

                SqlCommand cmdIns = new SqlCommand("INSERT INTO Wallet (TenVi, LoaiVi, MaChiaSe, TienBanDau) VALUES (@T, N'Gia Đình', @C, 0); SELECT SCOPE_IDENTITY();", conn);
                cmdIns.Parameters.AddWithValue("@T", tenVi);
                cmdIns.Parameters.AddWithValue("@C", "W" + idAdmin + idTrang + DateTime.Now.ToString("mmss"));
                int wId = Convert.ToInt32(cmdIns.ExecuteScalar());

                SqlCommand cmdM1 = new SqlCommand("INSERT INTO WalletMember (WalletID, AccountID, VaiTro) VALUES (@W, @A, N'Chủ Ví')", conn);
                cmdM1.Parameters.AddWithValue("@W", wId);
                cmdM1.Parameters.AddWithValue("@A", idAdmin);
                cmdM1.ExecuteNonQuery();

                SqlCommand cmdM2 = new SqlCommand("INSERT INTO WalletMember (WalletID, AccountID, VaiTro) VALUES (@W, @A, N'Thành Viên')", conn);
                cmdM2.Parameters.AddWithValue("@W", wId);
                cmdM2.Parameters.AddWithValue("@A", idTrang);
                cmdM2.ExecuteNonQuery();

                SqlCommand cmdTien = new SqlCommand("INSERT INTO Tien (TienHienCo, AccountID, WalletID) VALUES (0, @A, @W)", conn);
                cmdTien.Parameters.AddWithValue("@A", idAdmin);
                cmdTien.Parameters.AddWithValue("@W", wId);
                cmdTien.ExecuteNonQuery();

                return wId;
            }
        }

        private static List<ExcelRow> ParseSheetByName(string filePath, string targetSheetName)
        {
            List<ExcelRow> list = new List<ExcelRow>();
            List<string> sharedStrings = new List<string>();

            using (ZipArchive archive = ZipFile.OpenRead(filePath))
            {
                // 1. Shared Strings
                ZipArchiveEntry ssEntry = archive.GetEntry("xl/sharedStrings.xml");
                if (ssEntry != null)
                {
                    using (Stream s = ssEntry.Open())
                    {
                        XDocument xdoc = XDocument.Load(s);
                        XNamespace ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
                        foreach (var si in xdoc.Descendants(ns + "si"))
                        {
                            string str = string.Join("", si.Descendants(ns + "t").Select(t => t.Value));
                            sharedStrings.Add(str);
                        }
                    }
                }

                // 2. Tìm ID của Sheet theo Tên
                string sheetFileName = "";
                ZipArchiveEntry wbEntry = archive.GetEntry("xl/workbook.xml");
                if (wbEntry != null)
                {
                    using (Stream s = wbEntry.Open())
                    {
                        XDocument xdoc = XDocument.Load(s);
                        XNamespace ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
                        int idx = 1;
                        foreach (var sheet in xdoc.Descendants(ns + "sheet"))
                        {
                            string name = (string)sheet.Attribute("name") ?? "";
                            if (name.Equals(targetSheetName, StringComparison.OrdinalIgnoreCase))
                            {
                                sheetFileName = $"xl/worksheets/sheet{idx}.xml";
                                break;
                            }
                            idx++;
                        }
                    }
                }

                if (string.IsNullOrEmpty(sheetFileName)) return list;

                ZipArchiveEntry sheetEntry = archive.GetEntry(sheetFileName);
                if (sheetEntry == null) return list;

                using (Stream s = sheetEntry.Open())
                {
                    XDocument xdoc = XDocument.Load(s);
                    XNamespace ns = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";

                    foreach (var row in xdoc.Descendants(ns + "row"))
                    {
                        List<string> vals = new List<string>();
                        foreach (var cell in row.Elements(ns + "c"))
                        {
                            string t = (string)cell.Attribute("t") ?? "";
                            string v = cell.Element(ns + "v")?.Value ?? "";

                            if (t == "s" && int.TryParse(v, out int sIdx) && sIdx < sharedStrings.Count)
                            {
                                v = sharedStrings[sIdx];
                            }
                            vals.Add(v.Trim());
                        }

                        if (vals.Count >= 5)
                        {
                            string loai = vals.Count > 1 ? vals[1] : "";
                            if (loai == "Chi" || loai == "Thu")
                            {
                                string dmRaw = vals.Count > 2 ? vals[2] : "";
                                string ndRaw = vals.Count > 3 ? vals[3] : "";
                                string stRaw = vals.Count > 4 ? vals[4] : "0";
                                string dStr = vals.Count > 5 ? vals[5] : "1";
                                string mStr = vals.Count > 6 ? vals[6] : "1";
                                string yStr = vals.Count > 7 ? vals[7] : "2026";

                                string cleanMoney = Regex.Replace(stRaw, @"[^\d.]", "");
                                if (decimal.TryParse(cleanMoney, out decimal st) && st > 0)
                                {
                                    int day = int.TryParse(dStr, out int d) ? d : 1;
                                    int month = int.TryParse(mStr, out int m) ? m : 8;
                                    int year = int.TryParse(yStr, out int y) ? y : 2026;
                                    if (year > 2030) year = 2026;
                                    if (month < 1 || month > 12) month = 8;
                                    if (day < 1 || day > 31) day = 15;

                                    DateTime dtDate;
                                    try { dtDate = new DateTime(year, month, day); }
                                    catch { dtDate = new DateTime(2026, 8, 1); }

                                    string mappedCategory = MapCategory(dmRaw, loai);

                                    list.Add(new ExcelRow
                                    {
                                        Loai = loai,
                                        DanhMuc = mappedCategory,
                                        NoiDung = string.IsNullOrWhiteSpace(ndRaw) ? mappedCategory : ndRaw,
                                        SoTien = st,
                                        Ngay = dtDate
                                    });
                                }
                            }
                        }
                    }
                }
            }
            return list;
        }

        private static string MapCategory(string dmRaw, string loai)
        {
            if (loai == "Thu") return "Lương";

            string lower = dmRaw.ToLower();
            if (lower.Contains("ăn") || lower.Contains("uống") || lower.Contains("nấu")) return "Ăn Uống";
            if (lower.Contains("đi") || lower.Contains("xăng") || lower.Contains("gửi xe") || lower.Contains("xe")) return "Di Chuyển";
            if (lower.Contains("hóa đơn") || lower.Contains("card") || lower.Contains("phí") || lower.Contains("điện") || lower.Contains("nước")) return "Hóa Đơn & Tiện Ích";
            if (lower.Contains("giải trí") || lower.Contains("café") || lower.Contains("nhậu") || lower.Contains("thuốc")) return "Giải Trí";
            if (lower.Contains("mua") || lower.Contains("bhx")) return "Mua Sắm";
            if (lower.Contains("gia đình") || lower.Contains("con") || lower.Contains("mẹ")) return "Gia Đình";
            if (lower.Contains("học") || lower.Contains("giáo dục")) return "Giáo Dục";
            if (lower.Contains("y tế") || lower.Contains("thuốc tây")) return "Y Tế & Sức Khỏe";

            return !string.IsNullOrWhiteSpace(dmRaw) ? dmRaw : "Khác (Chi)";
        }
    }

    public class ExcelRow
    {
        public string Loai { get; set; } = "Chi";
        public string DanhMuc { get; set; } = "Ăn Uống";
        public string NoiDung { get; set; } = "";
        public decimal SoTien { get; set; }
        public DateTime Ngay { get; set; }
    }
}
