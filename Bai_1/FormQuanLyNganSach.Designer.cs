using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    partial class FormQuanLyNganSach
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
            this.lblThangNam = new Label();
            this.dtpThangNam = new DateTimePicker();
            this.lblDanhMuc = new Label();
            this.cboDanhMuc = new ComboBox();
            this.lblGioiHan = new Label();
            this.txtGioiHan = new TextBox();
            this.btnLuuNganSach = new Button();
            this.dgvNganSach = new DataGridView();
            this.btnDong = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNganSach)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.DarkSlateBlue;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(570, 37);
            this.lblTitle.Text = "🎯 QUẢN LÝ NGÂN SÁCH & CẢNH BÁO CHI TIÊU";

            // lblViInfo
            this.lblViInfo.AutoSize = true;
            this.lblViInfo.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblViInfo.ForeColor = Color.DarkGreen;
            this.lblViInfo.Location = new Point(22, 55);
            this.lblViInfo.Name = "lblViInfo";
            this.lblViInfo.Size = new Size(200, 23);
            this.lblViInfo.Text = "Đang đặt ngân sách ví: ---";

            // lblThangNam
            this.lblThangNam.AutoSize = true;
            this.lblThangNam.Font = new Font("Segoe UI", 9.5F);
            this.lblThangNam.Location = new Point(22, 95);
            this.lblThangNam.Text = "Tháng / Năm:";
            this.dtpThangNam.CustomFormat = "MM/yyyy";
            this.dtpThangNam.Font = new Font("Segoe UI", 9.5F);
            this.dtpThangNam.Format = DateTimePickerFormat.Custom;
            this.dtpThangNam.Location = new Point(130, 92);
            this.dtpThangNam.Size = new Size(130, 29);
            this.dtpThangNam.ValueChanged += new EventHandler(this.dtpThangNam_ValueChanged);

            // lblDanhMuc
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Font = new Font("Segoe UI", 9.5F);
            this.lblDanhMuc.Location = new Point(280, 95);
            this.lblDanhMuc.Text = "Danh mục:";
            this.cboDanhMuc.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Font = new Font("Segoe UI", 9.5F);
            this.cboDanhMuc.Items.AddRange(new object[] {
                "Ăn Uống",
                "Di Chuyển",
                "Mua Sắm",
                "Hóa Đơn & Tiện Ích",
                "Giải Trí",
                "Y Tế & Sức Khỏe",
                "Giáo Dục",
                "Khác (Chi)"
            });
            this.cboDanhMuc.Location = new Point(365, 92);
            this.cboDanhMuc.Size = new Size(170, 29);

            // lblGioiHan
            this.lblGioiHan.AutoSize = true;
            this.lblGioiHan.Font = new Font("Segoe UI", 9.5F);
            this.lblGioiHan.Location = new Point(550, 95);
            this.lblGioiHan.Text = "Hạn mức (VNĐ):";
            this.txtGioiHan.Font = new Font("Segoe UI", 9.5F);
            this.txtGioiHan.Location = new Point(670, 92);
            this.txtGioiHan.Size = new Size(130, 29);

            // btnLuuNganSach
            this.btnLuuNganSach.BackColor = Color.Teal;
            this.btnLuuNganSach.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnLuuNganSach.ForeColor = Color.White;
            this.btnLuuNganSach.Location = new Point(670, 130);
            this.btnLuuNganSach.Size = new Size(130, 34);
            this.btnLuuNganSach.Text = "💾 Thiết Lập";
            this.btnLuuNganSach.UseVisualStyleBackColor = false;
            this.btnLuuNganSach.Click += new EventHandler(this.btnLuuNganSach_Click);

            // dgvNganSach
            this.dgvNganSach.AllowUserToAddRows = false;
            this.dgvNganSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNganSach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNganSach.ColumnHeadersHeight = 36;
            this.dgvNganSach.Location = new Point(22, 175);
            this.dgvNganSach.Name = "dgvNganSach";
            this.dgvNganSach.ReadOnly = true;
            this.dgvNganSach.RowHeadersWidth = 51;
            this.dgvNganSach.RowTemplate.Height = 30;
            this.dgvNganSach.Size = new Size(815, 310);

            // btnDong
            this.btnDong.BackColor = Color.DimGray;
            this.btnDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDong.ForeColor = Color.White;
            this.btnDong.Location = new Point(695, 495);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new Size(140, 38);
            this.btnDong.Text = "❌ Quay Lại";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new EventHandler(this.btnDong_Click);

            // FormQuanLyNganSach
            this.ClientSize = new Size(860, 550);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvNganSach);
            this.Controls.Add(this.btnLuuNganSach);
            this.Controls.Add(this.txtGioiHan);
            this.Controls.Add(this.lblGioiHan);
            this.Controls.Add(this.cboDanhMuc);
            this.Controls.Add(this.lblDanhMuc);
            this.Controls.Add(this.dtpThangNam);
            this.Controls.Add(this.lblThangNam);
            this.Controls.Add(this.lblViInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormQuanLyNganSach";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Ngân Sách & Cảnh Báo Chi Tiêu";
            this.Load += new EventHandler(this.FormQuanLyNganSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNganSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblViInfo;
        private Label lblThangNam;
        private DateTimePicker dtpThangNam;
        private Label lblDanhMuc;
        private ComboBox cboDanhMuc;
        private Label lblGioiHan;
        private TextBox txtGioiHan;
        private Button btnLuuNganSach;
        private DataGridView dgvNganSach;
        private Button btnDong;
    }
}
