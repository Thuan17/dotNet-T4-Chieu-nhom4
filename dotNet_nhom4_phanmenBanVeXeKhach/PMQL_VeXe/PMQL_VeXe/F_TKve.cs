using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PMQL_VeXe
{
    public partial class F_TKve : Form
    {


        SqlConnection con;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public F_TKve()
        {
            InitializeComponent();
        }


        public void LoadDGV()
        {
        }


        private void F_TKve_Load(object sender, EventArgs e)
        {

            con = new SqlConnection(str);
            con.Open();
            LoadChartTheoThang();
            ThongKeTheoVeMuaNhieuNhat();
            //ThongKeTheoNamHienTai();
        }


        public void ThongKeTheoVeMuaNhieuNhat() 
        { 
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT V.*, L.TenLichTrinh FROM dbo_BangVeXe V INNER JOIN dbo_BangLichTrinh L ON V.MaBangLichTrinh = L.MaBangLichTrinh";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            chartVeMuaNhieu.DataSource = table;
            chartVeMuaNhieu.Series["Series1"].XValueMember = "TenLichTrinh";
            chartVeMuaNhieu.Series["Series1"].YValueMembers = "GiaVe";
            chartVeMuaNhieu.Series[0].ChartType = SeriesChartType.Pie;
            con.Close();
        }

       


        public void LoadChartTheoThang()
        {
            // Đảm bảo rằng adapter và table được khởi tạo lại
            adapter = new SqlDataAdapter();
            table = new DataTable();

            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT MONTH(V.NgayMua) AS Thang, L.TenLichTrinh, SUM(V.GiaVe) AS TongGiaVe " +
                              "FROM dbo_BangVeXe V " +
                              "INNER JOIN dbo_BangLichTrinh L ON V.MaBangLichTrinh = L.MaBangLichTrinh " +
                              "GROUP BY MONTH(V.NgayMua), L.TenLichTrinh";

            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            // Xóa tất cả các Legend trước khi thêm một
            chartVe.Legends.Clear();
            chartVe.Legends.Add(new Legend("Legend1"));

            if (table.Rows.Count > 0)
            {
                chartVe.DataSource = table;
                chartVe.Series["Series1"].XValueMember = "Thang"; // Sử dụng tháng thay vì tên lịch trình
                chartVe.Series["Series1"].YValueMembers = "TongGiaVe";
                chartVe.Series["Series1"].LegendText = "#AXISLABEL - #VALX";
                chartVe.Series[0].ChartType = SeriesChartType.Pie;

                // Đặt tên cột tháng và tên lịch trình
                chartVe.ChartAreas[0].AxisX.Title = "Tháng";
                chartVe.ChartAreas[0].AxisY.Title = "Tổng giá vé";
                chartVe.ChartAreas[0].AxisX.Title = "Tháng";
                chartVe.ChartAreas[0].AxisX.Title = "Tháng";

                // Thêm tên lịch trình vào chú thích
                foreach (DataPoint point in chartVe.Series["Series1"].Points)
                {
                    int index;
                    if (int.TryParse(point.AxisLabel, out index) && index >= 1 && index <= table.Rows.Count)
                    {
                        point.AxisLabel = table.Rows[index - 1]["TenLichTrinh"].ToString();
                    }
                }
            }
            else
            {
                // Xử lý khi không có dữ liệu.
                // Bạn có thể hiển thị một thông báo hoặc thực hiện các hành động phù hợp khác.
            }
        }




    }
}
