using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using Tesseract;

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
        private Thread threadOcr = null;
        private Thread threadAutoConfirm   = null;
        private Thread threadUpdateText = null;


        //Runtime Informations

        private Int32 currentPrice;
        private Int32 targetPrice;
        private String serverTime;
        private String targetTime = "11:29:47";
        private String forceConfirmTime = "11:29:56";

        private Double remainTime;
        private String delay;

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
            closeThead(threadOcr);
            closeThead(threadAutoConfirm);
            closeThead(threadUpdateText);
        }

        private void closeThead(Thread thread)
        {
            if (thread != null)
            {
                thread.Abort();
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

            

            threadUpdateText = new Thread(new ThreadStart(UpdateTextThread));
            threadUpdateText.Start();

            threadOcr = new Thread(new ThreadStart(this.ocrThread));
            threadOcr.Start();

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

        private Int32 ocrInt(IntPtr pWndIE, Rectangle rect)
        {
            try
            {
                return Int32.Parse(ocrText(pWndIE, rect));
            }
            catch (Exception e)
            {
                return 0;
            }
        }


        private String ocrText(IntPtr pWndIE,Rectangle rect)
        {
            try
            {
                Bitmap bmp = ScreenUtils.CaptureWindow(pWndIE, rect);
                //bmp.Save(postionCfg.Replace('.', '_') + ".bmp);

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
                return "unrecorded";
            }
        }

        private void test_sceen_Click(object sender, EventArgs e)
        {
            if(threadOcr == null)
            {
                threadOcr = new Thread(new ThreadStart(this.ocrThread));
                threadOcr.Start();
            }else
            {
                threadOcr.Abort();
                threadOcr = null;
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
        public void ocrThread()
        {
            while (true) {

                currentPrice = ocrInt(pWndIE, Configuration.GetClientRect(Configuration.CONFIG_PRICE_RECT));
                serverTime = ocrText(pWndIE, Configuration.GetClientRect(Configuration.CONFIG_TIME_RECT));
                Thread.Sleep(200);//让线程暂停  
            }
        }

        public void UpdateTextThread()
        {
            while (true)
            {
                tbTime.Invoke(new Action(() => tbTime.Text = serverTime));
                tbPrice.Invoke(new Action(() => tbPrice.Text = currentPrice.ToString()));
                tbTargetPrice.Invoke(new Action(() => tbTargetPrice.Text = targetPrice.ToString()));
                tbTargetTime.Invoke(new Action(() => tbTargetTime.Text = targetTime.ToString()));
                tbRemainTime.Invoke(new Action(() => tbRemainTime.Text = remainTime.ToString()));

                Thread.Sleep(200);//让线程暂停  
            }
        }


        private void plus700_Click(object sender, EventArgs e)
        {
            if (threadAutoConfirm != null && threadAutoConfirm.IsAlive)
            {
                return;
            }
            
            threadAutoConfirm = new Thread(new ThreadStart(this.AutoConfirmThread));

            threadAutoConfirm.Start();

        }


        /// <summary>  
        /// 不带参数的启动方法  
        /// </summary>  
        public void AutoConfirmThread()
        {
            DateTime dtTargetTime = Convert.ToDateTime(targetTime);

            while ((remainTime = (dtTargetTime - Convert.ToDateTime(serverTime)).TotalSeconds)>0)
            {
                Thread.Sleep(100);
            }

            // Click +700
            clickAddSubmit(700);

            while (true)
            {
                Int32 different = targetPrice - currentPrice;
                tb_differences.Invoke(new Action(() => tb_differences.Text = different.ToString()));


                if (different <= Configuration.BeforeTarget() || Convert.ToDateTime(serverTime) >= Convert.ToDateTime(forceConfirmTime))
                {
                    WinInputHelpers.MouseMoveToClick(Configuration.GetScreenPoint(Configuration.CONFIG_CONFIRM_BTN_POINT, pWndIE));
                    break;
                }

                Thread.Sleep(100);
            }
        }

        private void clickAddSubmit(Int32 addPrice)
        {
            WinInputHelpers.MouseMoveToDoubleClick(Configuration.GetScreenPoint(Configuration.CONFIG_INC_IN_POINT, pWndIE));

            WinInputHelpers.KeyboardType(addPrice.ToString(), 30);

            WinInputHelpers.MouseMoveToClick(Configuration.GetScreenPoint(Configuration.CONFIG_INC_BTN_POINT, pWndIE));

            targetPrice = currentPrice + addPrice;

            WinInputHelpers.MouseMoveToClick(Configuration.GetScreenPoint(Configuration.CONFIG_SUBMIT_BTN_POINT, pWndIE));

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
