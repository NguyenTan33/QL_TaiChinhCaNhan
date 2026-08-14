using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    partial class FormPhanTichDuLieu
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.lblViInfo = new Label();

            this.pnlScrollable = new Panel();

            // 6 Chart Boxes
            this.grpChart1 = new GroupBox();
            this.dgvChart1 = new DataGridView();
            this.pnlInsight1 = new Panel();
            this.lblInsight1 = new Label();

            this.grpChart2 = new GroupBox();
            this.dgvChart2 = new DataGridView();
            this.pnlInsight2 = new Panel();
            this.lblInsight2 = new Label();

            this.grpChart3 = new GroupBox();
            this.dgvChart3 = new DataGridView();
            this.pnlInsight3 = new Panel();
            this.lblInsight3 = new Label();

            this.grpChart4 = new GroupBox();
            this.dgvChart4 = new DataGridView();
            this.pnlInsight4 = new Panel();
            this.lblInsight4 = new Label();

            this.grpChart5 = new GroupBox();
            this.dgvChart5 = new DataGridView();
            this.pnlInsight5 = new Panel();
            this.lblInsight5 = new Label();

            this.grpChart6 = new GroupBox();
            this.dgvChart6 = new DataGridView();
            this.pnlInsight6 = new Panel();
            this.lblInsight6 = new Label();

            this.btnDong = new Button();

            this.pnlHeader.SuspendLayout();
            this.pnlScrollable.SuspendLayout();

            this.grpChart1.SuspendLayout();
            this.grpChart2.SuspendLayout();
            this.grpChart3.SuspendLayout();
            this.grpChart4.SuspendLayout();
            this.grpChart5.SuspendLayout();
            this.grpChart6.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dgvChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChart5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChart6)).BeginInit();

            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = Color.DarkSlateBlue;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblViInfo);
            this.pnlHeader.Location = new Point(15, 12);
            this.pnlHeader.Size = new Size(1050, 65);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(15, 8);
            this.lblTitle.Text = "📊 TRUNG TÂM PHÂN TÍCH DỮ LIỆU TÀI CHÍNH (6 BIỂU ĐỒ & AI INSIGHTS)";

            this.lblViInfo.AutoSize = true;
            this.lblViInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            this.lblViInfo.ForeColor = Color.Gold;
            this.lblViInfo.Location = new Point(15, 40);
            this.lblViInfo.Text = "Ví đang phân tích: ---";

            // pnlScrollable Container
            this.pnlScrollable.AutoScroll = true;
            this.pnlScrollable.BorderStyle = BorderStyle.FixedSingle;
            this.pnlScrollable.Location = new Point(15, 85);
            this.pnlScrollable.Size = new Size(1050, 570);

            // ==========================================
            // CHART 1: Tỷ Trọng Chi Tiêu
            // ==========================================
            this.grpChart1.Controls.Add(this.dgvChart1);
            this.grpChart1.Controls.Add(this.pnlInsight1);
            this.grpChart1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpChart1.Location = new Point(15, 15);
            this.grpChart1.Size = new Size(1000, 270);
            this.grpChart1.Text = "🍰 1. BIỂU ĐỒ TỶ TRỌNG CHI TIÊU THEO DANH MỤC";

            this.dgvChart1.AllowUserToAddRows = false;
            this.dgvChart1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChart1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChart1.ColumnHeadersHeight = 36;
            this.dgvChart1.Location = new Point(12, 28);
            this.dgvChart1.ReadOnly = true;
            this.dgvChart1.Size = new Size(975, 175);

            this.pnlInsight1.BackColor = Color.Indigo;
            this.pnlInsight1.Controls.Add(this.lblInsight1);
            this.pnlInsight1.Location = new Point(12, 210);
            this.pnlInsight1.Size = new Size(975, 45);
            this.lblInsight1.AutoSize = true;
            this.lblInsight1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblInsight1.ForeColor = Color.Gold;
            this.lblInsight1.Location = new Point(10, 12);
            this.lblInsight1.Text = "💡 AI NHẬN XÉT: Đang tính toán dữ liệu chi tiêu...";

            // ==========================================
            // CHART 2: Thu Nhập vs Chi Tiêu Theo Tháng
            // ==========================================
            this.grpChart2.Controls.Add(this.dgvChart2);
            this.grpChart2.Controls.Add(this.pnlInsight2);
            this.grpChart2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpChart2.Location = new Point(15, 300);
            this.grpChart2.Size = new Size(1000, 270);
            this.grpChart2.Text = "📈 2. BIỂU ĐỒ XU HƯỚNG THU NHẬP VS CHI TIÊU THEO THÁNG";

            this.dgvChart2.AllowUserToAddRows = false;
            this.dgvChart2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChart2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChart2.ColumnHeadersHeight = 36;
            this.dgvChart2.Location = new Point(12, 28);
            this.dgvChart2.ReadOnly = true;
            this.dgvChart2.Size = new Size(975, 175);

            this.pnlInsight2.BackColor = Color.DarkSlateGray;
            this.pnlInsight2.Controls.Add(this.lblInsight2);
            this.pnlInsight2.Location = new Point(12, 210);
            this.pnlInsight2.Size = new Size(975, 45);
            this.lblInsight2.AutoSize = true;
            this.lblInsight2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblInsight2.ForeColor = Color.LightCyan;
            this.lblInsight2.Location = new Point(10, 12);
            this.lblInsight2.Text = "💡 AI NHẬN XÉT: Đang tổng hợp xu hướng thu chi...";

            // ==========================================
            // CHART 3: Burn Rate & Số Ngày Sống Sót
            // ==========================================
            this.grpChart3.Controls.Add(this.dgvChart3);
            this.grpChart3.Controls.Add(this.pnlInsight3);
            this.grpChart3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpChart3.Location = new Point(15, 585);
            this.grpChart3.Size = new Size(1000, 270);
            this.grpChart3.Text = "🔥 3. BIỂU ĐỒ TỐC ĐỘ ĐỐT TIỀN (BURN RATE) & SỐ NGÀY SỐNG SÓT";

            this.dgvChart3.AllowUserToAddRows = false;
            this.dgvChart3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChart3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChart3.ColumnHeadersHeight = 36;
            this.dgvChart3.Location = new Point(12, 28);
            this.dgvChart3.ReadOnly = true;
            this.dgvChart3.Size = new Size(975, 175);

            this.pnlInsight3.BackColor = Color.Maroon;
            this.pnlInsight3.Controls.Add(this.lblInsight3);
            this.pnlInsight3.Location = new Point(12, 210);
            this.pnlInsight3.Size = new Size(975, 45);
            this.lblInsight3.AutoSize = true;
            this.lblInsight3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblInsight3.ForeColor = Color.MistyRose;
            this.lblInsight3.Location = new Point(10, 12);
            this.lblInsight3.Text = "💡 AI NHẬN XÉT: Đang đo lường tốc độ tiêu tiền...";

            // ==========================================
            // CHART 4: Ngân Sách Utilization
            // ==========================================
            this.grpChart4.Controls.Add(this.dgvChart4);
            this.grpChart4.Controls.Add(this.pnlInsight4);
            this.grpChart4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpChart4.Location = new Point(15, 870);
            this.grpChart4.Size = new Size(1000, 270);
            this.grpChart4.Text = "🎯 4. BIỂU ĐỒ MỨC ĐỘ SỬ DỤNG NGÂN SÁCH VS HẠN MỨC";

            this.dgvChart4.AllowUserToAddRows = false;
            this.dgvChart4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChart4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChart4.ColumnHeadersHeight = 36;
            this.dgvChart4.Location = new Point(12, 28);
            this.dgvChart4.ReadOnly = true;
            this.dgvChart4.Size = new Size(975, 175);

            this.pnlInsight4.BackColor = Color.DarkGreen;
            this.pnlInsight4.Controls.Add(this.lblInsight4);
            this.pnlInsight4.Location = new Point(12, 210);
            this.pnlInsight4.Size = new Size(975, 45);
            this.lblInsight4.AutoSize = true;
            this.lblInsight4.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblInsight4.ForeColor = Color.Honeydew;
            this.lblInsight4.Location = new Point(10, 12);
            this.lblInsight4.Text = "💡 AI NHẬN XÉT: Đang đối chiếu hạn mức ngân sách...";

            // ==========================================
            // CHART 5: Quy Tắc 50/30/20
            // ==========================================
            this.grpChart5.Controls.Add(this.dgvChart5);
            this.grpChart5.Controls.Add(this.pnlInsight5);
            this.grpChart5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpChart5.Location = new Point(15, 1155);
            this.grpChart5.Size = new Size(1000, 270);
            this.grpChart5.Text = "⚖️ 5. BIỂU ĐỒ PHÂN PHỐI DÒNG TIỀN QUY TẮC 50/30/20";

            this.dgvChart5.AllowUserToAddRows = false;
            this.dgvChart5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChart5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChart5.ColumnHeadersHeight = 36;
            this.dgvChart5.Location = new Point(12, 28);
            this.dgvChart5.ReadOnly = true;
            this.dgvChart5.Size = new Size(975, 175);

            this.pnlInsight5.BackColor = Color.MidnightBlue;
            this.pnlInsight5.Controls.Add(this.lblInsight5);
            this.pnlInsight5.Location = new Point(12, 210);
            this.pnlInsight5.Size = new Size(975, 45);
            this.lblInsight5.AutoSize = true;
            this.lblInsight5.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblInsight5.ForeColor = Color.LemonChiffon;
            this.lblInsight5.Location = new Point(10, 12);
            this.lblInsight5.Text = "💡 AI NHẬN XÉT: Đang phân tích tỷ lệ quy tắc 50/30/20...";

            // ==========================================
            // CHART 6: Hiệu Suất Đầu Tư & ROI
            // ==========================================
            this.grpChart6.Controls.Add(this.dgvChart6);
            this.grpChart6.Controls.Add(this.pnlInsight6);
            this.grpChart6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpChart6.Location = new Point(15, 1440);
            this.grpChart6.Size = new Size(1000, 270);
            this.grpChart6.Text = "💎 6. BIỂU ĐỒ HIỆU SUẤT DANH MỤC ĐẦU TƯ & TỶ SUẤT ROI (%)";

            this.dgvChart6.AllowUserToAddRows = false;
            this.dgvChart6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChart6.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvChart6.ColumnHeadersHeight = 36;
            this.dgvChart6.Location = new Point(12, 28);
            this.dgvChart6.ReadOnly = true;
            this.dgvChart6.Size = new Size(975, 175);

            this.pnlInsight6.BackColor = Color.Purple;
            this.pnlInsight6.Controls.Add(this.lblInsight6);
            this.pnlInsight6.Location = new Point(12, 210);
            this.pnlInsight6.Size = new Size(975, 45);
            this.lblInsight6.AutoSize = true;
            this.lblInsight6.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblInsight6.ForeColor = Color.White;
            this.lblInsight6.Location = new Point(10, 12);
            this.lblInsight6.Text = "💡 AI NHẬN XÉT: Đang đo lường tỷ suất sinh lời danh mục đầu tư...";

            // Add Charts to Scrollable Panel
            this.pnlScrollable.Controls.Add(this.grpChart1);
            this.pnlScrollable.Controls.Add(this.grpChart2);
            this.pnlScrollable.Controls.Add(this.grpChart3);
            this.pnlScrollable.Controls.Add(this.grpChart4);
            this.pnlScrollable.Controls.Add(this.grpChart5);
            this.pnlScrollable.Controls.Add(this.grpChart6);

            // btnDong
            this.btnDong.BackColor = Color.DimGray;
            this.btnDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDong.ForeColor = Color.White;
            this.btnDong.Location = new Point(925, 665);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new Size(140, 38);
            this.btnDong.Text = "❌ Quay Lại";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new EventHandler(this.btnDong_Click);

            // FormPhanTichDuLieu
            this.ClientSize = new Size(1085, 715);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.pnlScrollable);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormPhanTichDuLieu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Trung Tâm Phân Tích Dữ Liệu Tài Chính & AI Insights";
            this.Load += new EventHandler(this.FormPhanTichDuLieu_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlScrollable.ResumeLayout(false);

            this.grpChart1.ResumeLayout(false);
            this.grpChart2.ResumeLayout(false);
            this.grpChart3.ResumeLayout(false);
            this.grpChart4.ResumeLayout(false);
            this.grpChart5.ResumeLayout(false);
            this.grpChart6.ResumeLayout(false);

            this.pnlInsight1.ResumeLayout(false);
            this.pnlInsight1.PerformLayout();
            this.pnlInsight2.ResumeLayout(false);
            this.pnlInsight2.PerformLayout();
            this.pnlInsight3.ResumeLayout(false);
            this.pnlInsight3.PerformLayout();
            this.pnlInsight4.ResumeLayout(false);
            this.pnlInsight4.PerformLayout();
            this.pnlInsight5.ResumeLayout(false);
            this.pnlInsight5.PerformLayout();
            this.pnlInsight6.ResumeLayout(false);
            this.pnlInsight6.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(this.dgvChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChart5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChart6)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblViInfo;

        private Panel pnlScrollable;

        private GroupBox grpChart1;
        private DataGridView dgvChart1;
        private Panel pnlInsight1;
        private Label lblInsight1;

        private GroupBox grpChart2;
        private DataGridView dgvChart2;
        private Panel pnlInsight2;
        private Label lblInsight2;

        private GroupBox grpChart3;
        private DataGridView dgvChart3;
        private Panel pnlInsight3;
        private Label lblInsight3;

        private GroupBox grpChart4;
        private DataGridView dgvChart4;
        private Panel pnlInsight4;
        private Label lblInsight4;

        private GroupBox grpChart5;
        private DataGridView dgvChart5;
        private Panel pnlInsight5;
        private Label lblInsight5;

        private GroupBox grpChart6;
        private DataGridView dgvChart6;
        private Panel pnlInsight6;
        private Label lblInsight6;

        private Button btnDong;
    }
}
