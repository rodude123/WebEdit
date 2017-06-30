using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MsgBox;
using System.Text.RegularExpressions;

namespace htmlEditor
{
    public partial class htmlFormBuilder : Form
    {
        int yPos = 0;
        int formNo = 1;
        int[] startRange;
        int[] endRange;
        Dictionary<int, string> formList = new Dictionary<int, string>();
        Dictionary<string, int> inpType = new Dictionary<string, int>();
        int i = -1;
        int j = 1;
        int k = 1;
        int l = 1;
        int flNum = 0;

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

        public htmlFormBuilder()
        {
            InitializeComponent();
        }

        #region Mouse Down
        private void inpTxt_MouseDown(object sender, MouseEventArgs e)
        {
            inpTxt.DoDragDrop("Input Text", DragDropEffects.Move);
        }

        private void inpEmail_MouseDown(object sender, MouseEventArgs e)
        {
            inpEmail.DoDragDrop("Input E-mail", DragDropEffects.Move);
        }

        private void inpAdress_MouseDown(object sender, MouseEventArgs e)
        {
            inpAdress.DoDragDrop("Input Address", DragDropEffects.Move);
        }

        private void mobileNo_MouseDown(object sender, MouseEventArgs e)
        {
            mobileNo.DoDragDrop("Number", DragDropEffects.Move);
        }

        private void numberRange_MouseDown(object sender, MouseEventArgs e)
        {
            numberRange.DoDragDrop("Range", DragDropEffects.Move);
        }

        private void radio_MouseDown(object sender, MouseEventArgs e)
        {
            radio.DoDragDrop("Radio", DragDropEffects.Move);
        }

        private void check_MouseDown(object sender, MouseEventArgs e)
        {
            check.DoDragDrop("Check", DragDropEffects.Move);
        }

        private void select_MouseDown(object sender, MouseEventArgs e)
        {
            select.DoDragDrop("Select", DragDropEffects.Move);
        }

        private void textarea_MouseDown(object sender, MouseEventArgs e)
        {
            textarea.DoDragDrop("Textarea", DragDropEffects.Move);
        }

        #endregion

        #region drag enter
        private void panel2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void inpEmail_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        #endregion

        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string str = (string)e.Data.GetData(DataFormats.StringFormat);
                formList[flNum] = str;
                flNum++;
                Point cursorPos = new Point(0, 20);

