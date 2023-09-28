using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_VeXe
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

     
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn Muốn Thoát Chương Trình ?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {


            string user = txtUser.Text;
            string pass = txtPass.Text;

            if (user == null || user.Equals(""))
            {
                MessageBox.Show("Tài Khoản Không Để Trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             if (pass == null || user.Equals(""))
            {
                MessageBox.Show("Mật Khẩu Không Để Trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Hide();
            FromLoading load = new FromLoading();
            load.Show();
           

            
        }
    }
}
