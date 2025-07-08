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
            btnBest.Click += this.btnBest_Click;
            // 
            // BobaeDreamForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 570);
            Controls.Add(btnBest);
            Name = "BobaeDreamForm";
            Text = "FormBobaeDream";
            ResumeLayout(false);
        }

        #endregion

        private Button btnBest;
    }
}