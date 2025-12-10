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
            SuspendLayout();
            // 
            // btnDN
            // 
            btnDN.BackColor = Color.DarkOrange;
            btnDN.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDN.Location = new Point(33, 215);
            btnDN.Name = "btnDN";
            btnDN.Size = new Size(126, 38);
            btnDN.TabIndex = 6;
            btnDN.Text = "Đăng Nhập";
            btnDN.UseVisualStyleBackColor = false;
            btnDN.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Orange;
            label1.Location = new Point(101, 9);
            label1.Name = "label1";
            label1.Size = new Size(233, 51);
            label1.TabIndex = 2;
            label1.Text = "Đăng Nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(33, 72);
            label2.Name = "label2";
            label2.Size = new Size(73, 17);
            label2.TabIndex = 3;
            label2.Text = "Tài Khoản:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(33, 141);
            label3.Name = "label3";
            label3.Size = new Size(71, 17);
            label3.TabIndex = 4;
            label3.Text = "Mật Khẩu:";
            // 
            // txtTK
            // 
            txtTK.BorderStyle = BorderStyle.FixedSingle;
            txtTK.Location = new Point(33, 90);
            txtTK.Name = "txtTK";
            txtTK.Size = new Size(360, 27);
            txtTK.TabIndex = 0;
            txtTK.Text = "Admin";
            txtTK.TextChanged += txtTK_TextChanged;
            // 
            // txtMK
            // 
            txtMK.BorderStyle = BorderStyle.FixedSingle;
            txtMK.Location = new Point(33, 161);
            txtMK.MaxLength = 244;
            txtMK.Name = "txtMK";
            txtMK.PasswordChar = '*';
            txtMK.Size = new Size(360, 27);
            txtMK.TabIndex = 6;
            txtMK.TextChanged += txtMK_TextChanged;
            // 
            // btnDK
            // 
            btnDK.BackColor = Color.DarkOrange;
            btnDK.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDK.Location = new Point(267, 215);
            btnDK.Name = "btnDK";
            btnDK.Size = new Size(126, 38);
            btnDK.TabIndex = 7;
            btnDK.Text = "Đăng Ký";
            btnDK.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(427, 279);
            Controls.Add(btnDK);
            Controls.Add(txtMK);
            Controls.Add(txtTK);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDN);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
    }
}
