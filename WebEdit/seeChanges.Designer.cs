namespace htmlEditor
{
    partial class seeChanges
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
            this.localRtb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.remoteRtb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rejectChanges = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.acceptChanges = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.acceptTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.localRtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteRtb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // localRtb
            // 
            this.localRtb.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.localRtb.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.localRtb.BackBrush = null;
            this.localRtb.CharHeight = 14;
            this.localRtb.CharWidth = 8;
            this.localRtb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.localRtb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.localRtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.localRtb.IsReplaceMode = false;
            this.localRtb.Location = new System.Drawing.Point(0, 0);
            this.localRtb.Name = "localRtb";
            this.localRtb.Paddings = new System.Windows.Forms.Padding(0);
            this.localRtb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.localRtb.ServiceColors = null;
            this.localRtb.Size = new System.Drawing.Size(353, 320);
            this.localRtb.TabIndex = 26;
            this.localRtb.Zoom = 100;
            this.localRtb.SelectionChanged += new System.EventHandler(this.tb_VisibleRangeChanged);
            this.localRtb.VisibleRangeChanged += new System.EventHandler(this.tb_VisibleRangeChanged);
            // 
            // remoteRtb
            // 
            this.remoteRtb.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.remoteRtb.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.remoteRtb.BackBrush = null;
            this.remoteRtb.CharHeight = 14;
            this.remoteRtb.CharWidth = 8;
            this.remoteRtb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.remoteRtb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.remoteRtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.remoteRtb.IsReplaceMode = false;
            this.remoteRtb.Location = new System.Drawing.Point(0, 0);
            this.remoteRtb.Name = "remoteRtb";
            this.remoteRtb.Paddings = new System.Windows.Forms.Padding(0);
            this.remoteRtb.ReadOnly = true;
            this.remoteRtb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.remoteRtb.ServiceColors = null;
            this.remoteRtb.Size = new System.Drawing.Size(365, 320);
            this.remoteRtb.TabIndex = 27;
            this.remoteRtb.Zoom = 100;
            this.remoteRtb.SelectionChanged += new System.EventHandler(this.tb_VisibleRangeChanged);
            this.remoteRtb.VisibleRangeChanged += new System.EventHandler(this.tb_VisibleRangeChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 117);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.localRtb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.remoteRtb);
            this.splitContainer1.Size = new System.Drawing.Size(722, 320);
            this.splitContainer1.SplitterDistance = 353;
            this.splitContainer1.TabIndex = 28;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.rejectChanges);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.acceptChanges);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(722, 111);
            this.splitContainer2.SplitterDistance = 359;
            this.splitContainer2.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Deleted lines";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.BackColor = System.Drawing.Color.Pink;
            this.label7.Location = new System.Drawing.Point(13, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = " ";
            // 
            // rejectChanges
            // 
            this.rejectChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rejectChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rejectChanges.Location = new System.Drawing.Point(80, 34);
            this.rejectChanges.Name = "rejectChanges";
            this.rejectChanges.Size = new System.Drawing.Size(122, 25);
            this.rejectChanges.TabIndex = 37;
            this.rejectChanges.Text = "Reject Changes";
            this.rejectChanges.UseVisualStyleBackColor = true;
            this.rejectChanges.Click += new System.EventHandler(this.rejectChanges_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Local File";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Inserted lines";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.BackColor = System.Drawing.Color.PaleGreen;
            this.label4.Location = new System.Drawing.Point(260, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = " ";
            // 
            // acceptChanges
            // 
            this.acceptChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptChanges.Location = new System.Drawing.Point(118, 34);
            this.acceptChanges.Name = "acceptChanges";
            this.acceptChanges.Size = new System.Drawing.Size(124, 25);
            this.acceptChanges.TabIndex = 36;
            this.acceptChanges.Text = "Accept Changes";
            this.acceptChanges.UseVisualStyleBackColor = true;
            this.acceptChanges.Click += new System.EventHandler(this.acceptChanges_Click);
            this.acceptChanges.MouseHover += new System.EventHandler(this.acceptChanges_MouseHover);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Remote File";
            // 
            // seeChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 437);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(738, 476);
            this.Name = "seeChanges";
            this.Text = "See Changes";
            this.Load += new System.EventHandler(this.seeChanges_Load);
            ((System.ComponentModel.ISupportInitialize)(this.localRtb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteRtb)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private FastColoredTextBoxNS.FastColoredTextBox localRtb;
        private FastColoredTextBoxNS.FastColoredTextBox remoteRtb;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button rejectChanges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button acceptChanges;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip acceptTip;
    }
}