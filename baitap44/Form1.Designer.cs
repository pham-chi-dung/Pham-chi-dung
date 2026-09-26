namespace baitap44
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picImage = new PictureBox();
            btnLoadImage = new Button();
            btnExportCSV = new Button();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            SuspendLayout();
            // 
            // picImage
            // 
            picImage.BorderStyle = BorderStyle.FixedSingle;
            picImage.Location = new Point(66, 32);
            picImage.Name = "picImage";
            picImage.Size = new Size(655, 324);
            picImage.TabIndex = 0;
            picImage.TabStop = false;
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(32, 378);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(94, 29);
            btnLoadImage.TabIndex = 1;
            btnLoadImage.Text = "Nạp ảnh";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // btnExportCSV
            // 
            btnExportCSV.Location = new Point(662, 378);
            btnExportCSV.Name = "btnExportCSV";
            btnExportCSV.Size = new Size(94, 29);
            btnExportCSV.TabIndex = 2;
            btnExportCSV.Text = "Xuất CSV";
            btnExportCSV.UseVisualStyleBackColor = true;
            btnExportCSV.Click += btnExportCSV_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExportCSV);
            Controls.Add(btnLoadImage);
            Controls.Add(picImage);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picImage;
        private Button btnLoadImage;
        private Button btnExportCSV;
    }
}
