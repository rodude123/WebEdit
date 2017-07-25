namespace htmlEditor
{
    partial class connectToTeam
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
            this.getCode = new System.Windows.Forms.Button();
            this.rtbCode = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.greetMessage = new System.Windows.Forms.Label();
            this.connectTeam = new System.Windows.Forms.Button();
            this.rtbTeamCode = new System.Windows.Forms.RichTextBox();
            this.teamCodeErr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // getCode
            // 
            this.getCode.Cursor = System.Windows.Forms.Cursors.Default;
            this.getCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getCode.Location = new System.Drawing.Point(51, 71);
            this.getCode.Margin = new System.Windows.Forms.Padding(4);
            this.getCode.Name = "getCode";
            this.getCode.Size = new System.Drawing.Size(152, 37);
            this.getCode.TabIndex = 7;
            this.getCode.Text = "Get a team code";
            this.getCode.UseVisualStyleBackColor = true;
            this.getCode.Click += new System.EventHandler(this.getCode_Click);
            // 
            // rtbCode
            // 
            this.rtbCode.EnableAutoDragDrop = true;
            this.rtbCode.Location = new System.Drawing.Point(233, 71);
            this.rtbCode.Margin = new System.Windows.Forms.Padding(4);
            this.rtbCode.Multiline = false;
            this.rtbCode.Name = "rtbCode";
            this.rtbCode.ReadOnly = true;
            this.rtbCode.Size = new System.Drawing.Size(245, 36);
            this.rtbCode.TabIndex = 6;
            this.rtbCode.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Your Team Code";
            this.label1.UseWaitCursor = true;
            // 
            // greetMessage
            // 
            this.greetMessage.AutoSize = true;
            this.greetMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greetMessage.Location = new System.Drawing.Point(229, 126);
            this.greetMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.greetMessage.Name = "greetMessage";
            this.greetMessage.Size = new System.Drawing.Size(0, 20);
            this.greetMessage.TabIndex = 8;
            // 
            // connectTeam
            // 
            this.connectTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectTeam.Location = new System.Drawing.Point(51, 184);
            this.connectTeam.Name = "connectTeam";
            this.connectTeam.Size = new System.Drawing.Size(152, 35);
            this.connectTeam.TabIndex = 9;
            this.connectTeam.Text = "Connect to team";
            this.connectTeam.UseVisualStyleBackColor = true;
            this.connectTeam.Click += new System.EventHandler(this.connectTeam_Click);
            // 
            // rtbTeamCode
            // 
            this.rtbTeamCode.EnableAutoDragDrop = true;
            this.rtbTeamCode.Location = new System.Drawing.Point(233, 183);
            this.rtbTeamCode.Margin = new System.Windows.Forms.Padding(4);
            this.rtbTeamCode.MaxLength = 6;
            this.rtbTeamCode.Multiline = false;
            this.rtbTeamCode.Name = "rtbTeamCode";
            this.rtbTeamCode.Size = new System.Drawing.Size(245, 36);
            this.rtbTeamCode.TabIndex = 10;
            this.rtbTeamCode.Text = "";
            // 
            // teamCodeErr
            // 
            this.teamCodeErr.AutoSize = true;
            this.teamCodeErr.ForeColor = System.Drawing.Color.Red;
            this.teamCodeErr.Location = new System.Drawing.Point(515, 191);
            this.teamCodeErr.Name = "teamCodeErr";
            this.teamCodeErr.Size = new System.Drawing.Size(0, 17);
            this.teamCodeErr.TabIndex = 11;
            // 
            // connectToTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 395);
            this.Controls.Add(this.teamCodeErr);
            this.Controls.Add(this.rtbTeamCode);
            this.Controls.Add(this.connectTeam);
            this.Controls.Add(this.greetMessage);
            this.Controls.Add(this.getCode);
            this.Controls.Add(this.rtbCode);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "connectToTeam";
            this.Text = "connectToTeam";
            this.Load += new System.EventHandler(this.connectToTeam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getCode;
        private System.Windows.Forms.RichTextBox rtbCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label greetMessage;
        private System.Windows.Forms.Button connectTeam;
        private System.Windows.Forms.RichTextBox rtbTeamCode;
        private System.Windows.Forms.Label teamCodeErr;
    }
}