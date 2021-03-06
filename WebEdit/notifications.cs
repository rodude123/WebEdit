﻿using System;
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
        string teamname = "";
        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string dbPassword;
        string changedFiles;
        string projPath;
        int count = 0;
        int yPos;
        string[] notificationType;
        string[] notification;
        string[] message;
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
                user = value.ToString().ToLower();
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
            set
            {
                teamname = value.ToString();
            }
        }

        //getting project path
        public string projectPath
        {
            set
            {
                projPath = value.ToString(); 
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
If you do then please contact the developer for isseus.", "You cannot see your notifications right now");
                Console.WriteLine(e.ToString());
                return connection;
            }
        }

        private void notifications_Resize(object sender, EventArgs e)
        {

        }

        private void notifications_Load(object sender, EventArgs e)
        {
            try
            {
                //made connection to use to get the notifications
                MySqlConnection conn = makeConnection();
                //get notification type
                string getNotiTypesQuery = @"SELECT notificationType FROM webEditUsers WHERE username = '" + user + "'";
                MySqlCommand getNotiTypes = new MySqlCommand(getNotiTypesQuery, conn);
                string notificationTypes = getNotiTypes.ExecuteScalar().ToString();
                //string notificationTypes = "teamRejected"; //just for testing
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
                        p1.Location = new Point(49, 66 + yPos);
                        p1.Name = "p," + i;
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
                        b1.Click += rejectUser_Click;
                        p1.Controls.Add(b1);

                        //Accept button
                        Button b2 = new Button();
                        b2.Location = new Point(207, 82);
                        b2.Size = new Size(71, 21);
                        b2.Name = "ab" + i;
                        b2.Text = "Accept";
                        b2.FlatStyle = FlatStyle.Flat;
                        b2.Click += acceptUser_Click;
                        p1.Controls.Add(b2);

                        //Remove Button
                        Button b3 = new Button();
                        b3.Location = new Point(270, -1);
                        b3.Size = new Size(23, 28);
                        b3.Name = "newUser" + i;
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
                        //making sure it fits in after each notification
                        yPos = yPos + 100;
                    }
                    else if (notificationType[i] == "teamRejected")
                    {
                        teamname = notification[i];
                        Panel p1 = new Panel();
                        p1.Location = new Point(49, 66 + yPos);
                        p1.Name = "p," + i;
                        p1.Size = new Size(294, 75);
                        p1.BorderStyle = BorderStyle.FixedSingle;
                        //adds the panel to a lits to be removed when clicked
                        panels[count] = p1;
                        //adds the control to the panel
                        mainPanel.Controls.Add(p1);

                        //Label for title
                        Label l1 = new Label();
                        l1.Location = new Point(65, 8);
                        l1.Size = new Size(175, 13);
                        l1.Name = "title" + i;
                        l1.Text = "Team has rejected your proposal";
                        p1.Controls.Add(l1);

                        //Info text
                        Label l2 = new Label();
                        l2.Location = new Point(16, 24);
                        l2.Size = new Size(175, 39);
                        l2.Name = "infoText" + i;
                        l2.Text = "You have not been accepted into the team: " + teamname;
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
                        //making sure it fits in after each notification
                        yPos = yPos + 100;
                    }
                    else if (notificationType[i] == "newUpload")
                    {
                        changedFiles = notification[i];
                        //Back panel to group controls
                        Panel p1 = new Panel();
                        p1.Location = new Point(49, 66 + yPos);
                        p1.Name = "p," + i;
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
                        l1.Text = "Project Updated";
                        p1.Controls.Add(l1);

                        //Info text
                        Label l2 = new Label();
                        l2.Location = new Point(16, 24);
                        l2.Size = new Size(175, 39);
                        l2.Name = "infoText" + i;
                        l2.Text = notification[i] + "Do you want to see the changes.";
                        p1.Controls.Add(l2);

                        //See changes button
                        Button b2 = new Button();
                        b2.Location = new Point(195, 82);
                        b2.Size = new Size(91, 21);
                        b2.Name = "ab" + i;
                        b2.Text = "See Chnages";
                        b2.FlatStyle = FlatStyle.Flat;
                        b2.Click += seeChanges_Click;
                        p1.Controls.Add(b2);

                        //Remove Button
                        Button b3 = new Button();
                        b3.Location = new Point(270, -1);
                        b3.Size = new Size(23, 28);
                        b3.Name = "newUpload" + i;
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
                        //making sure it fits in after each notification
                        yPos = yPos + 100;
                    }
                    else if (notificationType[i] == "newTN")
                    {
                        string[] message = notification[i].Split(';');
                        //Back panel to group controls
                        Panel p1 = new Panel();
                        p1.Location = new Point(49, 66 + yPos);
                        p1.Name = "p," + i;
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
                        l1.Text = "New Team Name";
                        p1.Controls.Add(l1);

                        //Info text
                        Label l2 = new Label();
                        l2.Location = new Point(16, 24);
                        l2.Size = new Size(175, 39);
                        l2.Name = "infoText" + i;
                        l2.Text = message[0] + "Do you Accept or Reject the new Team Name";
                        p1.Controls.Add(l2);

                        //Reject button
                        Button b1 = new Button();
                        b1.Location = new Point(19, 82);
                        b1.Size = new Size(71, 21);
                        b1.Name = "rb" + i;
                        b1.Text = "Reject";
                        b1.FlatStyle = FlatStyle.Flat;
                        b1.Click += remove_Click;
                        p1.Controls.Add(b1);

                        //Accept button
                        Button b2 = new Button();
                        b2.Location = new Point(207, 82);
                        b2.Size = new Size(71, 21);
                        b2.Name = "ab" + i;
                        b2.Text = "Accept";
                        b2.FlatStyle = FlatStyle.Flat;
                        b2.Click += acceptTeam_Click;
                        p1.Controls.Add(b2);

                        //Remove Button
                        Button b3 = new Button();
                        b3.Location = new Point(270, -1);
                        b3.Size = new Size(23, 28);
                        b3.Name = "newTN" + i;
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
                        //making sure it fits in after each notification
                        yPos = yPos + 100;
                    }
                    else if(notificationType[i] == "leftTeam")
                    {
                        string user = notification[i];
                        Panel p1 = new Panel();
                        p1.Location = new Point(49, 66 + yPos);
                        p1.Name = "p," + i;
                        p1.Size = new Size(294, 75);
                        p1.BorderStyle = BorderStyle.FixedSingle;
                        //adds the panel to a lits to be removed when clicked
                        panels[count] = p1;
                        //adds the control to the panel
                        mainPanel.Controls.Add(p1);

                        //Label for title
                        Label l1 = new Label();
                        l1.Location = new Point(65, 8);
                        l1.Size = new Size(175, 13);
                        l1.Name = "title" + i;
                        l1.Text = "A member has left the team";
                        p1.Controls.Add(l1);

                        //Info text
                        Label l2 = new Label();
                        l2.Location = new Point(16, 24);
                        l2.Size = new Size(175, 39);
                        l2.Name = "infoText" + i;
                        l2.Text = "Ther team member:" + user + " has left the team";
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
                        //making sure it fits in after each notification
                        yPos = yPos + 100;
                    }
                }
                //close connection as not needed
                conn.Close();
            }
            catch (Exception)
            {

            }
        }

        //removes the panel from the controls and from the list so that it cannot accedently try to be removed again later which may give an error
        //also helps with memory issues
        private void remove_Click(object sender, EventArgs e)
        {
            //gets control
            Control control = (Control)sender;
            Console.WriteLine(control.Parent.Name); //for testing
            try
            { 
                //to remove control by Name
                foreach (Control item in mainPanel.Controls.OfType<Control>())
                {
                    if (item.Name == control.Parent.Name)
                        mainPanel.Controls.Remove(item);
                }
                MySqlConnection conn = makeConnection();
                //get particular notificationType
                string notiTypeQuery = "SELECT notificationType FROM webEditUsers WHERE username = '" + user + "'";
                MySqlCommand notiType = new MySqlCommand(notiTypeQuery, conn);
                string notiTypes = notiType.ExecuteScalar().ToString();
                //puts the notification types in a list 
                List<string> notificationTypes = new List<string>(notiTypes.Split(new string[] { ", " }, StringSplitOptions.None));
                //splits the control name in to two separate items i.e. string and int (for now a )
                string[] ctrlName = control.Name.Split(new char[] { ',' });
                //converts the string number from the control to number.
                //the number at the end of the control name corosponds to the number in the notificationType and notification list
                int num = Convert.ToInt32(ctrlName[1]);
                //removes the notificaionType from the list
                notificationTypes.RemoveAt(num);
                //creates string to hold removed notificationType
                string notificationType = "";
                //loops through the list of notificationTypes and adds them to the string
                for (int i = 0; i < notificationTypes.Count; i++)
                {
                    if (i != notificationTypes.Count-1)
                    {
                        notificationType += notificationTypes[i] + ", ";
                    }
                    else
                    {
                        notificationType += notificationTypes[i];
                    }
                }
                //get particular notification
                //repeats as above i.e. same as above but with different variables 
                string notiQuery = "SELECT notification FROM webEditUsers WHERE username = '" + user + "'";
                MySqlCommand notiCom = new MySqlCommand(notiQuery, conn);
                string noti = notiCom.ExecuteScalar().ToString();
                List<string> notifications = new List<string>(noti.Split(new string[] { ", " }, StringSplitOptions.None));
                notifications.RemoveAt(num);
                string notification = "";
                for (int i = 0; i < notifications.Count; i++)
                {
                    if (i != notifications.Count - 1)
                    {
                        notification += notifications[i] + ", ";
                    }
                    else
                    {
                        notification += notifications[i];
                    }
                }

                //get teamCode
                string getTeamCodeQuery = "SELECT teamCode FROM webEditUsers WHERE username = '" + user + "'";
                MySqlCommand getTeamCode = new MySqlCommand(getTeamCodeQuery, conn);
                string teamCode = getTeamCode.ExecuteScalar().ToString();
                //update team notifications
                string updateNotiQuery = "UPDATE webEditUsers SET notificationTypes = '" + notificationType + "', notification = '" + notification + "' WHERE teamCode = '" + teamCode + "'";
                MySqlCommand updateNoti = new MySqlCommand(updateNotiQuery, conn);
                updateNoti.ExecuteNonQuery();

                conn.Close();
            }
            catch
            {

            }
        }

        private void rejectUser_Click(object sender, EventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                remove_Click(sender, e);
                MySqlConnection conn = makeConnection();
                //sets notification so that user it notified that he didn't get accepted
                string notiTypeQuery = "UPDATE webEditUsers SET notificationType = 'teamRejected' WHERE username = '" + user2Add + "'";
                MySqlCommand notiType = new MySqlCommand(notiTypeQuery, conn);
                notiType.ExecuteNonQuery();
                //get team name
                string getTeamNameQuery = "SELECT teamName FROM webEditUsers WHERE username = '" + user + "'";
                MySqlCommand getTeamName = new MySqlCommand(getTeamNameQuery, conn);
                string teamName = getTeamName.ExecuteScalar().ToString();
                string notiQuery = "UPDATE webEditUsers SET notification                                                                                         = '" + teamName + "'";
                MySqlCommand noti = new MySqlCommand(notiQuery, conn);
                noti.ExecuteNonQuery();
                //close connection as not needed
                conn.Close();
            }
            catch(Exception)
            {

            }
        }

        private void acceptUser_Click(object sender, EventArgs e)
        {
            try
            {
                Control control = (Control)sender;
                //user accepted
                MessageBox.Show(user2Add + " accepted in to team");
                remove_Click(sender, e);
                MySqlConnection conn = makeConnection();
                //get team name
                string getTeamNameQuery = "SELECT teamName FROM webEditUsers WHERE username = '" + user + "'";
                MySqlCommand getTeamName = new MySqlCommand(getTeamNameQuery, conn);
                string teamName = getTeamName.ExecuteScalar().ToString();
                //get teamCode
                string getTeamCodeQuery = "SELECT teamCode FROM webEditUsers WHERE username = '" + user + "'";
                MySqlCommand getTeamCode = new MySqlCommand(getTeamCodeQuery, conn);
                string teamCode = getTeamCode.ExecuteScalar().ToString();
                //update teamName and teamCode
                string updateTeamQuery = "UPDATE webEditUsers SET teamName = '" + teamName + "', teamCode = '" + teamCode + "' WHERE username = '" + user2Add + "'";
                MySqlCommand updateTeam = new MySqlCommand(updateTeamQuery, conn);
                updateTeam.ExecuteNonQuery();
                //close connection as not needed
                conn.Close();
            }
            catch(Exception)
            {

            }
        }

        private void seeChanges_Click(object sender, EventArgs e)
        {
            seeChanges SC = new seeChanges();
            SC.changedFiles = changedFiles;
            if (string.IsNullOrWhiteSpace(projPath))
            {
                MessageBox.Show("Make sure that the project folder is open before seeing the changes", "Open a project Folder");
            }
            else
            {
                SC.teamName = teamname;
                SC.projPath = projPath;
                SC.username = user;
                SC.Show();
            }
            remove_Click(sender, e);
        }

        private void acceptTeam_Click(object sender, EventArgs e)
        {
            string teamName = message[1];
            MySqlConnection conn = makeConnection();
            string updateTNameQuery = @"UPDATE webEditUsers SET teamName = '" + teamName + "' WHERE username = '" + user + "'";
            MySqlCommand updateTName = new MySqlCommand(updateTNameQuery, conn);
            updateTName.ExecuteNonQuery();
            conn.Close();
        }

    }
}
