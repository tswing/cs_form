namespace WinFormsApp1
{
    partial class BobaeDreamForm
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
            btnBest = new Button();
            dataGridView1 = new DataGridView();
            lblTotalCount = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnBest
            // 
            btnBest.Location = new Point(12, 12);
            btnBest.Name = "btnBest";
            btnBest.Size = new Size(129, 32);
            btnBest.TabIndex = 0;
            btnBest.Text = "베스트 가져오기";
            btnBest.UseVisualStyleBackColor = true;
            btnBest.Click += btnBest_ClickAsync;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 50);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1015, 520);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellValueNeeded += dataGridView1_CellValueNeeded;
            // 
            // lblTotalCount
            // 
            lblTotalCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalCount.AutoSize = true;
            lblTotalCount.Location = new Point(956, 21);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(47, 15);
            lblTotalCount.TabIndex = 2;
            lblTotalCount.Text = "Total: 0";
            // 
            // BobaeDreamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 570);
            Controls.Add(lblTotalCount);
            Controls.Add(dataGridView1);
            Controls.Add(btnBest);
            Name = "BobaeDreamForm";
            Text = "FormBobaeDream";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBest;
        private DataGridView dataGridView1;
        private Label lblTotalCount;
    }
}