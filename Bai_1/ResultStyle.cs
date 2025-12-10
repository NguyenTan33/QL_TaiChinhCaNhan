using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1
{
    internal class ResultStyle
    {
        public static void ApplyStyle(DataGridView dgv)
        {
            // Bỏ viền thô
            dgv.BorderStyle = BorderStyle.None;

            // Màu dòng chẵn – lẻ
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv.RowsDefaultCellStyle.BackColor = Color.White;

            // Viền ô
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.Silver;

            // Header
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 40;

            // Dòng dữ liệu
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 204, 113);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Chiều cao dòng
            dgv.RowTemplate.Height = 35;

            // Tự co giãn cột
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Chọn 1 dòng
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Nếu muốn chỉ đọc:
            // dgv.ReadOnly = true;
        }
    }
}
