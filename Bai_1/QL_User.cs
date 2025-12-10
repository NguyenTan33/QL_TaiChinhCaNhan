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
    public partial class QL_User : Form
    {
        DataModel dt = new DataModel();
        public QL_User()
        {
            InitializeComponent();
            Reload();
        }
        public void Reload()
        {
            string sql = "Exec sp_Account_SelectAll";
            ResultStyle.ApplyStyle(dataGridView1);
            dataGridView1.DataSource = dt.TruyVan(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page TrangChu = new Home_Page();
            TrangChu.ShowDialog();
            this.Close();
        }
    }
}
