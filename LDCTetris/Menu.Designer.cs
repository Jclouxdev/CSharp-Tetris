namespace LDCTetris
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.start = new System.Windows.Forms.Button();
            this.option = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.start.Location = new System.Drawing.Point(234, 127);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(223, 83);
            this.start.TabIndex = 0;
            this.start.Text = "START";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // option
            // 
            this.option.BackColor = System.Drawing.Color.White;
            this.option.Location = new System.Drawing.Point(234, 237);
            this.option.Name = "option";
            this.option.Size = new System.Drawing.Size(226, 80);
            this.option.TabIndex = 1;
            this.option.Text = "OPTION";
            this.option.UseVisualStyleBackColor = false;
            this.option.Click += new System.EventHandler(this.option_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Red;
            this.exit.Location = new System.Drawing.Point(234, 350);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(228, 72);
            this.exit.TabIndex = 2;
            this.exit.Text = "EXIT";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(689, 623);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.option);
            this.Controls.Add(this.start);
            this.DoubleBuffered = true;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button option;
        private System.Windows.Forms.Button exit;
    }
}