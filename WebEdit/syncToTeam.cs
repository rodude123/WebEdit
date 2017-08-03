using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace htmlEditor
{
    public partial class syncToTeam : Form
    {
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
    }
}
