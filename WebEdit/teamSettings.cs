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
    public partial class teamSettings : Form
    {
        bool leftteam;
        string teamcode;
        string teamname;
        string user;
        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string dbPassword;
        public teamSettings()
        {
            InitializeComponent();
        }

        public bool leftTeam
        {
            get
            {
                return leftteam;
            }
        }

        public string teamName
        {
            set
            {
                teamname = value.ToString();
            }
        } 

        public string username
        {
            set
            {
                user = value.ToString();
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
If you do then please contact the developer for isseus.", "You cannot leave a team or rename your team Name right now");
                Console.WriteLine(e.ToString());
                return connection;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void leaveTeam_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = makeConnection();
            string leftTeamQuery = "UPDATE WebEditUsers SET teamName = '', teamCode = '0', notification = '', notificationType = ''";
            MySqlCommand leftTeam = new MySqlCommand(leftTeamQuery, conn);
            leftTeam.ExecuteNonQuery();
            string checkNotiTypeQuery = "SELECT COUNT(*) FROM `webEditUsers` WHERE teamCode='" + teamcode + "' AND `notificationType` IS NULL";
            MySqlCommand checkNotiType = new MySqlCommand(checkNotiTypeQuery, conn);
            string checkNotiTypeResult = checkNotiType.ExecuteScalar().ToString();
            if (checkNotiTypeResult != "0")
            {
                //if not just set as normal
                string updateNotiQuery = "UPDATE webEditUsers SET notificationType = 'leftTeam', notification='" + user + "' WHERE teamCode='" + teamcode + "' ";
                MySqlCommand updateNoti = new MySqlCommand(updateNotiQuery, conn);
                updateNoti.ExecuteNonQuery();
            }
            else
            {
                //if so add new after previous with [,] as the definer to make easier later to get the notifications
                string updateNotiQuery = "UPDATE webEditUsers SET notificationType = concat(notificationType, ', leftTeam'), notification = concat(notification, ', " + user + "') WHERE teamCode='" + teamcode + "'";
                MySqlCommand updateNoti = new MySqlCommand(updateNotiQuery, conn);
                updateNoti.ExecuteNonQuery();
            }
            leftteam = true;
            this.Dispose();
            this.Close();
        }

        private void renameTN_Click(object sender, EventArgs e)
        {
            while (true)
            {
                InputBoxResult result = InputBox.Show("New Team Name", "Team Name", "e.g. companyTeam1", null);
                if (result.Text != "")
                {
                    MySqlConnection conn = makeConnection();
                    string checkNotiTypeQuery = "SELECT COUNT(*) FROM `webEditUsers` WHERE teamCode='" + teamcode + "' AND `notificationType` IS NULL";
                    MySqlCommand checkNotiType = new MySqlCommand(checkNotiTypeQuery, conn);
                    string checkNotiTypeResult = checkNotiType.ExecuteScalar().ToString();
                    if (checkNotiTypeResult != "0")
                    {
                        //if not just set as normal
                        string updateNotiQuery = "UPDATE webEditUsers SET notificationType = 'newTN', notification='The user: " + user + " wants to change the the Team Name to " +  result.Text + ";" + result.Text + "' WHERE teamCode='" + teamcode + "' ";
                        MySqlCommand updateNoti = new MySqlCommand(updateNotiQuery, conn);
                        updateNoti.ExecuteNonQuery();
                    }
                    else
                    {
                        //if so add new after previous with [,] as the definer to make easier later to get the notifications
                        string updateNotiQuery = "UPDATE webEditUsers SET notificationType = concat(notificationType, ', newTN'), notification = concat(notification, ', The user: " + user + " wants to change the the Team Name to " + result.Text + ";" + result.Text + "') WHERE teamCode='" + teamcode + "' ";
                        MySqlCommand updateNoti = new MySqlCommand(updateNotiQuery, conn);
                        updateNoti.ExecuteNonQuery();
                    }
                    break;
                }
            }
        }

        private void teamSettings_Load(object sender, EventArgs e)
        {
            //make connection
            MySqlConnection conn = makeConnection();
            //gets teamCode
            string teamCodeQuery = "SELECT teamCode FROM WebEditUsers WHERE teamName ='" + teamname + "' LIMIT 1";
            MySqlCommand getTeamCode = new MySqlCommand(teamCodeQuery, conn);
            teamcode = getTeamCode.ExecuteScalar().ToString();
        }

        private void teamSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
