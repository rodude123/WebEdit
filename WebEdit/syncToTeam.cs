using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WinSCP;
using MySql.Data.MySqlClient;

namespace htmlEditor
{
    public partial class syncToTeam : Form
    {
        //predefined variables 
        string teamname = "";
        string projectPath = "";
        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string dbPassword;
        string user;
        public DirectoryInfo[] directories;

        public syncToTeam()
        {
            InitializeComponent();
        }
        //predefined functions to output the connection opptions
        SessionOptions SO()
        {
            //host options
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = "ftp.webedit.heliohost.org",
                UserName = "webEditTeams@webedit.heliohost.org",
                Password = "Gangolli123"
            };
            return sessionOptions;
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
        //ends here
        //gets teamName here
        public string teamName
        {
            set
            {
                teamname = value.ToString();
            }
        }

        public string projPath
        {
           set
           {
                projectPath = value.ToString();
           }
        }

        public string username
        {
            set
            {
                user = value.ToString();
            }
        }

        #region tooltip hover text
        private void sync_MouseHover(object sender, EventArgs e)
        {
            syncTip.Show("Changes have to be aproved by another team member", sync);
        }

        private void revs_MouseHover(object sender, EventArgs e)
        {
            revsTip.Show("See upto 4 previous revisions of the project", revs);
        }

        private void dLProj_MouseHover(object sender, EventArgs e)
        {
            dLTip.Show("Download the latest revision of the project", dLProj);
        }

        private void deleteFiles_MouseHover(object sender, EventArgs e)
        {
            deleteTip.Show("Delete unwanted files from the project but changes have to be aproved by another team member", deleteFiles);
        }
        #endregion

