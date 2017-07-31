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

namespace htmlEditor
{
    public partial class notifications : Form
    {
        //defining global variables
        string user = "";
        string pass = "";
        string user2Add = "";
        string teamName = "";
        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string dbPassword;
        int count = 0;
        int removeCount = 0;
        string[] notificationType;
        string[] notification;
        Dictionary<int, Panel> panels = new Dictionary<int, Panel>();
        public notifications()
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
                Console.WriteLine(e.ToString());
                return connection;
            }
        }

        private void notifications_Resize(object sender, EventArgs e)
        {

        }

        private void notifications_Load(object sender, EventArgs e)
        {
            //made connection to use to get the notifications
            MySqlConnection conn = makeConnection();
            //get notification type
            string getNotiTypesQuery = @"SELECT notificationType FROM webEditUsers WHERE username = '" + user + "'";
            MySqlCommand getNotiTypes = new MySqlCommand(getNotiTypesQuery, conn);
            string notificationTypes = getNotiTypes.ExecuteScalar().ToString();
            //string notificationTypes = "newUser"; //just for testing
            //get the notification itself
            string getNotiQuery = @"SELECT notification FROM webEditUsers WHERE username = '" + user + "'";
            MySqlCommand getNoti = new MySqlCommand(getNotiQuery, conn);
            string notifications = getNoti.ExecuteScalar().ToString();
            //string notifications = "rodude123"; //just for testing
            //getting each value by splitting by the deliminater [,]
            notificationType = notificationTypes.Split(new string[] { ", " }, StringSplitOptions.None);
            notification = notifications.Split(new string[] { ", " }, StringSplitOptions.None);


            //loop for each value in notifactions and display them
            for (int i = 0; i < notificationType.Length; i++)
            {
                if (notificationType[i] == "newUser")
                {
                    user2Add = notification[i];
                    //Back panel to group controls
                    Panel p1 = new Panel();
                    p1.Location = new Point(49, 66);
                    p1.Name = "p" + i;
                    p1.Size = new Size(294, 117);
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    //adds the panel to a lits to be removed when clicked
                    panels[count] = p1;
                    //adds the control to the panel
                    mainPanel.Controls.Add(p1);

                    //Label for title
                    Label l1 = new Label();
                    l1.Location = new Point(100, 8);
                    l1.Size = new Size(54, 13);
                    l1.Name = "title" + i;
                    l1.Text = "New User";
                    p1.Controls.Add(l1);

                    //Info text
                    Label l2 = new Label();
                    l2.Location = new Point(16, 24);
                    l2.Size = new Size(175, 39);
                    l2.Name = "infoText" + i;
                    l2.Text = "The user: " + notification[i] + " wants to join your team. \nDo you accept/reject";
                    p1.Controls.Add(l2);

                    //Reject button
                    Button b1 = new Button();
                    b1.Location = new Point(19, 82);
                    b1.Size = new Size(71, 21);
                    b1.Name = "rb" + i;
                    b1.Text = "Reject";
                    b1.FlatStyle = FlatStyle.Flat;
                    b1.Click += reject_Click;
                    p1.Controls.Add(b1);

                    //Accept button
                    Button b2 = new Button();
                    b2.Location = new Point(207, 82);
                    b2.Size = new Size(71, 21);
                    b2.Name = "ab" + i;
                    b2.Text = "Accept";
                    b2.FlatStyle = FlatStyle.Flat;
                    b2.Click += accept_Click;
                    p1.Controls.Add(b2);

                    //Remove Button
                    Button b3 = new Button();
                    b3.Location = new Point(270, -1);
                    b3.Size = new Size(23, 28);
                    b3.Name = "remove" + i;
                    b3.Text = "X";
                    b3.FlatStyle = FlatStyle.Flat;
                    b3.FlatAppearance.BorderSize = 0;
                    b3.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    b3.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    b3.BackColor = Color.Transparent;
                    b3.BackgroundImageLayout = ImageLayout.Center;
                    b3.Cursor = Cursors.Hand;
                    b3.Click += remove_Click;
                    p1.Controls.Add(b3);

                    count = count + i;
                }
                else if(notificationType[i] == "teamRejected")
                {
                    teamName = notification[i];
                    Panel p1 = new Panel();
                    p1.Location = new Point(49, 66);
                    p1.Name = "p" + i;
                    p1.Size = new Size(294, 117);
                    p1.BorderStyle = BorderStyle.FixedSingle;
                    //adds the panel to a lits to be removed when clicked
                    panels[count] = p1;
                    //adds the control to the panel
                    mainPanel.Controls.Add(p1);

                    //Label for title
                    Label l1 = new Label();
                    l1.Location = new Point(100, 8);
                    l1.Size = new Size(54, 13);
                    l1.Name = "title" + i;
                    l1.Text = "New User";
                    p1.Controls.Add(l1);

                    //Info text
                    Label l2 = new Label();
                    l2.Location = new Point(16, 24);
                    l2.Size = new Size(175, 39);
                    l2.Name = "infoText" + i;
                    l2.Text = "You have not been accepted into the team: " + teamName;
                    p1.Controls.Add(l2);

                    //Remove Button
                    Button b3 = new Button();
                    b3.Location = new Point(270, -1);
                    b3.Size = new Size(23, 28);
                    b3.Name = "remove" + i;
                    b3.Text = "X";
                    b3.FlatStyle = FlatStyle.Flat;
                    b3.FlatAppearance.BorderSize = 0;
                    b3.FlatAppearance.MouseDownBackColor = Color.Transparent;
                    b3.FlatAppearance.MouseOverBackColor = Color.Transparent;
                    b3.BackColor = Color.Transparent;
                    b3.BackgroundImageLayout = ImageLayout.Center;
                    b3.Cursor = Cursors.Hand;
                    b3.Click += remove_Click;
                    p1.Controls.Add(b3);

                    count = count + i;
                }
            }
        }

        private void remove_Click(object sender, EventArgs e)
        { 
            //removes the panel from the controls and from the list so that it cannot accedently try to be removed again later which may give an error
            //also helps with memory issues
            //adds one to the remove count showing how many have been remnoved
            mainPanel.Controls.Remove(panels[removeCount]);
            panels.Remove(removeCount);
            removeCount++;
            MySqlConnection conn = makeConnection();
            //removes particular notification
            string notiTypeQuery = "UPDATE webEditUsers SET notificationType = '', SET notification = '' WHERE username = '" + user + "'";
            MySqlCommand notiType = new MySqlCommand(notiTypeQuery, conn);
            notiType.ExecuteNonQuery();
        }

        private void reject_Click(object sender, EventArgs e)
        {
            //user not accepted
            //MessageBox.Show(user2Add + " not accepted"); //for testing
            //same as in remove_Click()
            mainPanel.Controls.Remove(panels[removeCount]);
            panels.Remove(removeCount);
            removeCount++;
            MySqlConnection conn = makeConnection();
            //sets notification so that user it notified that he didn't get accepted
            string notiTypeQuery = "UPDATE webEditUsers SET notificationType = 'teamRejected' WHERE username = '" + user2Add +"'";
            MySqlCommand notiType = new MySqlCommand(notiTypeQuery, conn);
            notiType.ExecuteNonQuery();
            //get team name
            string getTeamNameQuery = "SELECT teamName FROM webEditUsers WHERE username = '" + user + "'";
            MySqlCommand getTeamName = new MySqlCommand(getTeamNameQuery, conn);
            string teamName = getTeamName.ExecuteScalar().ToString();
            string notiQuery = "UPDATE webEditUsers SET notification = '" + teamName + "'";
            MySqlCommand noti = new MySqlCommand(notiQuery, conn);
            noti.ExecuteNonQuery();

        }

        private void accept_Click(object sender, EventArgs e)
        {
            //user accepted
            MessageBox.Show(user2Add + " accepted in to team");
            //same as in remove_Click
            mainPanel.Controls.Remove(panels[removeCount]);
            panels.Remove(removeCount);
            removeCount++;
            MySqlConnection conn = makeConnection();
            //get team name
            string getTeamNameQuery = "SELECT teamName FROM webEditUsers WHERE username = '" + user + "'";
            MySqlCommand getTeamName = new MySqlCommand(getTeamNameQuery, conn);
            string teamName = getTeamName.ExecuteScalar().ToString();
            //get teamCode
            string getTeamCodeQuery = "SELECT teamCode FROM webEditUsers WHERE username = '" + user +"'";
            MySqlCommand getTeamCode = new MySqlCommand(getTeamCodeQuery, conn);
            string teamCode = getTeamCode.ExecuteScalar().ToString();
            //update teamName and teamCode
            string updateTeamQuery = "UPDATE webEditUser SET teamName = '" + teamName + "', teamCode = '" + teamCode + "' WHERE username = '" + user2Add + "'";
            MySqlCommand updateTeam = new MySqlCommand(updateTeamQuery, conn);
            updateTeam.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        { 

        }
    }
}
