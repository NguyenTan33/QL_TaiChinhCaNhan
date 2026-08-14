using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    internal static class SaveIdUser
    {
        public static int AccountID { get; set; }
        public static string AccountUserName { get; set; } = string.Empty;
        public static int CurrentWalletID { get; set; }
        public static string CurrentWalletName { get; set; } = string.Empty;
        public static string CurrentWalletRole { get; set; } = string.Empty;
        public static string CurrentWalletCode { get; set; } = string.Empty;
    }
}
