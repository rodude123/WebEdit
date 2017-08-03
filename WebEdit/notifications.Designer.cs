namespace htmlEditor
{
    partial class notifications
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.notiLable = new System.Windows.Forms.Label();
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(418, 383);
            this.mainPanel.TabIndex = 0;
            // 
            // titlePanel
            // 
            this.titlePanel.Controls.Add(this.notiLable);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(418, 60);
            this.titlePanel.TabIndex = 1;
            // 
            // notiLable
            // 
            this.notiLable.AutoSize = true;
            this.notiLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notiLable.Location = new System.Drawing.Point(151, 19);
            this.notiLable.Name = "notiLable";
            this.notiLable.Size = new System.Drawing.Size(96, 20);
            this.notiLable.TabIndex = 0;
            this.notiLable.Text = "Notifications";
            // 
            // notifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 383);
            this.Controls.Add(this.titlePanel);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(434, 422);
            this.Name = "notifications";
            this.Text = "Notifications";
            this.Load += new System.EventHandler(this.notifications_Load);
            this.Resize += new System.EventHandler(this.notifications_Resize);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label notiLable;
    }
}