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
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(HandleRef hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(HandleRef hWnd, StringBuilder lpString, int nMaxCount);


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
        private String serverTime;
        private String targetTime = "11:29:45";
        private int increasePrice = 900;
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

        private void clickAttachIE(object sender, EventArgs e)
        {
            //Restart  IE相关
            pWndIE = FindWindow("IEFrame", null);
            if (pWndIE == IntPtr.Zero)
            {
                if (MessageBox.Show("是否重新启动IE？", "确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    startIE();
                    setIEWnd();
                }
            }
            else
            {
                setIEWnd();
                //获得窗口title
                int capacity = GetWindowTextLength(new HandleRef(this, pWndTab)) * 2;
                StringBuilder stringBuilder = new StringBuilder(capacity);
                GetWindowText(new HandleRef(this, pWndTab), stringBuilder, stringBuilder.Capacity);
                MessageBox.Show("关联IE窗口成功" + pWndTab + "title = " + stringBuilder.ToString());
            }
        }

        private void btStart_Click(object sender, EventArgs e)
        {
           
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

            pWndTab = FindWindowEx(pWndIE, IntPtr.Zero, "Frame Tab", null);
            while (pWndIE == IntPtr.Zero)
            {
                Thread.Sleep(1000);
                pWndTab = FindWindowEx(pWndIE, IntPtr.Zero, "Frame Tab", null);
            }
            pWndTab = FindWindowEx(pWndTab, IntPtr.Zero, "TabWindowClass", null);
           pWndTab = FindWindowEx(pWndTab, IntPtr.Zero, "Shell DocObject View", null);
           pWndTab = FindWindowEx(pWndTab, IntPtr.Zero, "Internet Explorer_Server", null);

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


        private String ocrText(IntPtr pWndIE, Rectangle rect)
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
            Bitmap bmp = ScreenUtils.CaptureWindow(pWndTab, ScreenUtils.getIETabWndRect(pWndTab));
            bmp.Save("测试截图.bmp");
            MessageBox.Show("测试截图文件已被保存");

        }

        private void btn_show_positions_Click(object sender, EventArgs e)
        {

            if (isDfClosed)
            {
                df = new PaintForm(pWndIE);//不穿透鼠标透明窗体

                df.Show();//显示
            }
            else
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
            while (true)
            {
                //TODO： 最好用一次截屏得到两个结果
                currentPrice = ocrInt(pWndIE, Configuration.GetClientRect(Configuration.CONFIG_PRICE_RECT));
                serverTime = ocrText(pWndIE, Configuration.GetClientRect(Configuration.CONFIG_TIME_RECT));
                log.Info("Got price is " + currentPrice + " time is " + serverTime);
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
                labelStatus.Invoke(new Action(() => labelStatus.Text = isStarted().ToString()));
                Thread.Sleep(200);//让线程暂停  
            }
        }


        private void plus700_Click(object sender, EventArgs e)
        {
            if (isStarted())
            {
                return;
            }

            threadAutoConfirm = new Thread(new ThreadStart(this.AutoConfirmThread));

            threadAutoConfirm.Start();

        }

        private bool isStarted()
        {
            return threadAutoConfirm != null && threadAutoConfirm.IsAlive;
        }


        /// <summary>  
        /// 不带参数的启动方法  
        /// </summary>  
        public void AutoConfirmThread()
        {
            DateTime dtTargetTime = Convert.ToDateTime(targetTime);

            while ((remainTime = (dtTargetTime - Convert.ToDateTime(serverTime)).TotalSeconds) > 0)
            {
                Thread.Sleep(100);
            }

            // Click +700
            clickAddSubmit(increasePrice);

            while (true)
            {
                Int32 different = targetPrice - currentPrice;
                tb_differences.Invoke(new Action(() => tb_differences.Text = different.ToString()));

                //当前价格小于差价 或者超过强制出价时间则出价
                if (different <= Configuration.BeforeTarget())
                {
                    //差价100 等待100毫秒出价
                    Thread.Sleep(100);
                    WinInputHelpers.MouseMoveToClick(Configuration.GetScreenPoint(Configuration.CONFIG_CONFIRM_BTN_POINT, pWndIE));
                    threadAutoConfirm.Abort();
                }
                Thread.Sleep(100);

                //暂时不强制时间出价
                //Convert.ToDateTime(serverTime) >= Convert.ToDateTime(forceConfirmTime);



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
