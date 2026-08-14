using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai_1
{
    public partial class FormAIChatbox : Form
    {
        private AIAdvisorEngine _aiEngine = new AIAdvisorEngine();

        public FormAIChatbox()
        {
            InitializeComponent();
        }

        private void FormAIChatbox_Load(object sender, EventArgs e)
        {
            AppendBotMessage("🤖 Xin chào! Tôi là AI Advisor - Cố vấn tài chính thông minh của bạn.\nTôi có thể hỗ trợ bạn phân tích sức khỏe tài chính, dự đoán nguy cơ cạn tiền và đưa ra lời khuyên quản lý thu chi hợp lý.\nHãy chọn câu hỏi gợi ý bên dưới hoặc tự nhập thắc mắc của bạn nhé!");
        }

        private void AppendUserMessage(string text)
        {
            rtbChatLog.SelectionColor = Color.Blue;
            rtbChatLog.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            rtbChatLog.AppendText($"\n👤 Bạn: {text}\n");
            rtbChatLog.ScrollToCaret();
        }

        private void AppendBotMessage(string text)
        {
            rtbChatLog.SelectionColor = Color.DarkGreen;
            rtbChatLog.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            rtbChatLog.AppendText($"\n{text}\n");
            rtbChatLog.ScrollToCaret();
        }

        private void ProcessQuestion(string question)
        {
            if (string.IsNullOrWhiteSpace(question)) return;
            AppendUserMessage(question);
            txtQuestion.Clear();

            string response = _aiEngine.GetChatbotResponse(question, SaveIdUser.CurrentWalletID);
            AppendBotMessage(response);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ProcessQuestion(txtQuestion.Text);
        }

        private void txtQuestion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ProcessQuestion(txtQuestion.Text);
            }
        }

        private void btnGoiYPhanTich_Click(object sender, EventArgs e)
        {
            ProcessQuestion("Phân tích tình hình thu chi tài chính của tôi");
        }

        private void btnGoiYDuDoan_Click(object sender, EventArgs e)
        {
            ProcessQuestion("Dự đoán với số dư hiện tại tôi còn sống được bao nhiêu ngày nữa?");
        }

        private void btnGoiYTietKiem_Click(object sender, EventArgs e)
        {
            ProcessQuestion("Cho tôi lời khuyên tiết kiệm theo quy tắc 50/30/20");
        }

        private void btnGoiYMuaSam_Click(object sender, EventArgs e)
        {
            ProcessQuestion("Tôi có nên mua sắm đồ đắt tiền hoặc mua iPhone mới lúc này không?");
        }

        private void btnGoiYTopChi_Click(object sender, EventArgs e)
        {
            ProcessQuestion("Tháng này tôi tiêu tốn tiền nhiều nhất vào danh mục nào?");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
