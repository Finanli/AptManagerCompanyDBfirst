namespace AptManagerCompanyDBfirst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.unametxt = new System.Windows.Forms.TextBox();
            this.pswtxt = new System.Windows.Forms.TextBox();
            this.enterb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // unametxt
            // 
            this.unametxt.Location = new System.Drawing.Point(355, 254);
            this.unametxt.Name = "unametxt";
            this.unametxt.Size = new System.Drawing.Size(230, 20);
            this.unametxt.TabIndex = 0;
            // 
            // pswtxt
            // 
            this.pswtxt.Location = new System.Drawing.Point(355, 318);
            this.pswtxt.Name = "pswtxt";
            this.pswtxt.PasswordChar = '*';
            this.pswtxt.Size = new System.Drawing.Size(230, 20);
            this.pswtxt.TabIndex = 1;
            // 
            // enterb
            // 
            this.enterb.BackColor = System.Drawing.Color.Transparent;
            this.enterb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.enterb.Location = new System.Drawing.Point(616, 284);
            this.enterb.Name = "enterb";
            this.enterb.Size = new System.Drawing.Size(105, 143);
            this.enterb.TabIndex = 2;
            this.enterb.UseVisualStyleBackColor = false;
            this.enterb.Click += new System.EventHandler(this.enterb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(844, 451);
            this.Controls.Add(this.enterb);
            this.Controls.Add(this.pswtxt);
            this.Controls.Add(this.unametxt);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox unametxt;
        private System.Windows.Forms.TextBox pswtxt;
        private System.Windows.Forms.Button enterb;
    }
}

