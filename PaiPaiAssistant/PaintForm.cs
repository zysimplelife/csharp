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
        private IntPtr pWnd;

        public PaintForm(IntPtr pWnd)
        {
            InitializeComponent();

            this.pWnd = pWnd;

        }

        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 画图 
            Graphics dc = e.Graphics;
            Pen pen = new Pen(Color.Red, 1);
            Brush brush = (Brush)Brushes.Red;

            Rectangle rectIE = ScreenHelpers.getClientRect(pWnd);
            Point point;
            Rectangle rect;

            dc.DrawRectangle(pen, rectIE);

            // 价格
            rect = Configuration.GetScreenRect(Configuration.CONFIG_PRICE_RECT, pWnd);
            dc.DrawRectangle(pen, rect);

            // 时间
            rect = Configuration.GetScreenRect(Configuration.CONFIG_TIME_RECT, pWnd);
            dc.DrawRectangle(pen, rect);

            // 加价
            point = Configuration.GetScreenPoint(Configuration.CONFIG_INC_IN_POINT, pWnd);
            dc.FillRectangle(brush, point.X, point.Y,5,5);

            // 加价确认
            point = Configuration.GetScreenPoint(Configuration.CONFIG_INC_BTN_POINT, pWnd);
            dc.FillRectangle(brush, point.X, point.Y, 5, 5);

            // 出价
            point = Configuration.GetScreenPoint(Configuration.CONFIG_SUBMIT_BTN_POINT, pWnd);
            dc.FillRectangle(brush, point.X, point.Y, 5, 5);


            // 确认
            point = Configuration.GetScreenPoint(Configuration.CONFIG_CONFIRM_BTN_POINT, pWnd);
            dc.FillRectangle(brush, point.X, point.Y, 5, 5);


            // 取消
            point = Configuration.GetScreenPoint(Configuration.CONFIG_CANCEL_BTN_POINT, pWnd);
            dc.FillRectangle(brush, point.X, point.Y, 5, 5);

        }

       
    }
}
