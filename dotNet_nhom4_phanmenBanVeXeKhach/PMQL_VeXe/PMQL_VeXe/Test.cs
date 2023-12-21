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
using System.Windows.Forms.DataVisualization.Charting;

namespace PMQL_VeXe
{
    public partial class Test : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            LoadChart();
        }


        public void LoadChart()
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT V.*, L.TenLichTrinh FROM dbo_BangVeXe V INNER JOIN dbo_BangLichTrinh L ON V.MaBangLichTrinh = L.MaBangLichTrinh";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            chart1.DataSource= table;
            chart1.Series["Series1"].XValueMember = "TenLichTrinh";
            chart1.Series["Series1"].YValueMembers = "GiaVe";
            chart1.Series[0].ChartType = SeriesChartType.Pie;
            con.Close();
        }

    }
}
