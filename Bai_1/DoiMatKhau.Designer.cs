namespace Bai_1
{
    partial class DoiMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiMatKhau));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnDK = new Button();
            button2 = new Button();
            txtMKmoi = new TextBox();
            txtMKmoi2 = new TextBox();
            txtMKcu = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(69, 9);
            label1.Name = "label1";
            label1.Size = new Size(227, 38);
            label1.TabIndex = 0;
            label1.Text = "Đổi Mật Khẩu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(46, 61);
            label2.Name = "label2";
            label2.Size = new Size(102, 17);
            label2.TabIndex = 1;
            label2.Text = "Mật Khẩu Cũ:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(46, 129);
            label3.Name = "label3";
            label3.Size = new Size(110, 17);
            label3.TabIndex = 2;
            label3.Text = "Mật Khẩu Mới:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(46, 193);
            label4.Name = "label4";
            label4.Size = new Size(173, 17);
            label4.TabIndex = 3;
            label4.Text = "Nhập Lại Mật Khẩu Mới:";
            // 
            // btnDK
            // 
            btnDK.BackColor = Color.DarkOrange;
            btnDK.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDK.Location = new Point(46, 267);
            btnDK.Name = "btnDK";
            btnDK.Size = new Size(94, 29);
            btnDK.TabIndex = 4;
            btnDK.Text = "Thay Đổi";
            btnDK.UseVisualStyleBackColor = false;
            btnDK.Click += btnDK_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkOrange;
            button2.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(224, 267);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 5;
            button2.Text = "Trở Về";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // txtMKmoi
            // 
            txtMKmoi.Location = new Point(46, 149);
            txtMKmoi.Name = "txtMKmoi";
            txtMKmoi.PasswordChar = '*';
            txtMKmoi.Size = new Size(272, 27);
            txtMKmoi.TabIndex = 6;
            // 
            // txtMKmoi2
            // 
            txtMKmoi2.Location = new Point(46, 213);
            txtMKmoi2.Name = "txtMKmoi2";
            txtMKmoi2.PasswordChar = '*';
            txtMKmoi2.Size = new Size(272, 27);
            txtMKmoi2.TabIndex = 7;
            // 
            // txtMKcu
            // 
            txtMKcu.Location = new Point(46, 81);
            txtMKcu.Name = "txtMKcu";
            txtMKcu.PasswordChar = '*';
            txtMKcu.Size = new Size(272, 27);
            txtMKcu.TabIndex = 0;
            // 
            // DoiMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 324);
            Controls.Add(txtMKcu);
            Controls.Add(txtMKmoi2);
            Controls.Add(txtMKmoi);
            Controls.Add(button2);
            Controls.Add(btnDK);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "DoiMatKhau";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnDK;
        private Button button2;
        private TextBox txtMKmoi;
        private TextBox txtMKmoi2;
        private TextBox txtMKcu;
    }
}