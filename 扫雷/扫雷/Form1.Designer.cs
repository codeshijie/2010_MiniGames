namespace 扫雷
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.初级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自定义ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于扫雷ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbMineNum = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.buttonAgain = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(292, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.初级ToolStripMenuItem,
            this.中级ToolStripMenuItem,
            this.高级ToolStripMenuItem,
            this.自定义ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.退出ToolStripMenuItem});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.开始ToolStripMenuItem.Text = "开始";
            this.开始ToolStripMenuItem.Click += new System.EventHandler(this.开始ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 6);
            // 
            // 初级ToolStripMenuItem
            // 
            this.初级ToolStripMenuItem.Name = "初级ToolStripMenuItem";
            this.初级ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.初级ToolStripMenuItem.Text = "初级";
            this.初级ToolStripMenuItem.Click += new System.EventHandler(this.初级ToolStripMenuItem_Click);
            // 
            // 中级ToolStripMenuItem
            // 
            this.中级ToolStripMenuItem.Name = "中级ToolStripMenuItem";
            this.中级ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.中级ToolStripMenuItem.Text = "中级";
            this.中级ToolStripMenuItem.Click += new System.EventHandler(this.中级ToolStripMenuItem_Click);
            // 
            // 高级ToolStripMenuItem
            // 
            this.高级ToolStripMenuItem.Name = "高级ToolStripMenuItem";
            this.高级ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.高级ToolStripMenuItem.Text = "高级";
            this.高级ToolStripMenuItem.Click += new System.EventHandler(this.高级ToolStripMenuItem_Click);
            // 
            // 自定义ToolStripMenuItem
            // 
            this.自定义ToolStripMenuItem.Name = "自定义ToolStripMenuItem";
            this.自定义ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.自定义ToolStripMenuItem.Text = "自定义";
            this.自定义ToolStripMenuItem.Click += new System.EventHandler(this.自定义ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(103, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于扫雷ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于扫雷ToolStripMenuItem
            // 
            this.关于扫雷ToolStripMenuItem.Name = "关于扫雷ToolStripMenuItem";
            this.关于扫雷ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关于扫雷ToolStripMenuItem.Text = "关于扫雷";
            this.关于扫雷ToolStripMenuItem.Click += new System.EventHandler(this.关于扫雷ToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbMineNum
            // 
            this.lbMineNum.AutoSize = true;
            this.lbMineNum.BackColor = System.Drawing.Color.LightGray;
            this.lbMineNum.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbMineNum.Font = new System.Drawing.Font("楷体_GB2312", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMineNum.ForeColor = System.Drawing.Color.Green;
            this.lbMineNum.Location = new System.Drawing.Point(0, 24);
            this.lbMineNum.Name = "lbMineNum";
            this.lbMineNum.Size = new System.Drawing.Size(0, 16);
            this.lbMineNum.TabIndex = 1;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.Color.LightGray;
            this.lbTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbTime.Font = new System.Drawing.Font("楷体_GB2312", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.ForeColor = System.Drawing.Color.Green;
            this.lbTime.Location = new System.Drawing.Point(292, 24);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(0, 16);
            this.lbTime.TabIndex = 2;
            // 
            // buttonAgain
            // 
            this.buttonAgain.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonAgain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAgain.Location = new System.Drawing.Point(134, 27);
            this.buttonAgain.Name = "buttonAgain";
            this.buttonAgain.Size = new System.Drawing.Size(25, 25);
            this.buttonAgain.TabIndex = 3;
            this.buttonAgain.UseVisualStyleBackColor = true;
            this.buttonAgain.Click += new System.EventHandler(this.buttonAgain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.buttonAgain);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbMineNum);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫雷";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 初级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 自定义ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于扫雷ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbMineNum;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Button buttonAgain;
    }
}

