namespace Bai_1
{
    partial class Home_Page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home_Page));
            menuStrip1 = new MenuStrip();
            adminToolStripMenuItem = new ToolStripMenuItem();
            QL_User = new ToolStripMenuItem();
            DoiMk = new ToolStripMenuItem();
            Out = new ToolStripMenuItem();
            thuChiToolStripMenuItem = new ToolStripMenuItem();
            ThuNhap = new ToolStripMenuItem();
            ChiTieu = new ToolStripMenuItem();
            thôngTinToolStripMenuItem = new ToolStripMenuItem();
            DKVSD = new ToolStripMenuItem();
            HDSD = new ToolStripMenuItem();
            BanQuyen = new ToolStripMenuItem();
            LienHe = new ToolStripMenuItem();
            label1 = new Label();
            btnInBaoCao = new Button();
            groupBox1 = new GroupBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtTNTB = new TextBox();
            txtTienCon = new TextBox();
            txtCTTB = new TextBox();
            txtTC = new TextBox();
            txtCTTN = new TextBox();
            txtTNTN = new TextBox();
            txtCTNN = new TextBox();
            txtTT = new TextBox();
            txtTNNN = new TextBox();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { adminToolStripMenuItem, thuChiToolStripMenuItem, thôngTinToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { QL_User, DoiMk, Out });
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(67, 24);
            adminToolStripMenuItem.Text = "Admin";
            // 
            // QL_User
            // 
            QL_User.Name = "QL_User";
            QL_User.Size = new Size(230, 26);
            QL_User.Text = "Quản Lý Người Dùng";
            QL_User.Click += QL_User_Click;
            // 
            // DoiMk
            // 
            DoiMk.Name = "DoiMk";
            DoiMk.Size = new Size(230, 26);
            DoiMk.Text = "Đổi Mật Khẩu";
            DoiMk.Click += DoiMk_Click;
            // 
            // Out
            // 
            Out.Name = "Out";
            Out.Size = new Size(230, 26);
            Out.Text = "Thoát";
            Out.Click += Out_Click;
            // 
            // thuChiToolStripMenuItem
            // 
            thuChiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ThuNhap, ChiTieu });
            thuChiToolStripMenuItem.Name = "thuChiToolStripMenuItem";
            thuChiToolStripMenuItem.Size = new Size(72, 24);
            thuChiToolStripMenuItem.Text = "Thu Chi";
            thuChiToolStripMenuItem.Click += thuChiToolStripMenuItem_Click;
            // 
            // ThuNhap
            // 
            ThuNhap.Name = "ThuNhap";
            ThuNhap.Size = new Size(156, 26);
            ThuNhap.Text = "Thu Nhập";
            ThuNhap.Click += ThuNhap_Click;
            // 
            // ChiTieu
            // 
            ChiTieu.Name = "ChiTieu";
            ChiTieu.Size = new Size(156, 26);
            ChiTieu.Text = "Chi Tiêu";
            ChiTieu.Click += ChiTieu_Click;
            // 
            // thôngTinToolStripMenuItem
            // 
            thôngTinToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { DKVSD, HDSD, BanQuyen, LienHe });
            thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            thôngTinToolStripMenuItem.Size = new Size(89, 24);
            thôngTinToolStripMenuItem.Text = "Thông Tin";
            // 
            // DKVSD
            // 
            DKVSD.Name = "DKVSD";
            DKVSD.Size = new Size(250, 26);
            DKVSD.Text = "Điều Khoản Và Sử Dụng";
            // 
            // HDSD
            // 
            HDSD.Name = "HDSD";
            HDSD.Size = new Size(250, 26);
            HDSD.Text = "Hướng Dẫn Sử Dụng";
            // 
            // BanQuyen
            // 
            BanQuyen.Name = "BanQuyen";
            BanQuyen.Size = new Size(250, 26);
            BanQuyen.Text = "Bản Quyền";
            // 
            // LienHe
            // 
            LienHe.Name = "LienHe";
            LienHe.Size = new Size(250, 26);
            LienHe.Text = "Liên Hệ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(324, 34);
            label1.Name = "label1";
            label1.Size = new Size(164, 45);
            label1.TabIndex = 2;
            label1.Text = "Báo Cáo";
            label1.Click += label1_Click;
            // 
            // btnInBaoCao
            // 
            btnInBaoCao.BackColor = Color.Chartreuse;
            btnInBaoCao.ForeColor = Color.DarkSlateGray;
            btnInBaoCao.Location = new Point(694, 50);
            btnInBaoCao.Name = "btnInBaoCao";
            btnInBaoCao.Size = new Size(94, 29);
            btnInBaoCao.TabIndex = 3;
            btnInBaoCao.Text = "In Báo Cáo";
            btnInBaoCao.UseVisualStyleBackColor = false;
            btnInBaoCao.Click += btnInBaoCao_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.CadetBlue;
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtTNTB);
            groupBox1.Controls.Add(txtTienCon);
            groupBox1.Controls.Add(txtCTTB);
            groupBox1.Controls.Add(txtTC);
            groupBox1.Controls.Add(txtCTTN);
            groupBox1.Controls.Add(txtTNTN);
            groupBox1.Controls.Add(txtCTNN);
            groupBox1.Controls.Add(txtTT);
            groupBox1.Controls.Add(txtTNNN);
            groupBox1.Location = new Point(12, 82);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 306);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(605, 33);
            label10.Name = "label10";
            label10.Size = new Size(82, 19);
            label10.TabIndex = 17;
            label10.Text = "Tiền Còn:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label9.Location = new Point(27, 34);
            label9.Name = "label9";
            label9.Size = new Size(84, 19);
            label9.TabIndex = 16;
            label9.Text = "Tổng Thu:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label8.Location = new Point(318, 34);
            label8.Name = "label8";
            label8.Size = new Size(83, 19);
            label8.TabIndex = 15;
            label8.Text = "Tổng Chi:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label7.Location = new Point(27, 165);
            label7.Name = "label7";
            label7.Size = new Size(111, 19);
            label7.TabIndex = 14;
            label7.Text = "Thu Nhập TB:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label6.Location = new Point(318, 100);
            label6.Name = "label6";
            label6.Size = new Size(166, 19);
            label6.TabIndex = 13;
            label6.Text = "Chi Tiêu Nhiều Nhất:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label5.Location = new Point(27, 239);
            label5.Name = "label5";
            label5.Size = new Size(164, 19);
            label5.TabIndex = 12;
            label5.Text = "Thu Nhập Thấp Nhất:";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label4.Location = new Point(27, 100);
            label4.Name = "label4";
            label4.Size = new Size(172, 19);
            label4.TabIndex = 11;
            label4.Text = "Thu Nhập Nhiều Nhất:";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label3.Location = new Point(318, 239);
            label3.Name = "label3";
            label3.Size = new Size(158, 19);
            label3.TabIndex = 10;
            label3.Text = "Chi Tiêu Thấp Nhất:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label2.Location = new Point(318, 165);
            label2.Name = "label2";
            label2.Size = new Size(105, 19);
            label2.TabIndex = 9;
            label2.Text = "Chi Tiêu TB:";
            // 
            // txtTNTB
            // 
            txtTNTB.Enabled = false;
            txtTNTB.Location = new Point(27, 187);
            txtTNTB.Name = "txtTNTB";
            txtTNTB.Size = new Size(243, 27);
            txtTNTB.TabIndex = 8;
            // 
            // txtTienCon
            // 
            txtTienCon.Enabled = false;
            txtTienCon.Location = new Point(605, 56);
            txtTienCon.Name = "txtTienCon";
            txtTienCon.Size = new Size(165, 27);
            txtTienCon.TabIndex = 7;
            // 
            // txtCTTB
            // 
            txtCTTB.Enabled = false;
            txtCTTB.Location = new Point(318, 187);
            txtCTTB.Name = "txtCTTB";
            txtCTTB.Size = new Size(243, 27);
            txtCTTB.TabIndex = 6;
            // 
            // txtTC
            // 
            txtTC.Enabled = false;
            txtTC.Location = new Point(318, 56);
            txtTC.Name = "txtTC";
            txtTC.Size = new Size(239, 27);
            txtTC.TabIndex = 5;
            // 
            // txtCTTN
            // 
            txtCTTN.Enabled = false;
            txtCTTN.Location = new Point(318, 261);
            txtCTTN.Name = "txtCTTN";
            txtCTTN.Size = new Size(243, 27);
            txtCTTN.TabIndex = 4;
            // 
            // txtTNTN
            // 
            txtTNTN.Enabled = false;
            txtTNTN.Location = new Point(27, 261);
            txtTNTN.Name = "txtTNTN";
            txtTNTN.Size = new Size(243, 27);
            txtTNTN.TabIndex = 3;
            // 
            // txtCTNN
            // 
            txtCTNN.Enabled = false;
            txtCTNN.Location = new Point(318, 122);
            txtCTNN.Name = "txtCTNN";
            txtCTNN.Size = new Size(243, 27);
            txtCTNN.TabIndex = 2;
            // 
            // txtTT
            // 
            txtTT.Enabled = false;
            txtTT.Location = new Point(27, 56);
            txtTT.Name = "txtTT";
            txtTT.Size = new Size(243, 27);
            txtTT.TabIndex = 1;
            // 
            // txtTNNN
            // 
            txtTNNN.Enabled = false;
            txtTNNN.Location = new Point(27, 122);
            txtTNNN.Name = "txtTNNN";
            txtTNNN.Size = new Size(243, 27);
            txtTNNN.TabIndex = 0;
            // 
            // Home_Page
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(btnInBaoCao);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MaximumSize = new Size(818, 497);
            MinimumSize = new Size(818, 497);
            Name = "Home_Page";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang Chủ";
            Load += Home_Page_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem QL_User;
        private ToolStripMenuItem LockScreen;
        private ToolStripMenuItem DoiMk;
        private ToolStripMenuItem Out;
        private ToolStripMenuItem thuChiToolStripMenuItem;
        private ToolStripMenuItem ThuNhap;
        private ToolStripMenuItem ChiTieu;
        private ToolStripMenuItem thôngTinToolStripMenuItem;
        private ToolStripMenuItem DKVSD;
        private ToolStripMenuItem HDSD;
        private ToolStripMenuItem BanQuyen;
        private ToolStripMenuItem LienHe;
        private ToolStripMenuItem User;
        private Label label1;
        private Button btnInBaoCao;
        private GroupBox groupBox1;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtTNTB;
        private TextBox txtTienCon;
        private TextBox txtCTTB;
        private TextBox txtTC;
        private TextBox txtCTTN;
        private TextBox txtTNTN;
        private TextBox txtCTNN;
        private TextBox txtTT;
        private TextBox txtTNNN;
        private Label label10;
    }
}