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
            System.Windows.Forms.Button attachIE;
            this.gbRuntime = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbPrice = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lbtime = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
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
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.config_advance_price = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.config_force_time = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.config_increase_amount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.config_time_to_increase = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.bt_start = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.test_sceen = new System.Windows.Forms.Button();
            this.btn_show_positions = new System.Windows.Forms.Button();
            attachIE = new System.Windows.Forms.Button();
            this.gbRuntime.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // attachIE
            // 
            attachIE.Location = new System.Drawing.Point(3, 3);
            attachIE.Name = "attachIE";
            attachIE.Size = new System.Drawing.Size(75, 23);
            attachIE.TabIndex = 3;
            attachIE.Text = "关联IE";
            attachIE.UseVisualStyleBackColor = true;
            attachIE.Click += new System.EventHandler(this.clickAttachIE);
            // 
            // gbRuntime
            // 
            this.gbRuntime.Controls.Add(this.flowLayoutPanel1);
            this.gbRuntime.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRuntime.Location = new System.Drawing.Point(0, 0);
            this.gbRuntime.Margin = new System.Windows.Forms.Padding(10);
            this.gbRuntime.Name = "gbRuntime";
            this.gbRuntime.Size = new System.Drawing.Size(207, 81);
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(201, 61);
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
            this.tbPrice.ReadOnly = true;
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
            this.tbTime.ReadOnly = true;
            this.tbTime.Size = new System.Drawing.Size(129, 21);
            this.tbTime.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 81);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(207, 136);
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
            this.flowLayoutPanel4.Size = new System.Drawing.Size(201, 116);
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
            this.tbTargetPrice.ReadOnly = true;
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
            this.tb_differences.ReadOnly = true;
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
            this.tbTargetTime.ReadOnly = true;
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
            this.tbRemainTime.ReadOnly = true;
            this.tbRemainTime.Size = new System.Drawing.Size(129, 21);
            this.tbRemainTime.TabIndex = 7;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label4);
            this.flowLayoutPanel5.Controls.Add(this.config_advance_price);
            this.flowLayoutPanel5.Controls.Add(this.label5);
            this.flowLayoutPanel5.Controls.Add(this.config_force_time);
            this.flowLayoutPanel5.Controls.Add(this.label3);
            this.flowLayoutPanel5.Controls.Add(this.config_increase_amount);
            this.flowLayoutPanel5.Controls.Add(this.label6);
            this.flowLayoutPanel5.Controls.Add(this.config_time_to_increase);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(201, 118);
            this.flowLayoutPanel5.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "提前出价";
            // 
            // config_advance_price
            // 
            this.config_advance_price.Dock = System.Windows.Forms.DockStyle.Top;
            this.config_advance_price.Location = new System.Drawing.Point(62, 3);
            this.config_advance_price.Name = "config_advance_price";
            this.config_advance_price.Size = new System.Drawing.Size(129, 21);
            this.config_advance_price.TabIndex = 1;
            this.config_advance_price.Text = "100";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "强制出价";
            // 
            // config_force_time
            // 
            this.config_force_time.Dock = System.Windows.Forms.DockStyle.Top;
            this.config_force_time.Location = new System.Drawing.Point(62, 30);
            this.config_force_time.Name = "config_force_time";
            this.config_force_time.Size = new System.Drawing.Size(129, 21);
            this.config_force_time.TabIndex = 3;
            this.config_force_time.Text = "11:29:56";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "加价幅度";
            // 
            // config_increase_amount
            // 
            this.config_increase_amount.Dock = System.Windows.Forms.DockStyle.Top;
            this.config_increase_amount.Location = new System.Drawing.Point(62, 57);
            this.config_increase_amount.Name = "config_increase_amount";
            this.config_increase_amount.Size = new System.Drawing.Size(129, 21);
            this.config_increase_amount.TabIndex = 5;
            this.config_increase_amount.Text = "900";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "加价时间";
            // 
            // config_time_to_increase
            // 
            this.config_time_to_increase.Dock = System.Windows.Forms.DockStyle.Top;
            this.config_time_to_increase.Location = new System.Drawing.Point(62, 84);
            this.config_time_to_increase.Name = "config_time_to_increase";
            this.config_time_to_increase.Size = new System.Drawing.Size(129, 21);
            this.config_time_to_increase.TabIndex = 7;
            this.config_time_to_increase.Text = "11:29:45";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 217);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(207, 138);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "参数设置";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 355);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 55);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "拍牌";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.bt_start);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(201, 35);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(3, 3);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(75, 23);
            this.bt_start.TabIndex = 5;
            this.bt_start.Text = "启动拍牌";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.btStart_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 410);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 83);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "调试";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(attachIE);
            this.flowLayoutPanel2.Controls.Add(this.test_sceen);
            this.flowLayoutPanel2.Controls.Add(this.btn_show_positions);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(201, 63);
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
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(207, 534);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbRuntime);
            this.Name = "Information";
            this.Text = "Information";
            this.gbRuntime.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox tbTime;
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox config_advance_price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox config_force_time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox config_increase_amount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox config_time_to_increase;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button test_sceen;
        private System.Windows.Forms.Button btn_show_positions;
        private System.Windows.Forms.Button bt_start;
    }
}

