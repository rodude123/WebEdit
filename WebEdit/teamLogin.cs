using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using MsgBox;

namespace htmlEditor
{
    public partial class teamLogin : Form
    {

        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string dbPassword;
        bool conResult;

        public teamLogin()
        {
            InitializeComponent();
        }

        public bool isLoggedIn
        {
            get
            {
                return loggedIn;
            }
        }
        private void signUpBtn_Click(object sender, EventArgs e)
        {
            // grab the user input and store in respective variables
            string username = usernameSTxt.Text;
            string email = emailSText.Text;
            string password = passwordSText.Text;
            string rePassword = rePassSTxt.Text;
            string company = companySTxt.Text;
            //validation
            //username
            if (string.IsNullOrWhiteSpace(username))
            {
                //check if username is empty, null or only consists of whitespaces
                usernameErr.Text = "Type a username";
            }
            else
            {
                string userReg = @"^[_a-zA-Z0-9]+$";
                Match userMatch = Regex.Match(username, userReg);
                //checks if it matches the criteria
                if (string.IsNullOrWhiteSpace(userMatch.ToString()))
                {
                    // if username is invalid
                    usernameErr.Text = "Invalid username";
                }
                else
                {
                    //connects to database
                    MySqlConnection usernameConn = makeConnection();
                    string usernameQuery = @"SELECT count(username) from webEditUsers WHERE username = '" + username + "' LIMIT 1";
                    MySqlCommand usernameComand = new MySqlCommand(usernameQuery, usernameConn);
                    //executes SQL code getting single string answer
                    string usernameResult = usernameComand.ExecuteScalar().ToString();
                    if (usernameResult.Trim() == "1")
                    {
                        //if username is in the database
                        usernameErr.Text = "Username already exists";
                    }
                    else
                    {
                        //if username is not in the databse
                        usernameErr.Text = "";
                    }
                    //closes connection as not needed for this execution of code
                    usernameConn.Close();
                }
            }
            //email address
            if (string.IsNullOrWhiteSpace(email))
            {
                //check if email address is empty, null or only consists of whitespaces
                emailErr.Text = "Type an email address";
            }
            else
            {
                string emailReg = @"^(([^<>()\[\]\\.,;:\s@""]+(\.[^<>()\[\]\\.,;:\s@""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";
                Match emailMatch = Regex.Match(email, emailReg);
                //checks if matches the criteria 
                if (string.IsNullOrWhiteSpace(emailMatch.ToString()))
                {
                    // if email address is invalid
                    emailErr.Text = "Invalid email address";
                }
                else
                {
                    //connects to database
                    MySqlConnection emailConn = makeConnection();
                    string emailQuery = @"SELECT count(email) from webEditUsers WHERE email = '" + email + "' LIMIT 1";
                    MySqlCommand emailComand = new MySqlCommand(emailQuery, emailConn);
                    //executes SQL code getting single string answer
                    string emailResult = emailComand.ExecuteScalar().ToString();
                    if (emailResult.Trim() == "1")
                    {
                        //checks if email is in the database
                        emailErr.Text = "Email Already exists";
                    }
                    else
                    {
                        //if email isn't in the database
                        emailErr.Text = "";
                    }
                    //closes connection as not needed for this execution of code
                    emailConn.Close();
                }
            }
            //password
            if (string.IsNullOrWhiteSpace(password))
            {
                //check if password is empty, null or only consists of whitespaces
                passwordErr.Text = "Type a password (Hover for help)";
            }
            else
            {
                string passReg = @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])([a-zA-Z0-9@#$%^&+=*.\-_]){8,}$";
                Match passMatch = Regex.Match(password, passReg);
                // checks if it matches the criteria
                if (string.IsNullOrWhiteSpace(passMatch.ToString()))
                {
                    //if password is invalid
                    passwordErr.Text = "Invalid password";
                }
                else
                {
                    //if password is valid
                    passwordErr.Text = "";
                }
            }
            //re-type password
            if (string.IsNullOrWhiteSpace(rePassword))
            {
                rePasswordErr.Text = "Please re-type the password";
            }
            else
            {
                if (rePassword.Trim() != password.Trim())
                {
                    //if passwords don't match
                    rePasswordErr.Text = "Passwords don't match";
                }
                else
                {
                    //if password is valid
                    rePasswordErr.Text = "";
                }
            }
            if (string.IsNullOrWhiteSpace(usernameErr.Text) && string.IsNullOrWhiteSpace(emailErr.Text) && string.IsNullOrWhiteSpace(passwordErr.Text) && string.IsNullOrWhiteSpace(rePasswordErr.Text))
            {
                //but before I should have checked if the username is already in the datahbase or not
                //and checked if the email address is in the database already too
                //omly then add the inforamtion to the database
                try
                {
                    //setup mail client with details
                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("no.reply.webedit@gmail.com", "gangolli");
                    //create email with confirmation code
                    Random rnd = new Random(); 
                    int conCode = rnd.Next(1,999999); //generate confirmation code
                    int conCodeLen = conCode.ToString().Length;
                    int conCodeFinal = 0;
                    switch (conCodeLen)
                    {
                        case 1:
                            conCodeFinal = Convert.ToInt32(conCode.ToString("D" + 5));
                            break;
                        case 2:
                            conCodeFinal = Convert.ToInt32(conCode.ToString("D" + 4));
                            break;
                        case 3:
                            conCodeFinal = Convert.ToInt32(conCode.ToString("D" + 3));
                            break;
                        case 4:
                            conCodeFinal = Convert.ToInt32(conCode.ToString("D" + 2));
                            break;
                        case 5:
                            conCodeFinal = Convert.ToInt32(conCode.ToString("D" + 1));
                            break;
                    }
                    MailMessage mm = new MailMessage("no.reply.webedit@gmail.com", email, "Webedit Sign Up Confirmation", "Here is the confirmation code required to sign up to WebEdit: " + conCodeFinal + "\n Sorry about the email address, this application is still in development, Thank you for downloading it and trying it out.");
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    //send email
                    client.Send(mm);

                    for (int i = 0; i < 3; i++)
                    {
                        int tries = 3;
                        tries = tries - i;
                        try
                        {
                            InputBoxResult result = InputBox.Show("Type your Confirmation code provided in your emails. \n You have " + tries + " tries left if it reaches 0 you will have sign up again.", "Confirmation Code", "0", null);
                            if (conCodeFinal == Convert.ToInt32(result.Text))
                            {
                                conResult = true;
                                break;
                            }
                        }
                        catch (Exception)
                        {

                        }

                    }

                    if (conResult == true)
                    {
                        MySqlConnection insConn = makeConnection();
                        string insQuery = "INSERT INTO webEditUsers(username, email, password, company) VALUES('" + username + "', '" + email + "','" + password + "','" + company + "')";
                        MySqlCommand insCommand = new MySqlCommand(insQuery, insConn);
                        insCommand.ExecuteNonQuery();
                        insConn.Close();
                        MessageBox.Show("You have signed up successfully", "Signed up");
                    }
                    usernameSTxt.Text = "";
                    emailSText.Text = "";
                    passwordSText.Text = "";
                    rePassSTxt.Text = "";
                    companySTxt.Text = "";
                }
                catch (Exception)
                {
                    
                }
            }
        }

