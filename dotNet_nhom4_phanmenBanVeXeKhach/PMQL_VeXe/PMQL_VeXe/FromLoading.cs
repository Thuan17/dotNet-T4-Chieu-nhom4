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
    public partial class FromLoading : Form
    {
        public FromLoading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeline.Width += 8;
            if (timeline.Width >= 414)
            {

                timer1.Stop();/*/*vao properties enable=true*/
               Main main = new Main();  
                main.Show();
                Hide();
                //ResponsiveForm Main = new ResponsiveForm();
                //Main.Show();
                //this.Hide();
                //MessageBox.Show("Xin Chào");
            }
            if (timeline.Width == 250)
            {
                label1.Text = "Kiểm tra dữ liệu ... ";
            }
          

        }
    }
}

