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
    public partial class F_Home : Form
    {
        public F_Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiemDon_Enter(object sender, EventArgs e)
        {
            if (txtDiemDon.Text == "             Chọn Điểm Đón...")
            {
                txtDiemDon.Text = "";
                txtDiemDon.ForeColor = Color.Black;
            }
        }

        private void txtDiemDen_Enter(object sender, EventArgs e)
        {
            if (txtDiemDen.Text == "             Chọn Điểm Đến...")
            {
                txtDiemDen.Text = "";
                txtDiemDen.ForeColor = Color.Black;
            }
        }

        private void tableLayoutPanel1_Enter(object sender, EventArgs e)
        {

        }

        private void txtHoTen_Enter(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "      Họ Tên")
            {
                txtHoTen.Text = "";
                txtHoTen.ForeColor = Color.Black;
            }
        }

        private void txtSDT_Enter(object sender, EventArgs e)
        {
            if (txtSDT.Text == "   Số Điện Thoại")
            {
                txtSDT.Text = "";
                txtSDT.ForeColor = Color.Black;
            }
        }

        private void txtDiaChi_Enter(object sender, EventArgs e)
        {
          
            if (txtDiaChi.Text == "   Địa Chỉ")
            {
                txtDiaChi.Text = "";
                txtDiaChi.ForeColor = Color.Black;
            }
        }

        private void txtSoLuong_Enter(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == "   Số Lượng")
            {
                txtSoLuong.Text = "";
                txtSoLuong.ForeColor = Color.Black;
            }
        }

        private void txtSTT_Enter(object sender, EventArgs e)
        {
            if (txtSTT.Text == "   STT")
            {
                txtSTT.Text = "";
                txtSTT.ForeColor = Color.Black;
            }
        }



        public void CheckEmpty() {

            string DiemDon = txtDiemDon.Text;
            string DiemDen = txtDiemDen.Text;
            string Name = txtHoTen.Text;
            string sdt = txtSDT.Text;
            string DiaChi = txtDiaChi.Text;
            if (DiemDon == null || txtDiemDon.Text == "             Chọn Điểm Đón..."/*|| DiemDen == null || Name == null || sdt == null*/)
            {
                MessageBox.Show(" Không Để Trống Điểm Đón", "Kiểm Tra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (DiemDen == null || txtDiemDen.Text == "             Chọn Điểm Đến...")
            {
                MessageBox.Show(" Không Để Trống Điểm Đến", "Kiểm Tra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Name == null || txtHoTen.Text == "      Họ Tên")
            {
                MessageBox.Show(" Không Để Trống Tên", "Kiểm Tra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (sdt == null || txtSDT.Text == "   Số Điện Thoại")
            {
                MessageBox.Show(" Không Để Trống SĐT", "Kiểm Tra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (DiaChi == null || txtDiaChi.Text == "   Địa Chỉ")
            {
                MessageBox.Show(" Không Để Trống Địa Chỉ", "Kiểm Tra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                btnXuatVe.BackColor = Color.Lime;  
                btnXuatVe.Enabled = true;
            }
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            CheckEmpty();
          
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //txtSDT.Text = " ";
            //txtHoTen.Text = "";
            //txtDiemDen.Text = "";
            //txtDiemDon.Text = " ";
            //txtDiaChi.Text = " ";
        }
    }
}
