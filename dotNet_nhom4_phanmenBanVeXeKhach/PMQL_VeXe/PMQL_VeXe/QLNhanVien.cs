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
    public partial class QLNhanVien : Form
    {
        public QLNhanVien()
        {
            InitializeComponent();
        }

      

        private void txtMaNhanVien_Enter(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text == "   Mã Nhân Viên ")
            {
                txtMaNhanVien.Text = "";
                txtMaNhanVien.ForeColor = Color.Black;
            }
        }

        private void txtTenNhanVien_Enter(object sender, EventArgs e)
        {
            if (txtTenNhanVien.Text == "   Tên Nhân Viên")
            {
                txtTenNhanVien.Text = "";
                txtTenNhanVien.ForeColor = Color.Black;
            }
        }

      
    }
}
