namespace htmlEditor
{
    partial class syncToTeam
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.sync = new System.Windows.Forms.Button();
            this.revs = new System.Windows.Forms.Button();
            this.dLProj = new System.Windows.Forms.Button();
            this.syncTip = new System.Windows.Forms.ToolTip(this.components);
            this.revsTip = new System.Windows.Forms.ToolTip(this.components);
            this.dLTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sync with the team";
            // 
            // sync
            // 
            this.sync.Location = new System.Drawing.Point(62, 73);
            this.sync.Name = "sync";
            this.sync.Size = new System.Drawing.Size(102, 27);
            this.sync.TabIndex = 1;
            this.sync.Text = "Sync";
            this.sync.UseVisualStyleBackColor = true;
            this.sync.Click += new System.EventHandler(this.sync_Click);
            this.sync.MouseHover += new System.EventHandler(this.sync_MouseHover);
            // 
            // revs
            // 
            this.revs.Location = new System.Drawing.Point(206, 73);
            this.revs.Name = "revs";
            this.revs.Size = new System.Drawing.Size(102, 27);
            this.revs.TabIndex = 2;
            this.revs.Text = "Revisions";
            this.revs.UseVisualStyleBackColor = true;
            this.revs.Click += new System.EventHandler(this.revs_Click);
            this.revs.MouseHover += new System.EventHandler(this.revs_MouseHover);
            // 
            // dLProj
            // 
            this.dLProj.Location = new System.Drawing.Point(133, 124);
            this.dLProj.Name = "dLProj";
            this.dLProj.Size = new System.Drawing.Size(102, 27);
            this.dLProj.TabIndex = 3;
            this.dLProj.Text = "Download project";
            this.dLProj.UseVisualStyleBackColor = true;
            this.dLProj.Click += new System.EventHandler(this.dLProj_Click);
            this.dLProj.MouseHover += new System.EventHandler(this.dLProj_MouseHover);
            // 
            // syncToTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 347);
            this.Controls.Add(this.dLProj);
            this.Controls.Add(this.revs);
            this.Controls.Add(this.sync);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(432, 386);
            this.Name = "syncToTeam";
            this.Text = "syncToTeam";
            this.Load += new System.EventHandler(this.syncToTeam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sync;
        private System.Windows.Forms.Button revs;
        private System.Windows.Forms.Button dLProj;
        private System.Windows.Forms.ToolTip syncTip;
        private System.Windows.Forms.ToolTip revsTip;
        private System.Windows.Forms.ToolTip dLTip;
    }
}