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
        private Thread ocrThread = null;
        private Thread autoConfirmThread   = null;




        public Information()
        {
            InitializeComponent();

            pWndIE = FindWindow("IEFrame", null);

            //Init OCA
            engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
            engine.SetVariable("tessedit_char_whitelist", "0123456789:");
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (ocrThread != null)
            {
                ocrThread.Abort();
            }
        }

      
        private void btStart_Click(object sender, EventArgs e)
        {
            //Restart  IE相关
            pWndIE = FindWindow("IEFrame", null);
            if (pWndIE != IntPtr.Zero)
            {
                if (MessageBox.Show("检测到IE已经打开，是否重新启动？","确认" ,MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    stopIE();
                    startIE();
                    setIEWnd();
                }
            }
            else
            {
                startIE();
                setIEWnd();
            }
        }

        private void stopIE()
        {
            int WM_CLOSE = 0x0010;
            SendMessage(pWndIE, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            pWndIE = FindWindow("IEFrame", null);

            while (pWndIE != IntPtr.Zero)
            {
                Thread.Sleep(1000);
                pWndIE = FindWindow("IEFrame", null);
            }
        }

        private void startIE()
        {
            // Start IE process 
            String url = ConfigurationManager.AppSettings["ie.url"];
            ProcessStartInfo info = new ProcessStartInfo("C:\\Program Files\\Internet Explorer\\iexplore.exe");
            info.Arguments += url;
            Process.Start(info);
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

       
        private String ocrText(IntPtr pWndIE,Rectangle rect)
        {
            try
            {
                Bitmap bmp = ScreenUtils.CaptureWindow(pWndIE, rect);

               //String imgPath = postionCfg.Replace('.', '_') + ".bmp";
               //
               //bmp.Save(imgPath);

                using (var page = engine.Process(bmp, PageSegMode.SingleLine))
                {
                    var text = page.GetText();
                    if (text != "")
                    {
                       return text.Replace(" ", "");
                    }
                    else
                    {
                       return "unrecorded";
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "unrecorded";

            }
        }

        private void test_sceen_Click(object sender, EventArgs e)
        {
            //ParameterRun(pWndIE, "postion.test");

            //this.tbPrice.Text = ocrText(pWndIE, Configuration.GetPriceRect(false));
            //this.tbtime.Text = ocrText(pWndIE, Configuration.GetTimeRect(false));
            //ParameterRun(pWndIE, "postion.time");

            if(ocrThread == null)
            {
                ocrThread = new Thread(new ThreadStart(this.PriceThread));
                ocrThread.Start();
            }else
            {
                ocrThread.Abort();
                ocrThread = null;
            }

            


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

       
            
        /// <summary>  
        /// 不带参数的启动方法  
        /// </summary>  
        public void PriceThread()
        {
            while (true) {

                String price = ocrText(pWndIE, Configuration.GetClientRect(Configuration.CONFIG_PRICE_RECT));
                tbPrice.Invoke(new Action(() => tbPrice.Text = price));


                String time = ocrText(pWndIE, Configuration.GetClientRect(Configuration.CONFIG_TIME_RECT));
                tbtime.Invoke(new Action(() => tbtime.Text = time));

                Thread.Sleep(200);//让线程暂停  
            }
        }

      


        private void plus700_Click(object sender, EventArgs e)
        {
            WinInputHelpers.MouseMoveToDoubleClick(Configuration.GetScreenPoint(Configuration.CONFIG_INC_IN_POINT,pWndIE));
            
            WinInputHelpers.KeyboardType("700",30);

            WinInputHelpers.MouseMoveToClick(Configuration.GetScreenPoint(Configuration.CONFIG_INC_BTN_POINT, pWndIE));

            WinInputHelpers.MouseMoveToClick(Configuration.GetScreenPoint(Configuration.CONFIG_SUBMIT_BTN_POINT, pWndIE));

            tb_target_price.Text = (Int32.Parse(tbPrice.Text) + 700).ToString();

            autoConfirmThread = new Thread(new ThreadStart(this.AutoConfirmThread));

            autoConfirmThread.Start();

        }

        /// <summary>  
        /// 不带参数的启动方法  
        /// </summary>  
        public void AutoConfirmThread()
        {
            while (true)
            {
                Int32 different = Int32.Parse(readControlText(tb_target_price)) - Int32.Parse(readControlText(tbPrice)) - 300;
                tb_differences.Invoke(new Action(() => tb_differences.Text = different.ToString()));


                if (different <= 100)
                {
                    WinInputHelpers.MouseMoveToClick(Configuration.GetScreenPoint(Configuration.CONFIG_CONFIRM_BTN_POINT, pWndIE));
                    break;
                }

                Thread.Sleep(100);
            }
        }

        public string readControlText(Control varControl)
        {
            if (varControl.InvokeRequired)
            {
                return (string)varControl.Invoke(
                  new Func<String>(() => readControlText(varControl))
                );
            }
            else
            {
                string varText = varControl.Text;
                return varText;
            }
        }

    }
}
