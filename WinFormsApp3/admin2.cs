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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin21 admin21 = new admin21();
            admin21.ShowDialog();
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = "select * from Instrumentation";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
            show1();
            dao.DaoClose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Table() 
        { 
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = "select * from Instrumentation";
            IDataReader dc = dao.read(sql);
            while(dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }

        private void admin2_Load(object sender, EventArgs e)
        {
            Table();
            show1();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {            
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult dr = MessageBox.Show("确认删除吗", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                string sql = $"delete from Instrumentation where id ='{id}'";
                Dao dao = new Dao();
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("删除成功");
                    Table();
                }
                else
                {
                    MessageBox.Show("删除失败" + sql);
                }
                show1();
                dao.DaoClose();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void show1()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                label3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
            else
            {
                label3.Text = "";
            }
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            show1();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                dataGridView1.Rows.Clear();
                Dao dao = new Dao();
                string sql = $"select * from Instrumentation where id ='{textBox1.Text}'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
                }
                dc.Close();
                dao.DaoClose();
                show1();
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();
            textBox1.Text = "";
            textBox2.Text = "";
            show1();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                dataGridView1.Rows.Clear();
                Dao dao = new Dao();
                string sql = $"select * from Instrumentation where inname like '%{textBox2.Text}%'";
                IDataReader dc = dao.read(sql);
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
                }
                dc.Close();
                dao.DaoClose();
                show1();
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();  
            string number = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            admin22 admin22 = new admin22(id,name,number);
            admin22.ShowDialog();

            Table();
            show1();
        }
    }
}
