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

        

        private void drawPositions()
        {


            Rectangle rect = ScreenCapture.getWndRect(pIEWnd);

            Graphics gs = CreateGraphics();//创建窗体画板
            Pen pen = new Pen(Color.Black, 3f);//画笔

            gs.DrawRectangle(pen, rect);
            gs.Dispose();
        }

        private void PaintForm_Load(object sender, EventArgs e)
        {
            drawPositions();
        }
    }
}
