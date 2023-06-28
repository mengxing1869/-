namespace WinFormsApp3
{
    partial class admin22
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(251, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(337, 48);
            this.button1.TabIndex = 24;
            this.button1.Text = "修改仪器";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(357, 196);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(166, 27);
            this.textBox3.TabIndex = 23;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(357, 135);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(166, 27);
            this.textBox2.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(271, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 27);
            this.label3.TabIndex = 21;
            this.label3.Text = "库存:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(271, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 27);
            this.label2.TabIndex = 20;
            this.label2.Text = "仪器名:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(357, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 27);
            this.textBox1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(271, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 27);
            this.label1.TabIndex = 18;
            this.label1.Text = "编号:";
            // 
            // admin22
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "admin22";
            this.Text = "admin22";
            this.Load += new System.EventHandler(this.admin22_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button1;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label3;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
    }
}