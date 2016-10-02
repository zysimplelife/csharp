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
using Tesseract;
using System.Drawing.Drawing2D;

namespace PaiPaiAssistant
{
    public partial class Information : Form
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]

        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private IntPtr pWndIE;
        private TesseractEngine engine;
        private PaintForm df;
        private Boolean isDfClosed = true;

        public Information()
        {
            InitializeComponent();

            pWndIE = FindWindow("IEFrame", null);

            //Init OCA
            engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
            engine.SetVariable("tessedit_char_whitelist", "0123456789");
        }

        private void Information_Load(object sender, EventArgs e)
        {

        }

        private void btStart_Click(object sender, EventArgs e)
        {
            //Restart  IE相关
            pWndIE = FindWindow("IEFrame", null);
            if (pWndIE != IntPtr.Zero)
            {
                if (MessageBox.Show("检测到IE已经打开，是否重新启动？","确认" ,MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int WM_CLOSE = 0x0010;
                    SendMessage(pWndIE, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    Thread.Sleep(1000);
                    startIE();
                }
            }else
            {
                startIE();
            }
        }

        private void startIE()
        {
            // Start IE process 
            String url = ConfigurationManager.AppSettings["ie.url"];
            ProcessStartInfo info = new ProcessStartInfo("C:\\Program Files\\Internet Explorer\\iexplore.exe");
            info.Arguments += url;

            Process.Start(info);

            setIEWnd();
        }

        private void setIEWnd()
        {
            pWndIE = FindWindow("IEFrame", null);
            while (pWndIE == IntPtr.Zero)
            {
                Thread.Sleep(1000);
                pWndIE = FindWindow("IEFrame", null);
            }
        }

        public void ParameterRun(IntPtr pWndIE, String postionCfg)
        {
            String start = ConfigurationManager.AppSettings["postion.start"];
            String[] startPoint = start.Split(',');


            String position = ConfigurationManager.AppSettings[postionCfg];
            String[] points = position.Split(',');

            ScreenCapture pc = new ScreenCapture();

            Int32 x = Int32.Parse(startPoint[0]) + Int32.Parse(points[0]);
            Int32 y = Int32.Parse(startPoint[1]) + Int32.Parse(points[1]);
            Int32 width = Int32.Parse(points[2]);
            Int32 height =Int32.Parse(points[3]);

            try
            {
                Bitmap bmp = ScreenCapture.CaptureWindow(pWndIE, new Rectangle(x,y,width,height));
                String imgPath = postionCfg.Replace('.', '_') + ".bmp";
                bmp.Save(imgPath);
                using (var page = engine.Process(bmp, PageSegMode.SingleLine))
                {
                    var text = page.GetText();
                    if(text != "")
                    {
                        tbPrice.Text = text;
                    }else
                    {
                        tbPrice.Text = "unrecorded";
                    }
                        
                }                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);

            }

           
        }

        
        private void test_sceen_Click(object sender, EventArgs e)
        {
            //ParameterRun(pWndIE, "postion.test");
            ParameterRun(pWndIE, "postion.price");
            //ParameterRun(pWndIE, "postion.time");

        }

        private void btn_show_positions_Click(object sender, EventArgs e)
        {

            if (isDfClosed)
            {
                df = new PaintForm(pWndIE);//不穿透鼠标透明窗体

                df.Show();//显示
            }else
            {
                df.Close();//显示
            }

            isDfClosed = !isDfClosed;

        }

      
    }
}
