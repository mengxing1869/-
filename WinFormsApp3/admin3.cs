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
    public partial class admin3 : Form
    {
        public admin3()
        {
            InitializeComponent();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();
            Dao dao = new Dao();
            string sql = "select * from borrow";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void admin3_Load(object sender, EventArgs e)
        {
            Table();
        }
    }
}
