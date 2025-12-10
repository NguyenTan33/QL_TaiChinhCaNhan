namespace Bai_1
{
    partial class Thu_Nhap
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
            label1 = new Label();
            label2 = new Label();
            NgayThang = new DateTimePicker();
            txtThuNhap = new TextBox();
            txtTienHienCo = new TextBox();
            label3 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnDuDoan = new Button();
            btnLoiKhuyen = new Button();
            label4 = new Label();
            Result = new DataGridView();
            Id = new TextBox();
            btnOut = new Button();
            label5 = new Label();
            groupBox1 = new GroupBox();
            label7 = new Label();
            txtKhac = new TextBox();
            groupBox2 = new GroupBox();
            label6 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)Result).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(201, 26);
            label1.Name = "label1";
            label1.Size = new Size(63, 19);
            label1.TabIndex = 0;
            label1.Text = "Lương:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(15, 93);
            label2.Name = "label2";
            label2.Size = new Size(71, 19);
            label2.TabIndex = 1;
            label2.Text = "Thưởng:";
            label2.Click += label2_Click;
            // 
            // NgayThang
            // 
            NgayThang.CalendarForeColor = SystemColors.ActiveCaptionText;
            NgayThang.Location = new Point(613, 12);
            NgayThang.MaxDate = new DateTime(3000, 12, 31, 0, 0, 0, 0);
            NgayThang.MinDate = new DateTime(2024, 1, 25, 23, 59, 59, 999);
            NgayThang.Name = "NgayThang";
            NgayThang.Size = new Size(250, 27);
            NgayThang.TabIndex = 9;
            // 
            // txtThuNhap
            // 
            txtThuNhap.Location = new Point(15, 115);
            txtThuNhap.Name = "txtThuNhap";
            txtThuNhap.Size = new Size(159, 27);
            txtThuNhap.TabIndex = 6;
            txtThuNhap.Text = "0";
            txtThuNhap.TextChanged += txtThuNhap_TextChanged;
            // 
            // txtTienHienCo
            // 
            txtTienHienCo.Location = new Point(201, 48);
            txtTienHienCo.Name = "txtTienHienCo";
            txtTienHienCo.Size = new Size(219, 27);
            txtTienHienCo.TabIndex = 1;
            txtTienHienCo.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkOrange;
            label3.Location = new Point(12, 23);
            label3.Name = "label3";
            label3.Size = new Size(167, 38);
            label3.TabIndex = 6;
            label3.Text = "Thu Nhập";
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(76, 175, 80);
            btnThem.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            btnThem.ForeColor = SystemColors.Control;
            btnThem.Location = new Point(28, 30);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(255, 193, 7);
            btnSua.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            btnSua.ForeColor = SystemColors.Control;
            btnSua.Location = new Point(28, 74);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(229, 57, 53);
            btnXoa.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            btnXoa.ForeColor = SystemColors.Control;
            btnXoa.Location = new Point(28, 115);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnDuDoan
            // 
            btnDuDoan.BackColor = SystemColors.AppWorkspace;
            btnDuDoan.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            btnDuDoan.ForeColor = SystemColors.Control;
            btnDuDoan.Location = new Point(161, 30);
            btnDuDoan.Name = "btnDuDoan";
            btnDuDoan.Size = new Size(94, 29);
            btnDuDoan.TabIndex = 10;
            btnDuDoan.Text = "Dự Đoán";
            btnDuDoan.UseVisualStyleBackColor = false;
            btnDuDoan.Click += btnDuDoan_Click;
            // 
            // btnLoiKhuyen
            // 
            btnLoiKhuyen.BackColor = SystemColors.AppWorkspace;
            btnLoiKhuyen.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            btnLoiKhuyen.ForeColor = SystemColors.Control;
            btnLoiKhuyen.Location = new Point(161, 74);
            btnLoiKhuyen.Name = "btnLoiKhuyen";
            btnLoiKhuyen.Size = new Size(94, 29);
            btnLoiKhuyen.TabIndex = 11;
            btnLoiKhuyen.Text = "Lời Khuyên";
            btnLoiKhuyen.UseVisualStyleBackColor = false;
            btnLoiKhuyen.Click += btnLoiKhuyen_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(537, 10);
            label4.Name = "label4";
            label4.Size = new Size(0, 31);
            label4.TabIndex = 13;
            // 
            // Result
            // 
            Result.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Result.BackgroundColor = SystemColors.Menu;
            Result.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Result.Location = new Point(12, 282);
            Result.Name = "Result";
            Result.RowHeadersWidth = 51;
            Result.Size = new Size(851, 256);
            Result.TabIndex = 14;
            // 
            // Id
            // 
            Id.Location = new Point(15, 48);
            Id.Name = "Id";
            Id.Size = new Size(159, 27);
            Id.TabIndex = 15;
            Id.Text = "0";
            // 
            // btnOut
            // 
            btnOut.BackColor = Color.FromArgb(84, 110, 122);
            btnOut.Font = new Font("Times New Roman", 9F, FontStyle.Bold);
            btnOut.ForeColor = SystemColors.Control;
            btnOut.Location = new Point(161, 115);
            btnOut.Name = "btnOut";
            btnOut.Size = new Size(94, 29);
            btnOut.TabIndex = 16;
            btnOut.Text = "Trở Về";
            btnOut.UseVisualStyleBackColor = false;
            btnOut.Click += btnOut_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(15, 26);
            label5.Name = "label5";
            label5.Size = new Size(33, 19);
            label5.TabIndex = 17;
            label5.Text = "ID:";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtKhac);
            groupBox1.Controls.Add(txtThuNhap);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Id);
            groupBox1.Controls.Add(txtTienHienCo);
            groupBox1.Location = new Point(12, 79);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(439, 166);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(201, 93);
            label7.Name = "label7";
            label7.Size = new Size(52, 19);
            label7.TabIndex = 23;
            label7.Text = "Khác:";
            // 
            // txtKhac
            // 
            txtKhac.Location = new Point(201, 115);
            txtKhac.Name = "txtKhac";
            txtKhac.Size = new Size(219, 27);
            txtKhac.TabIndex = 22;
            txtKhac.Text = "0";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(232, 238, 241);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Controls.Add(btnOut);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnDuDoan);
            groupBox2.Controls.Add(btnLoiKhuyen);
            groupBox2.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(580, 79);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(283, 166);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thao Tác:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 260);
            label6.Name = "label6";
            label6.Size = new Size(91, 19);
            label6.TabIndex = 20;
            label6.Text = "Danh Sách:";
            // 
            // button1
            // 
            button1.BackColor = Color.SkyBlue;
            button1.Location = new Point(580, 12);
            button1.Name = "button1";
            button1.Size = new Size(27, 29);
            button1.TabIndex = 21;
            button1.Text = "☯";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Thu_Nhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 249);
            ClientSize = new Size(875, 540);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(Result);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(NgayThang);
            ForeColor = SystemColors.ActiveCaptionText;
            MaximumSize = new Size(893, 587);
            MinimumSize = new Size(893, 587);
            Name = "Thu_Nhap";
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

        private Label label1;
        private Label label2;
        private DateTimePicker NgayThang;
        private TextBox txtThuNhap;
        private TextBox txtTienHienCo;
        private Label label3;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnDuDoan;
        private Button btnLoiKhuyen;
        private Label label4;
        private DataGridView Result;
        private TextBox Id;
        private Button btnOut;
        private Label label5;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label6;
        private Button button1;
        private Label label7;
        private TextBox txtKhac;
    }
}