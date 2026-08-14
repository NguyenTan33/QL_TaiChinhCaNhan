using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    partial class FormAIChatbox
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
            this.rtbChatLog = new RichTextBox();
            this.grpGoiY = new GroupBox();
            this.btnGoiYPhanTich = new Button();
            this.btnGoiYDuDoan = new Button();
            this.btnGoiYTietKiem = new Button();
            this.btnGoiYMuaSam = new Button();
            this.btnGoiYTopChi = new Button();
            this.txtQuestion = new TextBox();
            this.btnSend = new Button();
            this.btnDong = new Button();
            this.grpGoiY.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.DarkSlateBlue;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(540, 37);
            this.lblTitle.Text = "🤖 AI ADVISOR & CHATBOX TƯ VẤN TÀI CHÍNH";

            // rtbChatLog
            this.rtbChatLog.BackColor = Color.Ivory;
            this.rtbChatLog.Font = new Font("Segoe UI", 10F);
            this.rtbChatLog.Location = new Point(22, 60);
            this.rtbChatLog.Name = "rtbChatLog";
            this.rtbChatLog.ReadOnly = true;
            this.rtbChatLog.Size = new Size(740, 330);
            this.rtbChatLog.Text = "";

            // grpGoiY
            this.grpGoiY.Controls.Add(this.btnGoiYTopChi);
            this.grpGoiY.Controls.Add(this.btnGoiYMuaSam);
            this.grpGoiY.Controls.Add(this.btnGoiYTietKiem);
            this.grpGoiY.Controls.Add(this.btnGoiYDuDoan);
            this.grpGoiY.Controls.Add(this.btnGoiYPhanTich);
            this.grpGoiY.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.grpGoiY.Location = new Point(22, 400);
            this.grpGoiY.Name = "grpGoiY";
            this.grpGoiY.Size = new Size(740, 75);
            this.grpGoiY.TabStop = false;
            this.grpGoiY.Text = "💡 Gợi ý câu hỏi nhanh cho AI";

            // btnGoiYPhanTich
            this.btnGoiYPhanTich.BackColor = Color.SteelBlue;
            this.btnGoiYPhanTich.ForeColor = Color.White;
            this.btnGoiYPhanTich.Location = new Point(10, 25);
            this.btnGoiYPhanTich.Size = new Size(135, 36);
            this.btnGoiYPhanTich.Text = "📊 Phân tích thu chi";
            this.btnGoiYPhanTich.UseVisualStyleBackColor = false;
            this.btnGoiYPhanTich.Click += new EventHandler(this.btnGoiYPhanTich_Click);

            // btnGoiYDuDoan
            this.btnGoiYDuDoan.BackColor = Color.Teal;
            this.btnGoiYDuDoan.ForeColor = Color.White;
            this.btnGoiYDuDoan.Location = new Point(152, 25);
            this.btnGoiYDuDoan.Size = new Size(135, 36);
            this.btnGoiYDuDoan.Text = "⏳ Dự đoán cạn tiền";
            this.btnGoiYDuDoan.UseVisualStyleBackColor = false;
            this.btnGoiYDuDoan.Click += new EventHandler(this.btnGoiYDuDoan_Click);

            // btnGoiYTietKiem
            this.btnGoiYTietKiem.BackColor = Color.DarkGreen;
            this.btnGoiYTietKiem.ForeColor = Color.White;
            this.btnGoiYTietKiem.Location = new Point(294, 25);
            this.btnGoiYTietKiem.Size = new Size(135, 36);
            this.btnGoiYTietKiem.Text = "💡 Mẹo tiết kiệm";
            this.btnGoiYTietKiem.UseVisualStyleBackColor = false;
            this.btnGoiYTietKiem.Click += new EventHandler(this.btnGoiYTietKiem_Click);

            // btnGoiYMuaSam
            this.btnGoiYMuaSam.BackColor = Color.OrangeRed;
            this.btnGoiYMuaSam.ForeColor = Color.White;
            this.btnGoiYMuaSam.Location = new Point(436, 25);
            this.btnGoiYMuaSam.Size = new Size(140, 36);
            this.btnGoiYMuaSam.Text = "📱 Có nên mua sắm?";
            this.btnGoiYMuaSam.UseVisualStyleBackColor = false;
            this.btnGoiYMuaSam.Click += new EventHandler(this.btnGoiYMuaSam_Click);

            // btnGoiYTopChi
            this.btnGoiYTopChi.BackColor = Color.Purple;
            this.btnGoiYTopChi.ForeColor = Color.White;
            this.btnGoiYTopChi.Location = new Point(583, 25);
            this.btnGoiYTopChi.Size = new Size(145, 36);
            this.btnGoiYTopChi.Text = "🔥 Top danh mục chi";
            this.btnGoiYTopChi.UseVisualStyleBackColor = false;
            this.btnGoiYTopChi.Click += new EventHandler(this.btnGoiYTopChi_Click);

            // txtQuestion
            this.txtQuestion.Font = new Font("Segoe UI", 11F);
            this.txtQuestion.Location = new Point(22, 490);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new Size(580, 32);
            this.txtQuestion.KeyDown += new KeyEventHandler(this.txtQuestion_KeyDown);

            // btnSend
            this.btnSend.BackColor = Color.DarkSlateBlue;
            this.btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSend.ForeColor = Color.White;
            this.btnSend.Location = new Point(610, 488);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new Size(152, 36);
            this.btnSend.Text = "🚀 Gửi Cho AI";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new EventHandler(this.btnSend_Click);

            // btnDong
            this.btnDong.BackColor = Color.DimGray;
            this.btnDong.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDong.ForeColor = Color.White;
            this.btnDong.Location = new Point(622, 540);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new Size(140, 38);
            this.btnDong.Text = "❌ Quay Lại";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new EventHandler(this.btnDong_Click);

            // FormAIChatbox
            this.ClientSize = new Size(785, 590);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.grpGoiY);
            this.Controls.Add(this.rtbChatLog);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormAIChatbox";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AI Advisor & Chatbox Tư Vấn Tài Chính";
            this.Load += new EventHandler(this.FormAIChatbox_Load);
            this.grpGoiY.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private RichTextBox rtbChatLog;
        private GroupBox grpGoiY;
        private Button btnGoiYPhanTich;
        private Button btnGoiYDuDoan;
        private Button btnGoiYTietKiem;
        private Button btnGoiYMuaSam;
        private Button btnGoiYTopChi;
        private TextBox txtQuestion;
        private Button btnSend;
        private Button btnDong;
    }
}
