namespace Bai_1
{
    partial class Chi_Tieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chi_Tieu));
            label2 = new Label();
            label3 = new Label();
            NgayThang = new DateTimePicker();
            label4 = new Label();
            Result = new DataGridView();
            txtSoTien = new TextBox();
            txtMoTa = new TextBox();
            listDanhMuc = new ComboBox();
            label5 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnDuDoan = new Button();
            btnOut = new Button();
            txtID = new TextBox();
            button1 = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)Result).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(103, 24);
            label2.Name = "label2";
            label2.Size = new Size(90, 19);
            label2.TabIndex = 1;
            label2.Text = "Danh Mục:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(6, 90);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 2;
            label3.Text = "Mô Tả:";
            // 
            // NgayThang
            // 
            NgayThang.Location = new Point(613, 12);
            NgayThang.Name = "NgayThang";
            NgayThang.Size = new Size(250, 27);
            NgayThang.TabIndex = 3;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(263, 24);
            label4.Name = "label4";
            label4.Size = new Size(70, 19);
            label4.TabIndex = 4;
            label4.Text = "Số Tiền:";
            // 
            // Result
            // 
            Result.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Result.BackgroundColor = SystemColors.Menu;
            Result.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Result.Location = new Point(12, 282);
            Result.Name = "Result";
            Result.RowHeadersWidth = 51;
            Result.Size = new Size(851, 246);
            Result.TabIndex = 5;
            // 
            // txtSoTien
            // 
            txtSoTien.Location = new Point(263, 46);
            txtSoTien.MaxLength = 244;
            txtSoTien.Name = "txtSoTien";
            txtSoTien.Size = new Size(218, 27);
            txtSoTien.TabIndex = 1;
            txtSoTien.Text = "0";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(6, 113);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(475, 27);
            txtMoTa.TabIndex = 8;
            txtMoTa.Text = "Trống";
            // 
            // listDanhMuc
            // 
            listDanhMuc.FormattingEnabled = true;
            listDanhMuc.Items.AddRange(new object[] { "Ăn Uống", "Du Lịch", "Sách", "Đi Lại", "Đám Tiệc", "Mua Sắm", "Khám Chữa Bệnh", "Cho Mượn", "Khác" });
            listDanhMuc.Location = new Point(103, 44);
            listDanhMuc.Name = "listDanhMuc";
            listDanhMuc.Size = new Size(122, 28);
            listDanhMuc.TabIndex = 9;
            listDanhMuc.Text = "Ăn Uống";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(12, 262);
            label5.Name = "label5";
            label5.Size = new Size(81, 17);
            label5.TabIndex = 10;
            label5.Text = "Danh Sách:";
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(76, 175, 80);
            btnThem.ForeColor = SystemColors.Control;
            btnThem.Location = new Point(16, 23);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 11;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(255, 193, 7);
            btnSua.ForeColor = SystemColors.Control;
            btnSua.Location = new Point(16, 69);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 12;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(229, 57, 53);
            btnXoa.ForeColor = SystemColors.Control;
            btnXoa.Location = new Point(16, 115);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 13;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnDuDoan
            // 
            btnDuDoan.BackColor = SystemColors.AppWorkspace;
            btnDuDoan.ForeColor = SystemColors.Control;
            btnDuDoan.Location = new Point(183, 23);
            btnDuDoan.Name = "btnDuDoan";
            btnDuDoan.Size = new Size(94, 29);
            btnDuDoan.TabIndex = 15;
            btnDuDoan.Text = "Dự Đoán";
            btnDuDoan.UseVisualStyleBackColor = false;
            btnDuDoan.Click += btnDuDoan_Click;
            // 
            // btnOut
            // 
            btnOut.BackColor = Color.FromArgb(84, 110, 122);
            btnOut.ForeColor = SystemColors.Control;
            btnOut.Location = new Point(183, 115);
            btnOut.Name = "btnOut";
            btnOut.Size = new Size(94, 29);
            btnOut.TabIndex = 16;
            btnOut.Text = "Trở Về";
            btnOut.UseVisualStyleBackColor = false;
            btnOut.Click += btnOut_Click;
            // 
            // txtID
            // 
            txtID.Location = new Point(6, 45);
            txtID.Name = "txtID";
            txtID.Size = new Size(66, 27);
            txtID.TabIndex = 17;
            txtID.Text = "0";
            // 
            // button1
            // 
            button1.BackColor = Color.SkyBlue;
            button1.Location = new Point(580, 12);
            button1.Name = "button1";
            button1.Size = new Size(27, 29);
            button1.TabIndex = 18;
            button1.Text = "☯";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(34, 17);
            label1.TabIndex = 19;
            label1.Text = "ID: ";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(txtSoTien);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtID);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtMoTa);
            groupBox1.Controls.Add(listDanhMuc);
            groupBox1.Location = new Point(12, 79);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(497, 162);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(232, 238, 241);
            groupBox2.BackgroundImageLayout = ImageLayout.None;
            groupBox2.Controls.Add(btnDuDoan);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Controls.Add(btnOut);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Font = new Font("Times New Roman", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(580, 79);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(283, 162);
            groupBox2.TabIndex = 21;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thao Tác:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DarkOrange;
            label6.Location = new Point(12, 23);
            label6.Name = "label6";
            label6.Size = new Size(143, 38);
            label6.TabIndex = 22;
            label6.Text = "Chi Tiêu";
            label6.Click += label6_Click;
            // 
            // Chi_Tieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 249);
            ClientSize = new Size(875, 540);
            Controls.Add(label6);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(Result);
            Controls.Add(NgayThang);
            ForeColor = SystemColors.ActiveCaptionText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(893, 587);
            MinimumSize = new Size(893, 587);
            Name = "Chi_Tieu";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)Result).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private DateTimePicker NgayThang;
        private Label label4;
        private DataGridView Result;
        private TextBox txtSoTien;
        private TextBox txtMoTa;
        private ComboBox listDanhMuc;
        private Label label5;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnDuDoan;
        private Button btnOut;
        private TextBox txtID;
        private Button button1;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label6;
    }
}