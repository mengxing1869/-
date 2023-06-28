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
    public partial class admin5 : Form
    {
        public admin5()
        {
            InitializeComponent();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = "select * from t_user";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        public void show1()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
            else
            {
                label2.Text = "";
            }
        }
        private void admin5_Load(object sender, EventArgs e)
        {
            Table();
            show1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult dr = MessageBox.Show("确认删除吗", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                string sql = $"delete from t_user where uid ='{uid}'";
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
                Table();
                dao.DaoClose();
                show1();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin51 admin51 = new admin51();
            admin51.ShowDialog();
            Table();
            show1();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            show1();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string uid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            DialogResult dr = MessageBox.Show("确认修改吗", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                string sql = $"update t_user set psw='{textBox1.Text}' where uid ='{uid}'";
                Dao dao = new Dao();
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                    Table();
                }
                else
                {
                    MessageBox.Show("修改失败" + sql);
                }
            }
        }
    }
}
