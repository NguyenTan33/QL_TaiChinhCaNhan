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
            string sql = $"EXEC sp_ChiTieu_Xem @AccountID = {SaveIdUser.AccountID};";
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
            string DanhMuc = listDanhMuc.SelectedItem?.ToString() ?? "";
            double SoTien = double.Parse(txtSoTien.Text);
            string MoTa = txtMoTa.Text;
            string Ngay = NgayThang.Value.ToString("yyyy-MM-dd");

            string sql = $@"EXEC sp_ChiTieu_Insert 
                                @DanhMuc = N'{DanhMuc}',
                                @SoTien = {SoTien},
                                @NoiDung = N'{MoTa}',
                                @Ngay = '{Ngay}',
                                @AccountID = {SaveIdUser.AccountID};
                            ";
            dt.ExecuteNonQuery(sql);
            Reload();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            string DanhMuc = listDanhMuc.SelectedItem.ToString();
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
            int ID = int.Parse(txtID.Text);

            string sql = $@"EXEC sp_ChiTieu_Delete @ID = {ID}; ";

            dt.ExecuteNonQuery(sql);
            Reload();
        }

        private void btnDuDoan_Click(object sender, EventArgs e)
        {
            string sql = $@"EXEC sp_CanhBaoTieuTien {SaveIdUser.AccountID};";
            Result.DataSource = dt.TruyVan(sql);
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
