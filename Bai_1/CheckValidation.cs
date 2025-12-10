using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    internal class CheckValidation
    {
        public static bool TaiKhoan(string TK)
        {
            if (string.IsNullOrEmpty(TK) || TK == "" || TK.Length >= 244 || TK.Length <= 4)
            {
                MessageBox.Show("Tài Khoản Không Hợp Lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else 
            { 
                return true;
            }
        }
        public static bool MatKhau(string MK)
        {
            if (string.IsNullOrEmpty(MK) || MK == "" || MK.Length >= 244 || MK.Length <= 6)
            {
                MessageBox.Show("Mật Khẩu Không Hợp Lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else 
            { 
                return true;
            }
        }
        public static bool SameMK(string MKmoi , string MKmoi2)
        {
            bool result = string.Equals(MKmoi, MKmoi2);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DoiMK(string MKmoi)
        {
            string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,12}$";

            return System.Text.RegularExpressions.Regex.IsMatch(MKmoi, pattern);

        }


    }
}
