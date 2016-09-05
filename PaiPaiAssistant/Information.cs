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
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Threading;

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
            //Restart  IE相关
            IntPtr pWndIE = FindWindow("IEFrame", null);
            if (pWndIE != IntPtr.Zero)
            {

                if (MessageBox.Show("检测到IE已经打开，是否重新启动？") == DialogResult.Yes)
                {
                    int WM_CLOSE = 0x10;
                    SendMessage(pWndIE, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                }
            }

            String url = ConfigurationManager.AppSettings["ie.url"];
            ProcessStartInfo info = new ProcessStartInfo("C:\\Program Files\\Internet Explorer\\iexplore.exe");
            info.Arguments += url;
            Process.Start(info);

            pWndIE = FindWindow("IEFrame", null);
            while (pWndIE == IntPtr.Zero)
            {
                Thread.Sleep(1000);
                pWndIE = FindWindow("IEFrame", null);
            }

            RECT rect = new RECT();
            ScreenCapture pc = new ScreenCapture();
            pc.SetRECT(ref rect, 0, 200, 100, 0);

            Image image = pc.CaptureWindow(pWndIE, rect);
            image.Save("./snap.bmp");


        }      
    }
}
