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
            this.leaveTeam.Location = new System.Drawing.Point(82, 112);
            this.leaveTeam.Name = "leaveTeam";
            this.leaveTeam.Size = new System.Drawing.Size(119, 28);
            this.leaveTeam.TabIndex = 0;
            this.leaveTeam.Text = "Leave Team";
            this.leaveTeam.UseVisualStyleBackColor = true;
            this.leaveTeam.Click += new System.EventHandler(this.leaveTeam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Team Settings";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // renameTN
            // 
            this.renameTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renameTN.Location = new System.Drawing.Point(82, 65);
            this.renameTN.Name = "renameTN";
            this.renameTN.Size = new System.Drawing.Size(119, 23);
            this.renameTN.TabIndex = 2;
            this.renameTN.Text = "Rename Team Name";
            this.renameTN.UseVisualStyleBackColor = true;
            // 
            // teamSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.renameTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.leaveTeam);
            this.Name = "teamSettings";
            this.Text = "teamSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button leaveTeam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button renameTN;
    }
}