        public static void deleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                deleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        private void sync_Click(object sender, EventArgs e)
        {
            try
            {
                bool uploaded = false;
                MySqlConnection conn = makeConnection();
                string checkSyncQuery = "SELECT notificationType FROM webEditUsers WHERE teamName = '" + teamname + "'";
                MySqlCommand checkSync = new MySqlCommand(checkSyncQuery, conn);
                string notiTypes = checkSync.ExecuteScalar().ToString();
                string[] notiTypeSplit = notiTypes.Split(new string[] { ", " }, StringSplitOptions.None);
                foreach (string notiType in notiTypeSplit)
                {
                    if (notiType == "newUpload")
                    {
                        uploaded = true;
                    }
                }
                if (uploaded == false)
                {
                    using (Session session = new Session())
                    {
                        // Connect to FTP
                        session.Open(SO());
                        //set transfer options i.e. whether imgaes/text files/both 
                        TransferOptions TO = new TransferOptions();
                        TO.TransferMode = TransferMode.Automatic;
                        //remote directories
                        string remotePath1 = teamname + "1";
                        string remotePath2 = teamname + "2";
                        string remotePath3 = teamname + "3";
                        string remotePath4 = teamname + "4";
                        string remotePath5 = teamname + "5";
                        bool synced = false;
                        string[] uploadedFiles = new string[] { };
                        string[] downloadedFiles = new string[] { };
                        if (session.FileExists(teamname))
                        {
                            Console.WriteLine("Folder found"); //for testing
                                                               //checks for each directory on the server if it isn't there it creates it
                            if (session.FileExists(teamname + @"/" + remotePath1 + @"/"))
                            {
                                if (session.FileExists(teamname + @"/" + remotePath2))
                                {
                                    if (session.FileExists(teamname + @"/" + remotePath3))
                                    {
                                        if (session.FileExists(teamname + @"/" + remotePath4))
                                        {
                                            session.MoveFile(teamname + @"/" + remotePath4, teamname + @"/" + remotePath5);
                                            session.MoveFile(teamname + @"/" + remotePath3, teamname + @"/" + remotePath4);
                                            session.MoveFile(teamname + @"/" + remotePath2, teamname + @"/" + remotePath3);
                                            session.MoveFile(teamname + @"/" + remotePath1, teamname + @"/" + remotePath2);
                                            session.CreateDirectory(teamname + @"/" + remotePath1);
                                        }
                                        else
                                        {
                                            session.MoveFile(teamname + @"/" + remotePath3, teamname + @"/" + remotePath4);
                                            session.MoveFile(teamname + @"/" + remotePath2, teamname + @"/" + remotePath3);
                                            session.MoveFile(teamname + @"/" + remotePath1, teamname + @"/" + remotePath2);
                                            session.CreateDirectory(teamname + @"/" + remotePath1);
                                        }
                                    }
                                    else
                                    {
                                        session.MoveFile(teamname + @"/" + remotePath2, teamname + @"/" + remotePath3);
                                        session.MoveFile(teamname + @"/" + remotePath1, teamname + @"/" + remotePath2);
                                        session.CreateDirectory(teamname + @"/" + remotePath1);
                                    }
                                }
                                else
                                {
                                    session.MoveFile(teamname + @"/" + remotePath1, teamname + @"/" + remotePath2);

                                }
                                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\tempUpl");
                                session.GetFiles(teamname + @"/" + remotePath2, AppDomain.CurrentDomain.BaseDirectory + @"\tempUpl");
                                session.PutFiles(AppDomain.CurrentDomain.BaseDirectory + @"\tempUpl", teamname + @"/" + remotePath1);
                                deleteDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\tempUpl");
                                SynchronizationResult SR = session.SynchronizeDirectories(SynchronizationMode.Both, projectPath, teamname + @"/" + remotePath1, false);
                                TransferEventArgsCollection uploads = SR.Uploads;
                                TransferEventArgsCollection downloads = SR.Downloads;
                                synced = SR.IsSuccess;
                                for (int i = 0; i < uploads.Count; i++)
                                {
                                    uploadedFiles = new string[] { uploads[i].FileName };
                                }
                                for (int j = 0; j < downloads.Count; j++)
                                {
                                    downloadedFiles = new string[] { downloads[j].FileName };
                                }
                                if (uploadedFiles.Length == 0)
                                {
                                    if (session.FileExists(teamname + @"/" + remotePath2))
                                    {
                                        if (session.FileExists(teamname + @"/" + remotePath3))
                                        {
                                            if (session.FileExists(teamname + @"/" + remotePath4))
                                            {
                                                session.RemoveFiles(teamname + @"/" + remotePath1);
                                                session.MoveFile(teamname + @"/" + remotePath2, teamname + @"/" + remotePath1);
                                                session.MoveFile(teamname + @"/" + remotePath3, teamname + @"/" + remotePath2);
                                                session.MoveFile(teamname + @"/" + remotePath4, teamname + @"/" + remotePath3);
                                            }
                                            else
                                            {
                                                session.RemoveFiles(teamname + @"/" + remotePath1);
                                                session.MoveFile(teamname + @"/" + remotePath2, teamname + @"/" + remotePath1);
                                                session.MoveFile(teamname + @"/" + remotePath3, teamname + @"/" + remotePath2);
                                            }
                                        }
                                        else
                                        {
                                            session.RemoveFiles(teamname + @"/" + remotePath1);
                                            session.MoveFile(teamname + @"/" + remotePath2, teamname + @"/" + remotePath1);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Something went wrong");
                                    }
                                }
                            }
                            else
                            {
                                session.CreateDirectory(teamname + @"/" + remotePath1);
                                SynchronizationResult SR = session.SynchronizeDirectories(SynchronizationMode.Both, projectPath, teamname + @"/" + remotePath1, false);
                                TransferEventArgsCollection uploads = SR.Uploads;
                                TransferEventArgsCollection downloads = SR.Downloads;
                                synced = SR.IsSuccess;
                                for (int i = 0; i < uploads.Count; i++)
                                {
                                    uploadedFiles = new string[] { uploads[i].FileName };
                                }
                                for (int j = 0; j < downloads.Count; j++)
                                {
                                    downloadedFiles = new string[] { downloads[j].FileName };
                                }
                            }
                        }
                        else
                        {
                            //Console.WriteLine("Folder not found"); //for testing
                            session.CreateDirectory(teamname);
                            session.CreateDirectory(teamname + @"/" + remotePath1);
                        }
                        // if synced
                        if (synced && (uploadedFiles.Length != 0 || downloadedFiles.Length != 0))
                        {
                            MessageBox.Show("Synced files with the server");
                            //MessageBox.Show(uploadedFiles.ToString(), "Uploaded Files");
                        }
                        else
                        {
                            MessageBox.Show("Something went wrong or no files to upload or download");
                        }

                        string notiFiles = "";
                        foreach (string file in uploadedFiles)
                        {
                            notiFiles = file + "; ";
                            Console.WriteLine(notiFiles);
                        }
                        try
                        {
                            string getTeamCodeQuery = @"SELECT teamCode FROM webEditUsers WHERE teamName = '" + teamname + "' AND NOT username = '" + user + "' LIMIT 1";
                            MySqlCommand getTeamCode = new MySqlCommand(getTeamCodeQuery, conn);
                            string teamCode = getTeamCode.ExecuteScalar().ToString();
                            //checks if users in team to connect to have notifications that have not been seen
                            string checkNotiTypeQuery = "SELECT COUNT(*) FROM `webEditUsers` WHERE teamCode='" + teamCode + "' AND `notificationType` IS NULL";
                            MySqlCommand checkNotiType = new MySqlCommand(checkNotiTypeQuery, conn);
                            string checkNotiTypeResult = checkNotiType.ExecuteScalar().ToString();
                            if (checkNotiTypeResult != "0")
                            {
                                //if not just set as normal
                                string updateNotiQuery = "UPDATE webEditUsers SET notificationType = 'newUpload', notification='" + user + " updated these files: " + Path.GetFileName(notiFiles) + "' WHERE teamCode='" + teamCode + "' AND NOT usernane ='" + user + "";
                                MySqlCommand updateNoti = new MySqlCommand(updateNotiQuery, conn);
                                updateNoti.ExecuteNonQuery();
                            }
                            else
                            {
                                //if so add new after previous with [,] as the definer to make easier later to get the notifications
                                string updateNotiQuery = "UPDATE webEditUsers SET notificationType = concat(notificationType, ', newUpload'), notification = concat(notification, ', " + user + " updated these files: " + Path.GetFileName(notiFiles) + "') WHERE teamCode='" + teamCode + "'" + user + "";
                                MySqlCommand updateNoti = new MySqlCommand(updateNotiQuery, conn);
                                updateNoti.ExecuteNonQuery();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Make sure that there is more than one member in the team and if there is please contact the developer for issues", "Needs more than one team member");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("A user has already made changes to the project. See the changes and accept or reject the changes to upload again", "A user already made changes");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(@"Make sure you have a working internet connection.
If you do then please contact the developer for issues.","Cannot sync with the team");
                MessageBox.Show(ex.ToString());
            }
        }

        private void syncToTeam_Load(object sender, EventArgs e)
        {

        }
    }
}
