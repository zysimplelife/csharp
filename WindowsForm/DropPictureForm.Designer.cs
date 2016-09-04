using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForm
{
    partial class DropPictureForm
    {

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Point pictureLocation;
        private Image picture;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.AllowDrop = true;
            this.DragDrop += new DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new DragEventHandler(this.Form1_DragEnter);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // If the data is a file or a bitmap, display the copy cursor.
            if (e.Data.GetDataPresent(DataFormats.Bitmap) ||
               e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // Handle FileDrop data.
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                try
                {
                    // Assign the first image to the picture variable.
                    this.picture = Image.FromFile(files[0]);
                    // Set the picture location equal to the drop point.
                    this.pictureLocation = this.PointToClient(new Point(e.X, e.Y));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            // Handle Bitmap data.
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                try
                {
                    // Create an Image and assign it to the picture variable.
                    this.picture = (Image)e.Data.GetData(DataFormats.Bitmap);
                    // Set the picture location equal to the drop point.
                    this.pictureLocation = this.PointToClient(new Point(e.X, e.Y));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            // Force the form to be redrawn with the image.
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // If there is an image and it has a location, 
            // paint it when the Form is repainted.
            base.OnPaint(e);
            if (this.picture != null && this.pictureLocation != Point.Empty)
            {
                e.Graphics.DrawImage(this.picture, this.pictureLocation);
            }
        }



        #endregion
    }
}

