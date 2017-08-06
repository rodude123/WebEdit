using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using WinSCP;

namespace htmlEditor
{
    public partial class syncToTeam : Form
    {
        string teamname = "";
        string projectPath = "";
        public syncToTeam()
        {
            InitializeComponent();
        }

        SessionOptions SO()
        {
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = "ftp.webedit.heliohost.org",
                UserName = "webEditTeams@webedit.heliohost.org",
                Password = "Gangolli123"
            };
            return sessionOptions;
        }

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

        private void sync_Click(object sender, EventArgs e)
        {
            try
            {
                using (Session session = new Session())
                {
                    // Connect to FTP
                    session.Open(SO());
                    //set transfer options i.e. whether imgaes/text files/both 
                    TransferOptions TO = new TransferOptions();
                    TO.TransferMode = TransferMode.Automatic;
                    string remotePath1 = teamname + "1";
                    if (session.FileExists(teamname))
                    {
                        Console.WriteLine("Folder found"); //for testing
                        if (session.FileExists(teamname + @"\" + remotePath1))
                        {
                            //do something
                        }
                        else
                        {
                            session.CreateDirectory(remotePath1);
                        }
                    }
                    else
                    {
                        //Console.WriteLine("Folder not found"); //for testing
                        session.CreateDirectory(teamname);
                        session.CreateDirectory(teamname + @"\" + remotePath1);
                        
                    }
                    //TransferOperationResult TR = session.PutFiles(@"localFiles", "", false, TO);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(@"Make sure you have a working internet connection.
If you do then please contact the developer for isseus.","Cannot sync with the team");
                MessageBox.Show(ex.ToString());
            }
        }

        private void syncToTeam_Load(object sender, EventArgs e)
        {

        }
    }
}
