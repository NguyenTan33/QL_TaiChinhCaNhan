using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class Thu_Nhap : Form
    {
        DataModel dt = new DataModel();
        public Thu_Nhap()
        {
            InitializeComponent();
            reload();
        }
        public void reload()
        {
            string sql = $"Exec sp_ThuNhap_Select @AccountID = {SaveIdUser.AccountID}";
            ResultStyle.ApplyStyle(Result);
            Result.DataSource = dt.TruyVan(sql);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            double Luong = double.Parse(txtTienHienCo.Text);
            double Thuong = double.Parse(txtThuNhap.Text);
            double Khac = double.Parse(txtKhac.Text);
            string Ngay = NgayThang.Value.ToString("yyyy-MM-dd");
            string sql = $@"EXEC sp_ThuNhap_Insert 
                                @Luong = {Luong},
                                @Thuong = {Thuong},
                                @Khac = {Khac},
                                @Ngay = '{Ngay}',
                                @AccountID = {SaveIdUser.AccountID};";
            dt.ExecuteNonQuery(sql);
            reload();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Id.Text);
            string sql = $"EXEC sp_ThuNhap_Delete @ID = {ID};";
            dt.ExecuteNonQuery(sql);
            reload();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Id.Text);
            double Luong = double.Parse(txtTienHienCo.Text);
            double Thuong = double.Parse(txtThuNhap.Text);
            double Khac = double.Parse(txtKhac.Text);
            string Ngay = NgayThang.Value.ToString("yyyy-MM-dd");
            string sql = $@"EXEC sp_ThuNhap_Update
                                @ID = {ID},
                                @Luong = {Luong},
                                @Thuong = {Thuong},
                                @Khac = {Khac},
                                @Ngay = '{Ngay}';";
            dt.ExecuteNonQuery(sql);
            reload();
        }

        private void btnDuDoan_Click(object sender, EventArgs e)
        {
        }

        private void btnLoiKhuyen_Click(object sender, EventArgs e)
        {

            string sql = $"EXEC sp_DanhGiaThuNhap @AccountID = {SaveIdUser.AccountID};";
            Result.DataSource = dt.TruyVan(sql);
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page TrangChu = new Home_Page();
            TrangChu.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void txtThuNhap_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

