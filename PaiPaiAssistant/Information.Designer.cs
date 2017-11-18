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
            this.tbTime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.test_sceen = new System.Windows.Forms.Button();
            this.btn_show_positions = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbTargetPrice = new System.Windows.Forms.Label();
            this.tbTargetPrice = new System.Windows.Forms.TextBox();
            this.remain_price = new System.Windows.Forms.Label();
            this.tb_differences = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTargetTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRemainTime = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            btStart = new System.Windows.Forms.Button();
            plus700 = new System.Windows.Forms.Button();
            this.gbRuntime.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
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
            this.flowLayoutPanel1.Controls.Add(this.tbTime);
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
            // tbTime
            // 
            this.tbTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbTime.Location = new System.Drawing.Point(62, 30);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(129, 21);
            this.tbTime.TabIndex = 3;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 81);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 130);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "拍牌信息";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.lbTargetPrice);
            this.flowLayoutPanel4.Controls.Add(this.tbTargetPrice);
            this.flowLayoutPanel4.Controls.Add(this.remain_price);
            this.flowLayoutPanel4.Controls.Add(this.tb_differences);
            this.flowLayoutPanel4.Controls.Add(this.label1);
            this.flowLayoutPanel4.Controls.Add(this.tbTargetTime);
            this.flowLayoutPanel4.Controls.Add(this.label2);
            this.flowLayoutPanel4.Controls.Add(this.tbRemainTime);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(203, 110);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // lbTargetPrice
            // 
            this.lbTargetPrice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbTargetPrice.AutoSize = true;
            this.lbTargetPrice.Location = new System.Drawing.Point(3, 7);
            this.lbTargetPrice.Name = "lbTargetPrice";
            this.lbTargetPrice.Size = new System.Drawing.Size(53, 12);
            this.lbTargetPrice.TabIndex = 0;
            this.lbTargetPrice.Text = "目标价格";
            // 
            // tbTargetPrice
            // 
            this.tbTargetPrice.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbTargetPrice.Location = new System.Drawing.Point(62, 3);
            this.tbTargetPrice.Name = "tbTargetPrice";
            this.tbTargetPrice.Size = new System.Drawing.Size(129, 21);
            this.tbTargetPrice.TabIndex = 1;
            // 
            // remain_price
            // 
            this.remain_price.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.remain_price.AutoSize = true;
            this.remain_price.Location = new System.Drawing.Point(3, 34);
            this.remain_price.Name = "remain_price";
            this.remain_price.Size = new System.Drawing.Size(53, 12);
            this.remain_price.TabIndex = 2;
            this.remain_price.Text = "相差价格";
            // 
            // tb_differences
            // 
            this.tb_differences.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_differences.Location = new System.Drawing.Point(62, 30);
            this.tb_differences.Name = "tb_differences";
            this.tb_differences.Size = new System.Drawing.Size(129, 21);
            this.tb_differences.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "目标时间";
            // 
            // tbTargetTime
            // 
            this.tbTargetTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbTargetTime.Location = new System.Drawing.Point(62, 57);
            this.tbTargetTime.Name = "tbTargetTime";
            this.tbTargetTime.Size = new System.Drawing.Size(129, 21);
            this.tbTargetTime.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "剩余时间";
            // 
            // tbRemainTime
            // 
            this.tbRemainTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbRemainTime.Location = new System.Drawing.Point(62, 84);
            this.tbRemainTime.Name = "tbRemainTime";
            this.tbRemainTime.Size = new System.Drawing.Size(129, 21);
            this.tbRemainTime.TabIndex = 7;
            // 
            // status
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(6, 237);
            this.labelStatus.Name = "status";
            this.labelStatus.Size = new System.Drawing.Size(41, 12);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "status";
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 423);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRuntime;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label lbtime;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button test_sceen;
        private System.Windows.Forms.Button btn_show_positions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label lbTargetPrice;
        private System.Windows.Forms.TextBox tbTargetPrice;
        private System.Windows.Forms.Label remain_price;
        private System.Windows.Forms.TextBox tb_differences;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTargetTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRemainTime;
        private System.Windows.Forms.Label labelStatus;
    }
}

