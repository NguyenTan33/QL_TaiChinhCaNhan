using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    partial class FormKhoiTaoVi
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
            this.lblViHienTai = new Label();
            this.lblMaChiaSe = new Label();
            this.lblTienBanDau = new Label();
            this.txtTienBanDau = new TextBox();
            this.btnCapNhatTien = new Button();
            this.grpTaoVi = new GroupBox();
            this.lblTenViMoi = new Label();
            this.txtTenViMoi = new TextBox();
            this.lblLoaiVi = new Label();
            this.cboLoaiVi = new ComboBox();
            this.lblTienKhoiTaoMoi = new Label();
            this.txtTienKhoiTaoMoi = new TextBox();
            this.btnTaoVi = new Button();
            this.grpThamGiaVi = new GroupBox();
            this.lblNhapMa = new Label();
            this.txtMaChiaSeThamGia = new TextBox();
            this.btnThamGiaVi = new Button();
            this.dgvDanhSachVi = new DataGridView();
            this.btnChonVi = new Button();
            this.btnDong = new Button();
            this.grpTaoVi.SuspendLayout();
            this.grpThamGiaVi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachVi)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.DarkSlateBlue;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(540, 37);
            this.lblTitle.Text = "💼 KHỞI TẠO SỐ DƯ & QUẢN LÝ VÍ GIA ĐÌNH";

            // lblViHienTai
            this.lblViHienTai.AutoSize = true;
            this.lblViHienTai.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblViHienTai.ForeColor = Color.Navy;
            this.lblViHienTai.Location = new Point(22, 60);
            this.lblViHienTai.Name = "lblViHienTai";
            this.lblViHienTai.Size = new Size(250, 25);
            this.lblViHienTai.Text = "Ví đang chọn: Chưa xác định";

            // lblMaChiaSe
            this.lblMaChiaSe.AutoSize = true;
            this.lblMaChiaSe.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblMaChiaSe.ForeColor = Color.DarkGreen;
            this.lblMaChiaSe.Location = new Point(380, 62);
            this.lblMaChiaSe.Name = "lblMaChiaSe";
            this.lblMaChiaSe.Size = new Size(130, 23);
            this.lblMaChiaSe.Text = "Mã ví chung: ---";

            // lblTienBanDau
            this.lblTienBanDau.AutoSize = true;
            this.lblTienBanDau.Font = new Font("Segoe UI", 10F);
            this.lblTienBanDau.Location = new Point(22, 100);
            this.lblTienBanDau.Name = "lblTienBanDau";
            this.lblTienBanDau.Size = new Size(200, 23);
            this.lblTienBanDau.Text = "Số tiền ban đầu (VNĐ):";

            // txtTienBanDau
            this.txtTienBanDau.Font = new Font("Segoe UI", 10F);
            this.txtTienBanDau.Location = new Point(220, 97);
            this.txtTienBanDau.Name = "txtTienBanDau";
            this.txtTienBanDau.Size = new Size(180, 30);

            // btnCapNhatTien
            this.btnCapNhatTien.BackColor = Color.Teal;
            this.btnCapNhatTien.ForeColor = Color.White;
            this.btnCapNhatTien.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnCapNhatTien.Location = new Point(415, 94);
            this.btnCapNhatTien.Name = "btnCapNhatTien";
            this.btnCapNhatTien.Size = new Size(160, 34);
            this.btnCapNhatTien.Text = "💾 Lưu Số Dư Ban Đầu";
            this.btnCapNhatTien.UseVisualStyleBackColor = false;
            this.btnCapNhatTien.Click += new EventHandler(this.btnCapNhatTien_Click);

            // dgvDanhSachVi
            this.dgvDanhSachVi.AllowUserToAddRows = false;
            this.dgvDanhSachVi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachVi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachVi.Location = new Point(22, 140);
            this.dgvDanhSachVi.Name = "dgvDanhSachVi";
            this.dgvDanhSachVi.ReadOnly = true;
            this.dgvDanhSachVi.RowHeadersWidth = 51;
            this.dgvDanhSachVi.RowTemplate.Height = 29;
            this.dgvDanhSachVi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachVi.Size = new Size(740, 160);

            // btnChonVi
            this.btnChonVi.BackColor = Color.DarkSlateBlue;
            this.btnChonVi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnChonVi.ForeColor = Color.White;
            this.btnChonVi.Location = new Point(22, 308);
            this.btnChonVi.Name = "btnChonVi";
            this.btnChonVi.Size = new Size(200, 38);
            this.btnChonVi.Text = "🔄 Sử Dụng Ví Đang Chọn";
            this.btnChonVi.UseVisualStyleBackColor = false;
            this.btnChonVi.Click += new EventHandler(this.btnChonVi_Click);

            // grpTaoVi
            this.grpTaoVi.Controls.Add(this.lblTenViMoi);
            this.grpTaoVi.Controls.Add(this.txtTenViMoi);
            this.grpTaoVi.Controls.Add(this.lblLoaiVi);
            this.grpTaoVi.Controls.Add(this.cboLoaiVi);
            this.grpTaoVi.Controls.Add(this.lblTienKhoiTaoMoi);
            this.grpTaoVi.Controls.Add(this.txtTienKhoiTaoMoi);
            this.grpTaoVi.Controls.Add(this.btnTaoVi);
            this.grpTaoVi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpTaoVi.Location = new Point(22, 360);
            this.grpTaoVi.Name = "grpTaoVi";
            this.grpTaoVi.Size = new Size(360, 220);
            this.grpTaoVi.TabStop = false;
            this.grpTaoVi.Text = "➕ Tạo Ví Mới / Ví Gia Đình";

            // lblTenViMoi
            this.lblTenViMoi.AutoSize = true;
            this.lblTenViMoi.Font = new Font("Segoe UI", 9F);
            this.lblTenViMoi.Location = new Point(15, 35);
            this.lblTenViMoi.Text = "Tên ví:";
            this.txtTenViMoi.Font = new Font("Segoe UI", 9F);
            this.txtTenViMoi.Location = new Point(130, 32);
            this.txtTenViMoi.Size = new Size(210, 27);

            // lblLoaiVi
            this.lblLoaiVi.AutoSize = true;
            this.lblLoaiVi.Font = new Font("Segoe UI", 9F);
            this.lblLoaiVi.Location = new Point(15, 75);
            this.lblLoaiVi.Text = "Loại ví:";
            this.cboLoaiVi.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLoaiVi.Font = new Font("Segoe UI", 9F);
            this.cboLoaiVi.Items.AddRange(new object[] { "Cá Nhân", "Gia Đình (2+ Người dùng chung)" });
            this.cboLoaiVi.Location = new Point(130, 72);
            this.cboLoaiVi.Size = new Size(210, 28);
            this.cboLoaiVi.SelectedIndex = 1;

            // lblTienKhoiTaoMoi
            this.lblTienKhoiTaoMoi.AutoSize = true;
            this.lblTienKhoiTaoMoi.Font = new Font("Segoe UI", 9F);
            this.lblTienKhoiTaoMoi.Location = new Point(15, 115);
            this.lblTienKhoiTaoMoi.Text = "Tiền ban đầu:";
            this.txtTienKhoiTaoMoi.Font = new Font("Segoe UI", 9F);
            this.txtTienKhoiTaoMoi.Location = new Point(130, 112);
            this.txtTienKhoiTaoMoi.Size = new Size(210, 27);
            this.txtTienKhoiTaoMoi.Text = "0";

            // btnTaoVi
            this.btnTaoVi.BackColor = Color.ForestGreen;
            this.btnTaoVi.ForeColor = Color.White;
            this.btnTaoVi.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnTaoVi.Location = new Point(130, 155);
            this.btnTaoVi.Size = new Size(210, 38);
            this.btnTaoVi.Text = "✨ Tạo Ví Ngay";
            this.btnTaoVi.UseVisualStyleBackColor = false;
            this.btnTaoVi.Click += new EventHandler(this.btnTaoVi_Click);

            // grpThamGiaVi
            this.grpThamGiaVi.Controls.Add(this.lblNhapMa);
            this.grpThamGiaVi.Controls.Add(this.txtMaChiaSeThamGia);
            this.grpThamGiaVi.Controls.Add(this.btnThamGiaVi);
            this.grpThamGiaVi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpThamGiaVi.Location = new Point(400, 360);
            this.grpThamGiaVi.Name = "grpThamGiaVi";
            this.grpThamGiaVi.Size = new Size(360, 220);
            this.grpThamGiaVi.TabStop = false;
            this.grpThamGiaVi.Text = "🔗 Tham Gia Ví Gia Đình Qua Mã";

            // lblNhapMa
            this.lblNhapMa.AutoSize = true;
            this.lblNhapMa.Font = new Font("Segoe UI", 9F);
            this.lblNhapMa.Location = new Point(15, 45);
            this.lblNhapMa.Text = "Nhập Mã Chia Sẻ Ví (6 Ký Tự):";

            // txtMaChiaSeThamGia
            this.txtMaChiaSeThamGia.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.txtMaChiaSeThamGia.CharacterCasing = CharacterCasing.Upper;
            this.txtMaChiaSeThamGia.Location = new Point(15, 80);
            this.txtMaChiaSeThamGia.Size = new Size(330, 34);

            // btnThamGiaVi
            this.btnThamGiaVi.BackColor = Color.OrangeRed;
            this.btnThamGiaVi.ForeColor = Color.White;
            this.btnThamGiaVi.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnThamGiaVi.Location = new Point(15, 135);
            this.btnThamGiaVi.Size = new Size(330, 38);
            this.btnThamGiaVi.Text = "🤝 Đăng Ký Tham Gia Ví";
            this.btnThamGiaVi.UseVisualStyleBackColor = false;
            this.btnThamGiaVi.Click += new EventHandler(this.btnThamGiaVi_Click);

            // btnDong
            this.btnDong.BackColor = Color.DimGray;
            this.btnDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDong.ForeColor = Color.White;
            this.btnDong.Location = new Point(620, 595);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new Size(140, 38);
            this.btnDong.Text = "❌ Quay Lại";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new EventHandler(this.btnDong_Click);

            // FormKhoiTaoVi
            this.ClientSize = new Size(785, 645);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.grpThamGiaVi);
            this.Controls.Add(this.grpTaoVi);
            this.Controls.Add(this.btnChonVi);
            this.Controls.Add(this.dgvDanhSachVi);
            this.Controls.Add(this.btnCapNhatTien);
            this.Controls.Add(this.txtTienBanDau);
            this.Controls.Add(this.lblTienBanDau);
            this.Controls.Add(this.lblMaChiaSe);
            this.Controls.Add(this.lblViHienTai);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormKhoiTaoVi";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Khởi Tạo Tiền Ban Đầu & Ví Gia Đình";
            this.Load += new EventHandler(this.FormKhoiTaoVi_Load);
            this.grpTaoVi.ResumeLayout(false);
            this.grpTaoVi.PerformLayout();
            this.grpThamGiaVi.ResumeLayout(false);
            this.grpThamGiaVi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachVi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblViHienTai;
        private Label lblMaChiaSe;
        private Label lblTienBanDau;
        private TextBox txtTienBanDau;
        private Button btnCapNhatTien;
        private GroupBox grpTaoVi;
        private Label lblTenViMoi;
        private TextBox txtTenViMoi;
        private Label lblLoaiVi;
        private ComboBox cboLoaiVi;
        private Label lblTienKhoiTaoMoi;
        private TextBox txtTienKhoiTaoMoi;
        private Button btnTaoVi;
        private GroupBox grpThamGiaVi;
        private Label lblNhapMa;
        private TextBox txtMaChiaSeThamGia;
        private Button btnThamGiaVi;
        private DataGridView dgvDanhSachVi;
        private Button btnChonVi;
        private Button btnDong;
    }
}
