using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data; 

namespace WinFormsApp3
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != ""&&textBox2.Text!="")
            {
                Login();
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }
        public void Login()
        {
            if(radioButtonUser.Checked==true)
            {
                Dao dao = new Dao();
                string sql = "select * from t_user where uid='" + textBox1.Text + "'and psw='" + textBox2.Text + "'";
                IDataReader dc = dao.read(sql);
                if(dc.Read())
                {
                    Data.UID = dc["uid"].ToString();
                    Data.UNname = dc["name"].ToString();

                    MessageBox.Show("登录成功");
                    user1 user = new user1();
                    this.Hide();
                    user.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
                dao.DaoClose();

            }
            if(radioButtonAdmin.Checked==true)
            {
                Dao dao = new Dao();
                string sql = "select * from t_admin where aid='" + textBox1.Text + "'and psw='" + textBox2.Text + "'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    Data.UID = dc["aid"].ToString();

                    MessageBox.Show("登录成功");
                    admin1 admin1 = new admin1();
                    this.Hide();
                    admin1.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                }
                dao.DaoClose();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}