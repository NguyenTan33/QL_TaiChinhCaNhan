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

        public SaveDLReport GetBaoCaoTongQuat(int accountId)
        {
            SaveDLReport report = null;

            using (SqlConnection conn = TaoKetNoi())
            {
                using (SqlCommand cmd = new SqlCommand("sp_BaoCaoTongQuat", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Truyền tham số AccountID
                    cmd.Parameters.AddWithValue("@AccountID", accountId);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Khởi tạo đối tượng và điền dữ liệu
                            report = new SaveDLReport
                            {
                                // Đọc giá trị từ DataReader và chuyển đổi sang Decimal
                                // Dùng GetDecimal để đảm bảo kiểu dữ liệu chính xác
                                TongThu = reader.GetDecimal(reader.GetOrdinal("TongThu")),
                                ThuTrungBinh = reader.GetDecimal(reader.GetOrdinal("ThuTrungBinh")),
                                ThuNhieuNhat = reader.GetDecimal(reader.GetOrdinal("ThuNhieuNhat")),
                                ThuItNhat = reader.GetDecimal(reader.GetOrdinal("ThuItNhat")),

                                TongChi = reader.GetDecimal(reader.GetOrdinal("TongChi")),
                                ChiTrungBinh = reader.GetDecimal(reader.GetOrdinal("ChiTrungBinh")),
                                ChiNhieuNhat = reader.GetDecimal(reader.GetOrdinal("ChiNhieuNhat")),
                                ChiItNhat = reader.GetDecimal(reader.GetOrdinal("ChiItNhat")),

                                TienHienCo = reader.GetDecimal(reader.GetOrdinal("TienHienCo"))
                            };
                        }
                    }
                }
            }
            return report;
        }

    }
}

