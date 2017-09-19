using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MsgBox;
namespace htmlEditor
{
    public partial class connectToTeam : Form
    {
        //defining global variables
        string user = "";
        string pass = "";
        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string dbPassword;
        string teamNameSender;

        public connectToTeam()
        {
            InitializeComponent();
        }

        //getting usrename
        public string username
        {
            set
            {
                user = value.ToString();
            }
        }
        //getting password
        public string password
        {
            set
            {
                pass = value.ToString();
            }
        }
        public string teamName
        {
            get
            {
                return teamNameSender;
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
                //if anything goes wrong
                MessageBox.Show(@"Make sure you have a working internet connection.
If you do then please contact the developer for isseus.", "You cannot connect to a team");
                Console.WriteLine(e.ToString());
                return connection;
            }
        }

        private void getCode_Click(object sender, EventArgs e)
        {
            try
            { 
                //defining variables
                Random rnd = new Random();
                bool inTable = false;
                int teamCode = 0;

                //loop until correct one is in the table
                while (inTable == false)
                {
                    //get random code
                    teamCode = rnd.Next(100000, 999999);
                    //check current code in database
                    MySqlConnection conn = makeConnection();
                    string checkUserResult = @"SELECT teamCode FROM webEditUsers WHERE username = '" + user + "' LIMIT 1";
                    MySqlCommand checkCode = new MySqlCommand(checkUserResult, conn);
                    string userResult = checkCode.ExecuteScalar().ToString();
                    //check if it is not equal to 0
                    if (userResult != "0")
                    {
                        rtbCode.Text = userResult;
                        string getTeamNameQuery = @"SELECT teamName FROM webEditUsers WHERE username = '" + user + "' ";
                        MySqlCommand getTeamName = new MySqlCommand(getTeamNameQuery, conn);
                        string teamName = getTeamName.ExecuteScalar().ToString();
                        greetMessage.Text = "Hello again, " + user + " and " + teamName;
                        inTable = true;
                    }
                    else
                    {
                        string codeQuery = @"SELECT count(teamCode) FROM webEditUsers WHERE teamCode = '" + teamCode + "' LIMIT 1";
                        MySqlCommand code = new MySqlCommand(codeQuery, conn);
                        string codeResult = code.ExecuteScalar().ToString();
                        if (codeResult == "0")
                        {
                            string updateCodeQuery = @"UPDATE webEditUsers SET teamCode = '" + teamCode + "' WHERE username = '" + user + "'";
                            MySqlCommand updateCode = new MySqlCommand(updateCodeQuery, conn);
                            updateCode.ExecuteNonQuery();
                            rtbCode.Text = teamCode.ToString();
                            inTable = true;
                            while (true)
                            {
                                InputBoxResult getTeamName = InputBox.Show("Please type a team name to use for your team. (This can be change later)", "Team Name", "", null);
                                if (getTeamName.OK && !string.IsNullOrWhiteSpace(getTeamName.Text))
                                {
                                    string selectTNameQuery = "SELECT COUNT(teamName) FROM webEditUsers WHERE teamName = '" + getTeamName.Text.Trim() + "'";
                                    MySqlCommand selectTname = new MySqlCommand(selectTNameQuery, conn);
                                    string checkTeamName = selectTname.ExecuteScalar().ToString();
                                    if (checkTeamName != "0")
                                    {
                                        MessageBox.Show("This team name is already taken, please chose another one","Team name already taken");
                                    }
                                    else
                                    {
                                        string updateTNameQuery = @"UPDATE webEditUsers SET teamName = '" + getTeamName.Text + "' WHERE username = '" + user + "'";
                                        MySqlCommand updateTName = new MySqlCommand(updateTNameQuery, conn);
                                        updateTName.ExecuteNonQuery();
                                        greetMessage.Text = "Hello, " + user + " and " + getTeamName.Text;
                                        teamNameSender = getTeamName.Text;
                                        teamNameSender = teamName;
                                        inTable = true;
                                        break;
                                    }
                                    
                                }
                            }
                        }
                    }
                    //close connection as not needed
                    conn.Close();
                }
            }
            catch
            {

            }
        }

        private void connectToTeam_Load(object sender, EventArgs e)
        {

        }

        private void connectTeam_Click(object sender, EventArgs e)
        {
            //define pre-variables
            string teamCode = rtbTeamCode.Text;
            if (string.IsNullOrEmpty(teamCode))
            {
                //if nothing was entered in text box
                teamCodeErr.Text = "Please type a team code";
            }
            else
            {
                try
                {
                    //makes connection to database
                    MySqlConnection conn = makeConnection();
                    //checks if there is a team code asociated with the user
                    string codeCheckQuery = "SELECT teamCode FROM webEditUsers WHERE username = '" + user + "' LIMIT 1";
                    MySqlCommand codeCheck = new MySqlCommand(codeCheckQuery, conn);
                    string codeResult = codeCheck.ExecuteScalar().ToString();
                    if (codeResult != "0")
                    {
                        // if so aks them to leave perevious team
                        teamCodeErr.Text = "Please leave previous team before joining a new one";
                    }
                    else
                    {
                        //checks if teamCode is correct i.e. exists in the database
                        string codeCorrectQuery = "SELECT COUNT(teamCode) FROM webEditUsers WHERE teamCode = '" + teamCode + "' LIMIT 1";
                        MySqlCommand codeCorrect = new MySqlCommand(codeCorrectQuery, conn);
                        string ccResult = codeCorrect.ExecuteScalar().ToString();
                        if (ccResult == "0")
                        {
                            teamCodeErr.Text = "Team code is invalid. Please try again";
                        }
                        else
                        {
                            //checks if users in team to connect to have notifications that have not been seen
                            string checkNotiTypeQuery = "SELECT COUNT(*) FROM `webEditUsers` WHERE teamCode='" + teamCode + "' AND `notificationType` IS NULL";
                            MySqlCommand checkNotiType = new MySqlCommand(checkNotiTypeQuery, conn);
                            string checkNotiTypeResult = checkNotiType.ExecuteScalar().ToString();
                            if (checkNotiTypeResult != "0")
                            {
                                //if not just set as normal
                                string updateNotiQuery = "UPDATE webEditUsers SET notificationType = 'newUser', notification='" + user + "' WHERE teamCode='" + teamCode + "' ";
                                MySqlCommand updateNoti = new MySqlCommand(updateNotiQuery, conn);
                                updateNoti.ExecuteNonQuery();
                            }
                            else
                            {
                                //if so add new after previous with [,] as the definer to make easier later to get the notifications
                                string updateNotiQuery = "UPDATE webEditUsers SET notificationType = concat(notificationType, ', newUser'), notification = concat(notification, ', " + user + "') WHERE teamCode='" + teamCode + "' ";
                                MySqlCommand updateNoti = new MySqlCommand(updateNotiQuery, conn);
                                updateNoti.ExecuteNonQuery();
                            }
                            teamCodeErr.Text = "";
                        }
                    }
                    //close connection as not needed
                    conn.Close();
                    this.Close();
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
