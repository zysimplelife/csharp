using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using Tesseract;
using System.Text;

namespace PaiPaiAssistant
{
    public partial class Information : Form
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        private IntPtr pWndIE;
        private IntPtr pWndTab;

        private TesseractEngine engine;
        private PaintForm df;
        private Boolean isDfClosed = true;
        private Thread threadOcr = null;
        private Thread threadAutoConfirm = null;
        private Thread threadUpdateText = null;


        //Runtime Informations

        private Int32 currentPrice;
        private Int32 targetPrice;
        private Int32 different;
        private String serverTime;
        private String targetTime = "11:29:45";
        private int increasePrice = 900;
        private String forceConfirmTime = "11:29:56";

        private Double remainTime;
        private String delay;

        private Boolean started = false;


        public Information()
        {
            InitializeComponent();
            pWndIE = FindWindow("IEFrame", null);
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

        private void clickAttachIE(object sender, EventArgs e)
        {
            pWndIE = FindWindow("IEFrame", null);
            if (pWndIE == IntPtr.Zero)
            {
                if (MessageBox.Show("是否重新启动IE？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    startIE();
                    Thread.Sleep(2000);
                    setIEWnd();
                }
            }
            else
            {
                setIEWnd();
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (started)
            {
                stop();
                return;
            }

            if (pWndIE == IntPtr.Zero)
            {
                MessageBox.Show("请先关联IE？");
                return;
            }

            if (engine == null)
            {
                initOcr();
            }

            started = true;

            threadOcr = new Thread(new ThreadStart(this.ocrThread));
            threadOcr.Start();

            threadUpdateText = new Thread(new ThreadStart(UpdateTextThread));
            threadUpdateText.Start();


            threadAutoConfirm = new Thread(new ThreadStart(this.AutoConfirmThread));
            threadAutoConfirm.Start();

            bt_start.Text = started ? "停止" : "启动";
        }

        private void stop()
        {
            started = false;
            tbRemainTime.Invoke(new Action(() => bt_start.Text = "启动"));
        }

        private void initOcr()
        {
            //Init OCA
            try
            {
                engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
                engine.SetVariable("tessedit_char_whitelist", "0123456789:");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to init Tesseract Engine" + ex.ToString());
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

            this.pWndTab = FindWindowEx(pWndIE, IntPtr.Zero, "Frame Tab", null);
            this.pWndTab = FindWindowEx(pWndTab, IntPtr.Zero, "TabWindowClass", null);
            this.pWndTab = FindWindowEx(pWndTab, IntPtr.Zero, "Shell DocObject View", null);
            this.pWndTab = FindWindowEx(pWndTab, IntPtr.Zero, "Internet Explorer_Server", null);

            if(pWndTab == IntPtr.Zero)
            {
                //获得窗口title
                MessageBox.Show("关联IE窗口失败，请重试");
            }else
            {
                MessageBox.Show("关联IE窗口成功 title = " + ScreenHelpers.GetWindowTitle(pWndIE));
            }


        }

        private Int32 ocrInt(IntPtr pWndIE, Rectangle rect)
        {
            try
            {
                return Int32.Parse(ocrText(pWndIE, rect));
            }
            catch (Exception)
            {
                return 0;
            }
        }


        private String ocrText(IntPtr pWndIE, Rectangle rect)
        {
            try
            {
                Bitmap bmp = ScreenHelpers.CaptureWindow(pWndIE, rect);
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
            catch (Exception)
            {
                return "unrecorded";
            }
        }

        private void test_sceen_Click(object sender, EventArgs e)
        {
            Bitmap bmp = ScreenHelpers.CaptureWindow(pWndTab);
            bmp.Save("测试截图.bmp");
            MessageBox.Show("测试截图文件已被保存");

        }

        private void btn_show_positions_Click(object sender, EventArgs e)
        {

            if (isDfClosed)
            {
                df = new PaintForm(pWndTab);//不穿透鼠标透明窗体

                df.Show();//显示
            }
            else
            {
                df.Close();//显示
            }

            isDfClosed = !isDfClosed;

        }



        /// <summary>  
        /// 用来获得解读的线程  
        /// </summary>  
        public void ocrThread()
        {
            while (started)
            {
                //TODO： 最好用一次截屏得到两个结果
                int price = ocrInt(pWndTab, Configuration.getRectangleFromConfig(Configuration.CONFIG_PRICE_RECT));
                if (price != 0) // only update validate value
                {
                    this.currentPrice = price;
                }

                string serverTime = ocrText(pWndTab, Configuration.getRectangleFromConfig(Configuration.CONFIG_TIME_RECT));

                if (serverTime != "unrecorded") // only update validate value
                {
                    this.serverTime = serverTime;
                }

                log.Info("Got price is " + currentPrice + " time is " + serverTime);
                Thread.Sleep(200);//让线程暂停  
            }
        }

        public void UpdateTextThread()
        {
            while (started)
            {
                tbTime.Invoke(new Action(() => tbTime.Text = serverTime));
                tbPrice.Invoke(new Action(() => tbPrice.Text = currentPrice.ToString()));
                tbTargetPrice.Invoke(new Action(() => tbTargetPrice.Text = targetPrice.ToString()));
                tbTargetTime.Invoke(new Action(() => tbTargetTime.Text = targetTime.ToString()));
                tbRemainTime.Invoke(new Action(() => tbRemainTime.Text = remainTime.ToString()));
                tb_differences.Invoke(new Action(() => tb_differences.Text = different.ToString()));
                //利用窗口的名称来退出线程，不知道好不好         
                Thread.Sleep(100);//让线程暂停  
            }
        }

      

        /// <summary>  
        /// 自动拍牌的线程  
        /// </summary>  
        public void AutoConfirmThread()
        {
            //线程开始前清空历史数据
            targetPrice = 0;
            different = 0;

            // wait until time to input price
            while (!isTimeToImputPrice() && started)
            {
                Thread.Sleep(100);
            }

            if (started)
            {
                clickAddSubmit(increasePrice);
            }

            while (started)
            {
                different = targetPrice - currentPrice;

                //当前价格小于差价 或者超过强制出价时间则出价
                if (different <= Configuration.BeforeTarget())
                {
                    //差价100 等待100毫秒出价
                    Thread.Sleep(100);
                    WinInputHelpers.MouseMoveToClick(Configuration.GetScreenPoint(Configuration.CONFIG_CONFIRM_BTN_POINT, pWndTab));
                    Thread.Sleep(100);
                }
                //等待5秒，让程序可以获得最后的价格
                Thread.Sleep(5000);
                stop();
                //暂时不强制时间出价
                //Convert.ToDateTime(serverTime) >= Convert.ToDateTime(forceConfirmTime);
            }
        }

        private bool isTimeToImputPrice()
        {
            try
            {
                DateTime dtTargetTime = Convert.ToDateTime(targetTime);
                DateTime dtServerTime = Convert.ToDateTime(serverTime);
                //这里必须要保留，这样才可以在界面上显示出来
                this.remainTime = (dtTargetTime - dtServerTime).TotalSeconds;
                return remainTime <= 0;
            }
            catch (Exception e)
            {
                log.Error("Failed to check server time", e);
                return false;
            }
        }

        private void clickAddSubmit(Int32 addPrice)
        {
            WinInputHelpers.MouseMoveToDoubleClick(Configuration.GetScreenPoint(Configuration.CONFIG_INC_IN_POINT, pWndTab));

            WinInputHelpers.KeyboardType(addPrice.ToString(), 30);

            WinInputHelpers.MouseMoveToClick(Configuration.GetScreenPoint(Configuration.CONFIG_INC_BTN_POINT, pWndTab));

            targetPrice = currentPrice + addPrice;

            WinInputHelpers.MouseMoveToClick(Configuration.GetScreenPoint(Configuration.CONFIG_SUBMIT_BTN_POINT, pWndTab));

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
