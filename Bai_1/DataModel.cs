using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    internal class DataModel
    {
        public SqlConnection TaoKetNoi()
        {
            return new SqlConnection("Data Source=localhost;Initial Catalog=QL_ChiTieu;Integrated Security=True;TrustServerCertificate=True");
        }
        public DataTable TruyVan(string sql)
        {
            SqlConnection con = TaoKetNoi();
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public void ExecuteNonQuery(string sql)
        {
            SqlConnection con = TaoKetNoi();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            cmd.Dispose();
        }
        public int CheckLogin(string tk, string mk)
        {
            using (SqlConnection conn = TaoKetNoi())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_Account_Check", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TaiKhoan", tk);
                cmd.Parameters.AddWithValue("@MatKhau", mk);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return Convert.ToInt32(dr["ID"]);
                }

                return -1;
            }
        }

        public string GetUsername(string tk, string mk)
        {
            using (SqlConnection conn = TaoKetNoi())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_Account_Check", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TaiKhoan", tk);
                cmd.Parameters.AddWithValue("@MatKhau", mk);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return dr["TaiKhoan"].ToString();
                }

                return null;
            }
        }

        public bool Register(string tk, string mk)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Account_Them", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaiKhoan", tk);
                    cmd.Parameters.AddWithValue("@MatKhau", mk);
                    cmd.ExecuteNonQuery();
                }

                int newAccId = CheckLogin(tk, mk);
                if (newAccId != -1)
                {
                    EnsureUserDefaultWallet(newAccId);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public void EnsureUserDefaultWallet(int accountId)
        {
            try
            {
                DataTable dtWallets = GetWalletsByAccount(accountId);
                if (dtWallets != null && dtWallets.Rows.Count > 0)
                {
                    DataRow row = dtWallets.Rows[0];
                    SaveIdUser.CurrentWalletID = Convert.ToInt32(row["WalletID"]);
                    SaveIdUser.CurrentWalletName = row["TenVi"].ToString() ?? "Ví";
                    SaveIdUser.CurrentWalletRole = row["VaiTro"].ToString() ?? "Chủ Ví";
                    SaveIdUser.CurrentWalletCode = row["MaChiaSe"].ToString() ?? "";
                }
                else
                {
                    // Call stored procedure to create default wallet
                    using (SqlConnection conn = TaoKetNoi())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_Wallet_Create", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountID", accountId);
                        cmd.Parameters.AddWithValue("@TenVi", "Ví Cá Nhân");
                        cmd.Parameters.AddWithValue("@LoaiVi", "Cá Nhân");
                        cmd.Parameters.AddWithValue("@TienBanDau", 0);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                SaveIdUser.CurrentWalletID = Convert.ToInt32(dr["WalletID"]);
                                SaveIdUser.CurrentWalletCode = dr["MaChiaSe"].ToString() ?? "";
                                SaveIdUser.CurrentWalletName = "Ví Cá Nhân";
                                SaveIdUser.CurrentWalletRole = "Chủ Ví";
                            }
                        }
                    }
                }
            }
            catch
            {
                // Fallback if DB upgrade procedure is not yet run
                SaveIdUser.CurrentWalletID = accountId;
            }
        }

        public DataTable GetWalletsByAccount(int accountId)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Wallet_GetByUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountID", accountId);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                return new DataTable();
            }
        }

        public bool CreateWallet(int accountId, string tenVi, string loaiVi, decimal tienBanDau, out string maChiaSe, out int newWalletId)
        {
            maChiaSe = "";
            newWalletId = -1;
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Wallet_Create", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountID", accountId);
                    cmd.Parameters.AddWithValue("@TenVi", tenVi);
                    cmd.Parameters.AddWithValue("@LoaiVi", loaiVi);
                    cmd.Parameters.AddWithValue("@TienBanDau", tienBanDau);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            newWalletId = Convert.ToInt32(dr["WalletID"]);
                            maChiaSe = dr["MaChiaSe"].ToString() ?? "";
                            return true;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool JoinWalletByCode(int accountId, string maChiaSe, out string tenVi, out int joinedWalletId)
        {
            tenVi = "";
            joinedWalletId = -1;
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Wallet_JoinByCode", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountID", accountId);
                    cmd.Parameters.AddWithValue("@MaChiaSe", maChiaSe);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            joinedWalletId = Convert.ToInt32(dr["WalletID"]);
                            tenVi = dr["TenVi"].ToString() ?? "";
                            return true;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        public bool SetInitialBalance(int walletId, decimal tienBanDau)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Tien_SetInitialBalance", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WalletID", walletId);
                    cmd.Parameters.AddWithValue("@TienBanDau", tienBanDau);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public SaveDLReport GetBaoCaoTongQuat(int accountId)
        {
            SaveDLReport report = new SaveDLReport();
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_BaoCaoTongQuat", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AccountID", accountId);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                report.TongThu = reader.IsDBNull(reader.GetOrdinal("TongThu")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TongThu"));
                                report.ThuTrungBinh = reader.IsDBNull(reader.GetOrdinal("ThuTrungBinh")) ? 0 : reader.GetDecimal(reader.GetOrdinal("ThuTrungBinh"));
                                report.ThuNhieuNhat = reader.IsDBNull(reader.GetOrdinal("ThuNhieuNhat")) ? 0 : reader.GetDecimal(reader.GetOrdinal("ThuNhieuNhat"));
                                report.ThuItNhat = reader.IsDBNull(reader.GetOrdinal("ThuItNhat")) ? 0 : reader.GetDecimal(reader.GetOrdinal("ThuItNhat"));

                                report.TongChi = reader.IsDBNull(reader.GetOrdinal("TongChi")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TongChi"));
                                report.ChiTrungBinh = reader.IsDBNull(reader.GetOrdinal("ChiTrungBinh")) ? 0 : reader.GetDecimal(reader.GetOrdinal("ChiTrungBinh"));
                                report.ChiNhieuNhat = reader.IsDBNull(reader.GetOrdinal("ChiNhieuNhat")) ? 0 : reader.GetDecimal(reader.GetOrdinal("ChiNhieuNhat"));
                                report.ChiItNhat = reader.IsDBNull(reader.GetOrdinal("ChiItNhat")) ? 0 : reader.GetDecimal(reader.GetOrdinal("ChiItNhat"));

                                report.TienHienCo = reader.IsDBNull(reader.GetOrdinal("TienHienCo")) ? 0 : reader.GetDecimal(reader.GetOrdinal("TienHienCo"));
                            }
                        }
                    }
                }
            }
            catch
            {
                // Fallback default values
            }
            return report;
        }

        public string GetSecurityQuestion(string tk)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Account_GetCauHoiBaoMat", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaiKhoan", tk);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return dr["CauHoiBaoMat"].ToString() ?? "Tên thú cưng đầu tiên của bạn là gì?";
                        }
                    }
                }
            }
            catch
            {
            }
            return "Tên thú cưng đầu tiên của bạn là gì?";
        }

        public bool ResetPassword(string tk, string answer, string newPassword, out string message)
        {
            message = "";
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Account_DatLaiMatKhau", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TaiKhoan", tk);
                    cmd.Parameters.AddWithValue("@DapAnBaoMat", answer);
                    cmd.Parameters.AddWithValue("@MatKhauMoi", newPassword);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int res = Convert.ToInt32(dr["Result"]);
                            message = dr["Message"].ToString() ?? "";
                            return res == 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return false;
        }

        public bool UpsertBudget(int walletId, string danhMuc, decimal gioiHan, int thang, int nam)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_NganSach_Upsert", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WalletID", walletId);
                    cmd.Parameters.AddWithValue("@DanhMuc", danhMuc);
                    cmd.Parameters.AddWithValue("@SoTienGioiHan", gioiHan);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetBudgets(int walletId, int thang, int nam)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_NganSach_GetByWallet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WalletID", walletId);
                    cmd.Parameters.AddWithValue("@Thang", thang);
                    cmd.Parameters.AddWithValue("@Nam", nam);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                return new DataTable();
            }
        }

        public void ExportToCsv(DataTable dt, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => $"\"{column.ColumnName.Replace("\"", "\"\"")}\"");
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => $"\"{field?.ToString()?.Replace("\"", "\"\"")}\"");
                sb.AppendLine(string.Join(",", fields));
            }

            System.IO.File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

        public bool CheckBudgetWarning(int walletId, string danhMuc, out int warningLevel, out string warningMsg)
        {
            warningLevel = 0;
            warningMsg = "";
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_NganSach_KiemTraCanhBao", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WalletID", walletId);
                    cmd.Parameters.AddWithValue("@DanhMuc", danhMuc);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            warningLevel = Convert.ToInt32(dr["LevelCanhBao"]);
                            warningMsg = dr["ThongBao"].ToString() ?? "";
                            return warningLevel > 0;
                        }
                    }
                }
            }
            catch
            {
            }
            return false;
        }

        public bool SaveVayNo(int accountId, int walletId, string loaiVayNo, string doiTac, decimal soTienGoc, decimal laiSuat, DateTime ngayVay, DateTime? hanTra, string ghiChu)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_VayNo_Upsert", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountID", accountId);
                    cmd.Parameters.AddWithValue("@WalletID", walletId);
                    cmd.Parameters.AddWithValue("@LoaiVayNo", loaiVayNo);
                    cmd.Parameters.AddWithValue("@DoiTac", doiTac);
                    cmd.Parameters.AddWithValue("@SoTienGoc", soTienGoc);
                    cmd.Parameters.AddWithValue("@LaiSuatThang", laiSuat);
                    cmd.Parameters.AddWithValue("@NgayVay", ngayVay);
                    cmd.Parameters.AddWithValue("@HanTra", (object?)hanTra ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GhiChu", (object?)ghiChu ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetVayNoList(int walletId)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_VayNo_GetByWallet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WalletID", walletId);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                return new DataTable();
            }
        }

        public bool ThanhToanVayNo(int id, decimal soTien)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_VayNo_ThanhToan", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@SoTienThanhToan", soTien);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool SaveDauTu(int accountId, int walletId, string loaiDauTu, string tenTaiSan, decimal soLuong, decimal giaVon, decimal giaTriHienTai, DateTime ngayDauTu, string ghiChu)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DauTu_Upsert", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountID", accountId);
                    cmd.Parameters.AddWithValue("@WalletID", walletId);
                    cmd.Parameters.AddWithValue("@LoaiDauTu", loaiDauTu);
                    cmd.Parameters.AddWithValue("@TenTaiSan", tenTaiSan);
                    cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmd.Parameters.AddWithValue("@GiaVonBanDau", giaVon);
                    cmd.Parameters.AddWithValue("@GiaTriHienTai", giaTriHienTai);
                    cmd.Parameters.AddWithValue("@NgayDauTu", ngayDauTu);
                    cmd.Parameters.AddWithValue("@GhiChu", (object?)ghiChu ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetDauTuList(int walletId)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_DauTu_GetByWallet", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WalletID", walletId);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable GetAnalyticsCategoryBreakdown(int walletId)
        {
            return TruyVan($"EXEC sp_PhanTich_DanhMucTyTrong @WalletID = {walletId};");
        }

        public DataTable GetAnalyticsIncomeVsExpense(int walletId)
        {
            return TruyVan($"EXEC sp_PhanTich_ThuVsChiThang @WalletID = {walletId};");
        }

        public DataTable GetAnalyticsBurnRate(int walletId)
        {
            return TruyVan($"EXEC sp_PhanTich_BurnRate @WalletID = {walletId};");
        }

        public DataTable GetAnalyticsBudgetUsage(int walletId)
        {
            return TruyVan($"EXEC sp_PhanTich_NganSachUtilization @WalletID = {walletId};");
        }

        public DataTable GetAnalytics503020Rule(int walletId)
        {
            return TruyVan($"EXEC sp_PhanTich_QuyTac503020 @WalletID = {walletId};");
        }

        public DataTable GetAnalyticsInvestmentROI(int walletId)
        {
            return TruyVan($"EXEC sp_PhanTich_DauTuROI @WalletID = {walletId};");
        }

        public bool PerformChotSo(int walletId, int accountId, decimal tienThucTe, string ghiChu, out decimal tienHeThong, out decimal chenhLech, out string thongBao)
        {
            tienHeThong = 0;
            chenhLech = 0;
            thongBao = "";
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_ChotSo_Perform", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WalletID", walletId);
                    cmd.Parameters.AddWithValue("@AccountID", accountId);
                    cmd.Parameters.AddWithValue("@TienThucTe", tienThucTe);
                    cmd.Parameters.AddWithValue("@GhiChu", (object?)ghiChu ?? DBNull.Value);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            tienHeThong = Convert.ToDecimal(dr["TienHeThong"]);
                            tienThucTe = Convert.ToDecimal(dr["TienThucTe"]);
                            chenhLech = Convert.ToDecimal(dr["ChenhLech"]);
                            thongBao = dr["ThongBao"].ToString() ?? "";
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                thongBao = ex.Message;
            }
            return false;
        }

        public DataTable GetLichSuChotSo(int walletId)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_ChotSo_GetHistory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WalletID", walletId);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable GetBaoCaoDashboard(int walletId, int? thang, int? nam)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_BaoCaoChuyenSauV2", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WalletID", walletId);
                    cmd.Parameters.AddWithValue("@Thang", (object?)thang ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nam", (object?)nam ?? DBNull.Value);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable GetVisualCategoryChartFiltered(int walletId, int? thang, int? nam)
        {
            try
            {
                using (SqlConnection conn = TaoKetNoi())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_PhanTich_DanhMucTyTrongFilter", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WalletID", walletId);
                    cmd.Parameters.AddWithValue("@Thang", (object?)thang ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Nam", (object?)nam ?? DBNull.Value);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    return dt;
                }
            }
            catch
            {
                return new DataTable();
            }
        }
    }
}

