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

     

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDropMenu_Click(object sender, EventArgs e)
        {
            timerDropMenu.Start();
            btnDropMenu.BackColor = Color.White;
            label13.Text = btnDropMenu.Text;
            btn_Home.BackColor = Color.SkyBlue;
        }
    }
}
