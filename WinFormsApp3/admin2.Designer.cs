namespace WinFormsApp3
{
    partial class admin2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(487, 450);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "仪器号";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "仪器名";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "库存";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(518, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "添加仪器";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(679, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 49);
            this.button3.TabIndex = 3;
            this.button3.Text = "删除仪器";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(679, 163);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 49);
            this.button4.TabIndex = 4;
            this.button4.Text = "刷新";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(679, 242);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(109, 49);
            this.button5.TabIndex = 5;
            this.button5.Text = "仪器号查询";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button6.Location = new System.Drawing.Point(679, 336);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(109, 49);
            this.button6.TabIndex = 6;
            this.button6.Text = "仪器名查询";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(518, 254);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 27);
            this.textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(518, 348);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(155, 27);
            this.textBox2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(518, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "当前选中的仪器是：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(707, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(679, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 11;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(518, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 49);
            this.button2.TabIndex = 12;
            this.button2.Text = "修改仪器";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // admin2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "admin2";
            this.Text = "仪器管理界面";
            this.Load += new System.EventHandler(this.admin2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private Button button1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button2;
    }
}