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

    class ScreenCapture
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        private static extern IntPtr ReleaseDC(IntPtr hc, IntPtr hDest);
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hWnd, out RECT rect);
        [DllImport("user32.dll")]
        private static extern bool PrintWindow(IntPtr hwnd, IntPtr hdcBlt, UInt32 nFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

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
            //bit.Save(@"capture2.png");
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
        public static Bitmap CaptureWindow(IntPtr hWnd)
        {
            IntPtr hscrdc = GetWindowDC(hWnd);
            return CaptureWindow(hWnd, new Rectangle());
        }

        /// <summary>
        /// 指定窗口区域截图
        /// </summary>
        /// <param name="handle">窗口句柄. (在windows应用程序中, 从Handle属性获得)</param>
        /// <param name="rect">窗口中的一个区域</param>
        /// <returns></returns>
        public static Bitmap CaptureWindow(IntPtr hWnd,Rectangle rect)
        {
            // 获取设备上下文环境句柄
            IntPtr hscrdc = GetWindowDC(hWnd);

            // 创建一个与指定设备兼容的内存设备上下文环境（DC）
            IntPtr hmemdc = CreateCompatibleDC(hscrdc);
            IntPtr myMemdc = CreateCompatibleDC(hscrdc);

            // 返回指定窗体的矩形尺寸
            Rectangle rectWnd =  getWndRect(hWnd);

            

            // 返回指定设备环境句柄对应的位图区域句柄
            IntPtr hbitmap = CreateCompatibleBitmap(hscrdc, rectWnd.Width, rectWnd.Height);
            IntPtr myBitmap = CreateCompatibleBitmap(hscrdc, rect.Width, rect.Height);

            //把位图选进内存DC 
            // IntPtr OldBitmap = (IntPtr)SelectObject(hmemdc, hbitmap);
            SelectObject(hmemdc, hbitmap);
            SelectObject(myMemdc, myBitmap);

            /////////////////////////////////////////////////////////////////////////////
            //
            // 下面开始所谓的作画过程，此过程可以用的方法很多，看你怎么调用 API 了
            //
            /////////////////////////////////////////////////////////////////////////////

            // 直接打印窗体到画布
            PrintWindow(hWnd, hmemdc, 0);

            // IntPtr hw = GetDesktopWindow();
            // IntPtr hmemdcClone = GetWindowDC(myBitmap);

            BitBlt(myMemdc, 0, 0, rect.Width, rect.Height, hmemdc, rect.X, rect.Y, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
            //SelectObject(myMemdc, myBitmap);

            Bitmap bmp = Bitmap.FromHbitmap(myBitmap);
            DeleteDC(hscrdc);
            DeleteDC(hmemdc);
            DeleteDC(myMemdc);

            return ScaleByPercent(bmp, 200);
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

        
        public static Bitmap ScaleByPercent(Bitmap imgPhoto, int Percent)
        {
            float nPercent = ((float)Percent / 100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            var destWidth = (int)(sourceWidth * nPercent);
            var destHeight = (int)(sourceHeight * nPercent);

            var bmPhoto = new Bitmap(destWidth, destHeight,
                                     PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                  imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.CompositingMode = CompositingMode.SourceCopy;
            grPhoto.PixelOffsetMode = PixelOffsetMode.Half;
            grPhoto.InterpolationMode = InterpolationMode.NearestNeighbor;

            // Draw your image here.

            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;


            grPhoto.DrawImage(imgPhoto,
                              new Rectangle(0, 0, destWidth, destHeight),
                              new Rectangle(0, 0, sourceWidth , sourceHeight ),
                              GraphicsUnit.Pixel);
            grPhoto.Dispose();
            imgPhoto.Save("before.bmp");
            bmPhoto.Save("scaled.bmp");

            return MakeGrayscale3(bmPhoto);
            //return bmPhoto;
        }

        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
               });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        public static Rectangle getWndRect(IntPtr handler)
        {
            RECT rect = new RECT();

            GetWindowRect(handler, out rect);
            return fromRECT(rect);
        }

        public static Rectangle fromRECT(RECT rect)
        {
            return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);

        }



    }

    

}
