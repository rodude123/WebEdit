namespace htmlEditor
{
    partial class teamLogin
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
            this.login = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rePasswordErr = new System.Windows.Forms.Label();
            this.passwordErr = new System.Windows.Forms.Label();
            this.emailErr = new System.Windows.Forms.Label();
            this.usernameErr = new System.Windows.Forms.Label();
            this.signUpBtn = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.companySTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rePassSTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.emailSTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.passwordSTxt = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.usernameSTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passHelp = new System.Windows.Forms.ToolTip(this.components);
            this.keepMeSignedIn = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.mainControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // login
            // 
            this.login.AutoSize = true;
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.login.Location = new System.Drawing.Point(204, 9);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(48, 20);
            this.login.TabIndex = 0;
            this.login.Text = "Login";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.login);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 40);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mainControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(481, 386);
            this.panel2.TabIndex = 2;
            // 
            // mainControl
            // 
            this.mainControl.Controls.Add(this.tabPage1);
            this.mainControl.Controls.Add(this.tabPage2);
            this.mainControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainControl.Location = new System.Drawing.Point(0, 0);
            this.mainControl.Name = "mainControl";
            this.mainControl.SelectedIndex = 0;
            this.mainControl.Size = new System.Drawing.Size(481, 386);
            this.mainControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPage1.Controls.Add(this.keepMeSignedIn);
            this.tabPage1.Controls.Add(this.maskedTextBox1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.usernameTxt);
            this.tabPage1.Controls.Add(this.loginBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(473, 360);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(102, 110);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.PasswordChar = '*';
            this.maskedTextBox1.Size = new System.Drawing.Size(147, 20);
            this.maskedTextBox1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(146, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username: ";
            // 
            // usernameTxt
            // 
            this.usernameTxt.Location = new System.Drawing.Point(102, 66);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(147, 20);
            this.usernameTxt.TabIndex = 1;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(139, 165);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 0;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.rePasswordErr);
            this.tabPage2.Controls.Add(this.passwordErr);
            this.tabPage2.Controls.Add(this.emailErr);
            this.tabPage2.Controls.Add(this.usernameErr);
            this.tabPage2.Controls.Add(this.signUpBtn);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.companySTxt);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.rePassSTxt);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.emailSTxt);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.passwordSTxt);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.usernameSTxt);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(473, 360);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sign Up";
            // 
            // rePasswordErr
            // 
            this.rePasswordErr.AutoSize = true;
            this.rePasswordErr.ForeColor = System.Drawing.Color.Red;
            this.rePasswordErr.Location = new System.Drawing.Point(306, 193);
            this.rePasswordErr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rePasswordErr.Name = "rePasswordErr";
            this.rePasswordErr.Size = new System.Drawing.Size(0, 13);
            this.rePasswordErr.TabIndex = 25;
            // 
            // passwordErr
            // 
            this.passwordErr.AutoSize = true;
            this.passwordErr.ForeColor = System.Drawing.Color.Red;
            this.passwordErr.Location = new System.Drawing.Point(306, 160);
            this.passwordErr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.passwordErr.Name = "passwordErr";
            this.passwordErr.Size = new System.Drawing.Size(0, 13);
            this.passwordErr.TabIndex = 24;
            // 
            // emailErr
            // 
            this.emailErr.AutoSize = true;
            this.emailErr.ForeColor = System.Drawing.Color.Red;
            this.emailErr.Location = new System.Drawing.Point(306, 124);
            this.emailErr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailErr.Name = "emailErr";
            this.emailErr.Size = new System.Drawing.Size(0, 13);
            this.emailErr.TabIndex = 23;
            // 
            // usernameErr
            // 
            this.usernameErr.AutoSize = true;
            this.usernameErr.ForeColor = System.Drawing.Color.Red;
            this.usernameErr.Location = new System.Drawing.Point(306, 91);
            this.usernameErr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.usernameErr.Name = "usernameErr";
            this.usernameErr.Size = new System.Drawing.Size(0, 13);
            this.usernameErr.TabIndex = 22;
            // 
            // signUpBtn
            // 
            this.signUpBtn.Location = new System.Drawing.Point(166, 264);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Size = new System.Drawing.Size(81, 21);
            this.signUpBtn.TabIndex = 21;
            this.signUpBtn.Text = "Sign Up";
            this.signUpBtn.UseVisualStyleBackColor = true;
            this.signUpBtn.Click += new System.EventHandler(this.signUpBtn_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(286, 193);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 20);
            this.label14.TabIndex = 20;
            this.label14.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(286, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 20);
            this.label13.TabIndex = 19;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(286, 124);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(286, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "*";
            // 
            // companySTxt
            // 
            this.companySTxt.Location = new System.Drawing.Point(133, 227);
            this.companySTxt.Name = "companySTxt";
            this.companySTxt.Size = new System.Drawing.Size(147, 20);
            this.companySTxt.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 227);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Company:";
            // 
            // rePassSTxt
            // 
            this.rePassSTxt.Location = new System.Drawing.Point(133, 193);
            this.rePassSTxt.Name = "rePassSTxt";
            this.rePassSTxt.Size = new System.Drawing.Size(147, 20);
            this.rePassSTxt.TabIndex = 14;
            this.rePassSTxt.MouseHover += new System.EventHandler(this.rePassSTxt_MouseHover);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Re-type password:";
            this.label9.MouseHover += new System.EventHandler(this.label9_MouseHover);
            // 
            // emailSTxt
            // 
            this.emailSTxt.Location = new System.Drawing.Point(133, 124);
            this.emailSTxt.Name = "emailSTxt";
            this.emailSTxt.Size = new System.Drawing.Size(147, 20);
            this.emailSTxt.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "E-mail:";
            // 
            // passwordSTxt
            // 
            this.passwordSTxt.Location = new System.Drawing.Point(133, 160);
            this.passwordSTxt.Name = "passwordSTxt";
            this.passwordSTxt.PasswordChar = '*';
            this.passwordSTxt.Size = new System.Drawing.Size(147, 20);
            this.passwordSTxt.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Password: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Username: ";
            // 
            // usernameSTxt
            // 
            this.usernameSTxt.Location = new System.Drawing.Point(133, 91);
            this.usernameSTxt.Name = "usernameSTxt";
            this.usernameSTxt.Size = new System.Drawing.Size(147, 20);
            this.usernameSTxt.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 26);
            this.label4.TabIndex = 1;
            this.label4.Text = "Haven\'t got an account yet sign up now\r\n to use team services and functions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(192, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Sign Up";
            // 
            // passHelp
            // 
            this.passHelp.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.passHelp.ToolTipTitle = "Password complexity";
            // 
            // keepMeSignedIn
            // 
            this.keepMeSignedIn.AutoSize = true;
            this.keepMeSignedIn.Location = new System.Drawing.Point(58, 142);
            this.keepMeSignedIn.Name = "keepMeSignedIn";
            this.keepMeSignedIn.Size = new System.Drawing.Size(112, 17);
            this.keepMeSignedIn.TabIndex = 7;
            this.keepMeSignedIn.TabStop = true;
            this.keepMeSignedIn.Text = "Keep me signed in";
            this.keepMeSignedIn.UseVisualStyleBackColor = true;
            // 
            // teamLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 426);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "teamLogin";
            this.Text = "teamLogin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.mainControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label login;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl mainControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox emailSTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox passwordSTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox usernameSTxt;
        private System.Windows.Forms.TextBox rePassSTxt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox companySTxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button signUpBtn;
        private System.Windows.Forms.Label rePasswordErr;
        private System.Windows.Forms.Label passwordErr;
        private System.Windows.Forms.Label emailErr;
        private System.Windows.Forms.Label usernameErr;
        private System.Windows.Forms.ToolTip passHelp;
        private System.Windows.Forms.RadioButton keepMeSignedIn;
    }
}