namespace LDCTetris
{
    partial class option_page
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
            this.easy = new System.Windows.Forms.Button();
            this.medium = new System.Windows.Forms.Button();
            this.hard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // easy
            // 
            this.easy.BackColor = System.Drawing.Color.Lime;
            this.easy.Location = new System.Drawing.Point(230, 127);
            this.easy.Name = "easy";
            this.easy.Size = new System.Drawing.Size(238, 77);
            this.easy.TabIndex = 0;
            this.easy.Text = "EASY";
            this.easy.UseVisualStyleBackColor = false;
            this.easy.Click += new System.EventHandler(this.easy_Click);
            // 
            // medium
            // 
            this.medium.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.medium.Location = new System.Drawing.Point(230, 255);
            this.medium.Name = "medium";
            this.medium.Size = new System.Drawing.Size(241, 75);
            this.medium.TabIndex = 1;
            this.medium.Text = "MEDIUM";
            this.medium.UseVisualStyleBackColor = false;
            this.medium.Click += new System.EventHandler(this.medium_Click);
            // 
            // hard
            // 
            this.hard.BackColor = System.Drawing.Color.Red;
            this.hard.Location = new System.Drawing.Point(230, 376);
            this.hard.Name = "hard";
            this.hard.Size = new System.Drawing.Size(241, 76);
            this.hard.TabIndex = 2;
            this.hard.Text = "HARD";
            this.hard.UseVisualStyleBackColor = false;
            this.hard.Click += new System.EventHandler(this.hard_Click);
            // 
            // option_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 643);
            this.Controls.Add(this.hard);
            this.Controls.Add(this.medium);
            this.Controls.Add(this.easy);
            this.Name = "option_page";
            this.Text = "option_page";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button easy;
        private System.Windows.Forms.Button medium;
        private System.Windows.Forms.Button hard;
    }
}