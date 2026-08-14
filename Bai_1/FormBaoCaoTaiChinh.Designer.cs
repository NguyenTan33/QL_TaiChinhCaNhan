using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    partial class FormBaoCaoTaiChinh
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
            this.lblTitle = new Label();
            this.lblViInfo = new Label();
            this.pnlCardTienBanDau = new Panel();
            this.lblCardTitle1 = new Label();
            this.lblValTienBanDau = new Label();
            this.pnlCardTienHienCo = new Panel();
            this.lblCardTitle2 = new Label();
            this.lblValTienHienCo = new Label();
            this.pnlCardTongThu = new Panel();
            this.lblCardTitle3 = new Label();
            this.lblValTongThu = new Label();
            this.pnlCardTongChi = new Panel();
            this.lblCardTitle4 = new Label();
            this.lblValTongChi = new Label();
            this.pnlCardThangDu = new Panel();
            this.lblCardTitle5 = new Label();
            this.lblValThangDu = new Label();
            this.dtpTuNgay = new DateTimePicker();
            this.dtpDenNgay = new DateTimePicker();
            this.lblTuNgay = new Label();
            this.lblDenNgay = new Label();
            this.btnLocData = new Button();
            this.btnXuatExcel = new Button();
            this.tabReport = new TabControl();
            this.tabCoCau = new TabPage();
            this.dgvCoCauDanhMuc = new DataGridView();
            this.tabGiaoDich = new TabPage();
            this.dgvAllGiaoDich = new DataGridView();
            this.btnDong = new Button();

            this.pnlCardTienBanDau.SuspendLayout();
            this.pnlCardTienHienCo.SuspendLayout();
            this.pnlCardTongThu.SuspendLayout();
            this.pnlCardTongChi.SuspendLayout();
            this.pnlCardThangDu.SuspendLayout();
            this.tabReport.SuspendLayout();
            this.tabCoCau.SuspendLayout();
            this.tabGiaoDich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoCauDanhMuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllGiaoDich)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.DarkSlateBlue;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(570, 37);
            this.lblTitle.Text = "📊 BÁO CÁO TÀI CHÍNH CHUẨN CHỈ XỊN XÒ";

            // lblViInfo
            this.lblViInfo.AutoSize = true;
            this.lblViInfo.Font = new Font("Segoe UI", 10.5F, FontStyle.Italic);
            this.lblViInfo.ForeColor = Color.DarkGreen;
            this.lblViInfo.Location = new Point(22, 55);
            this.lblViInfo.Name = "lblViInfo";
            this.lblViInfo.Size = new Size(200, 25);
            this.lblViInfo.Text = "Đang báo cáo ví: ---";

            // Card 1: Tiền Ban Đầu
            this.pnlCardTienBanDau.BackColor = Color.LightSteelBlue;
            this.pnlCardTienBanDau.BorderStyle = BorderStyle.FixedSingle;
            this.pnlCardTienBanDau.Controls.Add(this.lblValTienBanDau);
            this.pnlCardTienBanDau.Controls.Add(this.lblCardTitle1);
            this.pnlCardTienBanDau.Location = new Point(22, 90);
            this.pnlCardTienBanDau.Size = new Size(170, 85);
            this.lblCardTitle1.AutoSize = true;
            this.lblCardTitle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCardTitle1.Text = "💰 TIỀN BAN ĐẦU";
            this.lblCardTitle1.Location = new Point(8, 10);
            this.lblValTienBanDau.AutoSize = true;
            this.lblValTienBanDau.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblValTienBanDau.ForeColor = Color.DarkBlue;
            this.lblValTienBanDau.Location = new Point(8, 40);
            this.lblValTienBanDau.Text = "0 VNĐ";

            // Card 2: Tiền Hiện Có
            this.pnlCardTienHienCo.BackColor = Color.Honeydew;
            this.pnlCardTienHienCo.BorderStyle = BorderStyle.FixedSingle;
            this.pnlCardTienHienCo.Controls.Add(this.lblValTienHienCo);
            this.pnlCardTienHienCo.Controls.Add(this.lblCardTitle2);
            this.pnlCardTienHienCo.Location = new Point(205, 90);
            this.pnlCardTienHienCo.Size = new Size(170, 85);
            this.lblCardTitle2.AutoSize = true;
            this.lblCardTitle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCardTitle2.Text = "💵 TIỀN HIỆN CÓ";
            this.lblCardTitle2.Location = new Point(8, 10);
            this.lblValTienHienCo.AutoSize = true;
            this.lblValTienHienCo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblValTienHienCo.ForeColor = Color.DarkGreen;
            this.lblValTienHienCo.Location = new Point(8, 40);
            this.lblValTienHienCo.Text = "0 VNĐ";

            // Card 3: Tổng Thu
            this.pnlCardTongThu.BackColor = Color.Azure;
            this.pnlCardTongThu.BorderStyle = BorderStyle.FixedSingle;
            this.pnlCardTongThu.Controls.Add(this.lblValTongThu);
            this.pnlCardTongThu.Controls.Add(this.lblCardTitle3);
            this.pnlCardTongThu.Location = new Point(388, 90);
            this.pnlCardTongThu.Size = new Size(170, 85);
            this.lblCardTitle3.AutoSize = true;
            this.lblCardTitle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCardTitle3.Text = "📈 TỔNG THU";
            this.lblCardTitle3.Location = new Point(8, 10);
            this.lblValTongThu.AutoSize = true;
            this.lblValTongThu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblValTongThu.ForeColor = Color.Teal;
            this.lblValTongThu.Location = new Point(8, 40);
            this.lblValTongThu.Text = "0 VNĐ";

            // Card 4: Tổng Chi
            this.pnlCardTongChi.BackColor = Color.MistyRose;
            this.pnlCardTongChi.BorderStyle = BorderStyle.FixedSingle;
            this.pnlCardTongChi.Controls.Add(this.lblValTongChi);
            this.pnlCardTongChi.Controls.Add(this.lblCardTitle4);
            this.pnlCardTongChi.Location = new Point(571, 90);
            this.pnlCardTongChi.Size = new Size(170, 85);
            this.lblCardTitle4.AutoSize = true;
            this.lblCardTitle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCardTitle4.Text = "📉 TỔNG CHI";
            this.lblCardTitle4.Location = new Point(8, 10);
            this.lblValTongChi.AutoSize = true;
            this.lblValTongChi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblValTongChi.ForeColor = Color.DarkRed;
            this.lblValTongChi.Location = new Point(8, 40);
            this.lblValTongChi.Text = "0 VNĐ";

            // Card 5: Thặng Dư Net
            this.pnlCardThangDu.BackColor = Color.LemonChiffon;
            this.pnlCardThangDu.BorderStyle = BorderStyle.FixedSingle;
            this.pnlCardThangDu.Controls.Add(this.lblValThangDu);
            this.pnlCardThangDu.Controls.Add(this.lblCardTitle5);
            this.pnlCardThangDu.Location = new Point(754, 90);
            this.pnlCardThangDu.Size = new Size(170, 85);
            this.lblCardTitle5.AutoSize = true;
            this.lblCardTitle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblCardTitle5.Text = "💡 THẶNG DƯ (SAVINGS)";
            this.lblCardTitle5.Location = new Point(8, 10);
            this.lblValThangDu.AutoSize = true;
            this.lblValThangDu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblValThangDu.ForeColor = Color.Purple;
            this.lblValThangDu.Location = new Point(8, 40);
            this.lblValThangDu.Text = "0 VNĐ";

            // Filter controls
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new Font("Segoe UI", 9.5F);
            this.lblTuNgay.Location = new Point(22, 195);
            this.lblTuNgay.Text = "Từ ngày:";
            this.dtpTuNgay.Font = new Font("Segoe UI", 9.5F);
            this.dtpTuNgay.Format = DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new Point(90, 190);
            this.dtpTuNgay.Size = new Size(140, 29);

            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new Font("Segoe UI", 9.5F);
            this.lblDenNgay.Location = new Point(250, 195);
            this.lblDenNgay.Text = "Đến ngày:";
            this.dtpDenNgay.Font = new Font("Segoe UI", 9.5F);
            this.dtpDenNgay.Format = DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new Point(330, 190);
            this.dtpDenNgay.Size = new Size(140, 29);

            this.btnLocData.BackColor = Color.SteelBlue;
            this.btnLocData.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnLocData.ForeColor = Color.White;
            this.btnLocData.Location = new Point(490, 188);
            this.btnLocData.Size = new Size(140, 33);
            this.btnLocData.Text = "🔍 Lọc Dữ Liệu";
            this.btnLocData.UseVisualStyleBackColor = false;
            this.btnLocData.Click += new EventHandler(this.btnLocData_Click);

            this.btnXuatExcel.BackColor = Color.DarkGreen;
            this.btnXuatExcel.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnXuatExcel.ForeColor = Color.White;
            this.btnXuatExcel.Location = new Point(640, 188);
            this.btnXuatExcel.Size = new Size(150, 33);
            this.btnXuatExcel.Text = "📥 Xuất File CSV";
            this.btnXuatExcel.UseVisualStyleBackColor = false;
            this.btnXuatExcel.Click += new EventHandler(this.btnXuatExcel_Click);

            // TabControl
            this.tabReport.Controls.Add(this.tabCoCau);
            this.tabReport.Controls.Add(this.tabGiaoDich);
            this.tabReport.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.tabReport.Location = new Point(22, 235);
            this.tabReport.Size = new Size(902, 360);

            // Tab 1: Cơ cấu danh mục
            this.tabCoCau.Controls.Add(this.dgvCoCauDanhMuc);
            this.tabCoCau.Text = "🍰 Tỷ Trọng Chi Tiêu Theo Danh Mục";
            this.dgvCoCauDanhMuc.AllowUserToAddRows = false;
            this.dgvCoCauDanhMuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCoCauDanhMuc.Dock = DockStyle.Fill;
            this.dgvCoCauDanhMuc.ReadOnly = true;

            // Tab 2: Lịch sử giao dịch
            this.tabGiaoDich.Controls.Add(this.dgvAllGiaoDich);
            this.tabGiaoDich.Text = "📝 Toàn Bộ Giao Dịch Trong Ví";
            this.dgvAllGiaoDich.AllowUserToAddRows = false;
            this.dgvAllGiaoDich.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllGiaoDich.Dock = DockStyle.Fill;
            this.dgvAllGiaoDich.ReadOnly = true;

            // btnDong
            this.btnDong.BackColor = Color.DimGray;
            this.btnDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDong.ForeColor = Color.White;
            this.btnDong.Location = new Point(784, 605);
            this.btnDong.Size = new Size(140, 38);
            this.btnDong.Text = "❌ Quay Lại";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new EventHandler(this.btnDong_Click);

            // FormBaoCaoTaiChinh
            this.ClientSize = new Size(950, 655);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabReport);
            this.Controls.Add(this.btnLocData);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.pnlCardThangDu);
            this.Controls.Add(this.pnlCardTongChi);
            this.Controls.Add(this.pnlCardTongThu);
            this.Controls.Add(this.pnlCardTienHienCo);
            this.Controls.Add(this.pnlCardTienBanDau);
            this.Controls.Add(this.lblViInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormBaoCaoTaiChinh";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Tài Chính Chuẩn Chỉ Xịn Xò";
            this.Load += new EventHandler(this.FormBaoCaoTaiChinh_Load);
            this.pnlCardTienBanDau.ResumeLayout(false);
            this.pnlCardTienBanDau.PerformLayout();
            this.pnlCardTienHienCo.ResumeLayout(false);
            this.pnlCardTienHienCo.PerformLayout();
            this.pnlCardTongThu.ResumeLayout(false);
            this.pnlCardTongThu.PerformLayout();
            this.pnlCardTongChi.ResumeLayout(false);
            this.pnlCardTongChi.PerformLayout();
            this.pnlCardThangDu.ResumeLayout(false);
            this.pnlCardThangDu.PerformLayout();
            this.tabReport.ResumeLayout(false);
            this.tabCoCau.ResumeLayout(false);
            this.tabGiaoDich.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoCauDanhMuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllGiaoDich)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblViInfo;
        private Panel pnlCardTienBanDau;
        private Label lblCardTitle1;
        private Label lblValTienBanDau;
        private Panel pnlCardTienHienCo;
        private Label lblCardTitle2;
        private Label lblValTienHienCo;
        private Panel pnlCardTongThu;
        private Label lblCardTitle3;
        private Label lblValTongThu;
        private Panel pnlCardTongChi;
        private Label lblCardTitle4;
        private Label lblValTongChi;
        private Panel pnlCardThangDu;
        private Label lblCardTitle5;
        private Label lblValThangDu;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Label lblTuNgay;
        private Label lblDenNgay;
        private Button btnLocData;
        private TabControl tabReport;
        private TabPage tabCoCau;
        private DataGridView dgvCoCauDanhMuc;
        private TabPage tabGiaoDich;
        private DataGridView dgvAllGiaoDich;
        private Button btnDong;
        private Button btnXuatExcel;
    }
}
