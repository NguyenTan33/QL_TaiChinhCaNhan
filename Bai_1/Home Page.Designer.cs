using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    partial class Home_Page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home_Page));
            this.menuStrip1 = new MenuStrip();
            this.adminToolStripMenuItem = new ToolStripMenuItem();
            this.QL_User = new ToolStripMenuItem();
            this.DoiMk = new ToolStripMenuItem();
            this.khóaMànHìnhToolStripMenuItem = new ToolStripMenuItem();
            this.Out = new ToolStripMenuItem();
            this.thuChiToolStripMenuItem = new ToolStripMenuItem();
            this.khoiTaoViToolStripMenuItem = new ToolStripMenuItem();
            this.ThuNhap = new ToolStripMenuItem();
            this.ChiTieu = new ToolStripMenuItem();
            this.nganSachToolStripMenuItem = new ToolStripMenuItem();
            this.dauTuVayNoToolStripMenuItem = new ToolStripMenuItem();
            this.phanTichToolStripMenuItem = new ToolStripMenuItem();
            this.baoCaoXinXoToolStripMenuItem = new ToolStripMenuItem();
            this.aiAdvisorToolStripMenuItem = new ToolStripMenuItem();
            this.thôngTinToolStripMenuItem = new ToolStripMenuItem();
            this.DKVSD = new ToolStripMenuItem();

            this.pnlHeader = new Panel();
            this.lblWelcome = new Label();
            this.lblViActive = new Label();
            this.lblAlertBanner = new Label();

            // Cards Panel
            this.pnlCards = new Panel();
            this.cardTienBanDau = new Panel();
            this.lblT1 = new Label();
            this.lblV1 = new Label();
            this.cardTienHienCo = new Panel();
            this.lblT2 = new Label();
            this.lblV2 = new Label();
            this.cardTongThu = new Panel();
            this.lblT3 = new Label();
            this.lblV3 = new Label();
            this.cardTongChi = new Panel();
            this.lblT4 = new Label();
            this.lblV4 = new Label();
            this.cardThangDu = new Panel();
            this.lblT5 = new Label();
            this.lblV5 = new Label();

            // Quick Shortcuts Panel
            this.grpShortcuts = new GroupBox();
            this.btnNavKhoiTaoVi = new Button();
            this.btnNavThuNhap = new Button();
            this.btnNavChiTieu = new Button();
            this.btnNavNganSach = new Button();
            this.btnNavBaoCao = new Button();
            this.btnNavAIChat = new Button();
            this.btnNavHySu = new Button();

            // Visual Chart & Breakdown Section
            this.grpBieuDo = new GroupBox();
            this.dgvVisualChart = new DataGridView();

            this.menuStrip1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.cardTienBanDau.SuspendLayout();
            this.cardTienHienCo.SuspendLayout();
            this.cardTongThu.SuspendLayout();
            this.cardTongChi.SuspendLayout();
            this.cardThangDu.SuspendLayout();
            this.grpShortcuts.SuspendLayout();
            this.grpBieuDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisualChart)).BeginInit();
            this.SuspendLayout();

            // menuStrip1
            this.menuStrip1.ImageScalingSize = new Size(20, 20);
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
                this.adminToolStripMenuItem,
                this.thuChiToolStripMenuItem,
                this.thôngTinToolStripMenuItem
            });
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new Size(1030, 28);
            this.menuStrip1.TabIndex = 0;

            // adminToolStripMenuItem
            this.adminToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.QL_User,
                this.DoiMk,
                this.khóaMànHìnhToolStripMenuItem,
                this.Out
            });
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new Size(72, 24);
            this.adminToolStripMenuItem.Text = "Cài Đặt";

            this.QL_User.Name = "QL_User";
            this.QL_User.Size = new Size(230, 26);
            this.QL_User.Text = "Quản Lý Người Dùng";
            this.QL_User.Click += new EventHandler(this.QL_User_Click);

            this.DoiMk.Name = "DoiMk";
            this.DoiMk.Size = new Size(230, 26);
            this.DoiMk.Text = "Đổi Mật Khẩu";
            this.DoiMk.Click += new EventHandler(this.DoiMk_Click);

            this.khóaMànHìnhToolStripMenuItem.Name = "khóaMànHìnhToolStripMenuItem";
            this.khóaMànHìnhToolStripMenuItem.Size = new Size(230, 26);
            this.khóaMànHìnhToolStripMenuItem.Text = "Khóa Màn Hình";
            this.khóaMànHìnhToolStripMenuItem.Click += new EventHandler(this.khóaMànHìnhToolStripMenuItem_Click);

            this.Out.Name = "Out";
            this.Out.Size = new Size(230, 26);
            this.Out.Text = "Thoát";
            this.Out.Click += new EventHandler(this.Out_Click);

            // thuChiToolStripMenuItem
            this.thuChiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.khoiTaoViToolStripMenuItem,
                this.ThuNhap,
                this.ChiTieu,
                this.nganSachToolStripMenuItem,
                this.dauTuVayNoToolStripMenuItem,
                this.phanTichToolStripMenuItem,
                this.baoCaoXinXoToolStripMenuItem,
                this.aiAdvisorToolStripMenuItem
            });
            this.thuChiToolStripMenuItem.Name = "thuChiToolStripMenuItem";
            this.thuChiToolStripMenuItem.Size = new Size(128, 24);
            this.thuChiToolStripMenuItem.Text = "Quản Lý Thu Chi";

            this.phanTichToolStripMenuItem.Name = "phanTichToolStripMenuItem";
            this.phanTichToolStripMenuItem.Size = new Size(260, 26);
            this.phanTichToolStripMenuItem.Text = "📈 Phân Tích Dữ Liệu (6 Biểu Đồ)";
            this.phanTichToolStripMenuItem.Click += new EventHandler(this.phanTichToolStripMenuItem_Click);

            this.dauTuVayNoToolStripMenuItem.Name = "dauTuVayNoToolStripMenuItem";
            this.dauTuVayNoToolStripMenuItem.Size = new Size(260, 26);
            this.dauTuVayNoToolStripMenuItem.Text = "💎 Đầu Tư & Theo Dõi Vay Nợ";
            this.dauTuVayNoToolStripMenuItem.Click += new EventHandler(this.dauTuVayNoToolStripMenuItem_Click);

            this.khoiTaoViToolStripMenuItem.Name = "khoiTaoViToolStripMenuItem";
            this.khoiTaoViToolStripMenuItem.Size = new Size(260, 26);
            this.khoiTaoViToolStripMenuItem.Text = "💼 Tiền Ban Đầu & Ví Gia Đình";
            this.khoiTaoViToolStripMenuItem.Click += new EventHandler(this.khoiTaoViToolStripMenuItem_Click);

            this.ThuNhap.Name = "ThuNhap";
            this.ThuNhap.Size = new Size(260, 26);
            this.ThuNhap.Text = "💵 Thu Nhập";
            this.ThuNhap.Click += new EventHandler(this.ThuNhap_Click);

            this.ChiTieu.Name = "ChiTieu";
            this.ChiTieu.Size = new Size(260, 26);
            this.ChiTieu.Text = "📉 Chi Tiêu";
            this.ChiTieu.Click += new EventHandler(this.ChiTieu_Click);

            this.nganSachToolStripMenuItem.Name = "nganSachToolStripMenuItem";
            this.nganSachToolStripMenuItem.Size = new Size(260, 26);
            this.nganSachToolStripMenuItem.Text = "🎯 Quản Lý Ngân Sách";
            this.nganSachToolStripMenuItem.Click += new EventHandler(this.nganSachToolStripMenuItem_Click);

            this.baoCaoXinXoToolStripMenuItem.Name = "baoCaoXinXoToolStripMenuItem";
            this.baoCaoXinXoToolStripMenuItem.Size = new Size(260, 26);
            this.baoCaoXinXoToolStripMenuItem.Text = "📊 Báo Cáo Tài Chính Xịn Xò";
            this.baoCaoXinXoToolStripMenuItem.Click += new EventHandler(this.baoCaoXinXoToolStripMenuItem_Click);

            this.aiAdvisorToolStripMenuItem.Name = "aiAdvisorToolStripMenuItem";
            this.aiAdvisorToolStripMenuItem.Size = new Size(260, 26);
            this.aiAdvisorToolStripMenuItem.Text = "🤖 AI Advisor & Chatbox";
            this.aiAdvisorToolStripMenuItem.Click += new EventHandler(this.aiAdvisorToolStripMenuItem_Click);

            // thôngTinToolStripMenuItem
            this.thôngTinToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { this.DKVSD });
            this.thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            this.thôngTinToolStripMenuItem.Size = new Size(131, 24);
            this.thôngTinToolStripMenuItem.Text = "Quản Lý Sổ Sách";

            this.DKVSD.Name = "DKVSD";
            this.DKVSD.Size = new Size(224, 26);
            this.DKVSD.Text = "🎁 Sổ Hỷ Sự & Trả Lễ";
            this.DKVSD.Click += new EventHandler(this.DKVSD_Click);

            // Header Panel
            this.pnlHeader.BackColor = Color.DarkSlateBlue;
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblViActive);
            this.pnlHeader.Controls.Add(this.lblAlertBanner);
            this.pnlHeader.Location = new Point(15, 36);
            this.pnlHeader.Size = new Size(1000, 70);

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblWelcome.ForeColor = Color.White;
            this.lblWelcome.Location = new Point(15, 8);
            this.lblWelcome.Text = "🏠 TRANG CHỦ QUẢN LÝ TÀI CHÍNH";

            this.lblViActive.AutoSize = true;
            this.lblViActive.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            this.lblViActive.ForeColor = Color.Gold;
            this.lblViActive.Location = new Point(15, 42);
            this.lblViActive.Text = "Ví đang chọn: ---";

            this.lblAlertBanner.AutoSize = true;
            this.lblAlertBanner.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblAlertBanner.ForeColor = Color.Orange;
            this.lblAlertBanner.Location = new Point(560, 42);
            this.lblAlertBanner.Text = "📢 Trạng thái ngân sách: Tốt";

            // Dashboard Cards Panel
            this.pnlCards.Location = new Point(15, 115);
            this.pnlCards.Size = new Size(1000, 95);

            // Card 1: Tiền Ban Đầu
            this.cardTienBanDau.BackColor = Color.Lavender;
            this.cardTienBanDau.BorderStyle = BorderStyle.FixedSingle;
            this.cardTienBanDau.Controls.Add(this.lblV1);
            this.cardTienBanDau.Controls.Add(this.lblT1);
            this.cardTienBanDau.Location = new Point(0, 5);
            this.cardTienBanDau.Size = new Size(190, 85);
            this.lblT1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblT1.Location = new Point(8, 10);
            this.lblT1.Size = new Size(174, 22);
            this.lblT1.Text = "💰 TIỀN BAN ĐẦU";
            this.lblV1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblV1.ForeColor = Color.DarkBlue;
            this.lblV1.Location = new Point(8, 38);
            this.lblV1.Size = new Size(174, 35);
            this.lblV1.Text = "0 VNĐ";

            // Card 2: Tiền Hiện Có
            this.cardTienHienCo.BackColor = Color.Honeydew;
            this.cardTienHienCo.BorderStyle = BorderStyle.FixedSingle;
            this.cardTienHienCo.Controls.Add(this.lblV2);
            this.cardTienHienCo.Controls.Add(this.lblT2);
            this.cardTienHienCo.Location = new Point(202, 5);
            this.cardTienHienCo.Size = new Size(190, 85);
            this.lblT2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblT2.Location = new Point(8, 10);
            this.lblT2.Size = new Size(174, 22);
            this.lblT2.Text = "💵 TIỀN HIỆN CÓ";
            this.lblV2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblV2.ForeColor = Color.DarkGreen;
            this.lblV2.Location = new Point(8, 38);
            this.lblV2.Size = new Size(174, 35);
            this.lblV2.Text = "0 VNĐ";

            // Card 3: Tổng Thu
            this.cardTongThu.BackColor = Color.Azure;
            this.cardTongThu.BorderStyle = BorderStyle.FixedSingle;
            this.cardTongThu.Controls.Add(this.lblV3);
            this.cardTongThu.Controls.Add(this.lblT3);
            this.cardTongThu.Location = new Point(404, 5);
            this.cardTongThu.Size = new Size(190, 85);
            this.lblT3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblT3.Location = new Point(8, 10);
            this.lblT3.Size = new Size(174, 22);
            this.lblT3.Text = "📈 TỔNG THU NHẬP";
            this.lblV3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblV3.ForeColor = Color.Teal;
            this.lblV3.Location = new Point(8, 38);
            this.lblV3.Size = new Size(174, 35);
            this.lblV3.Text = "0 VNĐ";

            // Card 4: Tổng Chi
            this.cardTongChi.BackColor = Color.MistyRose;
            this.cardTongChi.BorderStyle = BorderStyle.FixedSingle;
            this.cardTongChi.Controls.Add(this.lblV4);
            this.cardTongChi.Controls.Add(this.lblT4);
            this.cardTongChi.Location = new Point(606, 5);
            this.cardTongChi.Size = new Size(190, 85);
            this.lblT4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblT4.Location = new Point(8, 10);
            this.lblT4.Size = new Size(174, 22);
            this.lblT4.Text = "📉 TỔNG CHI TIÊU";
            this.lblV4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblV4.ForeColor = Color.DarkRed;
            this.lblV4.Location = new Point(8, 38);
            this.lblV4.Size = new Size(174, 35);
            this.lblV4.Text = "0 VNĐ";

            // Card 5: Thặng Dư
            this.cardThangDu.BackColor = Color.LemonChiffon;
            this.cardThangDu.BorderStyle = BorderStyle.FixedSingle;
            this.cardThangDu.Controls.Add(this.lblV5);
            this.cardThangDu.Controls.Add(this.lblT5);
            this.cardThangDu.Location = new Point(808, 5);
            this.cardThangDu.Size = new Size(190, 85);
            this.lblT5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblT5.Location = new Point(8, 10);
            this.lblT5.Size = new Size(174, 22);
            this.lblT5.Text = "💡 THẶNG DƯ NET";
            this.lblV5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblV5.ForeColor = Color.Purple;
            this.lblV5.Location = new Point(8, 38);
            this.lblV5.Size = new Size(174, 35);
            this.lblV5.Text = "0 VNĐ";

            this.pnlCards.Controls.Add(this.cardTienBanDau);
            this.pnlCards.Controls.Add(this.cardTienHienCo);
            this.pnlCards.Controls.Add(this.cardTongThu);
            this.pnlCards.Controls.Add(this.cardTongChi);
            this.pnlCards.Controls.Add(this.cardThangDu);

            // Shortcuts Group
            this.grpShortcuts.Controls.Add(this.btnNavKhoiTaoVi);
            this.grpShortcuts.Controls.Add(this.btnNavThuNhap);
            this.grpShortcuts.Controls.Add(this.btnNavChiTieu);
            this.grpShortcuts.Controls.Add(this.btnNavNganSach);
            this.grpShortcuts.Controls.Add(this.btnNavBaoCao);
            this.grpShortcuts.Controls.Add(this.btnNavAIChat);
            this.grpShortcuts.Controls.Add(this.btnNavHySu);
            this.grpShortcuts.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpShortcuts.Location = new Point(15, 218);
            this.grpShortcuts.Name = "grpShortcuts";
            this.grpShortcuts.Size = new Size(1000, 85);
            this.grpShortcuts.TabStop = false;
            this.grpShortcuts.Text = "🚀 PHÍM TẮT THAO TÁC NHANH";

            // Nav Buttons
            this.btnNavKhoiTaoVi.BackColor = Color.SlateBlue;
            this.btnNavKhoiTaoVi.ForeColor = Color.White;
            this.btnNavKhoiTaoVi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnNavKhoiTaoVi.Location = new Point(12, 28);
            this.btnNavKhoiTaoVi.Size = new Size(130, 45);
            this.btnNavKhoiTaoVi.Text = "💼 Khởi Tạo Ví";
            this.btnNavKhoiTaoVi.UseVisualStyleBackColor = false;
            this.btnNavKhoiTaoVi.Click += new EventHandler(this.khoiTaoViToolStripMenuItem_Click);

            this.btnNavThuNhap.BackColor = Color.SeaGreen;
            this.btnNavThuNhap.ForeColor = Color.White;
            this.btnNavThuNhap.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnNavThuNhap.Location = new Point(152, 28);
            this.btnNavThuNhap.Size = new Size(130, 45);
            this.btnNavThuNhap.Text = "💵 Ghi Thu Nhập";
            this.btnNavThuNhap.UseVisualStyleBackColor = false;
            this.btnNavThuNhap.Click += new EventHandler(this.ThuNhap_Click);

            this.btnNavChiTieu.BackColor = Color.Crimson;
            this.btnNavChiTieu.ForeColor = Color.White;
            this.btnNavChiTieu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnNavChiTieu.Location = new Point(292, 28);
            this.btnNavChiTieu.Size = new Size(130, 45);
            this.btnNavChiTieu.Text = "📉 Ghi Chi Tiêu";
            this.btnNavChiTieu.UseVisualStyleBackColor = false;
            this.btnNavChiTieu.Click += new EventHandler(this.ChiTieu_Click);

            this.btnNavNganSach.BackColor = Color.Teal;
            this.btnNavNganSach.ForeColor = Color.White;
            this.btnNavNganSach.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnNavNganSach.Location = new Point(432, 28);
            this.btnNavNganSach.Size = new Size(135, 45);
            this.btnNavNganSach.Text = "🎯 Ngân Sách";
            this.btnNavNganSach.UseVisualStyleBackColor = false;
            this.btnNavNganSach.Click += new EventHandler(this.nganSachToolStripMenuItem_Click);

            this.btnNavBaoCao.BackColor = Color.DarkOrange;
            this.btnNavBaoCao.ForeColor = Color.White;
            this.btnNavBaoCao.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnNavBaoCao.Location = new Point(577, 28);
            this.btnNavBaoCao.Size = new Size(135, 45);
            this.btnNavBaoCao.Text = "📊 Báo Cáo Xịn";
            this.btnNavBaoCao.UseVisualStyleBackColor = false;
            this.btnNavBaoCao.Click += new EventHandler(this.baoCaoXinXoToolStripMenuItem_Click);

            this.btnNavAIChat.BackColor = Color.Indigo;
            this.btnNavAIChat.ForeColor = Color.White;
            this.btnNavAIChat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnNavAIChat.Location = new Point(722, 28);
            this.btnNavAIChat.Size = new Size(130, 45);
            this.btnNavAIChat.Text = "🤖 AI Advisor";
            this.btnNavAIChat.UseVisualStyleBackColor = false;
            this.btnNavAIChat.Click += new EventHandler(this.aiAdvisorToolStripMenuItem_Click);

            this.btnNavHySu.BackColor = Color.DarkMagenta;
            this.btnNavHySu.ForeColor = Color.White;
            this.btnNavHySu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnNavHySu.Location = new Point(862, 28);
            this.btnNavHySu.Size = new Size(125, 45);
            this.btnNavHySu.Text = "🎁 Sổ Hỷ Sự";
            this.btnNavHySu.UseVisualStyleBackColor = false;
            this.btnNavHySu.Click += new EventHandler(this.DKVSD_Click);

            // Chart & Visual Breakdown Group
            this.grpBieuDo.Controls.Add(this.dgvVisualChart);
            this.grpBieuDo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.grpBieuDo.Location = new Point(15, 310);
            this.grpBieuDo.Name = "grpBieuDo";
            this.grpBieuDo.Size = new Size(1000, 285);
            this.grpBieuDo.TabStop = false;
            this.grpBieuDo.Text = "📊 BIỂU ĐỒ & TỔNG HỢP CHI TIÊU THEO DANH MỤC";

            // dgvVisualChart
            this.dgvVisualChart.AllowUserToAddRows = false;
            this.dgvVisualChart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisualChart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVisualChart.ColumnHeadersHeight = 36;
            this.dgvVisualChart.Location = new Point(12, 30);
            this.dgvVisualChart.Name = "dgvVisualChart";
            this.dgvVisualChart.ReadOnly = true;
            this.dgvVisualChart.RowHeadersWidth = 51;
            this.dgvVisualChart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvVisualChart.Size = new Size(975, 240);

            // Home_Page Form
            this.ClientSize = new Size(1030, 610);
            this.Controls.Add(this.grpBieuDo);
            this.Controls.Add(this.grpShortcuts);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = (Icon)resources.GetObject("$this.Icon");
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Home_Page";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Trang Chủ Dashboard Quản Lý Tài Chính";
            this.Load += new EventHandler(this.Home_Page_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.cardTienBanDau.ResumeLayout(false);
            this.cardTienHienCo.ResumeLayout(false);
            this.cardTongThu.ResumeLayout(false);
            this.cardTongChi.ResumeLayout(false);
            this.cardThangDu.ResumeLayout(false);
            this.grpShortcuts.ResumeLayout(false);
            this.grpBieuDo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisualChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem QL_User;
        private ToolStripMenuItem DoiMk;
        private ToolStripMenuItem khóaMànHìnhToolStripMenuItem;
        private ToolStripMenuItem Out;
        private ToolStripMenuItem thuChiToolStripMenuItem;
        private ToolStripMenuItem khoiTaoViToolStripMenuItem;
        private ToolStripMenuItem ThuNhap;
        private ToolStripMenuItem ChiTieu;
        private ToolStripMenuItem nganSachToolStripMenuItem;
        private ToolStripMenuItem dauTuVayNoToolStripMenuItem;
        private ToolStripMenuItem phanTichToolStripMenuItem;
        private ToolStripMenuItem baoCaoXinXoToolStripMenuItem;
        private ToolStripMenuItem aiAdvisorToolStripMenuItem;
        private ToolStripMenuItem thôngTinToolStripMenuItem;
        private ToolStripMenuItem DKVSD;

        private Panel pnlHeader;
        private Label lblWelcome;
        private Label lblViActive;
        private Label lblAlertBanner;

        private Panel pnlCards;
        private Panel cardTienBanDau;
        private Label lblT1;
        private Label lblV1;
        private Panel cardTienHienCo;
        private Label lblT2;
        private Label lblV2;
        private Panel cardTongThu;
        private Label lblT3;
        private Label lblV3;
        private Panel cardTongChi;
        private Label lblT4;
        private Label lblV4;
        private Panel cardThangDu;
        private Label lblT5;
        private Label lblV5;

        private GroupBox grpShortcuts;
        private Button btnNavKhoiTaoVi;
        private Button btnNavThuNhap;
        private Button btnNavChiTieu;
        private Button btnNavNganSach;
        private Button btnNavBaoCao;
        private Button btnNavAIChat;
        private Button btnNavHySu;

        private GroupBox grpBieuDo;
        private DataGridView dgvVisualChart;
    }
}