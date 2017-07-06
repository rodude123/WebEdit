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
    public partial class teamLogin : Form
    {
        public teamLogin()
        {
            InitializeComponent();
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            string username = usernameSTxt.Text;
            string email = emailSTxt.Text;
            string password = passwordSTxt.Text;
            string rePassword = rePassSTxt.Text;
            string company = companySTxt.Text;
        }
    }
}
