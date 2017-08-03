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
        public SessionOptions SO;
        public syncToTeam()
        {
            InitializeComponent();
        }

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

        private void sync_Click(object sender, EventArgs e)
        {
            using (Session session = new Session())
            {
                // Connect
                session.Open(SO);
            }
        }

        private void syncToTeam_Load(object sender, EventArgs e)
        {
            SO = new SessionOptions
            {
                Protocol = Protocol.Ftp,
                HostName = "example.com",
                UserName = "user",
                Password = "password"
            };
        }
    }
}
