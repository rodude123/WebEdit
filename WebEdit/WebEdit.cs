using encDec;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace htmlEditor
{
    public partial class WebEditForm : Form
    {
        string filepath = null;
        public string path = @"";
        #region Syntax Variables
        public MatchCollection tagMatches;
        public MatchCollection attributeMatches;
        public MatchCollection commentMatches;
        public MatchCollection htmlCommentMatches;
        public MatchCollection stringMatches;
        public MatchCollection selectorMatches;
        public MatchCollection globalsMatches;
        public MatchCollection hexValueMatches;
        public MatchCollection keywordMatches;
        public MatchCollection typesAMatches;
        public MatchCollection typesBMatches;
        public MatchCollection otherMatches;
        public MatchCollection specialMatches;
        public MatchCollection variableMatches;
        public MatchCollection conditionMatches;
        #endregion
        public DirectoryInfo[] directories;
        int maxLC = 1;
        int DL = 0;
        int nfCount = 0;
        string lang = "";
        public string username = "";
        public string password = "";
        public string teamName = "";
        public string projPath = "";
        string[] pathSplit;
        string[] toSplit = new string[] { @"\" }; // split string
        Dictionary<int, string> openSaveDict = new Dictionary<int, string>();
        bool js = false;

        public WebEditForm()
        {
            InitializeComponent();
        }

        public WebEditForm(string[] file)
        {
            if (file.Length != 0)
            {
                filepath = file[0];
            }
        }

        //creats a new rich text box element to per new tab to be used in this code like an rtb element placed in the form
        private RichTextBox GetRichTextBox()
        {
            RichTextBox rtb = null;
            TabPage newTP = tabControl1.SelectedTab;
            if (newTP != null)
            {
                rtb = newTP.Controls[0] as RichTextBox;
                rtb.Name = "rtb" + tabControl1.SelectedIndex.ToString();
                rtb.TextChanged += rtb_TextChanged;
                //rtb.AcceptsTab = true;
            }
            return rtb;

        }

        #region Quick buttons

        #region  Quick buttons HTML
        private void img_Click(object sender, EventArgs e)
        {
            try
            {
                if (path == "")
                {
                    MessageBox.Show("To use this, open a folder or open a project");
                }
                else
                {

                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.FileName = "";
                    ofd.Filter = "JPEG Files (*.jpeg .jpg)|*.jpeg; *.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|BMP Files (*.bmp)|*.bmp";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string[] imgFileSplit = ofd.FileName.Split('\\');
                        string imgLoc = path + @"\img\" + imgFileSplit.Last();
                        Directory.CreateDirectory(path + @"\img");
                        File.Copy(ofd.FileName, imgLoc, true);
                        string imgTag = "<img src='img\\" + imgFileSplit.Last() + "' alt='" + imgFileSplit.Last() + "'>";
                        insertText(imgTag);
                    }
                }
            }
            catch (Exception n)
            {

                //MessageBox.Show("Make sure a new file is open before selecting a quick tag", "Open a new file"); //outputs a message box if there is an error e.g. no file is open
                MessageBox.Show(n.ToString());
            }

        }

        private void script_Click(object sender, EventArgs e)
        {
            try
            {
                //creates variable text with the script tag
                string text = "<script src=' '></script>";
                insertText(text);
                //creates a new file with the title "new JS file"
                //sets js syntax highlighting
                js = true;
                newToolStripButton_Click(sender, e);
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
                JS_Click(sender, e);
                js = false;
            }
            catch (Exception)
            {

                MessageBox.Show("Make sure a new file is open before selecting a quick tag", "Open a new file");
            }

        }

        private void script_MouseHover(object sender, EventArgs e)
        {
            extScriptHelp.Show("External Scripts are more efficient than ones inside the HTML file", script); //shows help screen for the button
        }

        private void section_Click(object sender, EventArgs e)
        {
            try
            {
                //inserts section tag 
                string text = @"<section class=' '></section>";
                insertText(text);
            }
            catch (Exception)
            {

                MessageBox.Show("Make sure a new file is open before selecting a quick tag", "Open a new file");
            }

        }

        private void paragrah_Click(object sender, EventArgs e)
        {
            try
            {
                string text = "<p class=' '></p>";
                insertText(text);
            }
            catch (Exception)
            {

                MessageBox.Show("Make sure a new file is open before selecting a quick tag", "Open a new file");
            }

        }

        private void navMenu_Click(object sender, EventArgs e)
        {
            try
            {
                string text = @"
<nav>
        <ul>
            <li><a href='index.html'>Home</a></li>
            <li><a href = ' ' ></a></li>
            <li><a href = ' ' ></a></li>
            <li><a href = ' ' ></a></li>
            <li><a href = ' ' ></a></li>              
        </ul>
</nav>";
                insertText(text);
            }
            catch (Exception)
            {

                MessageBox.Show("Make sure a new file is open before selecting a quick tag", "Open a new file");
            }
        }

        private void header_Click(object sender, EventArgs e)
        {
            try
            {
                string text = @"<header><header>";
                insertText(text);
            }
            catch (Exception)
            {

                MessageBox.Show("Make sure a new file is open before selecting a quick tag", "Open a new file");
            }

        }

        private void h1_Click(object sender, EventArgs e)
        {
            try
            {
                string text = "<h1 class==' '></h1>";
                insertText(text);
            }
            catch (Exception)
            {

                MessageBox.Show("Make sure a new file is open before selecting a quick tag", "Open a new file");
            }

        }

        private void standardHTML_Click(object sender, EventArgs e)
        {
            try
            {
                string text = @"<!DOCTYPE html>
<html lang='en'>
<head>
        <meta charset='UTF-8'>
        <title>My Site</title>
</head>
<body>
	
</body>
</html>";
                insertText(text);
            }
            catch (Exception)
            {

                MessageBox.Show("Make sure a new file is open before selecting a quick tag", "Open a new file");
            }

        }

        private void div_Click(object sender, EventArgs e)
        {
            try
            {
                string text = "<div class=''></div>";
                insertText(text);
            }
            catch (Exception)
            {

                MessageBox.Show("Make sure a new file is open before selecting a quick tag", "Open a new file");
            }

        }

        private void htmlForm_Click(object sender, EventArgs e)
        {
            //opens HTML Form Builder window
            htmlFormBuilder HFB = new htmlFormBuilder();
            HFB.Show();
        }
        #endregion

        #region Quick Buttons JS
        private void basicFunc_Click(object sender, EventArgs e)
        {
            //inserts a function snipit
            insertText(@"function myFunction()
{
   
}");
        }

        private void ifState_Click(object sender, EventArgs e)
        {
            insertText(@"if(true)
{

}
else
{

}");
        }

        private void whileState_Click(object sender, EventArgs e)
        {
            insertText(@"while(true)
{

}"); //while statement stored in text)
        }

        private void switchState_Click(object sender, EventArgs e)
        {
            insertText(@"switch(variableToSwitch)
{
	default:
    	break;
	case something:
		break;
}

");
        }

        private void forinState_Click(object sender, EventArgs e)
        {
            insertText(@"for(var in listVar)
{
    //e.g. output var
}");
        }

        private void forState_Click(object sender, EventArgs e)
        {
            insertText(@"for (i = 0; i < n; i++) {
    
        }");
        }

        private void documentID_Click(object sender, EventArgs e)
        {
            insertText(@"document.getElementById('idName');");
        }

        private void documentClass_Click(object sender, EventArgs e)
        {
            insertText(@"document.getElementsByClassName(className');");
        }

        private void documentCSS_Click(object sender, EventArgs e)
        {
            insertText(@"document.querySelector('cssSelector here');");
        }

        private void documentName_Click(object sender, EventArgs e)
        {
            insertText(@"document.getElementsByName('nameHere');");
        }

        #endregion

        #region Quick Buttons PHP

        private void phpBasicFunc_Click(object sender, EventArgs e)
        {
            insertText(@"function myFunction()
{
   
}");
        }

        private void phpIfState_Click(object sender, EventArgs e)
        {
            insertText(@"if(true)
{

}
else
{

}");
        }

        private void phpWhileState_Click(object sender, EventArgs e)
        {
            insertText(@"while(true)
{

}"); //while statement stored in text
        }

        private void phpSwitchState_Click(object sender, EventArgs e)
        {
            insertText(@"switch($variableToSwitch)
{
	default:
    	break;
	case something:
		break;
}

");
        }

        private void phpForState_Click(object sender, EventArgs e)
        {
            insertText(@"for (i = 0; i < n; i++) {
    
        }");
        }

        private void phpForeachState_Click(object sender, EventArgs e)
        {
            insertText(@"foreach ($array as $value) 
{
    //type some code 
}");
        }

        #endregion

        private void mediaQuery_Click(object sender, EventArgs e)
        {
            insertText(@"@media screen and (max-width: 768px) {
           /*CSS code in here*/
}");
        }

        private void insertText(string text)
        {
            try
            {
                //the text stored in text variable gets inserted at the cursor position 
                GetRichTextBox().Text = GetRichTextBox().Text.Insert(GetRichTextBox().SelectionStart, text);
            }
            catch (Exception)
            {

                MessageBox.Show("Make sure a new file is open before selecting a quick button", "Open a new file"); //outputs a message box if there is an error e.g. no file is open
            }
        }

        #endregion

        #region Nav Bar
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            //makes string varaible title
            string title = "";
            if (js == true)
            {
                // sets title to new JS file if js == true
                title = " new JS file";
            }
            else
            {
                title = " new file";
            }
            // creates new tabpage with title then adds rtb to it with its properties 
            TabPage newTP = new TabPage(title);
            //line numbers
            rtbSync rtb = new rtbSync();
            rtb.Dock = DockStyle.Left;
            rtb.BackColor = Color.WhiteSmoke;
            rtb.BorderStyle = BorderStyle.None;
            rtb.Font = new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            rtb.ForeColor = Color.Teal;
            rtb.Location = new Point(3, 3);
            rtb.Name = "rtb2";
            rtb.Size = new Size(50, 700);
            rtb.TabIndex = 0;
            rtb.Text = "1";
            rtb.ReadOnly = true;
            //rtb regular
            rtbSync rtb2 = new rtbSync();
            rtb2.BorderStyle = BorderStyle.None;
            rtb2.Dock = DockStyle.Fill;
            rtb2.Location = new Point(26, 3);
            rtb2.Name = "rtb";
            rtb2.Size = new Size(690, 700);
            rtb2.TabIndex = 1;
            rtb2.Text = "";
            rtb2.KeyUp += new KeyEventHandler(this.richTextBox1_KeyUp);
            rtb.Parent = rtb2.Parent = this;
            rtb.BindScroll(rtb2);
            newTP.Controls.Add(rtb2);
            newTP.Controls.Add(rtb);
            tabControl1.TabPages.Insert(tabControl1.SelectedIndex + 1, newTP);
            //inserts blank just to make sure there is a new file opened and no errors
            string text = "";
            rtb.Text = rtb.Text.Insert(rtb.SelectionStart, text);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            //creates an open file dialog
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "untitled";
            ofd.Filter = "HTML (*.html)|*.html|CSS (*.css)|*.css|JS (*.js)|*.js|PHP (*.php)|*.php|Plain Text (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                bool tabOpen = false;
                for (int i = 0; i < tabControl1.TabCount; i++)
                {
                    string tabText = tabControl1.TabPages[i].Text;
                    if (Path.GetFileName(ofd.FileName) == tabText)
                    {
                        tabControl1.SelectTab(i);
                        tabOpen = true;
                        break;
                    }
                    else
                    {
                        tabOpen = false;
                    }
                }
                //shows it and if the result is ok go to openFile with the path
                if (tabOpen == false)
                {
                    openFile(ofd.FileName);
                }
            }
        }

        private void openFolderToolStripButton_Click(object sender, EventArgs e)
        {
            //creates a folder browser dialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //sets path and runs openFolder function
                path = fbd.SelectedPath;
                projPath = path;
                openFolder();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //tries to save file if file is already saved. 
                //creates new stream writer for writing to
                StreamWriter sw = new StreamWriter(projPath + @"\" + tabControl1.SelectedTab.Text);
                //gets file name
                string fileName = Path.GetFileName(projPath + @"\" + tabControl1.SelectedTab.Text);
                //sets tab name to the file name
                tabControl1.SelectedTab.Text = fileName;
                //writes the current text to the file
                sw.Write(GetRichTextBox().Text);
                sw.Close();
                MessageBox.Show("File Saved");
            }
            catch (Exception)
            {
                //if file not saved already
                // creates new save file dialog
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "untitled";
                sfd.Filter = "Plain Text (*.txt)|*.txt|HTML (*.html)|*.html|CSS (*.css)|*.css|JS (*.js)|*.js|PHP (*.php)|*.php";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //writes to the new file in the new location
                    StreamWriter sw = new StreamWriter(sfd.FileName);
                    string fileName = Path.GetFileName(sfd.FileName);
                    //sets the new file name to the tab name
                    tabControl1.SelectedTab.Text = fileName;
                    sw.Write(GetRichTextBox().Text);
                    sw.Close();
                }
            }

        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Paste();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            try
            {
                //tries to close selected tab
                int tabIndex = tabControl1.SelectedIndex;
                int newIndex = tabIndex - 1;
                if (newIndex == -1)
                {
                    newIndex = 0;
                }
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                tabControl1.SelectTab(newIndex);
            }
            catch (Exception)
            {
                // if not tab to close
                MessageBox.Show("No file to close");
            }
        }

        private void saveProj_Click(object sender, EventArgs e)
        {

            string[] pathSplit = path.Split(toSplit, StringSplitOptions.None); // splitted path
            if (path == "" || path == null)
            {
                //if no folder is open
                MessageBox.Show("To get started open a folder and then save project", "Open a folder");
            }
            else
            {
                try
                {
                    //tries to write to the new temp file
                    using (StreamWriter file = new StreamWriter(path + @"\" + pathSplit[pathSplit.Length-2] + ".weproji", false)) //making new file with folder name as file name
                    { 
                        //gets the tab count i.e. the number of tabs open
                        if (tabControl1.TabCount != 0)
                        {
                            // iterates till the last tab
                            for (int i = 0; i < tabControl1.TabCount; i++)
                            {
                                if (tabControl1.TabPages[i].Text.ToString().Trim() == "new file")
                                {
                                    //writes the tab name to the file
                                    string eTab = "tab = " + tabControl1.TabPages[i].Text.ToString();
                                    file.Write(eTab + "\n");
                                    //writes the content from the new file
                                    string eNew = "new file = \n {" + tabControl1.TabPages[i].Controls[0].Text + "}";
                                    Console.WriteLine(eNew);
                                    //get the content from new file and save temporarly 
                                    file.WriteLine(eNew);
                                }
                                else
                                {
                                    //writes the tab name to the file
                                    string eTab = "tab = " + tabControl1.TabPages[i].Text.ToString();
                                    file.Write(eTab + "\n");
                                }
                            }
                        }
                        //shows message that project is saved
                        MessageBox.Show("Project Saved");
                    }
                    //encrypts file with the desired password for security reasons
                    encDecFile.EncryptFile("jKBuGvXJ", path + @"\" + pathSplit[pathSplit.Length - 2] + ".weproji", path + @"\" + pathSplit[pathSplit.Length - 2] + ".weproj");
                    //deletes temp file for security reasons
                    File.Delete(path + @"\" + pathSplit[pathSplit.Length - 2] + ".weproji");
                }
                catch (Exception n)
                {
                    // if anything goes wrong then it shows the error and error message
                    MessageBox.Show("This application requires adminstrator access for some features. Are you sure you have run with adminstrator access", "Requires Administrator Acess");
                    MessageBox.Show(n.ToString());
                }
            }
        }

        private void openProj_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.FileName = "";
                ofd.Filter = "Web Edit Project (*.weproj)|*.weproj";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(ofd.FileName);
                    string[] tempFile = ofd.FileName.Split('\\');
                    string tempLoc = "";
                    tempFile = tempFile.Where(w => w != tempFile.Last()).ToArray();
                    foreach (string temp in tempFile)
                    {
                        tempLoc += temp + @"\";
                    }
                    Directory.CreateDirectory(tempLoc + "temp");
                    encDecFile.DecryptFile("jKBuGvXJ", ofd.FileName, tempLoc + @"temp\" + tempFile.Last() + ".temp");
                    var decFileSplit = new Dictionary<int, string>();
                    string[] equalSplit;
                    string decFileLine;
                    int i = 0;
                    using (StreamReader decFile = new StreamReader(tempLoc + @"temp\" + tempFile.Last() + ".temp"))
                    {
                        while (decFile.Peek() >= 0)
                        {
                            decFileLine = decFile.ReadLine();
                            decFileSplit[i] = decFileLine;
                            equalSplit = decFileSplit[i].Split('=');
                            if (equalSplit[0].Trim() == "tab")
                            {
                                if (equalSplit[1].Trim() != "new file")
                                {
                                    openFile(tempLoc + equalSplit.Last().Trim());
                                }
                                else
                                {
                                    nfCount++;
                                    newToolStripButton_Click(sender, e);
                                    
                                }
                            }
                            if (equalSplit[0].Trim() == "new file")
                            {
                                using (StreamReader decFile2 = new StreamReader(tempLoc + @"temp\" + tempFile.Last() + ".temp"))
                                {
                                    Console.WriteLine(nfCount);
                                    string tags = @"[^}\]*{[^}]*}";
                                    tagMatches = Regex.Matches(decFile2.ReadToEnd(), tags, RegexOptions.Multiline);
                                    Match m = tagMatches[nfCount - 1];
                                    string m1 = m.Value.Replace("{", null);
                                    string m2 = m1.Replace("}", null);
                                    Console.WriteLine(m2);
                                    tabControl1.TabPages[tabControl1.TabCount-1].Controls[0].Text = m2;

                                }
                            }
                            Console.WriteLine(decFile.Peek());
                        }
                        decFile.Close();
                    }
                    path = tempLoc;
                    projPath = path;
                    openFolder();
                    sr.Close();

                    using (StreamWriter tempFileRe = new StreamWriter(tempLoc + @"temp\" + tempFile.Last() + ".temp", false))
                    {
                        tempFileRe.WriteLine("");
                    }
                    nfCount = 0;
                    File.Delete(tempLoc + @"temp\" + tempFile.Last() + ".temp");
                    Directory.Delete(tempLoc + @"temp\");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("This application requires adminstrator access for some features. Are you sure you have run with adminstrator access", "Requires Administrator Acess");
                MessageBox.Show(ex.ToString());
            }
        }

        //Languages
        private void HTML_Click(object sender, EventArgs e)
        {
            try
            {
                //sets language to HTML and inserts lang to tell the user that they have chosen HTML
                lang = "HTML";
                GetRichTextBox().Text = GetRichTextBox().Text.Insert(GetRichTextBox().SelectionStart, lang);
            }
            catch (Exception)
            {
                //if no file is open
                MessageBox.Show("Make sure a new file is open before selecting the language", "Open a new file");
            }
        }

        private void JS_Click(object sender, EventArgs e)
        {
            try
            {
                //sets language to JS and inserts lang to tell the user that they have chosen JS
                lang = "JS";
                GetRichTextBox().Text = GetRichTextBox().Text.Insert(GetRichTextBox().SelectionStart, lang);
            }
            catch (Exception)
            {
                //if no file is open
                MessageBox.Show("Make sure a new file is open before selecting the language", "Open a new file");
            }
        }

        private void CSS_Click(object sender, EventArgs e)
        {
            try
            {
                //sets language to CSS and inserts lang to tell the user that they have chosen CSS
                lang = "CSS";
                GetRichTextBox().Text = GetRichTextBox().Text.Insert(GetRichTextBox().SelectionStart, lang); //inserts the img tag in the rtb based on cursor position
            }
            catch (Exception)
            {
                //if no file is open
                MessageBox.Show("Make sure a new file is open before selecting the language", "Open a new file");
            }

        }

        private void PHP_Click(object sender, EventArgs e)
        {
            try
            {
                //sets language to PHP and inserts lang to tell the user that they have chosen PHP
                lang = "PHP";
                GetRichTextBox().Text = GetRichTextBox().Text.Insert(GetRichTextBox().SelectionStart, lang); //inserts the img tag in the rtb based on cursor position
            }
            catch (Exception)
            {
                //if no file is open
                MessageBox.Show("Make sure a new file is open before selecting the language", "Open a new file");
            }

        }

        //team services
        private void loginBtn_Click(object sender, EventArgs e)
        {
            //What it does
            //allows user to:
            //login
            //sign up
            //reset password
            teamLogin tl = new teamLogin(); //create new instance of teamLogin 
            tl.ShowDialog(); //show it as a dialog not window
            //set new variables
            username = tl.username;
            password = tl.password;
            teamName = tl.teamName;
            Console.WriteLine(teamName);
            if (tl.isLoggedIn == true)
            {
                if (tl.stayLoggedIn == true)
                {
                    //write username and password to temp file if stayLoggedIn == true
                    using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\settings.wei", false))
                    {
                        sw.WriteLine("username = " + tl.username); //username
                        sw.WriteLine("\n"); // new line (gap)
                        sw.WriteLine("password = " + tl.password); //password
                        sw.WriteLine("\n"); // new line (gap)
                        if (tl.teamName == "")
                        {
                            sw.WriteLine("teamName = N/A");
                        }
                        else
                        {
                            sw.WriteLine("teamName = " + tl.teamName); //teamName
                        }
                    }

                    //encrypt file
                    encDecFile.EncryptFile("jKBuGvXJ", AppDomain.CurrentDomain.BaseDirectory + @"\settings.wei", AppDomain.CurrentDomain.BaseDirectory + @"\settings.we");
                    //deletes temp file
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\settings.wei");

                    //enable new features and disable login
                }
                if (!string.IsNullOrWhiteSpace(teamName))
                {
                    syncBtn.Enabled = true;
                    teamSettingsBtn.Enabled = true;
                }

                connectBtn.Enabled = true;
                logOutBtn.Enabled = true;
                notifcationsBtn.Enabled = true;
                loginBtn.Enabled = false;
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\settings.wei", false))
                {
                    sw.WriteLine("username = N/A"); //username
                    sw.WriteLine("\n"); // new line (gap)
                    sw.WriteLine("password = N/A"); //password
                    sw.WriteLine("\n"); // new line (gap)
                    sw.WriteLine("teamName = N/A"); //teamName
                }

                //encrypt file
                encDecFile.EncryptFile("jKBuGvXJ", AppDomain.CurrentDomain.BaseDirectory + @"\settings.wei", AppDomain.CurrentDomain.BaseDirectory + @"\settings.we");
                //deletes temp file
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\settings.wei");
            }

        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            //allows user to logout of the team
            //enables login again and disables features required for login
            syncBtn.Enabled = false;
            teamSettingsBtn.Enabled = false;
            connectBtn.Enabled = false;
            logOutBtn.Enabled = false;
            notifcationsBtn.Enabled = false;
            loginBtn.Enabled = true;
            //deleting settings file which contains the login information to log back in again
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\settings.we");
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\settings.wei", false))
            {
                sw.WriteLine("username = N/A"); //username
                sw.WriteLine("\n"); // new line (gap)
                sw.WriteLine("password = N/A"); //password
                sw.WriteLine("\n"); // new line (gap)
                sw.WriteLine("teamName = N/A"); //teamName
            }

            //encrypt file
            encDecFile.EncryptFile("jKBuGvXJ", AppDomain.CurrentDomain.BaseDirectory + @"\settings.wei", AppDomain.CurrentDomain.BaseDirectory + @"\settings.we");
            //deletes temp file
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + @"\settings.wei");
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            //What it does
            //generates new pin code for team and user 
            //asks to join a team with notification support
            connectToTeam ct = new connectToTeam();
            ct.username = username;
            ct.password = password;
            ct.ShowDialog();
            teamName = ct.teamName;
            if (!string.IsNullOrWhiteSpace(teamName))
            {
                syncBtn.Enabled = true;
                teamSettingsBtn.Enabled = true;
            }

        }

        private void notifcationsBtn_Click(object sender, EventArgs e)
        {
            //What it does
            //shows current notifications for each user
            notifications noti = new notifications();
            noti.username = username;
            noti.password = password;
            noti.projectPath = projPath;
            noti.teamName = teamName;
            noti.Show();
        }

        private void syncBtn_Click(object sender, EventArgs e)
        {
            syncToTeam sync = new syncToTeam();
            sync.teamName = teamName;
            sync.username = username;
            if (string.IsNullOrWhiteSpace(projPath))
            {
                MessageBox.Show("To sync with the team open the project folder. \n (Idealy save your workspace as a project file)", "Open a folder");
            }
            else
            {
                sync.projPath = projPath;
                sync.Show();
            }
        }

        void openFile(string file)
        {
            //new working condition
            string text;
            //makes filestream to open and read the file
            var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);

            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                //uses a stream reader to read to the end of the file
                text = streamReader.ReadToEnd();
            }
            
            //gets the file e.g. "index.html"
            string fileName = Path.GetFileName(file);

            //adds a new tabpage with the rtb
            TabPage newTP = new TabPage(fileName);
            rtbSync rtb = new rtbSync();
            rtb.Dock = DockStyle.Left;
            rtb.BackColor = Color.WhiteSmoke;
            rtb.BorderStyle = BorderStyle.None;
            rtb.Font = new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            rtb.ForeColor = Color.Teal;
            rtb.Location = new Point(3, 3);
            rtb.Name = "rtb2";
            rtb.Size = new Size(50, 700);
            rtb.TabIndex = 0;
            rtb.Text = "1";
            rtb.ReadOnly = true;
            //rtb regular
            rtbSync rtb2 = new rtbSync();
            rtb2.BorderStyle = BorderStyle.None;
            rtb2.Dock = DockStyle.Fill;
            rtb2.Location = new Point(26, 3);
            rtb2.Name = "rtb";
            rtb2.Size = new Size(690, 700);
            rtb2.TabIndex = 1;
            rtb2.Text = "";
            rtb2.KeyUp += new KeyEventHandler(this.richTextBox1_KeyUp);
            rtb.Parent = rtb2.Parent = this;
            rtb.BindScroll(rtb2);
            newTP.Controls.Add(rtb2);
            newTP.Controls.Add(rtb);
            tabControl1.TabPages.Insert(tabControl1.SelectedIndex + 1, newTP);
            //adds the text to that selected rtb
            rtb2.Text = rtb2.Text.Insert(rtb2.SelectionStart, text);
        }

        //find and replace
        private void findReplaceBtn_Click(object sender, EventArgs e)
        {
            //sets variables 
            string textToSearch = GetRichTextBox().Text;
            string findT = findText.Text;
            string replaceT = replaceText.Text;

            //makes all text black
            GetRichTextBox().SelectionStart = 0;
            GetRichTextBox().SelectionLength = GetRichTextBox().Text.Length;
            GetRichTextBox().SelectionColor = Color.Black;

            if (findT != "" && replaceT == "")
            {
                //finds new text and colours orange-red
                MatchCollection findTR = Regex.Matches(GetRichTextBox().Text, findT);
                foreach (Match m in findTR)
                {
                    GetRichTextBox().SelectionStart = m.Index;
                    GetRichTextBox().SelectionLength = m.Length;
                    GetRichTextBox().SelectionColor = Color.OrangeRed;
                }
            }
        }

        void openFolder()
        {
            //creates amd indexed list
            IList<TreeNode> nodesWithChildren = new List<TreeNode>();
            pathSplit = path.Split(toSplit, StringSplitOptions.None); // splitted path

            foreach (TreeNode node in treeView1.Nodes)
            {
                node.Text = pathSplit[pathSplit.Length-1];

                if (node.Nodes.Count > 0)
                {
                    nodesWithChildren.Add(node);
                }
            }

            if (nodesWithChildren.Count != 0)
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(pathSplit[pathSplit.Length - 2]);
            }
            Console.WriteLine("path is found");
            Console.WriteLine(path.ToString());
            if (path != "")
            {
                flowLayoutPanel1.Width = 200;
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                directories = directoryInfo.GetDirectories();
                foreach (FileInfo file in directoryInfo.GetFiles())
                {

                    if (file.Exists)
                    {
                        TreeNode nodes = treeView1.Nodes[0].Nodes.Add(file.Name);
                        SetImageExtension(file.Name, nodes);
                    }
                }

                if (directories.Length > 0)
                {
                    DL = directories.Length;
                    foreach (DirectoryInfo directory in directories)
                    {
                        TreeNode node = treeView1.Nodes[0].Nodes.Add(directory.Name);
                        node.ImageIndex = node.SelectedImageIndex = 0;
                        foreach (FileInfo file in directory.GetFiles())
                        {
                            if (file.Exists)
                            {
                                TreeNode nodes = treeView1.Nodes[0].Nodes[node.Index].Nodes.Add(file.Name);
                                SetImageExtension(file.Name, nodes);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Extensions
        private void SetImageExtension(string name, TreeNode _node)
        {
            if (name.Contains(".html"))
                _node.ImageIndex = _node.SelectedImageIndex = 1;
            else if (name.Contains(".css"))
                _node.ImageIndex = _node.SelectedImageIndex = 2;
            else if (name.Contains(".js"))
                _node.ImageIndex = _node.SelectedImageIndex = 3;
            else if (name.Contains(".php"))
                _node.ImageIndex = _node.SelectedImageIndex = 4;
            else
            {
                _node.ImageIndex = _node.SelectedImageIndex = 5;
            }

        }
        #endregion

        #region Syntax Highlighting
        private void rtb_TextChanged(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            //checks which language has been selected and highlights based on that
            if (lang == "HTML")
            {
                HTML_syntax(sender, e);
            }
            if (lang == "CSS")
            {
                CSS_syntax(sender, e);
            }
            if (lang == "JS")
            {
                JS_syntax(sender, e);
            }
            if (lang == "PHP")
            {
                PHP_syntax(sender, e);
            }

            int linecount = rtb.GetLineFromCharIndex(rtb.TextLength) + 1;
            if (linecount != maxLC)
            {
                RichTextBox rtb2 = (RichTextBox)tabControl1.SelectedTab.Controls[1];
                rtb2.Clear();
                for (int i = 1; i < linecount + 1; i++)
                {
                    rtb2.AppendText(Convert.ToString(i) + "\n");
                }
                maxLC = linecount;
            }
        }

        void HTML_syntax(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            // getting tags
            //<TAG\b[^>]*>(.*?)</TAG>
            //string kewords = @"\b(public|private|partial|static|namespace|class|using|void|foreach|in|while)\b";
            string tags = @"<([/A-Za-z0-9]*)\b[^>]*>(.*?)";
            tagMatches = Regex.Matches(rtb.Text, tags, RegexOptions.Multiline);

            // getting attributes from the text
            string attributes = @"[A-Za-z0-9-_]*=[A-Za-z0-9-_]*";
            attributeMatches = Regex.Matches(rtb.Text, attributes);

            // getting comments (inline or multiline)
            string comments = @"(\<![ \r\n\t]*(--([^\-]|[\r\n]|-[^\-])*--[ \r\n\t]*)\>)";
            commentMatches = Regex.Matches(rtb.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            stringMatches = Regex.Matches(rtb.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = rtb.SelectionStart;
            int originalLength = rtb.SelectionLength;
            Color originalColor = Color.Black;


            // MANDATORY - focuses a label before highlighting (avoids blinking)
            label1.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            rtb.SelectionStart = 0;
            rtb.SelectionLength = rtb.Text.Length;
            rtb.SelectionColor = originalColor;

            foreach (Match m in tagMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Blue;
            }

            foreach (Match m in attributeMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Red;
            }

            foreach (Match m in commentMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Gray;
            }

            foreach (Match m in stringMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkGreen;
            }
            // restoring the original colors, for further writing
            rtb.SelectionStart = originalIndex;
            rtb.SelectionLength = originalLength;
            rtb.SelectionColor = originalColor;

            // giving back the focus
            rtb.Focus();
        }

        void CSS_syntax(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            // getting tags
            //string kewords = @"\b(public|private|partial|static|namespace|class|using|void|foreach|in|while)\b";
            string tags = @"([\.#@_A-Za-z0-9\-][_A-Za-z0-9\-]+)[^}]*{[^}]*}";
            tagMatches = Regex.Matches(rtb.Text, tags, RegexOptions.Multiline);

            // getting types a from the text e.g. background-color
            string typesA = @"([A-Za-z0-9-]*:)";
            typesAMatches = Regex.Matches(rtb.Text, typesA);

            string typesB = @"(: [A-Za-z0-9]*)";
            typesBMatches = Regex.Matches(rtb.Text, typesB);

            string selector = @"(:[A-Za-z]*)";
            selectorMatches = Regex.Matches(rtb.Text, selector);

            //Matching Hex Value
            string hexValue = "(#[a-f0-9]{3}){1,2}";
            hexValueMatches = Regex.Matches(rtb.Text, hexValue);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            commentMatches = Regex.Matches(rtb.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            stringMatches = Regex.Matches(rtb.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = rtb.SelectionStart;
            int originalLength = rtb.SelectionLength;
            Color originalColor = Color.Black;


            // MANDATORY - focuses a label before highlighting (avoids blinking)
            label1.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            rtb.SelectionStart = 0;
            rtb.SelectionLength = rtb.Text.Length;
            rtb.SelectionColor = originalColor;

            foreach (Match m in tagMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Red;
            }

            foreach (Match m in typesAMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in typesBMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in hexValueMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkOrchid;
            }

            foreach (Match m in selectorMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkOrange;
            }

            foreach (Match m in commentMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Gray;
            }

            foreach (Match m in stringMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkGreen;
            }
            // restoring the original colors, for further writing
            rtb.SelectionStart = originalIndex;
            rtb.SelectionLength = originalLength;
            rtb.SelectionColor = originalColor;

            // giving back the focus
            rtb.Focus();
        }

        void JS_syntax(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            // getting tags
            string kewords = @"\b(new|var|if|do|function|while|switch|for|foreach|in|continue|break)\b";
            keywordMatches = Regex.Matches(rtb.Text, kewords, RegexOptions.Multiline);

            // getting types a from the text e.g. background-color
            string globals = @"\b(document|window|Array|String|Object|Number|\$)\b";
            globalsMatches = Regex.Matches(rtb.Text, globals);

            string other = @"\b(getElementsBy(TagName|ClassName|Name)|getElementById|typeof|instanceof|querySelector)\b";
            otherMatches = Regex.Matches(rtb.Text, other);

            string special = @"\b(indexOf|match|replace|toString|length)\b";
            specialMatches = Regex.Matches(rtb.Text, special);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            commentMatches = Regex.Matches(rtb.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            stringMatches = Regex.Matches(rtb.Text, strings);

            // saving the original caret position + forecolor
            int originalIndex = rtb.SelectionStart;
            int originalLength = rtb.SelectionLength;
            Color originalColor = Color.Black;


            // MANDATORY - focuses a label before highlighting (avoids blinking)
            label1.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            rtb.SelectionStart = 0;
            rtb.SelectionLength = rtb.Text.Length;
            rtb.SelectionColor = originalColor;

            foreach (Match m in keywordMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Red;
            }

            foreach (Match m in globalsMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in otherMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkCyan;
            }


            foreach (Match m in specialMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkOrange;
            }

            foreach (Match m in commentMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Gray;
            }

            foreach (Match m in stringMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkGreen;

            }

            // restoring the original colors, for further writing
            rtb.SelectionStart = originalIndex;
            rtb.SelectionLength = originalLength;
            rtb.SelectionColor = originalColor;

            // giving back the focus
            rtb.Focus();
        }

        void PHP_syntax(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;
            // getting tags
            string kewords = @"\b(and|or|xor|do|as|return|die|exit|then|
                |new|delete|try|throw|catch|finally|class|function|string|
                array|object|resource|bool|boolean|int|integer|float|double|
                real|string|array|global|const|static|public|private|protected|
                published|extends|true|false|null|void|this|self|struct|
                char|signed|unsigned|short|long|echo)\b";
            keywordMatches = Regex.Matches(rtb.Text, kewords, RegexOptions.Multiline);

            // getting types a from the text e.g. background-color
            string globals = @"([A-Za-z0-9_-]*\()";
            globalsMatches = Regex.Matches(rtb.Text, globals);

            string condition = @"((if|elseif|for|foreach|while|switch)\(|([.]|[+]|[*]|[-]|[/]|[=]|[|][|])|else|((if|elseif|for|foreach|while|switch) \(|([.]|[+]|[*]|[-]|[/]|[=]|[|][|])))";
            conditionMatches = Regex.Matches(rtb.Text, condition);

            string variables = @"(\$\w*)";
            variableMatches = Regex.Matches(rtb.Text, variables);

            string other = @"(\b(true|false)\b|\\n|\\r)";
            otherMatches = Regex.Matches(rtb.Text, other);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/|#.*$)";
            commentMatches = Regex.Matches(rtb.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            stringMatches = Regex.Matches(rtb.Text, strings);

            //HTML Syntax

            string tags = @"<([/A-Za-z0-9]*)\b[^>]*>(.*?)";
            tagMatches = Regex.Matches(rtb.Text, tags, RegexOptions.Multiline);

            // getting attributes from the text
            string attributes = @"[A-Za-z0-9-_]*=[A-Za-z0-9-_]*";
            attributeMatches = Regex.Matches(rtb.Text, attributes);

            // getting comments (inline or multiline)
            string htmlComments = @"(\<![ \r\n\t]*(--([^\-]|[\r\n]|-[^\-])*--[ \r\n\t]*)\>)";
            htmlCommentMatches = Regex.Matches(rtb.Text, htmlComments, RegexOptions.Multiline);

            // saving the original caret position + forecolor
            int originalIndex = rtb.SelectionStart;
            int originalLength = rtb.SelectionLength;
            Color originalColor = Color.Black;


            // MANDATORY - focuses a label before highlighting (avoids blinking)
            label1.Focus();

            // removes any previous highlighting (so modified words won't remain highlighted)
            rtb.SelectionStart = 0;
            rtb.SelectionLength = rtb.Text.Length;
            rtb.SelectionColor = originalColor;

            foreach (Match m in keywordMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Red;
            }

            foreach (Match m in globalsMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkCyan;
            }

            foreach (Match m in conditionMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Red;
            }

            foreach (Match m in otherMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkOrchid;
            }


            foreach (Match m in variableMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkOrange;
            }

            foreach (Match m in htmlCommentMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Gray;
            }

            foreach (Match m in stringMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.DarkGreen;
            }

            foreach (Match m in tagMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Blue;
            }

            foreach (Match m in attributeMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Red;
            }

            foreach (Match m in commentMatches)
            {
                rtb.SelectionStart = m.Index;
                rtb.SelectionLength = m.Length;
                rtb.SelectionColor = Color.Gray;
            }

            // restoring the original colors, for further writing
            rtb.SelectionStart = originalIndex;
            rtb.SelectionLength = originalLength;
            rtb.SelectionColor = originalColor;

            // giving back the focus
            rtb.Focus();
        }
        #endregion

        private void treeView1_NodeDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            bool tabOpen = true;
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                string tabText = tabControl1.TabPages[i].Text;
                if (treeView1.SelectedNode.Text == tabText)
                {
                    tabControl1.SelectTab(i);
                    tabOpen = true;
                    break;
                }
                else
                {
                    tabOpen = false;
                }
            }

            if (tabOpen == false)
            {
                string text;
                string parentNode = treeView1.SelectedNode.Parent.Text;
                string nPath = "";
                string[] pathSplit = path.Split(toSplit, StringSplitOptions.None); // splitted path
                                                                                   //checks if the selected path is in the root folder or in a sub folder
                if (parentNode != pathSplit[pathSplit.Length - 2])
                {
                    nPath = path + @"\" + parentNode + @"\" + treeView1.SelectedNode.Text;
                }
                else
                {
                    nPath = path + @"\" + treeView1.SelectedNode.Text;
                }

                //works the same as in open file but with differnet variables
                var fileStream = new FileStream(nPath, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }

                TabPage newTP = new TabPage(treeView1.SelectedNode.Text);
                rtbSync rtb = new rtbSync();
                rtb.Dock = DockStyle.Left;
                rtb.BackColor = Color.WhiteSmoke;
                rtb.BorderStyle = BorderStyle.None;
                rtb.Font = new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                rtb.ForeColor = Color.Teal;
                rtb.Location = new Point(3, 3);
                rtb.Name = "rtb2";
                rtb.Size = new Size(50, 700);
                rtb.TabIndex = 0;
                rtb.Text = "1";
                rtb.ReadOnly = true;
                //rtb regular
                rtbSync rtb2 = new rtbSync();
                rtb2.BorderStyle = BorderStyle.None;
                rtb2.Dock = DockStyle.Fill;
                rtb2.Location = new Point(26, 3);
                rtb2.Name = "rtb";
                rtb2.Size = new Size(690, 700);
                rtb2.TabIndex = 1;
                rtb2.Text = "";
                rtb2.KeyUp += new KeyEventHandler(this.richTextBox1_KeyUp);
                rtb.Parent = rtb2.Parent = this;
                rtb.BindScroll(rtb2);
                newTP.Controls.Add(rtb2);
                newTP.Controls.Add(rtb);
                tabControl1.TabPages.Insert(tabControl1.SelectedIndex + 1, newTP);

                rtb2.Text = rtb2.Text.Insert(rtb2.SelectionStart, text);

                openSaveDict[tabControl1.SelectedIndex + 1] = nPath;
            }
        }

        private void WebEdit_Load(object sender, EventArgs e)
        {
            try
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\temp");
                encDecFile.DecryptFile("jKBuGvXJ", AppDomain.CurrentDomain.BaseDirectory + @"\settings.we", AppDomain.CurrentDomain.BaseDirectory + @"\temp\settings.temp");

                var decFileSplit = new Dictionary<int, string>();
                string[] equalSplit;
                string decFileLine;
                int i = 0;
                using (StreamReader decFile = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\temp\settings.temp"))
                {
                    while (decFile.Peek() >= 0)
                    {
                        decFileLine = decFile.ReadLine();
                        decFileSplit[i] = decFileLine;
                        equalSplit = decFileSplit[i].Split('=');
                        if (equalSplit[0].Trim() == "username")
                        {
                            if (equalSplit[1].Trim() != "N/A")
                            {
                                username = equalSplit[1].Trim();
                                connectBtn.Enabled = true;
                                logOutBtn.Enabled = true;
                                notifcationsBtn.Enabled = true;
                                loginBtn.Enabled = false;
                            }
                        }
                        if (equalSplit[0].Trim() == "password")
                        {
                            if (equalSplit[1].Trim() != "N/A")
                            {
                                password = equalSplit[1].Trim();
                            }
                        }
                        if (equalSplit[0].Trim() == "teamName")
                        {
                            if (equalSplit[1].Trim() != "N/A")
                            {
                                teamName = equalSplit[1].Trim();
                                syncBtn.Enabled = true;
                                teamSettingsBtn.Enabled = true;
                            }
                        }
                        i++;
                    }

                }

                using (StreamWriter tempFileRe = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\temp\settings.temp", false))
                {
                    tempFileRe.WriteLine("");
                }

            }
            catch (Exception)
            {
                
            }
        }

        //for shortcut keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //switches keys
            switch (keyData)
            {
                //checks which key is pressed and then performs action
                case (Keys.Control | Keys.S):
                    saveToolStripButton.PerformClick();
                    break;
                case (Keys.Control | Keys.O):
                    openToolStripButton.PerformClick();
                    break;
                case (Keys.Control | Keys.N):
                    newToolStripButton.PerformClick();
                    break;
                case (Keys.Control | Keys.Shift | Keys.S):
                    saveProj.PerformClick();
                    break;
                case (Keys.Control | Keys.Shift | Keys.O):
                    openFolderToolStripButton.PerformClick();
                    break;
                case (Keys.Control | Keys.W):
                    Remove.PerformClick();
                    break;
                case (Keys.Control | Keys.X):
                    cutToolStripButton.PerformClick();
                    break;
                case (Keys.Control | Keys.C):
                    copyToolStripButton.PerformClick();
                    break;
                case (Keys.Control | Keys.Z):
                    GetRichTextBox().Undo();
                    break;
                case (Keys.Control | Keys.Y):
                    GetRichTextBox().Redo();
                    break;
                case (Keys.Control | Keys.Shift | Keys.P):
                    openProj.PerformClick();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void WebEdit_Resize(object sender, EventArgs e)
        {
            //resizes folder viewer based on height of form
            treeView1.Height = Height;
        }

        private void teamSettingsBtn_Click(object sender, EventArgs e)
        {
            teamSettings ts = new teamSettings();
            ts.username = username;
            ts.teamName = teamName;
            ts.Show();
            if(ts.leftTeam == true)
            {
                syncBtn.Enabled = false;
                teamSettingsBtn.Enabled = false;
                connectBtn.Enabled = false;
                logOutBtn.Enabled = false;
            }
        }

        private void WebEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void richTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            RichTextBox rtb = (RichTextBox)sender;

            int linecount = rtb.GetLineFromCharIndex(rtb.TextLength) + 1;
            if (linecount != maxLC)
            {
                RichTextBox rtb2 = (RichTextBox)tabControl1.SelectedTab.Controls[1];
                rtb2.Clear();
                for (int i = 1; i < linecount + 1; i++)
                {
                    rtb2.AppendText(Convert.ToString(i) + "\n");
                }
                maxLC = linecount;
            }
        }

        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {

        }
    }

    public class rtbSync : RichTextBox
    {

        private const int WM_VSCROLL = 0x115;
        private const int WM_HSCROLL = 0x114;
        private const int WM_MOUSEWHEEL = 0x20a;

        private List<rtbSync> peers = new List<rtbSync>();

        /// <summary>
        /// Establish a 2-way binding between RTBs for scrolling.
        /// </summary>
        /// <param name="arg">Another RTB</param>
        public void BindScroll(rtbSync arg)
        {
            if (peers.Contains(arg) || arg == this) { return; }
            peers.Add(arg);
            arg.BindScroll(this);
        }

        private void DirectWndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL || m.Msg == WM_MOUSEWHEEL)
            {
                foreach (rtbSync peer in this.peers)
                {
                    Message peerMessage = Message.Create(peer.Handle, m.Msg, m.WParam, m.LParam);
                    peer.DirectWndProc(ref peerMessage);
                }
            }

            base.WndProc(ref m);
        }
    }
}
