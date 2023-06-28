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
    public partial class admin41 : Form
    {
        public admin41()
        {
            InitializeComponent();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = "select * from Maintenance";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        public void show1()
        {
            if (dataGridView1.Rows.Count != 0)
            {
                label2.Text = "编号"+dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
            else
            {
                label2.Text = "";
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void admin41_Load(object sender, EventArgs e)
        {
            Table();
            show1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult dr = MessageBox.Show("确认结束维修吗", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from Maintenance where no ={int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())};update Instrumentation set number=number+{int.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString())} where id ='{id}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("结束维修成功");
                        Table();
                        show1();
                    }
                    else
                    {
                        MessageBox.Show("结束维修失败" + sql);
                    }
                    dao.DaoClose();
                }
            }
            else
            {
                MessageBox.Show("没有仪器需要结束维修");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            show1();
        }
    }
}
