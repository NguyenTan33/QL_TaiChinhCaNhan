using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    partial class FormQuenMatKhau
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
            this.lblTK = new Label();
            this.txtTK = new TextBox();
            this.btnTimTK = new Button();
            this.lblCauHoi = new Label();
            this.txtCauHoiBaoMat = new TextBox();
            this.lblDapAn = new Label();
            this.txtDapAn = new TextBox();
            this.lblMK = new Label();
            this.txtMK = new TextBox();
            this.btnDatLaiMK = new Button();
            this.btnDong = new Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.DarkSlateBlue;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(420, 35);
            this.lblTitle.Text = "🔑 KHÔI PHỤC & QUÊN MẬT KHẨU";

            // lblTK
            this.lblTK.AutoSize = true;
            this.lblTK.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTK.Location = new Point(22, 65);
            this.lblTK.Name = "lblTK";
            this.lblTK.Text = "Tên tài khoản:";

            // txtTK
            this.txtTK.Font = new Font("Segoe UI", 10F);
            this.txtTK.Location = new Point(160, 62);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new Size(200, 30);

            // btnTimTK
            this.btnTimTK.BackColor = Color.SteelBlue;
            this.btnTimTK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnTimTK.ForeColor = Color.White;
            this.btnTimTK.Location = new Point(370, 60);
            this.btnTimTK.Name = "btnTimTK";
            this.btnTimTK.Size = new Size(95, 33);
            this.btnTimTK.Text = "🔍 Tìm Kiếm";
            this.btnTimTK.UseVisualStyleBackColor = false;
            this.btnTimTK.Click += new EventHandler(this.btnTimTK_Click);

            // lblCauHoi
            this.lblCauHoi.AutoSize = true;
            this.lblCauHoi.Font = new Font("Segoe UI", 10F);
            this.lblCauHoi.Location = new Point(22, 115);
            this.lblCauHoi.Name = "lblCauHoi";
            this.lblCauHoi.Text = "Câu hỏi bảo mật:";

            // txtCauHoiBaoMat
            this.txtCauHoiBaoMat.Font = new Font("Segoe UI", 10F);
            this.txtCauHoiBaoMat.Location = new Point(160, 112);
            this.txtCauHoiBaoMat.Name = "txtCauHoiBaoMat";
            this.txtCauHoiBaoMat.ReadOnly = true;
            this.txtCauHoiBaoMat.Size = new Size(305, 30);

            // lblDapAn
            this.lblDapAn.AutoSize = true;
            this.lblDapAn.Font = new Font("Segoe UI", 10F);
            this.lblDapAn.Location = new Point(22, 165);
            this.lblDapAn.Name = "lblDapAn";
            this.lblDapAn.Text = "Đáp án bảo mật:";

            // txtDapAn
            this.txtDapAn.Font = new Font("Segoe UI", 10F);
            this.txtDapAn.Location = new Point(160, 162);
            this.txtDapAn.Name = "txtDapAn";
            this.txtDapAn.Size = new Size(305, 30);

            // lblMK
            this.lblMK.AutoSize = true;
            this.lblMK.Font = new Font("Segoe UI", 10F);
            this.lblMK.Location = new Point(22, 215);
            this.lblMK.Name = "lblMK";
            this.lblMK.Text = "Mật khẩu mới:";

            // txtMK
            this.txtMK.Font = new Font("Segoe UI", 10F);
            this.txtMK.Location = new Point(160, 212);
            this.txtMK.Name = "txtMK";
            this.txtMK.PasswordChar = '*';
            this.txtMK.Size = new Size(305, 30);

            // btnDatLaiMK
            this.btnDatLaiMK.BackColor = Color.DarkGreen;
            this.btnDatLaiMK.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDatLaiMK.ForeColor = Color.White;
            this.btnDatLaiMK.Location = new Point(160, 265);
            this.btnDatLaiMK.Name = "btnDatLaiMK";
            this.btnDatLaiMK.Size = new Size(180, 38);
            this.btnDatLaiMK.Text = "💾 Lưu Mật Khẩu Mới";
            this.btnDatLaiMK.UseVisualStyleBackColor = false;
            this.btnDatLaiMK.Click += new EventHandler(this.btnDatLaiMK_Click);

            // btnDong
            this.btnDong.BackColor = Color.DimGray;
            this.btnDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDong.ForeColor = Color.White;
            this.btnDong.Location = new Point(355, 265);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new Size(110, 38);
            this.btnDong.Text = "❌ Hủy";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new EventHandler(this.btnDong_Click);

            // FormQuenMatKhau
            this.ClientSize = new Size(490, 325);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnDatLaiMK);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.lblMK);
            this.Controls.Add(this.txtDapAn);
            this.Controls.Add(this.lblDapAn);
            this.Controls.Add(this.txtCauHoiBaoMat);
            this.Controls.Add(this.lblCauHoi);
            this.Controls.Add(this.btnTimTK);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.lblTK);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormQuenMatKhau";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Khôi Phục Mật Khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblTK;
        private TextBox txtTK;
        private Button btnTimTK;
        private Label lblCauHoi;
        private TextBox txtCauHoiBaoMat;
        private Label lblDapAn;
        private TextBox txtDapAn;
        private Label lblMK;
        private TextBox txtMK;
        private Button btnDatLaiMK;
        private Button btnDong;
    }
}
