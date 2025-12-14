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
    public partial class DSHySu : Form
    {
        DataModel dt = new DataModel();
        public DSHySu()
        {
            InitializeComponent();
            Reload();
        }

        public void Reload()
        {
            string sql = "exec sp_XemDSKhachMoi";
            ResultStyle.ApplyStyle(dataGridView1);
            dataGridView1.DataSource = dt.TruyVan(sql);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Ten = txtSearch.Text;
            string sql = $"EXEC sp_TimKiemTheoTen @AccountID = {SaveIdUser.AccountID}, @TenCanTim = N'{Ten}';";
            ResultStyle.ApplyStyle(dataGridView1);
            dataGridView1.DataSource =dt.TruyVan(sql);
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page TrangChu = new Home_Page();
            TrangChu.ShowDialog();
            this.Close();
        }

        private void btnAllSearch_Click(object sender, EventArgs e)
        {
            Reload();
        }
    }
}
