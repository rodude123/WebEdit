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

namespace htmlEditor
{
    public partial class teamLogin : Form
    {

        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string dbPassword;

        public teamLogin()
        {
            InitializeComponent();
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
                    //before error message becomes blank check if it is in the MySQL db
                    usernameErr.Text = "";
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
                    //before error message becomes blank check if it is in the MySQL db
                    emailErr.Text = "";
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
                //connect to the MySQL database and store the information in a row of the table
                //but before I should have checked if the username is already in the datahbase or not
                //and checked if the email address is in the database already too
                //omly then add the inforamtion to the database
                MySqlConnection conn =  makeConnection();
                conn.Close();
            }
        }

        MySqlConnection makeConnection()
        {
            try
            {
                //connection information
                server = "rodude.heliohost.org";
                database = "rodude_WebEdit";
                uid = "rodude_webEdit";
                dbPassword = "Gangolli123";
                string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + dbPassword + ";";
                //connect to the database
                connection = new MySqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
                return connection;
            }
            catch (MySqlException)
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
            //grab the user info from the login screen
            string username = usernameSTxt.Text;
            string password = emailSText.Text;
            //to do:
            //- check if it matches with the database and if so go back to webEdit and enable the buttons.  
        }
    }
}
