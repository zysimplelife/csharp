using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;

namespace PaiPaiAssistant
{
    public partial class Information : Form
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]

        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        public Information()
        {
            InitializeComponent();
        }

        private void Information_Load(object sender, EventArgs e)
        {

        }

        private void btStart_Click(object sender, EventArgs e)
        {
            String value = ConfigurationManager.AppSettings["ie"];
            //Restart  IE相关
            IntPtr pWndIE = FindWindow("IEFrame", null);
            if (pWndIE != null)
            {
                int WM_CLOSE = 0x10;

                if (MessageBox.Show("检测到IE已经打开，是否重新启动？") == DialogResult.Yes)
                {
                    SendMessage(pWndIE, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                }
            }

        }
    }
}
