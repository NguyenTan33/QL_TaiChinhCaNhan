using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    partial class FormDauTuVayNo
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
            this.tabMain = new TabControl();
            this.tabVayNo = new TabPage();
            this.tabDauTu = new TabPage();

            // Controls inside tabVayNo
            this.lblLoaiVayNo = new Label();
            this.cboLoaiVayNo = new ComboBox();
            this.lblDoiTac = new Label();
            this.txtDoiTac = new TextBox();
            this.lblSoTienGoc = new Label();
            this.txtSoTienGoc = new TextBox();
            this.lblLaiSuat = new Label();
            this.txtLaiSuat = new TextBox();
            this.lblGhiChuVayNo = new Label();
            this.txtGhiChuVayNo = new TextBox();
            this.btnThemVayNo = new Button();
            this.btnThanhToanVayNo = new Button();
            this.dgvVayNo = new DataGridView();

            // Controls inside tabDauTu
            this.lblLoaiDauTu = new Label();
            this.cboLoaiDauTu = new ComboBox();
            this.lblTenTaiSan = new Label();
            this.txtTenTaiSan = new TextBox();
            this.lblGiaVon = new Label();
            this.txtGiaVon = new TextBox();
            this.lblGiaTriHienTai = new Label();
            this.txtGiaTriHienTai = new TextBox();
            this.lblSoLuong = new Label();
            this.txtSoLuong = new TextBox();
            this.lblGhiChuDauTu = new Label();
            this.txtGhiChuDauTu = new TextBox();
            this.btnThemDauTu = new Button();
            this.dgvDauTu = new DataGridView();

            this.btnDong = new Button();

            this.tabMain.SuspendLayout();
            this.tabVayNo.SuspendLayout();
            this.tabDauTu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVayNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDauTu)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.DarkSlateBlue;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Text = "💎 QUẢN LÝ ĐẦU TƯ & THEO DÕI VAY NỢ";

            // lblViInfo
            this.lblViInfo.AutoSize = true;
            this.lblViInfo.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblViInfo.ForeColor = Color.DarkGreen;
            this.lblViInfo.Location = new Point(22, 55);
            this.lblViInfo.Text = "Đang quản lý ví: ---";

            // TabControl
            this.tabMain.Controls.Add(this.tabVayNo);
            this.tabMain.Controls.Add(this.tabDauTu);
            this.tabMain.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.tabMain.Location = new Point(20, 90);
            this.tabMain.Size = new Size(960, 480);

            // Tab 1: Vay Nợ
            this.tabVayNo.Text = "🤝 Quản Lý Vay & Cho Mượn";
            this.tabVayNo.Controls.Add(this.lblLoaiVayNo);
            this.tabVayNo.Controls.Add(this.cboLoaiVayNo);
            this.tabVayNo.Controls.Add(this.lblDoiTac);
            this.tabVayNo.Controls.Add(this.txtDoiTac);
            this.tabVayNo.Controls.Add(this.lblSoTienGoc);
            this.tabVayNo.Controls.Add(this.txtSoTienGoc);
            this.tabVayNo.Controls.Add(this.lblLaiSuat);
            this.tabVayNo.Controls.Add(this.txtLaiSuat);
            this.tabVayNo.Controls.Add(this.lblGhiChuVayNo);
            this.tabVayNo.Controls.Add(this.txtGhiChuVayNo);
            this.tabVayNo.Controls.Add(this.btnThemVayNo);
            this.tabVayNo.Controls.Add(this.btnThanhToanVayNo);
            this.tabVayNo.Controls.Add(this.dgvVayNo);

            // Tab 1 Form Controls Layout
            this.lblLoaiVayNo.Font = new Font("Segoe UI", 9.5F);
            this.lblLoaiVayNo.Location = new Point(15, 18);
            this.lblLoaiVayNo.Text = "Loại giao dịch:";
            this.cboLoaiVayNo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLoaiVayNo.Font = new Font("Segoe UI", 9.5F);
            this.cboLoaiVayNo.Items.AddRange(new object[] { "Cho Mượn (Người khác nợ)", "Đi Vay (Mình nợ)", "Nợ Thẻ Tín Dụng" });
            this.cboLoaiVayNo.Location = new Point(125, 15);
            this.cboLoaiVayNo.Size = new Size(200, 29);

            this.lblDoiTac.Font = new Font("Segoe UI", 9.5F);
            this.lblDoiTac.Location = new Point(340, 18);
            this.lblDoiTac.Text = "Đối tác/Người mượn:";
            this.txtDoiTac.Font = new Font("Segoe UI", 9.5F);
            this.txtDoiTac.Location = new Point(490, 15);
            this.txtDoiTac.Size = new Size(170, 29);

            this.lblSoTienGoc.Font = new Font("Segoe UI", 9.5F);
            this.lblSoTienGoc.Location = new Point(675, 18);
            this.lblSoTienGoc.Text = "Số tiền gốc:";
            this.txtSoTienGoc.Font = new Font("Segoe UI", 9.5F);
            this.txtSoTienGoc.Location = new Point(765, 15);
            this.txtSoTienGoc.Size = new Size(165, 29);

            this.lblLaiSuat.Font = new Font("Segoe UI", 9.5F);
            this.lblLaiSuat.Location = new Point(15, 58);
            this.lblLaiSuat.Text = "Lãi suất (%/tháng):";
            this.txtLaiSuat.Font = new Font("Segoe UI", 9.5F);
            this.txtLaiSuat.Location = new Point(150, 55);
            this.txtLaiSuat.Size = new Size(90, 29);
            this.txtLaiSuat.Text = "0";

            this.lblGhiChuVayNo.Font = new Font("Segoe UI", 9.5F);
            this.lblGhiChuVayNo.Location = new Point(255, 58);
            this.lblGhiChuVayNo.Text = "Ghi chú:";
            this.txtGhiChuVayNo.Font = new Font("Segoe UI", 9.5F);
            this.txtGhiChuVayNo.Location = new Point(320, 55);
            this.txtGhiChuVayNo.Size = new Size(340, 29);

            this.btnThemVayNo.BackColor = Color.SeaGreen;
            this.btnThemVayNo.ForeColor = Color.White;
            this.btnThemVayNo.Location = new Point(675, 52);
            this.btnThemVayNo.Size = new Size(125, 34);
            this.btnThemVayNo.Text = "➕ Ghi Khoản Nợ";
            this.btnThemVayNo.UseVisualStyleBackColor = false;
            this.btnThemVayNo.Click += new EventHandler(this.btnThemVayNo_Click);

            this.btnThanhToanVayNo.BackColor = Color.DarkOrange;
            this.btnThanhToanVayNo.ForeColor = Color.White;
            this.btnThanhToanVayNo.Location = new Point(810, 52);
            this.btnThanhToanVayNo.Size = new Size(120, 34);
            this.btnThanhToanVayNo.Text = "✅ Đã Trả Nợ";
            this.btnThanhToanVayNo.UseVisualStyleBackColor = false;
            this.btnThanhToanVayNo.Click += new EventHandler(this.btnThanhToanVayNo_Click);

            this.dgvVayNo.AllowUserToAddRows = false;
            this.dgvVayNo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVayNo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVayNo.ColumnHeadersHeight = 36;
            this.dgvVayNo.Location = new Point(15, 95);
            this.dgvVayNo.ReadOnly = true;
            this.dgvVayNo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvVayNo.Size = new Size(925, 335);

            // Tab 2: Đầu Tư
            this.tabDauTu.Text = "📈 Portfolio Đầu Tư (Vàng, CP, BĐS) & ROI";
            this.tabDauTu.Controls.Add(this.lblLoaiDauTu);
            this.tabDauTu.Controls.Add(this.cboLoaiDauTu);
            this.tabDauTu.Controls.Add(this.lblTenTaiSan);
            this.tabDauTu.Controls.Add(this.txtTenTaiSan);
            this.tabDauTu.Controls.Add(this.lblGiaVon);
            this.tabDauTu.Controls.Add(this.txtGiaVon);
            this.tabDauTu.Controls.Add(this.lblGiaTriHienTai);
            this.tabDauTu.Controls.Add(this.txtGiaTriHienTai);
            this.tabDauTu.Controls.Add(this.lblSoLuong);
            this.tabDauTu.Controls.Add(this.txtSoLuong);
            this.tabDauTu.Controls.Add(this.lblGhiChuDauTu);
            this.tabDauTu.Controls.Add(this.txtGhiChuDauTu);
            this.tabDauTu.Controls.Add(this.btnThemDauTu);
            this.tabDauTu.Controls.Add(this.dgvDauTu);

            this.lblLoaiDauTu.Font = new Font("Segoe UI", 9.5F);
            this.lblLoaiDauTu.Location = new Point(15, 18);
            this.lblLoaiDauTu.Text = "Loại tài sản:";
            this.cboLoaiDauTu.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLoaiDauTu.Font = new Font("Segoe UI", 9.5F);
            this.cboLoaiDauTu.Items.AddRange(new object[] { "Chứng Khoán", "Vàng", "Bất Động Sản", "Crypto", "Tiết Kiệm" });
            this.cboLoaiDauTu.Location = new Point(110, 15);
            this.cboLoaiDauTu.Size = new Size(150, 29);

            this.lblTenTaiSan.Font = new Font("Segoe UI", 9.5F);
            this.lblTenTaiSan.Location = new Point(275, 18);
            this.lblTenTaiSan.Text = "Mã/Tên tài sản:";
            this.txtTenTaiSan.Font = new Font("Segoe UI", 9.5F);
            this.txtTenTaiSan.Location = new Point(385, 15);
            this.txtTenTaiSan.Size = new Size(160, 29);

            this.lblGiaVon.Font = new Font("Segoe UI", 9.5F);
            this.lblGiaVon.Location = new Point(560, 18);
            this.lblGiaVon.Text = "Vốn ban đầu:";
            this.txtGiaVon.Font = new Font("Segoe UI", 9.5F);
            this.txtGiaVon.Location = new Point(655, 15);
            this.txtGiaVon.Size = new Size(140, 29);

            this.lblSoLuong.Font = new Font("Segoe UI", 9.5F);
            this.lblSoLuong.Location = new Point(805, 18);
            this.lblSoLuong.Text = "SL:";
            this.txtSoLuong.Font = new Font("Segoe UI", 9.5F);
            this.txtSoLuong.Location = new Point(840, 15);
            this.txtSoLuong.Size = new Size(95, 29);
            this.txtSoLuong.Text = "1";

            this.lblGiaTriHienTai.Font = new Font("Segoe UI", 9.5F);
            this.lblGiaTriHienTai.Location = new Point(15, 58);
            this.lblGiaTriHienTai.Text = "Giá trị hiện tại:";
            this.txtGiaTriHienTai.Font = new Font("Segoe UI", 9.5F);
            this.txtGiaTriHienTai.Location = new Point(125, 55);
            this.txtGiaTriHienTai.Size = new Size(150, 29);

            this.lblGhiChuDauTu.Font = new Font("Segoe UI", 9.5F);
            this.lblGhiChuDauTu.Location = new Point(290, 58);
            this.lblGhiChuDauTu.Text = "Ghi chú:";
            this.txtGhiChuDauTu.Font = new Font("Segoe UI", 9.5F);
            this.txtGhiChuDauTu.Location = new Point(360, 55);
            this.txtGhiChuDauTu.Size = new Size(380, 29);

            this.btnThemDauTu.BackColor = Color.Indigo;
            this.btnThemDauTu.ForeColor = Color.White;
            this.btnThemDauTu.Location = new Point(755, 52);
            this.btnThemDauTu.Size = new Size(180, 34);
            this.btnThemDauTu.Text = "📈 Thêm Khoản Đầu Tư";
            this.btnThemDauTu.UseVisualStyleBackColor = false;
            this.btnThemDauTu.Click += new EventHandler(this.btnThemDauTu_Click);

            this.dgvDauTu.AllowUserToAddRows = false;
            this.dgvDauTu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDauTu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDauTu.ColumnHeadersHeight = 36;
            this.dgvDauTu.Location = new Point(15, 95);
            this.dgvDauTu.ReadOnly = true;
            this.dgvDauTu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDauTu.Size = new Size(925, 335);

            // btnDong
            this.btnDong.BackColor = Color.DimGray;
            this.btnDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDong.ForeColor = Color.White;
            this.btnDong.Location = new Point(840, 580);
            this.btnDong.Size = new Size(140, 38);
            this.btnDong.Text = "❌ Quay Lại";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new EventHandler(this.btnDong_Click);

            // FormDauTuVayNo
            this.ClientSize = new Size(1000, 630);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.lblViInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormDauTuVayNo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Đầu Tư & Theo Dõi Vay Nợ";
            this.Load += new EventHandler(this.FormDauTuVayNo_Load);
            this.tabMain.ResumeLayout(false);
            this.tabVayNo.ResumeLayout(false);
            this.tabVayNo.PerformLayout();
            this.tabDauTu.ResumeLayout(false);
            this.tabDauTu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVayNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDauTu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblViInfo;
        private TabControl tabMain;
        private TabPage tabVayNo;
        private TabPage tabDauTu;

        private Label lblLoaiVayNo;
        private ComboBox cboLoaiVayNo;
        private Label lblDoiTac;
        private TextBox txtDoiTac;
        private Label lblSoTienGoc;
        private TextBox txtSoTienGoc;
        private Label lblLaiSuat;
        private TextBox txtLaiSuat;
        private Label lblGhiChuVayNo;
        private TextBox txtGhiChuVayNo;
        private Button btnThemVayNo;
        private Button btnThanhToanVayNo;
        private DataGridView dgvVayNo;

        private Label lblLoaiDauTu;
        private ComboBox cboLoaiDauTu;
        private Label lblTenTaiSan;
        private TextBox txtTenTaiSan;
        private Label lblGiaVon;
        private TextBox txtGiaVon;
        private Label lblGiaTriHienTai;
        private TextBox txtGiaTriHienTai;
        private Label lblSoLuong;
        private TextBox txtSoLuong;
        private Label lblGhiChuDauTu;
        private TextBox txtGhiChuDauTu;
        private Button btnThemDauTu;
        private DataGridView dgvDauTu;

        private Button btnDong;
    }
}
