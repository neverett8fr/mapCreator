namespace WindowsFormsApp1
{
    partial class FRMMap
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BTNMapSubmit = new System.Windows.Forms.Button();
            this.PGBMapProgress = new System.Windows.Forms.ProgressBar();
            this.SCRMapSize = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 372);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BTNMapSubmit
            // 
            this.BTNMapSubmit.Location = new System.Drawing.Point(468, 390);
            this.BTNMapSubmit.Name = "BTNMapSubmit";
            this.BTNMapSubmit.Size = new System.Drawing.Size(100, 48);
            this.BTNMapSubmit.TabIndex = 1;
            this.BTNMapSubmit.Text = "Submit";
            this.BTNMapSubmit.UseVisualStyleBackColor = true;
            this.BTNMapSubmit.Click += new System.EventHandler(this.BTNMapSubmit_Click);
            // 
            // PGBMapProgress
            // 
            this.PGBMapProgress.Location = new System.Drawing.Point(574, 390);
            this.PGBMapProgress.Name = "PGBMapProgress";
            this.PGBMapProgress.Size = new System.Drawing.Size(214, 48);
            this.PGBMapProgress.TabIndex = 2;
            // 
            // SCRMapSize
            // 
            this.SCRMapSize.Location = new System.Drawing.Point(12, 390);
            this.SCRMapSize.Name = "SCRMapSize";
            this.SCRMapSize.Size = new System.Drawing.Size(453, 48);
            this.SCRMapSize.TabIndex = 3;
            // 
            // FRMMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SCRMapSize);
            this.Controls.Add(this.PGBMapProgress);
            this.Controls.Add(this.BTNMapSubmit);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FRMMap";
            this.Text = "Map Creator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BTNMapSubmit;
        private System.Windows.Forms.ProgressBar PGBMapProgress;
        private System.Windows.Forms.HScrollBar SCRMapSize;
    }
}

