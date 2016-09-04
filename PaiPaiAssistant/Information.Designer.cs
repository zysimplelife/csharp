namespace PaiPaiAssistant
{
    partial class Information
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.Windows.Forms.Button btStart;
            this.gbRuntime = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbPrice = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lbtime = new System.Windows.Forms.Label();
            this.tbtime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            btStart = new System.Windows.Forms.Button();
            this.gbRuntime.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRuntime
            // 
            this.gbRuntime.Controls.Add(this.flowLayoutPanel1);
            this.gbRuntime.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRuntime.Location = new System.Drawing.Point(0, 0);
            this.gbRuntime.Margin = new System.Windows.Forms.Padding(10);
            this.gbRuntime.Name = "gbRuntime";
            this.gbRuntime.Size = new System.Drawing.Size(206, 81);
            this.gbRuntime.TabIndex = 0;
            this.gbRuntime.TabStop = false;
            this.gbRuntime.Text = "服务器实时信息";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lbPrice);
            this.flowLayoutPanel1.Controls.Add(this.tbPrice);
            this.flowLayoutPanel1.Controls.Add(this.lbtime);
            this.flowLayoutPanel1.Controls.Add(this.tbtime);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 61);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lbPrice
            // 
            this.lbPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(3, 7);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(53, 12);
            this.lbPrice.TabIndex = 0;
            this.lbPrice.Text = "当前价格";
            // 
            // tbPrice
            // 
            this.tbPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbPrice.Location = new System.Drawing.Point(62, 3);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(129, 21);
            this.tbPrice.TabIndex = 1;
            // 
            // lbtime
            // 
            this.lbtime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbtime.AutoSize = true;
            this.lbtime.Location = new System.Drawing.Point(3, 34);
            this.lbtime.Name = "lbtime";
            this.lbtime.Size = new System.Drawing.Size(53, 12);
            this.lbtime.TabIndex = 2;
            this.lbtime.Text = "当前时间";
            // 
            // tbtime
            // 
            this.tbtime.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbtime.Location = new System.Drawing.Point(62, 30);
            this.tbtime.Name = "tbtime";
            this.tbtime.Size = new System.Drawing.Size(129, 21);
            this.tbtime.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 379);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工具";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(btStart);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 30);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btStart
            // 
            btStart.Location = new System.Drawing.Point(3, 3);
            btStart.Name = "btStart";
            btStart.Size = new System.Drawing.Size(75, 23);
            btStart.TabIndex = 0;
            btStart.Text = "启动";
            btStart.UseVisualStyleBackColor = true;
            btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 429);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbRuntime);
            this.Name = "Information";
            this.Text = "Information";
            this.Load += new System.EventHandler(this.Information_Load);
            this.gbRuntime.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRuntime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label lbtime;
        private System.Windows.Forms.TextBox tbtime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}

