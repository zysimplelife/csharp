using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaiPaiAssistant
{
    public partial class PaintForm : Form
    {
        private IntPtr pIEWnd;

        public PaintForm(IntPtr pIEWnd)
        {
            InitializeComponent();

            this.pIEWnd = pIEWnd;

        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 画图 
            Graphics dc = e.Graphics;
            Pen pen = new Pen(Color.Red, 1);
            Brush brush = (Brush)Brushes.Red;

            Rectangle rectIE = ScreenUtils.getWndRect(pIEWnd);
            Point point;
            Rectangle rect;

            // Price
            rect = Configuration.GetPriceRect(false);
            toClient(ref rectIE, ref rect);
            dc.DrawRectangle(pen, rect);

            // Time
            rect = Configuration.GetTimeRect(false);
            toClient(ref rectIE, ref rect);
            dc.DrawRectangle(pen, rect);

            // 加价
            point = Configuration.GetIncreaseButtonPoint(false);
            toClient(ref rectIE, ref point);
            dc.FillRectangle(brush, point.X, point.Y,5,5);

            // 加价
            point = Configuration.GetIncreaseInputPoint(false);
            toClient(ref rectIE, ref point);
            dc.FillRectangle(brush, point.X, point.Y, 5, 5);

            // 出价
            point = Configuration.GetSubmitButtonPoint(false);
            toClient(ref rectIE, ref point);
            dc.FillRectangle(brush, point.X, point.Y, 5, 5);


            // 出价
            point = Configuration.GetSubmitInputPoint(false);
            toClient(ref rectIE, ref point);
            dc.FillRectangle(brush, point.X, point.Y, 5, 5);

        }

        private static void toClient(ref Rectangle rectIE, ref Point increasePoint)
        {
            increasePoint.X += rectIE.X;
            increasePoint.Y += rectIE.Y;
        }

        private static void toClient(ref Rectangle rectIE, ref Rectangle rectPrice)
        {
            rectPrice.X += rectIE.X;
            rectPrice.Y += rectIE.Y;
        }
    }
}
