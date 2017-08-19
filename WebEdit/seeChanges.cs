using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using htmlEditor.DiffMergeStuffs;
using WinSCP;
using System.Linq;
using MySql.Data.MySqlClient;

namespace htmlEditor
{
    public partial class seeChanges : Form
    {
        int updating;
        Style greenStyle;
        Style redStyle;
        public string files;
        public List<string> fileSplit;
        public int fCount = 0;
        public string projectPath;
        public string teamname;
        public string user;
        MySqlConnection connection;
        string server;
        string database;
        string uid;
        string dbPassword;
        public seeChanges()
        {
            InitializeComponent();


            greenStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(50, Color.Lime)));
            redStyle = new MarkerStyle(new SolidBrush(Color.FromArgb(50, Color.Red)));
        }

        //getting files
        public string changedFiles
        {
            set
            {
                files = value.ToString();
            }
        }
        //getting project path
        public string projPath
        {
            set
            {
                projectPath = value.ToString();
            }
        }
        //getting team Name for remote path
        public string teamName
        {
            set
            {
                teamname = value.ToString();
            }
        }
        //getting username
        public string username
        {
            set
            {
                user = value.ToString();
            }
        }

        //predefined functions to get the connection opptions
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
                MessageBox.Show(@"Make sure you have a working internet connection.
If you do then please contact the developer for isseus.", "You cannot see your notifications right now");
                Console.WriteLine(e.ToString());
                return connection;
            }
        }

        #region comparison
        void tb_VisibleRangeChanged(object sender, EventArgs e)
        {
            if (updating > 0)
                return;

            var vPos = (sender as FastColoredTextBox).VerticalScroll.Value;
            var curLine = (sender as FastColoredTextBox).Selection.Start.iLine;

            if (sender == remoteRtb)
                UpdateScroll(localRtb, vPos, curLine);
            else
                UpdateScroll(remoteRtb, vPos, curLine);

            localRtb.Refresh();
            remoteRtb.Refresh();
        }

        void UpdateScroll(FastColoredTextBox tb, int vPos, int curLine)
        {
            if (updating > 0)
                return;
            //
            BeginUpdate();
            //
            if (vPos <= tb.VerticalScroll.Maximum)
            {
                tb.VerticalScroll.Value = vPos;
                tb.UpdateScrollbars();
            }

            if (curLine < tb.LinesCount)
                tb.Selection = new Range(tb, 0, curLine, 0, curLine);
            //
            EndUpdate();
        }

        private void EndUpdate()
        {
            updating--;
        }

        private void BeginUpdate()
        {
            updating++;
        }

        private void Process(Lines lines)
        {
            foreach (var line in lines)
            {
                switch (line.state)
                {
                    case DiffType.None:
                        localRtb.AppendText(line.line + Environment.NewLine);
                        remoteRtb.AppendText(line.line + Environment.NewLine);
                        break;
                    case DiffType.Inserted:
                        localRtb.AppendText(Environment.NewLine);
                        remoteRtb.AppendText(line.line + Environment.NewLine, greenStyle);
                        break;
                    case DiffType.Deleted:
                        localRtb.AppendText(line.line + Environment.NewLine, redStyle);
                        remoteRtb.AppendText(Environment.NewLine);
                        break;
                }
                if (line.subLines != null)
                    Process(line.subLines);
            }
        }
        #endregion

        private void seeChanges_Load(object sender, EventArgs e)
        {
            //gets the list of files from the text
            string[] filesSplit = files.Split(':');
            string[] fileSplitTemp = filesSplit[1].Trim().Split(';');
            fileSplit = fileSplitTemp.ToList();
            fileSplit.RemoveAt(fileSplit.Count - 1);

            //new working condition
            //gets remote file
            using (Session session = new Session())
            {
                // Connect to FTP
                session.Open(SO());
                //set transfer options i.e. whether imgaes/text files/both 
                TransferOptions TO = new TransferOptions();
                TO.TransferMode = TransferMode.Binary;
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "tempDwl");
                session.GetFiles(teamname + "/" + teamname + "1/" + fileSplit[fCount], AppDomain.CurrentDomain.BaseDirectory + "\\tempDwl\\", false, TO);
            }

            localRtb.Clear();
            remoteRtb.Clear();

            Cursor = Cursors.WaitCursor;
            //gets soruce files 
            var source1 = Lines.Load(projectPath + fileSplit[fCount]);
            var source2 = Lines.Load(AppDomain.CurrentDomain.BaseDirectory + "tempDwl\\" + fileSplit[fCount]);
            //checks files
            source1.Merge(source2);

            BeginUpdate();

            Process(source1);

            EndUpdate();

            Cursor = Cursors.Default;

            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "tempDwl\\" + fileSplit[fCount]);
        }

        private void acceptChanges_Click(object sender, EventArgs e)
        {
            string localText = localRtb.Text;
            FileStream FSW = new FileStream(projectPath + fileSplit[fCount], FileMode.Create, FileAccess.Write);
            using (StreamWriter SW = new StreamWriter(FSW))
            {
                SW.Write(localText);
                SW.Close();
            }
            FSW.Close();
            fCount++;
            if (fCount >= fileSplit.Count)
            {
                MessageBox.Show("All Changes have been accepted or rejected", "Changes Accepted or rejected");
                removeNoti();
                this.Close();
                this.Dispose();
            }
            else
            {
                //gets remote file
                using (Session session = new Session())
                {
                    // Connect to FTP
                    session.Open(SO());
                    //set transfer options i.e. whether imgaes/text files/both 
                    TransferOptions TO = new TransferOptions();
                    TO.TransferMode = TransferMode.Binary;
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "tempDwl");
                    session.GetFiles(teamname + "/" + teamname + "1/" + fileSplit[fCount], AppDomain.CurrentDomain.BaseDirectory + "\\tempDwl\\", false, TO);
                }

                localRtb.Clear();
                remoteRtb.Clear();

                Cursor = Cursors.WaitCursor;
                //gets soruce files 
                var source1 = Lines.Load(projectPath + fileSplit[fCount]);
                var source2 = Lines.Load(AppDomain.CurrentDomain.BaseDirectory + "tempDwl\\" + fileSplit[fCount]);
                //checks files
                source1.Merge(source2);

                BeginUpdate();

                Process(source1);

                EndUpdate();

                Cursor = Cursors.Default;

                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "tempDwl\\" + fileSplit[fCount]);
            }
        }



        private void acceptChanges_MouseHover(object sender, EventArgs e)
        {
            acceptTip.Show("Remember to make changes to the local file before accepting the changes. You can do this just by copying/deleting the sections in the left textbox", acceptChanges);
        }

        public void removeNoti()
        {
            MySqlConnection conn = makeConnection();
            //get particular notificationType
            string notiTypeQuery = "SELECT notificationType FROM webEditUsers WHERE username = '" + user + "'";
            MySqlCommand notiType = new MySqlCommand(notiTypeQuery, conn);
            string notiTypes = notiType.ExecuteScalar().ToString();
            //puts the notification types in a list 
            List<string> notificationTypes = new List<string>(notiTypes.Split(new string[] { ", " }, StringSplitOptions.None));
            //converts the string number from the control to number.
            int num = notificationTypes.IndexOf("newUpload");
            notificationTypes.Remove("newUpload");
            //creates string to hold removed notificationType
            string notificationType = "";
            //loops through the list of notificationTypes and adds them to the string
            for (int i = 0; i < notificationTypes.Count; i++)
            {
                if (i != notificationTypes.Count - 1)
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
            Console.WriteLine("Notification Types: {0} \nNotification: {1}", notificationType, notification);
            //get teamCode
            string getTeamCodeQuery = "SELECT teamCode FROM webEditUsers WHERE username = '" + user + "'";
            MySqlCommand getTeamCode = new MySqlCommand(getTeamCodeQuery, conn);
            string teamCode = getTeamCode.ExecuteScalar().ToString();
            //update team notifications
            string updateNotiQuery = "UPDATE webEditUsers SET notificationTypes = '" + notificationType + "', notification = '" + notification + "' WHERE teamCode = '" + teamCode + "'";
            MySqlCommand updateNoti = new MySqlCommand(updateNotiQuery, conn);
            updateNoti.ExecuteNonQuery();
        }

        private void rejectChanges_Click(object sender, EventArgs e)
        {
            using (Session session = new Session())
            {
                TransferOptions TO = new TransferOptions();
                TO.TransferMode = TransferMode.Binary;
                session.RemoveFiles(teamname + "/" + teamname + "1/" + fileSplit[fCount]);
                session.GetFiles(teamname + "/" + teamname + "2/" + fileSplit[fCount], AppDomain.CurrentDomain.BaseDirectory + "tempDwl\\", false, TO);
                session.PutFiles(AppDomain.CurrentDomain.BaseDirectory + "tempDwl\\" + fileSplit[fCount], teamname + "/" + teamname + "1/");
                session.Close();
            }
            fCount++;
            if (fCount >= fileSplit.Count)
            {
                MessageBox.Show("All Changes have been accepted or rejected", "Changes Accepted or rejected");
                removeNoti();
                this.Close();
                this.Dispose();
            }
            else
            {
                //gets remote file
                using (Session session = new Session())
                {
                    // Connect to FTP
                    session.Open(SO());
                    //set transfer options i.e. whether imgaes/text files/both 
                    TransferOptions TO = new TransferOptions();
                    TO.TransferMode = TransferMode.Binary;
                    Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "tempDwl");
                    session.GetFiles(teamname + "/" + teamname + "1/" + fileSplit[fCount], AppDomain.CurrentDomain.BaseDirectory + "\\tempDwl\\", false, TO);
                }

                localRtb.Clear();
                remoteRtb.Clear();

                Cursor = Cursors.WaitCursor;
                //gets soruce files 
                var source1 = Lines.Load(projectPath + fileSplit[fCount]);
                var source2 = Lines.Load(AppDomain.CurrentDomain.BaseDirectory + "tempDwl\\" + fileSplit[fCount]);
                //checks files
                source1.Merge(source2);

                BeginUpdate();

                Process(source1);

                EndUpdate();

                Cursor = Cursors.Default;

                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "tempDwl\\" + fileSplit[fCount]);
            }
        }
    }

    #region Merge stuffs

    namespace DiffMergeStuffs
    {
        public class SimpleDiff<T>
        {
            private IList<T> _left;
            private IList<T> _right;
            private int[,] _matrix;
            private bool _matrixCreated;
            private int _preSkip;
            private int _postSkip;

            private Func<T, T, bool> _compareFunc;

            public SimpleDiff(IList<T> left, IList<T> right)
            {
                _left = left;
                _right = right;

                InitializeCompareFunc();
            }

            public event EventHandler<DiffEventArgs<T>> LineUpdate;

            public TimeSpan ElapsedTime { get; private set; }

            /// <summary>
            /// This is the sole public method and it initializes
            /// the LCS matrix the first time it's called, and 
            /// proceeds to fire a series of LineUpdate events
            /// </summary>
            public void RunDiff()
            {
                if (!_matrixCreated)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    CalculatePreSkip();
                    CalculatePostSkip();
                    CreateLCSMatrix();
                    sw.Stop();
                    this.ElapsedTime = sw.Elapsed;
                }

                for (int i = 0; i < _preSkip; i++)
                {
                    FireLineUpdate(DiffType.None, i, -1);
                }

                int totalSkip = _preSkip + _postSkip;
                ShowDiff(_left.Count - totalSkip, _right.Count - totalSkip);

                int leftLen = _left.Count;
                for (int i = _postSkip; i > 0; i--)
                {
                    FireLineUpdate(DiffType.None, leftLen - i, -1);
                }
            }

            /// <summary>
            /// This method is an optimization that
            /// skips matching elements at the end of the 
            /// two arrays being diff'ed.
            /// Care's taken so that this will never
            /// overlap with the pre-skip.
            /// </summary>
            private void CalculatePostSkip()
            {
                int leftLen = _left.Count;
                int rightLen = _right.Count;
                while (_postSkip < leftLen && _postSkip < rightLen &&
                       _postSkip < (leftLen - _preSkip) &&
                       _compareFunc(_left[leftLen - _postSkip - 1], _right[rightLen - _postSkip - 1]))
                {
                    _postSkip++;
                }
            }

            /// <summary>
            /// This method is an optimization that
            /// skips matching elements at the start of
            /// the arrays being diff'ed
            /// </summary>
            private void CalculatePreSkip()
            {
                int leftLen = _left.Count;
                int rightLen = _right.Count;
                while (_preSkip < leftLen && _preSkip < rightLen &&
                       _compareFunc(_left[_preSkip], _right[_preSkip]))
                {
                    _preSkip++;
                }
            }

            /// <summary>
            /// This traverses the elements using the LCS matrix
            /// and fires appropriate events for added, subtracted, 
            /// and unchanged lines.
            /// It's recursively called till we run out of items.
            /// </summary>
            /// <param name="leftIndex"></param>
            /// <param name="rightIndex"></param>
            private void ShowDiff(int leftIndex, int rightIndex)
            {
                if (leftIndex > 0 && rightIndex > 0 &&
                    _compareFunc(_left[_preSkip + leftIndex - 1], _right[_preSkip + rightIndex - 1]))
                {
                    ShowDiff(leftIndex - 1, rightIndex - 1);
                    FireLineUpdate(DiffType.None, _preSkip + leftIndex - 1, -1);
                }
                else
                {
                    if (rightIndex > 0 &&
                        (leftIndex == 0 ||
                         _matrix[leftIndex, rightIndex - 1] >= _matrix[leftIndex - 1, rightIndex]))
                    {
                        ShowDiff(leftIndex, rightIndex - 1);
                        FireLineUpdate(DiffType.Inserted, -1, _preSkip + rightIndex - 1);
                    }
                    else if (leftIndex > 0 &&
                             (rightIndex == 0 ||
                              _matrix[leftIndex, rightIndex - 1] < _matrix[leftIndex - 1, rightIndex]))
                    {
                        ShowDiff(leftIndex - 1, rightIndex);
                        FireLineUpdate(DiffType.Deleted, _preSkip + leftIndex - 1, -1);
                    }
                }

            }

            /// <summary>
            /// This is the core method in the entire class,
            /// and uses the standard LCS calculation algorithm.
            /// </summary>
            private void CreateLCSMatrix()
            {
                int totalSkip = _preSkip + _postSkip;
                if (totalSkip >= _left.Count || totalSkip >= _right.Count)
                    return;

                // We only create a matrix large enough for the
                // unskipped contents of the diff'ed arrays
                _matrix = new int[_left.Count - totalSkip + 1, _right.Count - totalSkip + 1];

                for (int i = 1; i <= _left.Count - totalSkip; i++)
                {
                    // Simple optimization to avoid this calculation
                    // inside the outer loop (may have got JIT optimized 
                    // but my tests showed a minor improvement in speed)
                    int leftIndex = _preSkip + i - 1;

                    // Again, instead of calculating the adjusted index inside
                    // the loop, I initialize it under the assumption that
                    // incrementing will be a faster operation on most CPUs
                    // compared to addition. Again, this may have got JIT
                    // optimized but my tests showed a minor speed difference.
                    for (int j = 1, rightIndex = _preSkip + 1; j <= _right.Count - totalSkip; j++, rightIndex++)
                    {
                        _matrix[i, j] = _compareFunc(_left[leftIndex], _right[rightIndex - 1])
                                            ? _matrix[i - 1, j - 1] + 1
                                            : Math.Max(_matrix[i, j - 1], _matrix[i - 1, j]);
                    }
                }

                _matrixCreated = true;
            }

            private void FireLineUpdate(DiffType diffType, int leftIndex, int rightIndex)
            {
                var local = this.LineUpdate;

                if (local == null)
                    return;

                T lineValue = leftIndex >= 0 ? _left[leftIndex] : _right[rightIndex];

                local(this, new DiffEventArgs<T>(diffType, lineValue, leftIndex, rightIndex));
            }

            private void InitializeCompareFunc()
            {
                // Special case for String types
                if (typeof(T) == typeof(String))
                {
                    _compareFunc = StringCompare;
                }
                else
                {
                    _compareFunc = DefaultCompare;
                }
            }

            /// <summary>
            /// This comparison is specifically
            /// for strings, and was nearly thrice as 
            /// fast as the default comparison operation.
            /// </summary>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <returns></returns>
            private bool StringCompare(T left, T right)
            {
                return Object.Equals(left, right);
            }

            private bool DefaultCompare(T left, T right)
            {
                return left.Equals(right);
            }
        }

        [Flags]
        public enum DiffType
        {
            None = 0,
            Inserted = 1,
            Deleted = 2
        }

        public class DiffEventArgs<T> : EventArgs
        {
            public DiffType DiffType { get; set; }

            public T LineValue { get; private set; }
            public int LeftIndex { get; private set; }
            public int RightIndex { get; private set; }

            public DiffEventArgs(DiffType diffType, T lineValue, int leftIndex, int rightIndex)
            {
                this.DiffType = diffType;
                this.LineValue = lineValue;
                this.LeftIndex = leftIndex;
                this.RightIndex = rightIndex;
            }
        }

        /// <summary>
        /// Line of file
        /// </summary>
        public class Line
        {
            /// <summary>
            /// Source string
            /// </summary>
            public readonly string line;

            /// <summary>
            /// Inserted strings
            /// </summary>
            public Lines subLines;

            /// <summary>
            /// Line state
            /// </summary>
            public DiffType state;

            public Line(string line)
            {
                this.line = line;
            }

            /// <summary>
            /// Equals
            /// </summary>
            public override bool Equals(object obj)
            {
                return Object.Equals(line, ((Line)obj).line);
            }

            public static bool operator ==(Line line1, Line line2)
            {
                return Object.Equals(line1.line, line2.line);
            }

            public static bool operator !=(Line line1, Line line2)
            {
                return !Object.Equals(line1.line, line2.line);
            }

            public override string ToString()
            {
                return line;
            }
        }

        /// <summary>
        /// File as list of lines
        /// </summary>
        public class Lines : List<Line>, IEquatable<Lines>
        {
            //эта строка нужна для хранения строк, вставленных в самом начале, до первой строки исходного файла
            private Line fictiveLine = new Line("===fictive line===") { state = DiffType.Deleted };

            public Lines()
            {
            }


            public Lines(int capacity)
                : base(capacity)
            {
            }

            public Line this[int i]
            {
                get
                {
                    if (i == -1) return fictiveLine;
                    return base[i];
                }

                set
                {
                    if (i == -1) fictiveLine = value;
                    base[i] = value;
                }
            }

            /// <summary>
            /// Load from file
            /// </summary>
            public static Lines Load(string fileName, Encoding enc = null)
            {
                Lines lines = new Lines();
                foreach (var line in File.ReadAllLines(fileName, enc ?? Encoding.Default))
                    lines.Add(new Line(line));

                return lines;
            }

            /// <summary>
            /// Merge lines
            /// </summary>
            public void Merge(Lines lines)
            {
                SimpleDiff<Line> diff = new SimpleDiff<Line>(this, lines);
                int iLine = -1;

                diff.LineUpdate += (o, e) =>
                {
                    if (e.DiffType == DiffType.Inserted)
                    {
                        if (this[iLine].subLines == null)
                            this[iLine].subLines = new Lines();
                        e.LineValue.state = DiffType.Inserted;
                        this[iLine].subLines.Add(e.LineValue);
                    }
                    else
                    {
                        iLine++;
                        this[iLine].state = e.DiffType;
                        if (iLine > 0 &&
                            this[iLine - 1].state == DiffType.Deleted &&
                            this[iLine - 1].subLines == null &&
                            e.DiffType == DiffType.None)
                            this[iLine - 1].subLines = new Lines();
                    }
                };
                //запускаем алгоритм нахождения максимальной подпоследовательности (LCS)
                diff.RunDiff();
            }

            /// <summary>
            /// Clone
            /// </summary>
            public Lines Clone()
            {
                Lines result = new Lines(this.Count);
                foreach (var line in this)
                    result.Add(new Line(line.line));

                return result;
            }

            /// <summary>
            /// Is lines equal?
            /// </summary>
            public bool Equals(Lines other)
            {
                if (Count != other.Count)
                    return false;
                for (int i = 0; i < Count; i++)
                    if (this[i] != other[i])
                        return false;
                return true;
            }

            /// <summary>
            /// Transform tree to list
            /// </summary>
            public Lines Expand()
            {
                return Expand(-1, Count - 1);
            }

            /// <summary>
            /// Transform tree to list
            /// </summary>
            public Lines Expand(int from, int to)
            {
                Lines result = new Lines();
                for (int i = from; i <= to; i++)
                {
                    if (this[i].state != DiffType.Deleted)
                        result.Add(this[i]);
                    if (this[i].subLines != null)
                        result.AddRange(this[i].subLines.Expand());
                }

                return result;
            }
        }

        /// <summary>
        /// Строка, содержащая несколько конфликтных версий
        /// </summary>
        public class ConflictedLine : Line
        {
            public readonly Lines version1;
            public readonly Lines version2;

            public ConflictedLine(Lines version1, Lines version2)
                : base("?")
            {
                this.version1 = version1;
                this.version2 = version2;
            }
        }
    }
    #endregion
}