        MySqlConnection makeConnection()
        {
            try
            {
                //connection information
                server = "webedit.heliohost.org";
                database = "webedit_WebEdit";
                uid = "webedit_webEdit";
                dbPassword = "Gangolli123";
                string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + dbPassword + ";";
                //connect to the database
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
                return connection;
            }
            catch (MySqlException e)
            {
                MessageBox.Show(@"Make sure you have a working internet connection.
If you do then please contact the developer for isseus.", "You cannot sign up right now");
                return connection;
            }
        }

        private void passwordSTxt_MouseHover(object sender, EventArgs e)
        {
            //show a help screen for the password strength
            passHelp.Show("The password should contain: atleast 8 characters, 1 capital letter and 1 numbner e.g. London1968 ", passwordSText);
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            //show a help screen for the passwo strength
            passHelp.Show("The password should contain: atleast 8 characters, 1 capital letter and 1 numbner e.g. London1968 ", label6);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //grab the user info from the login screen
                string username = usernameTxt.Text;
                string password = passwordTxt.Text;
                //connects to database
                MySqlConnection usernameConn = makeConnection();
                string usernameQuery = @"SELECT count(username) from webEditUsers WHERE username = '" + username + "' LIMIT 1";
                MySqlCommand usernameComand = new MySqlCommand(usernameQuery, usernameConn);
                //executes SQL code getting single string answer
                string usernameResult = usernameComand.ExecuteScalar().ToString();
                if (usernameResult.Trim() != "1")
                {
                    //if username doesn't exist
                    usernameLogin.Text = "Username doesn't exist";
                }
                else
                {
                    //if username does exist
                    usernameLogin.Text = "";
                }

                //connects to database
                MySqlConnection passwordConn = makeConnection();
                string passwordQuery = @"SELECT count(username) from webEditUsers WHERE username = '" + username + "' and password = '" + password + "' LIMIT 1";
                MySqlCommand passwordComand = new MySqlCommand(passwordQuery, passwordConn);
                //executes SQL code getting single string answer
                string passwordResult = passwordComand.ExecuteScalar().ToString();
                if (usernameResult.Trim() != "1")
                {
                    //if username doesn't exists
                    passwordLogin.Text = "";
                }
                else if (passwordResult.Trim() != "1")
                {
                    //if username does exist but password is wrong
                    passwordLogin.Text = "Password is incorect";
                }
                else
                {
                    //if username and password are both correct
                    passwordLogin.Text = "";
                }

                if (usernameLogin.Text == "" && passwordLogin.Text == "")
                {
                    // if username and password are both correct
                    MessageBox.Show("Login Successful");
                    Application.Exit();
                }
            }
            catch (Exception)
            {
               
            }
        }

        private void fpSuhmit_Click(object sender, EventArgs e)
        {
            try
            {
                string email = fpEmail.Text;
                //connects to database
                MySqlConnection emailConn = makeConnection();
                string emailQuery = @"SELECT count(email) from webEditUsers WHERE email = '" + email + "' LIMIT 1";
                MySqlCommand emailComand = new MySqlCommand(emailQuery, emailConn);
                //executes SQL code getting single string answer
                string emailResult = emailComand.ExecuteScalar().ToString();
                if (emailResult.Trim() != "1")
                {
                    //checks if the email isn't in the database
                    fpEmailErr.Text = "Email doesn't exist";
                }
                else
                {
                    //if email is in the database
                    fpEmailErr.Text = "";
                }
                //closes connection as not needed for this execution of code
                emailConn.Close();

            }
            catch (Exception)
            {
                
            }
            //todo: 
            //- send an email to user with reset code if working NEED TO GET EMAIL WORKING SOMEHOW
        }
    }
}
