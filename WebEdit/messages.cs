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
            Timer timer1 = new Timer();
            timer1.Tick += Timer1_Tick;
            timer1.Interval = 15000; // in miliseconds
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            using (Session session = new Session())
            {
                session.Open(SO());
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\messagesTemp\\" + teamname + "M.txt"))
                {
                    DateTime remoteWriteTime = session.GetFileInfo("/" + teamname + "M.txt").LastWriteTime;
                    DateTime localWriteTime = File.GetLastWriteTime(AppDomain.CurrentDomain.BaseDirectory + "\\messagesTemp\\" + teamname + "M.txt");
                    if (remoteWriteTime >= localWriteTime)
                    {
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\messagesTemp\\" + teamname + "M.txt");
                        session.GetFiles("/" + teamname + "M.txt", AppDomain.CurrentDomain.BaseDirectory + "\\messagesTemp\\" + teamname + "M.txt");
                    }
                }
                session.Close();
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            //Checks if the file exists
            if(!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\messagesTemp\\" + teamname + "M.txt"))
            {
                //if the file doesn't exist then create a new one inside a specified directory
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\messagesTemp\\");
                File.Create(AppDomain.CurrentDomain.BaseDirectory + "\\messageTemp\\" + teamname + "M.txt");
            }

            //Creates a message 
            string message = DateTime.Today.ToString("dd/MM/yyy") + ", " + user + ": " + rtbMessage.Text.Trim();
            //displays message in listbox
            displayMessages.Items.Add(message);
            for (int i = 0; i < displayMessages.Items.Count; i++)
            {
                using (StreamWriter SW = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\messageTemp\\" + teamname + "M.txt", false))
                {
                    //writes message to file
                    SW.WriteLine(displayMessages.Items[i]);
                }
            }

            //deletes file from FTP location and adds new file
            using (Session session = new Session())
            { 
                //starts session
                session.Open(SO());
                
                //checks if the file exsists
                if (session.FileExists("/" + teamname + "M.txt"))
                {
                    //deletes/removes remote file
                    session.RemoveFiles("/" + teamname + "M.txt");
                }

                //put new file
                session.PutFiles(AppDomain.CurrentDomain.BaseDirectory + "\\messagesTemp\\" + teamname + "M.txt", "/");
                session.Close();
            }
        }
    }
}
