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
    public partial class admin1 : Form
    {
        public admin1()
        {
            InitializeComponent();
        }

        private void 图书管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void admin1_Load(object sender, EventArgs e)
        {

        }

        private void 仪器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin2 admin2 = new admin2();
            admin2.ShowDialog();
        }

        private void 仪器管理界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin3 admin3 = new admin3();
            admin3.ShowDialog();
        }

        private void 仪器维修ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin4 admin4 = new admin4();
            admin4.ShowDialog();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin5 admin5 = new admin5();
            admin5.ShowDialog();
        }
    }
}
