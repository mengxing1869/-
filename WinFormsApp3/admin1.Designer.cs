namespace WinFormsApp3
{
    partial class admin1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仪器管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借取信息查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仪器维修ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem,
            this.仪器管理ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // 仪器管理ToolStripMenuItem
            // 
            this.仪器管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.管理界面ToolStripMenuItem,
            this.借取信息查询ToolStripMenuItem,
            this.仪器维修ToolStripMenuItem});
            this.仪器管理ToolStripMenuItem.Name = "仪器管理ToolStripMenuItem";
            this.仪器管理ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.仪器管理ToolStripMenuItem.Text = "仪器管理";
            this.仪器管理ToolStripMenuItem.Click += new System.EventHandler(this.图书管理ToolStripMenuItem_Click);
            // 
            // 管理界面ToolStripMenuItem
            // 
            this.管理界面ToolStripMenuItem.Name = "管理界面ToolStripMenuItem";
            this.管理界面ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.管理界面ToolStripMenuItem.Text = "管理界面";
            this.管理界面ToolStripMenuItem.Click += new System.EventHandler(this.仪器ToolStripMenuItem_Click);
            // 
            // 借取信息查询ToolStripMenuItem
            // 
            this.借取信息查询ToolStripMenuItem.Name = "借取信息查询ToolStripMenuItem";
            this.借取信息查询ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.借取信息查询ToolStripMenuItem.Text = "借取信息查询";
            this.借取信息查询ToolStripMenuItem.Click += new System.EventHandler(this.仪器管理界面ToolStripMenuItem_Click);
            // 
            // 仪器维修ToolStripMenuItem
            // 
            this.仪器维修ToolStripMenuItem.Name = "仪器维修ToolStripMenuItem";
            this.仪器维修ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.仪器维修ToolStripMenuItem.Text = "仪器维修";
            this.仪器维修ToolStripMenuItem.Click += new System.EventHandler(this.仪器维修ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.帮助ToolStripMenuItem.Text = "用户管理";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(182, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "欢迎登录管理员界面";
            // 
            // admin1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "admin1";
            this.Text = "管理员主界面";
            this.Load += new System.EventHandler(this.admin1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 系统ToolStripMenuItem;
        private ToolStripMenuItem 仪器管理ToolStripMenuItem;
        private ToolStripMenuItem 帮助ToolStripMenuItem;
        private Label label1;
        private ToolStripMenuItem 管理界面ToolStripMenuItem;
        private ToolStripMenuItem 借取信息查询ToolStripMenuItem;
        private ToolStripMenuItem 仪器维修ToolStripMenuItem;
    }
}