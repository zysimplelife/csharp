using System.Windows.Forms;

namespace PaiPaiAssistant
{
    partial class PaintForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PaintForm
            // 
            this.Name = "PaintForm";
            this.Text = "PaintForm";
            // Set Transparent
            this.TransparencyKey = this.BackColor;
            // No Max/Min header
            this.ControlBox = false; 

            //没有标题
            this.FormBorderStyle = FormBorderStyle.None;
            //任务栏不显示
            this.ShowInTaskbar = false;

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }

        #endregion
    }
}