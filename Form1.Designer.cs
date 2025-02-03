namespace YouTubeToMP3Converter
{
    partial class Form1
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
            txtURL = new TextBox();
            btnConvert = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // txtURL
            // 
            txtURL.Location = new Point(49, 145);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(745, 35);
            txtURL.TabIndex = 0;
            // 
            // btnConvert
            // 
            btnConvert.Location = new Point(349, 198);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(136, 50);
            btnConvert.TabIndex = 1;
            btnConvert.Text = "Convert";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += btnConvert_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(349, 263);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(136, 30);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status: Ready";
            // 
            // Form1
            // 
            ClientSize = new Size(846, 435);
            Controls.Add(lblStatus);
            Controls.Add(btnConvert);
            Controls.Add(txtURL);
            Name = "Form1";
            Text = "YouTube to MP3 Converter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lblStatus;
    }
}
