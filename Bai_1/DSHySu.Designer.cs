namespace Bai_1
{
    partial class DSHySu
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
            txtSearch = new TextBox();
            label1 = new Label();
            btnSearch = new Button();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            btnOut = new Button();
            btnAllSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(7, 26);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(389, 27);
            txtSearch.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(276, 32);
            label1.TabIndex = 1;
            label1.Text = "Danh Sách Đám Cưới";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(417, 24);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm Kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(160, 163);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 93);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(907, 438);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAllSearch);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Location = new Point(294, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(625, 69);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            // 
            // btnOut
            // 
            btnOut.Location = new Point(12, 6);
            btnOut.Name = "btnOut";
            btnOut.Size = new Size(40, 29);
            btnOut.TabIndex = 6;
            btnOut.Text = "<--";
            btnOut.UseVisualStyleBackColor = true;
            btnOut.Click += btnOut_Click;
            // 
            // btnAllSearch
            // 
            btnAllSearch.Location = new Point(525, 24);
            btnAllSearch.Name = "btnAllSearch";
            btnAllSearch.Size = new Size(94, 29);
            btnAllSearch.TabIndex = 3;
            btnAllSearch.Text = "Tất Cả";
            btnAllSearch.UseVisualStyleBackColor = true;
            btnAllSearch.Click += btnAllSearch_Click;
            // 
            // DSHySu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 543);
            Controls.Add(btnOut);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DSHySu";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private Label label1;
        private Button btnSearch;
        private Label label2;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Button btnOut;
        private Button btnAllSearch;
    }
}