                switch (str)
                {  
                    case "Input Text":
                        formInput(cursorPos, "Input Box", false, false, false, "");
                        break;
                    case "Input E-mail":
                        formInput(cursorPos, "E-mail Input Box", false, false, false, "");
                        break;
                    case "Input Address":
                        formInput(cursorPos, "Address Input Box", true, false, false, "");
                        break;
                    case "Number":
                        formInput(cursorPos, "Number Input Box", false, false, false, "");
                        break;
                    case "Range":
                        formInput(cursorPos, "Number Range Input Box", false, true, false, "");
                        break;
                    case "Radio":
                        formInput(cursorPos, "Radio Input", false, false, true, str);
                        break;
                    case "Check":
                        formInput(cursorPos, "Check Box Input", false, false, true, str);
                        break;
                    case "Select":
                        formInput(cursorPos, "Drop Down List", false, false, true, str);
                        break;
                    case "Textarea":
                        formInput(cursorPos, "Multiline Input Box", false, false, false, "");
                        break;
                }

            }
        }
        // shows users input based on whats been dragged on to the area
        public void formInput(Point cursorPos, string labelText, bool readOnly, bool requireRange, bool option, string type)
        {
            if (requireRange == true)
            {
                //Start Number
                while (true)
                {
                    InputBoxResult result = InputBox.Show("Type a start number", "Start Number", "0", null);
                    if (result.OK)
                    {
                        try
                        {
                            startRange = new int[] { Convert.ToInt32(result.Text) };
                            i++;
                            break;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Type a number", "Please Type a number");
                        }
                    }
                }
                //End Number
                while (true)
                {
                    InputBoxResult result2 = InputBox.Show("Type an end number", "End Number", "0", null);
                    if (result2.OK)
                    {
                        try
                        {
                            if (startRange[i] >= 0 && Convert.ToInt32(result2.Text) <= startRange[i])
                            {
                                MessageBox.Show("End Rnage cannot be smaller than start range", "Number is invalid");
                            }
                            else
                            {
                                endRange = new int[] { Convert.ToInt32(result2.Text) };
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Type a number", "Please Type a number");
                        }
                    }
                }
            }

            if (option == true)
            {
                while (true)
                {
                    InputBoxResult result3 = InputBox.Show("Type the number of elements for the radio, select or checkbox ect.", "Type the Number", "0", null);
                    if (result3.OK && result3.Text != "0")
                    {
                        try
                        {
                            if (type == "Radio")
                            {
                                inpType[type + j] = Convert.ToInt32(result3.Text);
                                j++;
                            }
                            else if(type == "Select")
                            {
                                inpType[type + k] = Convert.ToInt32(result3.Text);
                                k++;
                            }
                            else if (type == "Check")
                            {
                                inpType[type + l] = Convert.ToInt32(result3.Text);
                                l++;
                            }
                            break;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Type a number", "Please Type a number");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Type a number greater than 0", "Please Type a number");
                    }
                }
            }

            Label info = new Label();
            info.Location = new Point(73, cursorPos.Y + yPos);
            info.Size = new Size(120, 17);
            info.Text = labelText;
            info.Name = "info" + formNo;
            panel2.Controls.Add(info);

            TextBox txtBox = new TextBox();
            txtBox.Location = new Point(cursorPos.Y, cursorPos.Y + yPos + 30);
            txtBox.Size = new Size(187, 22);
            txtBox.ReadOnly = readOnly;
            txtBox.Name = "txtBoxN" + formNo;
            if (readOnly == false)
            {
                txtBox.Text = "This is for the Name of the form element";
            }
            else
            {
                txtBox.Text = "Nothing to type here";
            }
            panel2.Controls.Add(txtBox);

            TextBox txtBox1 = new TextBox();
            txtBox1.Location = new Point(cursorPos.Y, cursorPos.Y + yPos + 60);
            txtBox1.Size = new Size(187, 22);
            txtBox1.ReadOnly = readOnly;
            txtBox1.Name = "txtBoxP" + formNo;
            if (readOnly == false)
            {
                if (type == "Radio" || type == "Check" || type == "Select")
                {
                    txtBox1.Text = "Nothing to type here";
                    txtBox1.ReadOnly = true;
                }
                else
                {
                    txtBox1.Text = "Type placeholder text in here";
                }
            }
            else
            {
                txtBox1.Text = "Nothing to type here";
            }
            panel2.Controls.Add(txtBox1);

            yPos = yPos + cursorPos.Y + 90;
            formNo++;

        }

        private void htmlFormBuilder_Load(object sender, EventArgs e)
        {
            panel2.AllowDrop = true;
            WindowState = FormWindowState.Maximized;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void finish_Click(object sender, EventArgs e)
        {
            if (yPos == 0)
            {
                MessageBox.Show("Please Choose form elements before finsishing", "Choose some elements");
            }
            else
            {
                htmlCode();
                jsCode();
                //phpCode();
            }
        }

        void htmlCode()
        {
            Dictionary<int, string> htmlText = new Dictionary<int, string>();
            int r = 1;
            int c = 1;
            int s = 1;
            int num = -2;
            int num2 = -1;
            int num3 = 0;
            int m = 0;
            rtb1.Text = "";
            htmlText[0] = @"<form name='myForm' method='post' action='submit.php' onsubmit='return validateForm()'>";
            rtb1.Text += htmlText[0] + "\n";
            for (int i = 1; i < formList.Count+1; i++)
            {
                switch (formList[i-1])
                {
                    case "Input Text":
                        num = num + 3;
                        num2 = num2 + 3;
                        htmlText[i] = "        " + panel2.Controls[num].Text + @": <input type='text' name='" + panel2.Controls[num].Text + @"' placeholder='" + panel2.Controls[num2].Text + @"'><br>";
                        rtb1.Text += htmlText[i] + "\n";
                        break;
                    case "Input E-mail":
                        num = num + 3;
                        num2 = num2 + 3;
                        htmlText[i] = "        Email: <input type='email' name='" + panel2.Controls[num].Text + @"' placeholder='" + panel2.Controls[num2].Text + @"'><br>";
                        rtb1.Text += htmlText[i] + "\n";
                        break;
                    case "Input Address":
                        num = num + 3;
                        num2 = num2 + 3;
                        htmlText[i] = @"        Address Line 1: <input type='text' name='line1' placeholder='Address Line 1'>" + "\n" +
                            @"        Address Line 2: <input type='text' name='line2' placeholder='Address Line 2'>" + "\n" +
                             @"        City: <input type='text' name='city' placeholder='City e.g. London'>" + "\n" +
                             @"        State/County/Region: <input type='text' name='SCR' placeholder='State/County/Region'>" + "\n" +
                             @"        Zip/Postal Code: <input type='text' name='ZPC' placeholder='e.g. NG9 6LL'>" + "\n" +
                             @"        Country: <input type='text' name='Country' placeholder='United Kingdom'>" + "\n";
                        rtb1.Text += htmlText[i] + "\n";
                        break;
                    case "Number":
                        num = num + 3;
                        num2 = num2 + 3;
                        htmlText[i] = "        " + panel2.Controls[num].Text + @": <input type='number' name='" + panel2.Controls[num].Text + @"' placeholder='" + panel2.Controls[num2].Text + @"'><br>";
                        rtb1.Text += htmlText[i] + "\n";
                        break;
                    case "Range":
                        num = num + 3;
                        num2 = num2 + 3;
                        htmlText[i] = "        " + panel2.Controls[num].Text + @": <input type='number' min='" + startRange[m] + "' max='" + endRange[m] + "' name='" + panel2.Controls[num].Text + @"' placeholder='" + panel2.Controls[num2].Text + @"'><br>";
                        rtb1.Text += htmlText[i] + "\n";
                        m++;
                        break;
                    case "Radio":
                        num = num + 3;
                        num2 = num2 + 3;
                        num3 = i;
                        for (int index = 0; index < inpType["Radio" + r]; index++)
                        {
                            htmlText[num3 + index] = "        <input type='radio' name='" + panel2.Controls[num].Text + "' value='Change Value'>Change Text<br>";
                            rtb1.Text += htmlText[i] + "\n";
                        }
                        num3 = i + inpType["Radio" + r];
                        r++;
                        break;
                    case "Check":
                        num = num + 3;
                        num2 = num2 + 3;
                        num3 = i;
                        for (int index2 = 0; index2 < inpType["Check" + c]; index2++)
                        {
                            htmlText[num3 + index2] = "        <input type='checkbox' name='" + panel2.Controls[num].Text + "' value='Change Value'>Change Text<br>";
                            rtb1.Text += htmlText[i] + "\n";
                        }
                        num3 = i + inpType["Check" + c];
                        c++;
                        break;
                    case "Select":
                        num = num + 3;
                        num2 = num2 + 3;
                        htmlText[i] = "    <select name='" + panel2.Controls[num].Text + "'>";
                        rtb1.Text += htmlText[i] + "\n";

                        for (int index3 = 1; index3 < inpType["Select" + s] + 1; index3++)
                        {
                            htmlText[i + index3] = "        <option value='value " + index3 + "'>value " + index3 + "</option";
                            rtb1.Text += htmlText[i + index3] + "\n";
                        }
                        num3 = i + inpType["Select" + s];
                        htmlText[i] = "    </select>";
                        rtb1.Text += htmlText[i] + "\n";
                        s++;
                        break;
                    case "Textarea":
                        num = num + 3;
                        num2 = num2 + 3;
                        htmlText[i] = "        " + panel2.Controls[num].Text + @": <textarea name='" + panel2.Controls[num].Text + @"' rows='10' cols='30'></textarea><br>";
                        rtb1.Text += htmlText[i] + "\n";
                        break;
                }
            }
            htmlText[htmlText.Count] = @"</form>";
            rtb1.Text += htmlText[htmlText.Count - 1] + "\n";

        }

        void jsCode()
        {
            Dictionary<int, string> jsText = new Dictionary<int, string>();
            int num = -2;
            int num2 = -1;
            rtb2.Text = "";
            jsText[0] = @"function validateForm()
{";
            rtb2.Text += jsText[0] + "\n";
            for (int i = 1; i < formList.Count + 1; i++)
            {
                switch (formList[i - 1])
                {
                    case "Input Text":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var text" + i + @" = document.forms['myForm']['" + panel2.Controls[num].Text + @"'].value;
        if (text" + i + @" == '')
        {
            alert('" + panel2.Controls[num].Text + @" must be filled out');
            return false;
        }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Input E-mail":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var email" + i + @" = document.forms['myForm']['" + panel2.Controls[num].Text + @"'].value;
        if (email" + i + @" == '')
        {
            alert('" + panel2.Controls[num].Text + @" must be filled out');
            return false;
        }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Input Address":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Number":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var num" + i + @" = document.forms['myForm']['" + panel2.Controls[num].Text + @"'].value;
        if (num" + i + @" == '')
        {
            alert('" + panel2.Controls[num].Text + @" must be filled out');
            return false;
        }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Range":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var text" + i + @" = document.forms['myForm']['" + panel2.Controls[num].Text + @"'].value;
        if (text" + i + @" == '')
        { 
            alert('" + panel2.Controls[num].Text + @" must be filled out');
            return false;
        }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Radio":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var radio" + i + @" = document.forms['myForm']['" + panel2.Controls[num].Text + @"'].value;
        if (radio" + i + @" == '')
        {
            alert('" + panel2.Controls[num].Text + @" opotion must be chosen');
            return false;
        }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Check":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var check" + i + @" = document.forms['myForm']['" + panel2.Controls[num].Text + @"'].value;
        if (check" + i + @" == '')
        {
            alert('" + panel2.Controls[num].Text + @" must be chosen');
            return false;
        }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Select":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var text" + i + @" = document.forms['myForm']['" + panel2.Controls[num].Text + @"'].value;
        if (text" + i + @" == '')
        {
            alert('" + panel2.Controls[num].Text + @" must be chosen');
            return false;
        }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Textarea":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var textarea" + i + @" = document.forms['myForm']['" + panel2.Controls[num].Text + @"'].value;
        if (textarea" + i + @" == '')
        {
            alert(' " + panel2.Controls[num].Text + @" must have some text');
            return false;
        }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                }
            }
            jsText[0] = @"}";
            rtb2.Text += jsText[0] + "\n";
        }

 /*       void phpCode()
        {
            Dictionary<int, string> jsText = new Dictionary<int, string>();
            int num = -2;
            int num2 = -1;
            rtb2.Text = "";
            jsText[0] = @"function validateForm()
{";
            rtb2.Text += jsText[0] + "\n";
            for (int i = 1; i < formList.Count + 1; i++)
            {
                switch (formList[i - 1])
                {
                    case "Input Text":
                        num = num + 3;
                        num2 = num2 + 3;
                        
                        break;
                    case "Input E-mail":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var num" + i + @" = document.forms['myForm']['" + panel2.Controls[num].Text + @"'].value;
        if (num" + i + @" == '')
        {
            alert('" + panel2.Controls[num].Text + @" must be filled out');
            return false;
        }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Input Address":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Number":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var num" + i + @" = document.forms['myForm']['" + panel2.Controls[num].Text + @"'].value;
        if (num" + i + @" == '')
        {
            alert('" + panel2.Controls[num].Text + @" must be filled out');
            return false;
        }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Range":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var text" + i + @" = document.forms['myForm']['" + panel2.Controls[num].Text + @"'].value;
        if (text" + i + @" == '')
        { 
            alert('" + panel2.Controls[num].Text + @" must be filled out');
            return false;
        }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Radio":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var radios = document.getElementsByName('" + panel2.Controls[num].Text + @"');
        var formValid = false;

        var i = 0;
        while (!formValid && i < radios.length)
        {
            if (radios[i].checked) formValid = true;
            i++;
         }
        
         if (!formValid)
         { 
             alert('option must be chosen');​
         }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Check":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var checks = document.getElementsByName('" + panel2.Controls[num].Text + @"');
        var formValid = false;

        var i = 0;
        while (!formValid && i < checks.length)
        {
            if (checks[i].checked) formValid = true;
            i++;
         }
        
         if (!formValid)
         { 
             alert('Must check some option');​
         }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Select":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"        var checks = document.getElementsByName('" + panel2.Controls[num].Text + @"');
        var formValid = false;

        var i = 0;
        while (!formValid && i < checks.length)
        {
            if (checks[i].checked) formValid = true;
            i++;
         }
        
         if (!formValid)
         { 
             alert('Must select an option');​
         }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                    case "Textarea":
                        num = num + 3;
                        num2 = num2 + 3;
                        jsText[i] = @"var text" + i + @" = document.forms['myForm']['" + panel2.Controls[num].Text + @"'].value;
        if (text" + i + @" == '')
        {
            alert('[' " + panel2.Controls[num].Text + @" must have some text');
            return false;
        }";
                        rtb2.Text += jsText[i] + "\n";
                        break;
                }
            }
            jsText[0] = @"}";
            rtb2.Text += jsText[0] + "\n";
        }*/

        private void rtb1_TextChanged(object sender, EventArgs e)
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
            inpTxt.Focus();

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

        private void rtb2_TextChanged(object sender, EventArgs e)
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
            inpTxt.Focus();

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

        private void rtb3_TextChanged(object sender, EventArgs e)
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
            inpTxt.Focus();

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
    }
}
