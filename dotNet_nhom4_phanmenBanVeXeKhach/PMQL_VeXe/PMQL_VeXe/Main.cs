using PMQL_VeXe.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PMQL_VeXe
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private Form currentFormChild;

        private bool isCollapsed;

        private bool isCollapsed2;




        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();

        }

        private void txtName_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_Home());
            label13.Text = btn_Home.Text;
            btn_Home.BackColor = Color.White;
            btn_Home.ForeColor = Color.Blue;
            btnDropMenu.BackColor = Color.SkyBlue;
            btnQLXe.BackColor = Color.SkyBlue;
            btnQLXe.ForeColor = Color.Black;
            timerDropMenu.Start();
            pHeThong.Location = new Point(10, 297);
        }

        private void timerDropMenu_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {

                pDropdown.Height += 10;
                if (pDropdown.Size == pDropdown.MaximumSize)
                {
                    timerDropMenu.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                pDropdown.Height -= 10;
                if (pDropdown.Size == pDropdown.MinimumSize)
                {
                    timerDropMenu.Stop();
                    isCollapsed = true;
                }
            }
        }


        public void load() {



            string name = txtName.Text = Login.Name;
            if (name == "admin")
            {
                pHeThong.Visible = true;

               
            }                



        }
        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDropMenu_Click(object sender, EventArgs e)
        {
            timerDropMenu.Start();

          

            pHeThong.Location = new Point(10, 414);

            btnDropMenu.BackColor = Color.White;
            label13.Text = btnDropMenu.Text;
            btn_Home.BackColor = Color.SkyBlue;
            btnQLXe.BackColor = Color.SkyBlue;
            btnQLXe.ForeColor = Color.Black;


            

           
        }

        private void Main_Load(object sender, EventArgs e)
        {
            load();
            //pHeThong.Location = new Point(10, 303);
           
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Hide(); 
            Login login = new Login();  
            login.Show();
        }

        private void btnQLXe_Click(object sender, EventArgs e)
        {
            btn_Home.BackColor = Color.SkyBlue;
            btn_Home.ForeColor= Color.Black;    
            btnQLXe.BackColor = Color.White;
            btnQLXe.ForeColor = Color.Blue;
            btnDropMenu.BackColor = Color.SkyBlue;
            timerDropMenu.Start();
            pHeThong.Location = new Point(10, 297);
        }

        private void timerQLHeThong_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {

                pHeThong.Height += 10;
                if (pHeThong.Size == pHeThong.MaximumSize)
                {
                    timerQLHeThong.Stop();
                    isCollapsed2 = false;
                }
            }
            else
            {
                pHeThong.Height -= 10;
                if (pHeThong.Size == pHeThong.MinimumSize)
                {
                    timerQLHeThong.Stop();
                    isCollapsed2 = true;
                }
            }
        }

        private void btnQLHeThong_Click(object sender, EventArgs e)
        {
            timerQLHeThong.Start();
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new QLNhanVien());
        }
    }
}
