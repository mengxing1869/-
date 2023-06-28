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
    public partial class admin4 : Form
    {
        public admin4()
        {
            InitializeComponent();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = "select * from Instrumentation";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        private void admin4_Load(object sender, EventArgs e)
        {
            Table();
            show1();
        }
        public void show1()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                label2.Text =  dataGridView1.SelectedRows[0].Cells[0].Value.ToString()+ dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
            else
            {
                label2.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            if (number >= int.Parse(textBox1.Text.ToString()))
            {
                DialogResult dr = MessageBox.Show("确认送入维修吗", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"insert into Maintenance([id],[inname],[number],[intime]) values('{id}','{name}','{int.Parse(textBox1.Text.ToString())}',getdate());update Instrumentation set number=number-{int.Parse(textBox1.Text.ToString())} where id ='{id}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("送入维修成功");
                        Table();
                        show1();
                        textBox1.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("送入维修失败" + sql);
                    }
                    dao.DaoClose();
                }
            }
            else
            {
                MessageBox.Show("库存不足");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            show1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin41 admin41 = new admin41();
            admin41.ShowDialog();
            Table();
        }
    }
}
