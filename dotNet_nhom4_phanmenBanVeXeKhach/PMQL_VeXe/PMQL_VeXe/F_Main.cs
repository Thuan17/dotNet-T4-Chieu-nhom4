using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PMQL_VeXe
{
    public partial class F_Main : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        //-------------------------------------

        SqlConnection con1;
        SqlCommand cmd1;
        string str1 = "Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True";
        SqlDataAdapter adapter1 = new SqlDataAdapter();
        DataTable table1 = new DataTable();




        public string MaNhanVien_get = F_LogIn.MaNhanVien;
        public string PassNhanVien_get = F_LogIn.Pass;





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
        //private void showSubmenu(submenu  Panel)
        //{

        private void btnVe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_BanVe());
        }



        private void F_Main_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            checkRole();
            getName();
            OpenChildForm(new F_BanVe());
        }
        public void checkRole()
        {
            cmd1 = con.CreateCommand();
            cmd1.CommandText = "select Role from dbo_NhanVien where MaNhanVien ='" + MaNhanVien_get.Trim() + "' and Pass='" + PassNhanVien_get.Trim() + "' ";
            adapter1.SelectCommand = cmd;
            SqlDataReader reader = cmd1.ExecuteReader();
            if (reader.Read() == true)
            {
                string Role = reader["Role"].ToString();
                string selectedValue = Role.Trim();
                lbName.Text = Role;    
                if (selectedValue == "admin"|| selectedValue == "QuanLy")
                {
                    btnQLLichTrinh.Visible = true;
                    btnQLXE.Visible = true;
                    btnTKDoanhSo.Visible = true;
                    btnLichSu.Visible = true;
                    btnQLNhanVien.Visible = true;
                    btn_ThongKeVe.Visible= true;    
                }
                else
                {

                }   
            }
            else
            {
                MessageBox.Show("Không Thấy");
            }
            reader.Close();
        }
       
        public void getName()
        {
            SqlCommand sqlCmd = new SqlCommand("select TenNV from dbo_NhanVien where MaNhanVien ='"+MaNhanVien_get.Trim()+"' and Pass='"+PassNhanVien_get.Trim()+"'", con);
            con = new SqlConnection(str);
            con.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            if (sqlReader.Read() == true)
            {
                string Role = sqlReader["TenNV"].ToString();
                string selectedValue = Role.Trim();
                lbName.Text = Role;
               
            }
            else
            {
                MessageBox.Show("Không Thấy");
            }
            sqlReader.Close();
        }
        //byte[] PathToByteArray(Image img)
        //{
        //    MemoryStream m = new MemoryStream();

        //    img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
        //    return m.ToArray();
        //}
        public void loadAvatar()
        {
            SqlCommand sqlCmd = new SqlCommand("select Img from dbo_NhanVien where MaNhanVien ='" + MaNhanVien_get.Trim() + "' and Pass='" + PassNhanVien_get.Trim() + "'", con);
            con = new SqlConnection(str);
            con.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            if (sqlReader.Read())
            {
                byte[] imageBytes = (byte[])sqlReader["Img"];
                using (MemoryStream memoryStream = new MemoryStream(imageBytes))
                {
                    //picAvtar.Image = Image.FromStream(memoryStream);
                }
            }
            sqlReader.Close();
        }
       
       
        public void LoadTenNhanVien()
        { 
            
        }


        private void btnQLXE_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_QLXe());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_QLVe());
        }

        private void btn_ThongKeVe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_TKve());
        }

        private void btnQLLichTrinh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_QLLichTrinh());
        }

      

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_QLNhanVien());
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new F_History());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            F_LogIn form = new F_LogIn();
            
            form.Show();
            Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            F_DoiMatKhau frm = new F_DoiMatKhau();
            frm.Show();
            Hide();
        }
    }
}
