namespace htmlEditor
{
    partial class revisions
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
            this.rev1 = new System.Windows.Forms.Button();
            this.rev2 = new System.Windows.Forms.Button();
            this.rev3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.FBD1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // rev1
            // 
            this.rev1.Location = new System.Drawing.Point(100, 50);
            this.rev1.Name = "rev1";
            this.rev1.Size = new System.Drawing.Size(119, 25);
            this.rev1.TabIndex = 0;
            this.rev1.Text = "Latest Revision";
            this.rev1.UseVisualStyleBackColor = true;
            this.rev1.Click += new System.EventHandler(this.rev1_Click);
            // 
            // rev2
            // 
            this.rev2.Location = new System.Drawing.Point(100, 101);
            this.rev2.Name = "rev2";
            this.rev2.Size = new System.Drawing.Size(119, 25);
            this.rev2.TabIndex = 1;
            this.rev2.Text = "Revision 2";
            this.rev2.UseVisualStyleBackColor = true;
            this.rev2.Click += new System.EventHandler(this.rev2_Click);
            // 
            // rev3
            // 
            this.rev3.Location = new System.Drawing.Point(100, 155);
            this.rev3.Name = "rev3";
            this.rev3.Size = new System.Drawing.Size(119, 25);
            this.rev3.TabIndex = 2;
            this.rev3.Text = "Revision 3";
            this.rev3.UseVisualStyleBackColor = true;
            this.rev3.Click += new System.EventHandler(this.rev3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "See up to the last 4 revisions/updates";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Revision 4";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // revisions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 329);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rev3);
            this.Controls.Add(this.rev2);
            this.Controls.Add(this.rev1);
            this.MaximumSize = new System.Drawing.Size(373, 368);
            this.Name = "revisions";
            this.Text = "Revisions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rev1;
        private System.Windows.Forms.Button rev2;
        private System.Windows.Forms.Button rev3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog FBD1;
    }
}