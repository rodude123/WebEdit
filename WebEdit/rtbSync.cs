using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rtb
{
    public class rtbSync : RichTextBox
    {

        private const int WM_VSCROLL = 0x115;
        private const int WM_HSCROLL = 0x114;
        private const int WM_MOUSEWHEEL = 0x20a;

        private List<rtbSync> peers = new List<rtbSync>();

        /// <summary>
        /// Establish a 2-way binding between RTBs for scrolling.
        /// </summary>
        /// <param name="arg">Another RTB</param>
        public void BindScroll(rtbSync arg)
        {
            if (peers.Contains(arg) || arg == this) { return; }
            peers.Add(arg);
            arg.BindScroll(this);
        }

        private void DirectWndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_VSCROLL || m.Msg == WM_HSCROLL || m.Msg == WM_MOUSEWHEEL)
            {
                foreach (rtbSync peer in this.peers)
                {
                    Message peerMessage = Message.Create(peer.Handle, m.Msg, m.WParam, m.LParam);
                    peer.DirectWndProc(ref peerMessage);
                }
            }

            base.WndProc(ref m);
        }
    }
}
