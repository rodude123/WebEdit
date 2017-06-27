namespace htmlEditor
{
    partial class htmlFormBuilder
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textarea = new System.Windows.Forms.Label();
            this.select = new System.Windows.Forms.Label();
            this.radio = new System.Windows.Forms.Label();
            this.check = new System.Windows.Forms.Label();
            this.numberRange = new System.Windows.Forms.Label();
            this.mobileNo = new System.Windows.Forms.Label();
            this.inpAdress = new System.Windows.Forms.Label();
            this.inpTxt = new System.Windows.Forms.Label();
            this.inpEmail = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rtb3 = new System.Windows.Forms.RichTextBox();
            this.rtb2 = new System.Windows.Forms.RichTextBox();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.finish = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.finish);
            this.panel1.Controls.Add(this.textarea);
            this.panel1.Controls.Add(this.select);
            this.panel1.Controls.Add(this.radio);
            this.panel1.Controls.Add(this.check);
            this.panel1.Controls.Add(this.numberRange);
            this.panel1.Controls.Add(this.mobileNo);
            this.panel1.Controls.Add(this.inpAdress);
            this.panel1.Controls.Add(this.inpTxt);
            this.panel1.Controls.Add(this.inpEmail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 555);
            this.panel1.TabIndex = 0;
            // 
            // textarea
            // 
            this.textarea.AutoSize = true;
            this.textarea.Location = new System.Drawing.Point(23, 301);
            this.textarea.Name = "textarea";
            this.textarea.Size = new System.Drawing.Size(107, 17);
            this.textarea.TabIndex = 8;
            this.textarea.Text = "Multiline textbox";
            this.textarea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textarea_MouseDown);
            // 
            // select
            // 
            this.select.AutoSize = true;
            this.select.Location = new System.Drawing.Point(23, 269);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(104, 17);
            this.select.TabIndex = 7;
            this.select.Text = "Drop Down List";
            this.select.MouseDown += new System.Windows.Forms.MouseEventHandler(this.select_MouseDown);
            // 
            // radio
            // 
            this.radio.AutoSize = true;
            this.radio.Location = new System.Drawing.Point(23, 199);
            this.radio.Name = "radio";
            this.radio.Size = new System.Drawing.Size(80, 17);
            this.radio.TabIndex = 6;
            this.radio.Text = "Radio Input";
            this.radio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.radio_MouseDown);
            // 
            // check
            // 
            this.check.AutoSize = true;
            this.check.Location = new System.Drawing.Point(23, 231);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(109, 17);
            this.check.TabIndex = 5;
            this.check.Text = "Check Box input";
            this.check.MouseDown += new System.Windows.Forms.MouseEventHandler(this.check_MouseDown);
            // 
            // numberRange
            // 
            this.numberRange.AutoSize = true;
            this.numberRange.Location = new System.Drawing.Point(23, 162);
            this.numberRange.Name = "numberRange";
            this.numberRange.Size = new System.Drawing.Size(104, 17);
            this.numberRange.TabIndex = 4;
            this.numberRange.Text = "Number Range";
            this.numberRange.MouseDown += new System.Windows.Forms.MouseEventHandler(this.numberRange_MouseDown);
            // 
            // mobileNo
            // 
            this.mobileNo.AutoSize = true;
            this.mobileNo.Location = new System.Drawing.Point(23, 128);
            this.mobileNo.Name = "mobileNo";
            this.mobileNo.Size = new System.Drawing.Size(58, 17);
            this.mobileNo.TabIndex = 3;
            this.mobileNo.Text = "Number";
            this.mobileNo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mobileNo_MouseDown);
            // 
            // inpAdress
            // 
            this.inpAdress.AutoSize = true;
            this.inpAdress.Location = new System.Drawing.Point(23, 93);
            this.inpAdress.Name = "inpAdress";
            this.inpAdress.Size = new System.Drawing.Size(87, 17);
            this.inpAdress.TabIndex = 2;
            this.inpAdress.Text = "Input Adress";
            this.inpAdress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inpAdress_MouseDown);
            // 
            // inpTxt
            // 
            this.inpTxt.AutoSize = true;
            this.inpTxt.BackColor = System.Drawing.SystemColors.Control;
            this.inpTxt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.inpTxt.Location = new System.Drawing.Point(23, 21);
            this.inpTxt.Name = "inpTxt";
            this.inpTxt.Size = new System.Drawing.Size(70, 17);
            this.inpTxt.TabIndex = 0;
            this.inpTxt.Text = "Input Text";
            this.inpTxt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inpTxt_MouseDown);
            // 
            // inpEmail
            // 
            this.inpEmail.AutoSize = true;
            this.inpEmail.Location = new System.Drawing.Point(23, 56);
            this.inpEmail.Name = "inpEmail";
            this.inpEmail.Size = new System.Drawing.Size(82, 17);
            this.inpEmail.TabIndex = 1;
            this.inpEmail.Text = "Input E-mail";
            this.inpEmail.DragEnter += new System.Windows.Forms.DragEventHandler(this.inpEmail_DragEnter);
            this.inpEmail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.inpEmail_MouseDown);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rtb3);
            this.panel3.Controls.Add(this.rtb2);
            this.panel3.Controls.Add(this.rtb1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(303, 340);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(598, 215);
            this.panel3.TabIndex = 2;
            // 
            // rtb3
            // 
            this.rtb3.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtb3.Location = new System.Drawing.Point(810, 0);
            this.rtb3.Name = "rtb3";
            this.rtb3.Size = new System.Drawing.Size(405, 215);
            this.rtb3.TabIndex = 2;
            this.rtb3.Text = "";
            // 
            // rtb2
            // 
            this.rtb2.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtb2.Location = new System.Drawing.Point(405, 0);
            this.rtb2.Name = "rtb2";
            this.rtb2.Size = new System.Drawing.Size(405, 215);
            this.rtb2.TabIndex = 1;
            this.rtb2.Text = "";
            // 
            // rtb1
            // 
            this.rtb1.Dock = System.Windows.Forms.DockStyle.Left;
            this.rtb1.Location = new System.Drawing.Point(0, 0);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(405, 215);
            this.rtb1.TabIndex = 0;
            this.rtb1.Text = "";
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel2.Location = new System.Drawing.Point(303, 0);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(598, 340);
            this.panel2.TabIndex = 3;
            this.panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel2_DragDrop);
            this.panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel2_DragEnter);
            // 
            // finish
            // 
            this.finish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finish.Location = new System.Drawing.Point(23, 340);
            this.finish.Name = "finish";
            this.finish.Size = new System.Drawing.Size(104, 30);
            this.finish.TabIndex = 9;
            this.finish.Text = "Finish";
            this.finish.UseVisualStyleBackColor = true;
            this.finish.Click += new System.EventHandler(this.finish_Click);
            // 
            // htmlFormBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 555);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "htmlFormBuilder";
            this.Text = "htmlFormBuilder";
            this.Load += new System.EventHandler(this.htmlFormBuilder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label inpTxt;
        private System.Windows.Forms.Label inpEmail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.RichTextBox rtb3;
        private System.Windows.Forms.RichTextBox rtb2;
        private System.Windows.Forms.Label inpAdress;
        private System.Windows.Forms.Label mobileNo;
        private System.Windows.Forms.Label numberRange;
        private System.Windows.Forms.Label radio;
        private System.Windows.Forms.Label check;
        private System.Windows.Forms.FlowLayoutPanel panel2;
        private System.Windows.Forms.Label textarea;
        private System.Windows.Forms.Label select;
        private System.Windows.Forms.Button finish;
    }
}