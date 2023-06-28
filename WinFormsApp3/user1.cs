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
    public partial class user1 : Form
    {
        public user1()
        {
            InitializeComponent();
        }

        private void 仪器查看和借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user2 user2 = new user2();
            user2.ShowDialog();
        }

        private void 当前借入仪器和归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user3 user3 = new user3();
            user3.ShowDialog();
        }

        private void user1_Load(object sender, EventArgs e)
        {

        }
    }
}
