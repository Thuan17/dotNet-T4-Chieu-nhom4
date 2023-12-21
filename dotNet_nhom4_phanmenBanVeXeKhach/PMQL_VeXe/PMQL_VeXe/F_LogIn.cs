using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PMQL_VeXe
{
    
    public partial class F_LogIn : Form
    {
        public static string MaNhanVien;
        public static string Pass;
        SqlConnection con;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public F_LogIn()
        {
            InitializeComponent();
        }

        private void F_LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
                MessageBox.Show("Bạn Có Muốn Thoát", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
        public void Alert(string noidung, string name)
        {
            TB_Mess frm = new TB_Mess();

            frm.showAlter(noidung, name);
        }

        
        private void btnDangNhap_Click(object sender, EventArgs e)
        {

          
            if ((string.IsNullOrEmpty(txtUser.Text)) || (string.IsNullOrEmpty(txtUser.Text)))
            {
                MessageBox.Show("Không Để Trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else 
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "select Role from dbo_NhanVien where MaNhanVien ='" + txtUser.Text .Trim()+ "' and Pass ='" + txtPass.Text .Trim()+ "' "  ;
                adapter.SelectCommand = cmd;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()==true)
                {
                    MaNhanVien=txtUser.Text;
                    Pass=txtPass.Text;


                    lbThongBao.Visible = true;
                    lbThongBao.Text = "Đăng Nhập Thành Công ";
                    lbThongBao.ForeColor = Color.Green;

                    this.Alert("Thành Công", "Đăng Nhập");

                    F_Main frm = new F_Main();
                    frm.Show();
                    Hide();
                }
                else
                {
                    lbThongBao.Visible = true;
                    lbThongBao.Text = "Đăng Nhập Thất Bại ";
                    lbThongBao.ForeColor = Color.Red;
                    txtUser.Text = null;
                    txtPass.Text = null;    
                }
                reader.Close(); 
            }
        }

        private void F_LogIn_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
        }

       

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;   
            btnAn.Visible = true;
            btnHienThi.Visible = false;
            btnAn.Visible = true;
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
            btnHienThi.Visible = true;
            btnAn.Visible=false;    
        }

        private void btnHienThi2_Click(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }
    }
}
