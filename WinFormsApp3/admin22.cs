using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class admin22 : Form
    {
        public admin22()
        {
            InitializeComponent();
        }

        public admin22(string id,string name,string number)
        {
            InitializeComponent();
            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = number;        
        }

        private void admin22_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                Dao dao = new Dao();
                string id = textBox1.Text;
                string sql = $"update Instrumentation set id='{textBox1.Text}' ,inname='{textBox2.Text} ',number={int.Parse(textBox3.Text)} where id='{id}'";
                int n = dao.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
                dao.DaoClose();
                this.Close();
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }
    }
}
