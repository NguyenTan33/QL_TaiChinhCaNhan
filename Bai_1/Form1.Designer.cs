namespace Bai_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnDN = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTK = new TextBox();
            txtMK = new TextBox();
            btnDK = new Button();
            btnQuenMK = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(115, 12);
            label1.Name = "label1";
            label1.Size = new Size(195, 46);
            label1.TabIndex = 0;
            label1.Text = "ĐĂNG NHẬP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label2.Location = new Point(33, 70);
            label2.Name = "label2";
            label2.Size = new Size(118, 21);
            label2.Text = "Tên Tài Khoản:";
            // 
            // txtTK
            // 
            txtTK.Font = new Font("Segoe UI", 10F);
            txtTK.Location = new Point(33, 95);
            txtTK.Name = "txtTK";
            txtTK.Size = new Size(360, 30);
            txtTK.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            label3.Location = new Point(33, 138);
            label3.Name = "label3";
            label3.Size = new Size(88, 21);
            label3.Text = "Mật Khẩu:";
            // 
            // txtMK
            // 
            txtMK.Font = new Font("Segoe UI", 10F);
            txtMK.Location = new Point(33, 163);
            txtMK.Name = "txtMK";
            txtMK.PasswordChar = '*';
            txtMK.Size = new Size(360, 30);
            txtMK.TabIndex = 1;
            // 
            // btnDN
            // 
            btnDN.BackColor = Color.DarkOrange;
            btnDN.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDN.ForeColor = Color.White;
            btnDN.Location = new Point(33, 215);
            btnDN.Name = "btnDN";
            btnDN.Size = new Size(115, 40);
            btnDN.TabIndex = 2;
            btnDN.Text = "🔑 Đăng Nhập";
            btnDN.UseVisualStyleBackColor = false;
            btnDN.Click += button1_Click;
            // 
            // btnDK
            // 
            btnDK.BackColor = Color.Teal;
            btnDK.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDK.ForeColor = Color.White;
            btnDK.Location = new Point(158, 215);
            btnDK.Name = "btnDK";
            btnDK.Size = new Size(115, 40);
            btnDK.TabIndex = 3;
            btnDK.Text = "📝 Đăng Ký";
            btnDK.UseVisualStyleBackColor = false;
            btnDK.Click += btnDk_Click;
            // 
            // btnQuenMK
            // 
            btnQuenMK.BackColor = Color.SteelBlue;
            btnQuenMK.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnQuenMK.ForeColor = Color.White;
            btnQuenMK.Location = new Point(283, 215);
            btnQuenMK.Name = "btnQuenMK";
            btnQuenMK.Size = new Size(110, 40);
            btnQuenMK.TabIndex = 4;
            btnQuenMK.Text = "❓ Quên MK";
            btnQuenMK.UseVisualStyleBackColor = false;
            btnQuenMK.Click += btnQuenMK_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(427, 279);
            Controls.Add(btnQuenMK);
            Controls.Add(btnDK);
            Controls.Add(txtMK);
            Controls.Add(txtTK);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDN);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(445, 326);
            MinimumSize = new Size(445, 326);
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDN;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTK;
        private TextBox txtMK;
        private Button btnDK;
        private Button btnQuenMK;
    }
}
