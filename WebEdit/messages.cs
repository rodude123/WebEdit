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

namespace htmlEditor
{
    public partial class messages : Form
    {
        string user;
        string teamname;
        public messages()
        {
            InitializeComponent();
        }

        public string username
        {
            set
            {
                user = value.ToString();
            }
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
                UserName = "webEditMessages@webedit.heliohost.org",
                Password = "Gangolli123"
            };
            return sessionOptions;
        }

        private void messages_Load(object sender, EventArgs e)
        {
            
        }

        private void send_Click(object sender, EventArgs e)
        {
            if(!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\messagesTemp\\" + teamname + "M.txt"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\messagesTemp\\");
                File.Create(AppDomain.CurrentDomain.BaseDirectory + "\\messageTemp\\" + teamname + "M.txt");
            }
            string message = DateTime.Today.ToString("dd/MM/yyy") + ", " + user + ": " + rtbMessage.Text.Trim();
            displayMessages.Items.Add(message);
            for (int i = 0; i < displayMessages.Items.Count; i++)
            {
                using (StreamWriter SW = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\messageTemp\\" + teamname + "M.txt", false))
                {
                    SW.WriteLine(displayMessages.Items[i]);
                }
            }
        }
    }
}
