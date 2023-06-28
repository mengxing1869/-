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
    public partial class user2 : Form
    {
        public user2()
        {
            InitializeComponent();
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
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
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
        private void user2_Load(object sender, EventArgs e)
        {
            Table();
            show1();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string name=dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            if (number >= 1)
            {
                DialogResult dr = MessageBox.Show("确认借出吗", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"insert into borrow ([id],[uid],[inname],[name],[intime]) values('{id}','{Data.UID}','{name}','{Data.UNname}',getdate());update Instrumentation set number=number-1 where id ='{id}'";
                    Dao dao = new Dao();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("借出成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("借出失败" + sql);
                    }
                    dao.DaoClose();
                    show1();
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
    }
}
