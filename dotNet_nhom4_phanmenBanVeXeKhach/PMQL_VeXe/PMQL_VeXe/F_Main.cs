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
    public partial class F_Main : Form
    {
        public F_Main()
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

        private void btnVe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_BanVe());
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {

        }

        private void btnTKDoanhSo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_TKve());
        }
    }
}
