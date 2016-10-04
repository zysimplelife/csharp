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
            System.Windows.Forms.Button plus700;
            this.gbRuntime = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbPrice = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lbtime = new System.Windows.Forms.Label();
            this.tbtime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.test_sceen = new System.Windows.Forms.Button();
            this.btn_show_positions = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            btStart = new System.Windows.Forms.Button();
            plus700 = new System.Windows.Forms.Button();
            this.gbRuntime.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
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
            // plus700
            // 
            plus700.Location = new System.Drawing.Point(3, 3);
            plus700.Name = "plus700";
            plus700.Size = new System.Drawing.Size(75, 23);
            plus700.TabIndex = 0;
            plus700.Text = "+700 出价";
            plus700.UseVisualStyleBackColor = true;
            plus700.Click += new System.EventHandler(this.plus700_Click);
            // 
            // gbRuntime
            // 
            this.gbRuntime.Controls.Add(this.flowLayoutPanel1);
            this.gbRuntime.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRuntime.Location = new System.Drawing.Point(0, 0);
            this.gbRuntime.Margin = new System.Windows.Forms.Padding(10);
            this.gbRuntime.Name = "gbRuntime";
            this.gbRuntime.Size = new System.Drawing.Size(209, 81);
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(203, 61);
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
            this.groupBox1.Location = new System.Drawing.Point(0, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 84);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工具";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(btStart);
            this.flowLayoutPanel2.Controls.Add(this.test_sceen);
            this.flowLayoutPanel2.Controls.Add(this.btn_show_positions);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(203, 64);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // test_sceen
            // 
            this.test_sceen.Location = new System.Drawing.Point(84, 3);
            this.test_sceen.Name = "test_sceen";
            this.test_sceen.Size = new System.Drawing.Size(75, 23);
            this.test_sceen.TabIndex = 1;
            this.test_sceen.Text = "测试截屏";
            this.test_sceen.UseVisualStyleBackColor = true;
            this.test_sceen.Click += new System.EventHandler(this.test_sceen_Click);
            // 
            // btn_show_positions
            // 
            this.btn_show_positions.Location = new System.Drawing.Point(3, 32);
            this.btn_show_positions.Name = "btn_show_positions";
            this.btn_show_positions.Size = new System.Drawing.Size(75, 23);
            this.btn_show_positions.TabIndex = 2;
            this.btn_show_positions.Text = "显示坐标";
            this.btn_show_positions.UseVisualStyleBackColor = true;
            this.btn_show_positions.Click += new System.EventHandler(this.btn_show_positions_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 84);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "拍牌";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(plus700);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(203, 64);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 423);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbRuntime);
            this.Name = "Information";
            this.Text = "Information";
            this.gbRuntime.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
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
        private System.Windows.Forms.Button test_sceen;
        private System.Windows.Forms.Button btn_show_positions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    }
}

