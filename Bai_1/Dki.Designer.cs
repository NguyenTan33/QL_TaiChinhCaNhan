namespace Bai_1
{
    partial class Dki
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTK = new TextBox();
            txtMKmoi = new TextBox();
            txtMK = new TextBox();
            button2 = new Button();
            btnDK = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtGmail = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // txtTK
            // 
            txtTK.Location = new Point(45, 82);
            txtTK.Name = "txtTK";
            txtTK.Size = new Size(272, 27);
            txtTK.TabIndex = 8;
            txtTK.TextChanged += txtTK_TextChanged;
            // 
            // txtMKmoi
            // 
            txtMKmoi.Location = new Point(45, 214);
            txtMKmoi.Name = "txtMKmoi";
            txtMKmoi.PasswordChar = '*';
            txtMKmoi.Size = new Size(272, 27);
            txtMKmoi.TabIndex = 16;
            // 
            // txtMK
            // 
            txtMK.Location = new Point(45, 150);
            txtMK.Name = "txtMK";
            txtMK.PasswordChar = '*';
            txtMK.Size = new Size(272, 27);
            txtMK.TabIndex = 15;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkOrange;
            button2.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(223, 326);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 14;
            button2.Text = "Trở Về";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnDK
            // 
            btnDK.BackColor = Color.DarkOrange;
            btnDK.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDK.Location = new Point(45, 326);
            btnDK.Name = "btnDK";
            btnDK.Size = new Size(94, 29);
            btnDK.TabIndex = 13;
            btnDK.Text = "Đăng Ký";
            btnDK.UseVisualStyleBackColor = false;
            btnDK.Click += btnDK_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(45, 194);
            label4.Name = "label4";
            label4.Size = new Size(173, 17);
            label4.TabIndex = 12;
            label4.Text = "Nhập Lại Mật Khẩu Mới:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(45, 130);
            label3.Name = "label3";
            label3.Size = new Size(110, 17);
            label3.TabIndex = 11;
            label3.Text = "Mật Khẩu Mới:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(45, 62);
            label2.Name = "label2";
            label2.Size = new Size(81, 17);
            label2.TabIndex = 10;
            label2.Text = "Tài Khoản:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(108, 9);
            label1.Name = "label1";
            label1.Size = new Size(147, 38);
            label1.TabIndex = 9;
            label1.Text = "Đăng Ký";
            // 
            // txtGmail
            // 
            txtGmail.Location = new Point(45, 276);
            txtGmail.Name = "txtGmail";
            txtGmail.Size = new Size(272, 27);
            txtGmail.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(45, 256);
            label5.Name = "label5";
            label5.Size = new Size(51, 17);
            label5.TabIndex = 17;
            label5.Text = "Gmail:";
            // 
            // Dki
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 374);
            Controls.Add(txtGmail);
            Controls.Add(label5);
            Controls.Add(txtTK);
            Controls.Add(txtMKmoi);
            Controls.Add(txtMK);
            Controls.Add(button2);
            Controls.Add(btnDK);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(377, 421);
            MinimumSize = new Size(377, 369);
            Name = "Dki";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTK;
        private TextBox txtMKmoi;
        private TextBox txtMK;
        private Button button2;
        private Button btnDK;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtGmail;
        private Label label5;
    }
}