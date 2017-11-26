using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PaiPaiAssistant
{
    struct RECT
    {
        public int Left; //最左坐标
        public int Top; //最上坐标
        public int Right; //最右坐标
        public int Bottom; //最下坐标
    }

    class ScreenHelpers
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hc, IntPtr hDest);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, out RECT rect);
        [DllImport("user32.dll")]
        public static extern IntPtr GetClientRect(IntPtr hWnd, out RECT rect);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, UInt32 nFlags);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);
        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);


        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateDC(
             string lpszDriver,         // driver name驱动名
             string lpszDevice,         // device name设备名
             string lpszOutput,         // not used; should be NULL
             IntPtr lpInitData          // optional printer data
         );
        [DllImport("gdi32.dll")]
        private static extern int BitBlt(
             IntPtr hdcDest, // handle to destination DC目标设备的句柄
             int nXDest,   // x-coord of destination upper-left corner目标对象的左上角的X坐标
             int nYDest,   // y-coord of destination upper-left corner目标对象的左上角的Y坐标
             int nWidth,   // width of destination rectangle目标对象的矩形宽度
             int nHeight, // height of destination rectangle目标对象的矩形长度
             IntPtr hdcSrc,   // handle to source DC源设备的句柄
             int nXSrc,    // x-coordinate of source upper-left corner源对象的左上角的X坐标
             int nYSrc,    // y-coordinate of source upper-left corner源对象的左上角的Y坐标
             CopyPixelOperation dwRop   // raster operation code光栅的操作值
         );
        //static extern int BitBlt(IntPtr hdcDest, int xDest, int yDest, int
        //wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(
         IntPtr hdc // handle to DC
         );
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleBitmap(
             IntPtr hdc,         // handle to DC
             int nWidth,      // width of bitmap, in pixels
             int nHeight      // height of bitmap, in pixels
         );
        [DllImport("gdi32.dll")]
        private static extern IntPtr SelectObject(
             IntPtr hdc,           // handle to DC
             IntPtr hgdiobj    // handle to object
         );
        [DllImport("gdi32.dll")]
        private static extern int DeleteDC(
            IntPtr hdc           // handle to DC
         );


        /// <summary>
        /// 抓取屏幕(层叠的窗口)
        /// </summary>
        /// <param name="x">左上角的横坐标</param>
        /// <param name="y">左上角的纵坐标</param>
        /// <param name="width">抓取宽度</param>
        /// <param name="height">抓取高度</param>
        /// <returns></returns>
        public  Bitmap CaptureScreen(int x, int y, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(new Point(x, y), new Point(0, 0), bmp.Size);
                g.Dispose();
            }
            return bmp;
        }

        /// <summary>
        /// 抓取整个屏幕
        /// </summary>
        /// <returns></returns>
        public  Bitmap CaptureScreen()
        {
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            return CaptureScreen(0, 0, screenSize.Width, screenSize.Height);
        }

        /// <summary>
        /// 全屏截图
        /// </summary>
        /// <returns></returns>
        public  Image CaptureScreenI()
        {
            return CaptureWindow(GetDesktopWindow());
        }

        /// <summary>
        /// 全屏指定区域截图
        /// </summary>
        /// <returns></returns>
        public  Image CaptureScreenI(Rectangle rect)
        {
            return CaptureWindow(GetDesktopWindow(),rect);
        }

        /// <summary>
        /// 指定窗口截图
        /// </summary>
        /// <param name="handle">窗口句柄. (在windows应用程序中, 从Handle属性获得)</param>
        /// <returns></returns>
      //public static Bitmap CaptureWindow(IntPtr hWnd)
      //{
      //    IntPtr hscrdc = GetWindowDC(hWnd);
      //    return CaptureWindow(hWnd, new Rectangle());
      //}

        /// <summary>
        /// 截取给定窗口
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static Bitmap CaptureWindow(IntPtr hWnd)
        {
            // 获取设备上下文环境句柄
            IntPtr hscrdc = GetWindowDC(hWnd);

            // 创建一个与指定设备兼容的内存设备上下文环境（DC）
            // 这个是用来保存全屏幕
            IntPtr hmemdc = CreateCompatibleDC(hscrdc);

            // 返回指定窗体的矩形尺寸
            Rectangle rectWnd = getWndRect(hWnd);

            // 返回指定设备环境句柄对应的位图区域句柄
            IntPtr hbitmap = CreateCompatibleBitmap(hscrdc, rectWnd.Width, rectWnd.Height);

            //将 hbitmap 作为画图的场所
            SelectObject(hmemdc, hbitmap);

            // 将目标窗口的写到 hmemdc中，也就是将屏幕中的东西写到内存中。 现在这个内存是 hbitmap
            PrintWindow(hWnd, hmemdc, 1);
            //还有一种方法是bitblt但是当窗口被遮挡，就会有问题
            //BitBlt(myMemdc, 0, 0, rect.Width, rect.Height, hmemdc, rect.X, rect.Y, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
        

            Bitmap bmp = Bitmap.FromHbitmap(hbitmap);
            DeleteDC(hscrdc);
            DeleteDC(hmemdc);

            return bmp;

        }

        public static String GetWindowTitle(IntPtr hWnd)
        {
            int capacity = GetWindowTextLength(hWnd) * 2;
            StringBuilder stringBuilder = new StringBuilder(capacity);
            GetWindowText(hWnd, stringBuilder, stringBuilder.Capacity);
            return stringBuilder.ToString();
        }



        /// <summary>
        /// 指定窗口区域截图
        /// </summary>
        /// <param name="handle">窗口句柄. (在windows应用程序中, 从Handle属性获得)</param>
        /// <param name="rect">窗口中的一个区域</param>
        /// <returns></returns>
        public static Bitmap CaptureWindow(IntPtr hWnd,Rectangle rect)
        {

            Bitmap bmp = CaptureWindow(hWnd);
            bmp = BitMapHelpers.cropImage(bmp, rect);
            //放大，以达到OCR需要的大小
            var scaled = BitMapHelpers.ScaleByPercent(bmp, 200);
            return BitMapHelpers.MakeGrayscale3(scaled);
        }

        /// <summary>
        /// 指定窗口截图 保存为图片文件
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        public void CaptureWindowToFile(IntPtr handle, string filename, ImageFormat format)
        {
            Image img = CaptureWindow(handle);
            img.Save(filename, format);
        }

        /// <summary>
        /// 全屏截图 保存为文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="format"></param>
        public void CaptureScreenToFile(string filename, ImageFormat format)
        {
            Image img = CaptureScreen();
            img.Save(filename, format);
        }


        /// <summary>
        ///  获取制定wnd的 Rectangle 返回值
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        private static Rectangle getWndRect(IntPtr hWnd)
        {
            RECT rect = new RECT();
            //Point point = new Point(0, 0);
            //ClientToScreen(hWnd, ref point);
            GetClientRect(hWnd, out rect);
            //return new Rectangle(point.X, point.Y, rect.Right - rect.Left, rect.Bottom - rect.Top);
            return new Rectangle(0,0,rect.Right - rect.Left, rect.Bottom - rect.Top);

        }

       
        public static Rectangle getClientRect(IntPtr hWnd)
        {
            RECT rect = new RECT();
            Point point = new Point(0, 0);
            ClientToScreen(hWnd, ref point);
            GetClientRect(hWnd, out rect);
            return new Rectangle(point.X, point.Y, rect.Right - rect.Left, rect.Bottom - rect.Top);

        }

    }

    

}
