using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    partial class FormDoiSoatChotSo
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

            this.pnlCards = new Panel();
            this.cardHeThong = new Panel();
            this.lblT1 = new Label();
            this.lblTienHeThong = new Label();

            this.cardThucTe = new Panel();
            this.lblT2 = new Label();
            this.txtTienThucTe = new TextBox();

            this.cardChenhLech = new Panel();
            this.lblT3 = new Label();
            this.lblChenhLech = new Label();

            this.grpAction = new GroupBox();
            this.lblGhiChu = new Label();
            this.txtGhiChu = new TextBox();
            this.btnKiemTra = new Button();
            this.btnChotSo = new Button();
            this.lblStatusAlert = new Label();

            this.grpHistory = new GroupBox();
            this.dgvHistory = new DataGridView();
            this.btnDong = new Button();

            this.pnlHeader.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.cardHeThong.SuspendLayout();
            this.cardThucTe.SuspendLayout();
            this.cardChenhLech.SuspendLayout();
            this.grpAction.SuspendLayout();
            this.grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();

            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = Color.DarkSlateBlue;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblViInfo);
            this.pnlHeader.Location = new Point(15, 12);
            this.pnlHeader.Size = new Size(930, 60);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(15, 8);
            this.lblTitle.Text = "🔒 TRUNG TÂM ĐỐI SOÁT & CHỐT SỔ TÀI CHÍNH";

            this.lblViInfo.AutoSize = true;
            this.lblViInfo.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblViInfo.ForeColor = Color.Gold;
            this.lblViInfo.Location = new Point(15, 36);
            this.lblViInfo.Text = "Ví đang kiểm đếm: ---";

            // pnlCards
            this.pnlCards.Controls.Add(this.cardHeThong);
            this.pnlCards.Controls.Add(this.cardThucTe);
            this.pnlCards.Controls.Add(this.cardChenhLech);
            this.pnlCards.Location = new Point(15, 80);
            this.pnlCards.Size = new Size(930, 100);

            // Card 1: Số dư Hệ thống
            this.cardHeThong.BackColor = Color.Teal;
            this.cardHeThong.Controls.Add(this.lblT1);
            this.cardHeThong.Controls.Add(this.lblTienHeThong);
            this.cardHeThong.Location = new Point(0, 0);
            this.cardHeThong.Size = new Size(295, 95);

            this.lblT1.AutoSize = true;
            this.lblT1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblT1.ForeColor = Color.LightCyan;
            this.lblT1.Location = new Point(12, 10);
            this.lblT1.Text = "📊 SỐ DƯ HỆ THỐNG (SỔ SÁCH)";

            this.lblTienHeThong.AutoSize = true;
            this.lblTienHeThong.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblTienHeThong.ForeColor = Color.White;
            this.lblTienHeThong.Location = new Point(12, 45);
            this.lblTienHeThong.Text = "0 đ";

            // Card 2: Số dư Thực tế
            this.cardThucTe.BackColor = Color.ForestGreen;
            this.cardThucTe.Controls.Add(this.lblT2);
            this.cardThucTe.Controls.Add(this.txtTienThucTe);
            this.cardThucTe.Location = new Point(315, 0);
            this.cardThucTe.Size = new Size(300, 95);

            this.lblT2.AutoSize = true;
            this.lblT2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblT2.ForeColor = Color.Honeydew;
            this.lblT2.Location = new Point(12, 10);
            this.lblT2.Text = "💵 SỐ DƯ THỰC TẾ (KIỂM ĐẾM)";

            this.txtTienThucTe.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.txtTienThucTe.Location = new Point(12, 45);
            this.txtTienThucTe.Size = new Size(275, 36);
            this.txtTienThucTe.Text = "0";
            this.txtTienThucTe.TextChanged += new EventHandler(this.txtTienThucTe_TextChanged);

            // Card 3: Chênh lệch
            this.cardChenhLech.BackColor = Color.DarkSlateGray;
            this.cardChenhLech.Controls.Add(this.lblT3);
            this.cardChenhLech.Controls.Add(this.lblChenhLech);
            this.cardChenhLech.Location = new Point(630, 0);
            this.cardChenhLech.Size = new Size(300, 95);

            this.lblT3.AutoSize = true;
            this.lblT3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblT3.ForeColor = Color.MistyRose;
            this.lblT3.Location = new Point(12, 10);
            this.lblT3.Text = "⚖️ CHÊNH LỆCH DÒNG TIỀN";

            this.lblChenhLech.AutoSize = true;
            this.lblChenhLech.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblChenhLech.ForeColor = Color.Gold;
            this.lblChenhLech.Location = new Point(12, 45);
            this.lblChenhLech.Text = "0 đ";

            // grpAction
            this.grpAction.Controls.Add(this.lblGhiChu);
            this.grpAction.Controls.Add(this.txtGhiChu);
            this.grpAction.Controls.Add(this.btnKiemTra);
            this.grpAction.Controls.Add(this.btnChotSo);
            this.grpAction.Controls.Add(this.lblStatusAlert);
            this.grpAction.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpAction.Location = new Point(15, 190);
            this.grpAction.Size = new Size(930, 115);
            this.grpAction.Text = "⚡ THAO TÁC ĐỐI SOÁT & CÂN BẰNG SỔ";

            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new Point(12, 28);
            this.lblGhiChu.Text = "Ghi chú:";

            this.txtGhiChu.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.txtGhiChu.Location = new Point(75, 25);
            this.txtGhiChu.Size = new Size(380, 29);

            this.btnKiemTra.BackColor = Color.SteelBlue;
            this.btnKiemTra.ForeColor = Color.White;
            this.btnKiemTra.Location = new Point(470, 23);
            this.btnKiemTra.Size = new Size(185, 33);
            this.btnKiemTra.Text = "⚖️ Phân Tích Lệch";
            this.btnKiemTra.UseVisualStyleBackColor = false;
            this.btnKiemTra.Click += new EventHandler(this.btnKiemTra_Click);

            this.btnChotSo.BackColor = Color.DarkMagenta;
            this.btnChotSo.ForeColor = Color.Gold;
            this.btnChotSo.Location = new Point(665, 23);
            this.btnChotSo.Size = new Size(250, 33);
            this.btnChotSo.Text = "🔒 Cân Bằng Ví & Chốt Sổ";
            this.btnChotSo.UseVisualStyleBackColor = false;
            this.btnChotSo.Click += new EventHandler(this.btnChotSo_Click);

            this.lblStatusAlert.AutoSize = true;
            this.lblStatusAlert.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblStatusAlert.ForeColor = Color.Indigo;
            this.lblStatusAlert.Location = new Point(12, 68);
            this.lblStatusAlert.Text = "💡 Trạng thái: Nhập số dư thực tế để tiến hành đối soát...";

            // grpHistory
            this.grpHistory.Controls.Add(this.dgvHistory);
            this.grpHistory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.grpHistory.Location = new Point(15, 315);
            this.grpHistory.Size = new Size(930, 245);
            this.grpHistory.Text = "📜 NHẬT KÝ LỊCH SỬ ĐỐI SOÁT & CHỐT SỔ";

            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistory.ColumnHeadersHeight = 36;
            this.dgvHistory.Location = new Point(12, 28);
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.Size = new Size(905, 205);

            // btnDong
            this.btnDong.BackColor = Color.DimGray;
            this.btnDong.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnDong.ForeColor = Color.White;
            this.btnDong.Location = new Point(805, 570);
            this.btnDong.Size = new Size(140, 38);
            this.btnDong.Text = "❌ Quay Lại";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new EventHandler(this.btnDong_Click);

            // FormDoiSoatChotSo
            this.ClientSize = new Size(960, 620);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.grpHistory);
            this.Controls.Add(this.grpAction);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormDoiSoatChotSo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Phân Hệ Đối Soát & Chốt Sổ Tài Chính";
            this.Load += new EventHandler(this.FormDoiSoatChotSo_Load);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.cardHeThong.ResumeLayout(false);
            this.cardHeThong.PerformLayout();
            this.cardThucTe.ResumeLayout(false);
            this.cardThucTe.PerformLayout();
            this.cardChenhLech.ResumeLayout(false);
            this.cardChenhLech.PerformLayout();
            this.grpAction.ResumeLayout(false);
            this.grpAction.PerformLayout();
            this.grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblViInfo;

        private Panel pnlCards;
        private Panel cardHeThong;
        private Label lblT1;
        private Label lblTienHeThong;

        private Panel cardThucTe;
        private Label lblT2;
        private TextBox txtTienThucTe;

        private Panel cardChenhLech;
        private Label lblT3;
        private Label lblChenhLech;

        private GroupBox grpAction;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Button btnKiemTra;
        private Button btnChotSo;
        private Label lblStatusAlert;

        private GroupBox grpHistory;
        private DataGridView dgvHistory;
        private Button btnDong;
    }
}
