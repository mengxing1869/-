namespace WinFormsApp3
{
    partial class user1
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
            this.仪器查看和借阅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前借入仪器和归还ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem,
            this.仪器查看和借阅ToolStripMenuItem,
            this.当前借入仪器和归还ToolStripMenuItem});
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
            // 仪器查看和借阅ToolStripMenuItem
            // 
            this.仪器查看和借阅ToolStripMenuItem.Name = "仪器查看和借阅ToolStripMenuItem";
            this.仪器查看和借阅ToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.仪器查看和借阅ToolStripMenuItem.Text = "仪器查看和借阅";
            this.仪器查看和借阅ToolStripMenuItem.Click += new System.EventHandler(this.仪器查看和借阅ToolStripMenuItem_Click);
            // 
            // 当前借入仪器和归还ToolStripMenuItem
            // 
            this.当前借入仪器和归还ToolStripMenuItem.Name = "当前借入仪器和归还ToolStripMenuItem";
            this.当前借入仪器和归还ToolStripMenuItem.Size = new System.Drawing.Size(158, 24);
            this.当前借入仪器和归还ToolStripMenuItem.Text = "当前借入仪器和归还";
            this.当前借入仪器和归还ToolStripMenuItem.Click += new System.EventHandler(this.当前借入仪器和归还ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(195, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "欢迎登录用户界面";
            // 
            // user1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "user1";
            this.Text = "用户界面";
            this.Load += new System.EventHandler(this.user1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 系统ToolStripMenuItem;
        private ToolStripMenuItem 仪器查看和借阅ToolStripMenuItem;
        private ToolStripMenuItem 当前借入仪器和归还ToolStripMenuItem;
        private Label label1;
    }
}