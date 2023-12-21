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
    public partial class F_History : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public F_History()
        {
            InitializeComponent();
        }

        private void F_History_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            LoadDGV();
        }
        public void LoadDGV()
        {
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM dbo_History";
                adapter.SelectCommand = cmd;
                table.Clear();
                adapter.Fill(table);
                DGVHistory.DataSource = table;
            }
            catch
            {
                //MessageBox.Show("Lỗi Load Data Lên Bảng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
