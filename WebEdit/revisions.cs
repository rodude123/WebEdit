using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCP;

namespace htmlEditor
{
    public partial class revisions : Form
    {
        string teamname;
        public revisions()
        {
            InitializeComponent();
        }

        public string teamName
        {
            set
            {
                teamname = value.ToString();
            }
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

        //gets folder path to save to
        public void saveRev(string revNo)
        {
            string path = "";
            //creates a folder browser dialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }

            using (Session session = new Session())
            {
                session.Open(SO());
                //set transfer options i.e. whether imgaes/text files/both 
                TransferOptions TO = new TransferOptions();
                TO.TransferMode = TransferMode.Automatic;
                TransferOperationResult dl1 = session.GetFiles(teamname + "/" + teamname + revNo, path);
                if (dl1.IsSuccess)
                {
                    MessageBox.Show("Porject downloaded");
                }
                else
                {
                    MessageBox.Show("Try agauin with a different location or try again later. If nothing works please contact the developer for information");
                }
            }
        }

        private void rev1_Click(object sender, EventArgs e)
        {
            saveRev("1");
        }

        private void rev2_Click(object sender, EventArgs e)
        {
            saveRev("1");
        }

        private void rev3_Click(object sender, EventArgs e)
        {
            saveRev("3");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveRev("4");
        }
    }
}
