using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class Chi_Tieu : Form
    {
        DataModel dt = new DataModel();
        public void Reload()
        {
            dt.EnsureUserDefaultWallet(SaveIdUser.AccountID);
            string sql = SaveIdUser.CurrentWalletID > 0
                ? $"EXEC sp_ChiTieu_SelectByWallet @WalletID = {SaveIdUser.CurrentWalletID};"
                : $"EXEC sp_ChiTieu_Xem @AccountID = {SaveIdUser.AccountID};";
            ResultStyle.ApplyStyle(Result);
            Result.DataSource = dt.TruyVan(sql);
        }
        public Chi_Tieu()
        {
            InitializeComponent();
            listDanhMuc.Text = "Ăn Uống";
            Reload();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page TrangChu = new Home_Page();
            TrangChu.ShowDialog();
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtSoTien.Text, out double SoTien) || SoTien <= 0)
            {
                MessageBox.Show("Số tiền phải là số hợp lệ > 0!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string DanhMuc = listDanhMuc.SelectedItem?.ToString() ?? "Ăn Uống";
            string MoTa = txtMoTa.Text;
            string Ngay = NgayThang.Value.ToString("yyyy-MM-dd");

            string sql = $@"EXEC sp_ChiTieu_InsertV2 
                                @DanhMuc = N'{DanhMuc}',
                                @SoTien = {SoTien},
                                @NoiDung = N'{MoTa}',
                                @Ngay = '{Ngay}',
                                @AccountID = {SaveIdUser.AccountID},
                                @WalletID = {SaveIdUser.CurrentWalletID};
                            ";
            dt.ExecuteNonQuery(sql);
            Reload();

            // Tự động kiểm tra cảnh báo ngân sách (80% / 100%)
            if (dt.CheckBudgetWarning(SaveIdUser.CurrentWalletID, DanhMuc, out int level, out string msg))
            {
                MessageBoxIcon icon = level >= 2 ? MessageBoxIcon.Error : MessageBoxIcon.Warning;
                MessageBox.Show(msg, "CẢNH BÁO HẠN MỨC NGÂN SÁCH", MessageBoxButtons.OK, icon);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int ID)) return;
            string DanhMuc = listDanhMuc.SelectedItem?.ToString() ?? "Ăn Uống";
            double SoTien = double.Parse(txtSoTien.Text);
            string MoTa = txtMoTa.Text;
            string Ngay = NgayThang.Value.ToString("yyyy-MM-dd");

            string sql = $@"EXEC sp_ChiTieu_Update
                                @ID = {ID},
                                @DanhMuc = N'{DanhMuc}',
                                @SoTien = {SoTien},
                                @NoiDung = N'{MoTa}',
                                @Ngay = '{Ngay}';
                            ";
            dt.ExecuteNonQuery(sql);
            Reload();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int ID)) return;

            string sql = $@"EXEC sp_ChiTieu_Delete @ID = {ID}; ";

            dt.ExecuteNonQuery(sql);
            Reload();
        }

        private void btnDuDoan_Click(object sender, EventArgs e)
        {
            FormAIChatbox chat = new FormAIChatbox();
            chat.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
