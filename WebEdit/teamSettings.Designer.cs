namespace htmlEditor
{
    partial class teamSettings
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
            this.leaveTeam = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.renameTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // leaveTeam
            // 
            this.leaveTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leaveTeam.Location = new System.Drawing.Point(109, 138);
            this.leaveTeam.Margin = new System.Windows.Forms.Padding(4);
            this.leaveTeam.Name = "leaveTeam";
            this.leaveTeam.Size = new System.Drawing.Size(159, 34);
            this.leaveTeam.TabIndex = 0;
            this.leaveTeam.Text = "Leave Team";
            this.leaveTeam.UseVisualStyleBackColor = true;
            this.leaveTeam.Click += new System.EventHandler(this.leaveTeam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Team Settings";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // renameTN
            // 
            this.renameTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renameTN.Location = new System.Drawing.Point(109, 80);
            this.renameTN.Margin = new System.Windows.Forms.Padding(4);
            this.renameTN.Name = "renameTN";
            this.renameTN.Size = new System.Drawing.Size(159, 28);
            this.renameTN.TabIndex = 2;
            this.renameTN.Text = "Rename Team Name";
            this.renameTN.UseVisualStyleBackColor = true;
            this.renameTN.Click += new System.EventHandler(this.renameTN_Click);
            // 
            // teamSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.renameTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.leaveTeam);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "teamSettings";
            this.Text = "teamSettings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.teamSettings_FormClosed);
            this.Load += new System.EventHandler(this.teamSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button leaveTeam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button renameTN;
    }
}