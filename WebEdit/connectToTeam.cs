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
    public partial class connectToTeam : Form
    {
        //defining global variables
        string user = "";
        string pass = "";

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

        private void getCode_Click(object sender, EventArgs e)
        {
            //defining variables
            Random rnd = new Random();
            bool notInTable = false;
            int teamCode = 0;

            //checking if it is in the table
            while (notInTable == false)
            {
                teamCode = rnd.Next(100000, 999999);
                rtbCode.Text = teamCode.ToString();
                notInTable = true;
            }
        }
    }
}
