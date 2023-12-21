using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_VeXe
{
    public partial class F_DoiMatKhau : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True");
        public F_DoiMatKhau()
        {
            InitializeComponent();
        }

        private void btn_xacnhan_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select count (*) From dbo_NhanVien Where MaNhanVien= N'" + txt_tendangnhap.Text + "' and Pass= N'" + txt_matkhaucu.Text + "'", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (txt_xacnhanmk.Text == txt_matkhaumoi.Text)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("Update dbo_NhanVien set Pass = N'" + txt_matkhaumoi.Text + "' Where MaNhanVien= N'" + txt_tendangnhap.Text + "' and Pass = N'" + txt_matkhaucu.Text + "'", con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    MessageBox.Show("Thành công", "Đổi Mật Khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                }
                else
                {
                    errorProvider1.SetError(txt_matkhaumoi, "Bạn chưa điền mật khẩu !");
                    errorProvider1.SetError(txt_xacnhanmk, "Mật khẩu mới chưa đúng !");
                }
            }
            else
            {
                errorProvider1.SetError(txt_tendangnhap, "Tên đăng nhập sai !");
                errorProvider1.SetError(txt_matkhaucu, "Mật khẩu cũ sai !");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_tendangnhap.Clear();
            txt_matkhaucu.Clear();
            txt_matkhaumoi.Clear();
            txt_xacnhanmk.Clear();
            txt_tendangnhap.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            F_LogIn frm = new F_LogIn();
            frm.Show();
            Hide();
        }
    }
}
