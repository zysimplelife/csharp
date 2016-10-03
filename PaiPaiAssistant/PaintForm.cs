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
            Pen bluePen = new Pen(Color.Red, 1);
            Rectangle rectIE = ScreenUtils.getWndRect(pIEWnd);

            // Price
            Rectangle rectPrice = Configuration.GetPriceRect(false);
            rectPrice.X += rectIE.X;
            rectPrice.Y += rectIE.Y;
            dc.DrawRectangle(bluePen, rectPrice);

            // Time
            Rectangle rectTime = Configuration.GetTimeRect(false);
            rectTime.X += rectIE.X;
            rectTime.Y += rectIE.Y;
            dc.DrawRectangle(bluePen, rectTime);

        }

    }
}
