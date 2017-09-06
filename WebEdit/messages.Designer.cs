namespace htmlEditor
{
    partial class messages
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.send = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.displayMessages = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 317);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbMessage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.send);
            this.splitContainer1.Size = new System.Drawing.Size(386, 79);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 0;
            // 
            // rtbMessage
            // 
            this.rtbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessage.Location = new System.Drawing.Point(0, 0);
            this.rtbMessage.MaxLength = 350;
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(242, 79);
            this.rtbMessage.TabIndex = 0;
            this.rtbMessage.Text = "";
            // 
            // send
            // 
            this.send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.send.Location = new System.Drawing.Point(23, 22);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(91, 30);
            this.send.TabIndex = 0;
            this.send.Text = "Send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.displayMessages);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 317);
            this.panel1.TabIndex = 1;
            // 
            // displayMessages
            // 
            this.displayMessages.BackColor = System.Drawing.SystemColors.Control;
            this.displayMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayMessages.FormattingEnabled = true;
            this.displayMessages.Location = new System.Drawing.Point(0, 0);
            this.displayMessages.Name = "displayMessages";
            this.displayMessages.Size = new System.Drawing.Size(386, 317);
            this.displayMessages.TabIndex = 0;
            // 
            // messages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 396);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "messages";
            this.Text = "messages";
            this.Load += new System.EventHandler(this.messages_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox displayMessages;
    }
}