using ComponentFactory.Krypton.Toolkit;
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
using System.Xml.Linq;

namespace PMQL_VeXe
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }
      
     

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }


        byte[] PathToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] b = PathToByteArray(pictureBox1.Image);
            cmd = con.CreateCommand();
            cmd.CommandText = @"insert into test values(N'80980',@hinh)";
            cmd.Parameters.Add("@hinh",b);
            cmd.ExecuteNonQuery();



        }
        public void LoadDGV()
        {

            cmd = con.CreateCommand();
            cmd.CommandText = "select MaNhanVien, TenNV, Luong ,Role,CCCD,Img from dbo_NhanVien";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            DGV.DataSource = table;

        }

    }
}
