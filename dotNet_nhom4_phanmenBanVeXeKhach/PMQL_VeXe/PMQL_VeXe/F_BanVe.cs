using DTO;
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
using System.Xml.Linq;

namespace PMQL_VeXe
{
    public partial class F_BanVe : Form
    {

        DB connection;
        DataColumn[] primaryKey;
        SqlDataAdapter adapter1, adapter2;

        private void F_BanVe_Load(object sender, EventArgs e)
        {
            LoadDGV();
            loadCBXTime();
            loadCBXDate();
        }

        public F_BanVe()
        {
            InitializeComponent();
            connection = new DB();
            primaryKey = new DataColumn[1];
        }

        private void DGVVE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DGVVE.CurrentRow.Index;
            txtSDT.Text = DGVVE.Rows[i].Cells[2].Value.ToString();
           
           
        }

        public void LoadDGV()
        {

            try
            {
                string ma = "select * from dbo_BangVeXe";
                var table = connection.GetDataTable(ma, "Ve");
                DGVVE.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
        }


        private void loadCBXTime()
        {
            try
            {
                string selection = "select * from dbo_BangLichTrinh";
                var table = connection.GetDataTable(selection, "dbo_BangLichTrinh");
                cbx_Time.DataSource = table;

                cbx_Time.DisplayMember = "Gio";
            }
            catch
            {
                MessageBox.Show("Không Load được dữ liệu");
            }
        }
        private void loadCBXDate()
        {
            try
            {
                string selection = "select * from dbo_BangLichTrinh";
                var table = connection.GetDataTable(selection, "dbo_BangLichTrinh");
                cbx_Time.DataSource = table;

                cbx_Time.DisplayMember = "NgayKhoiHanh";
            }
            catch
            {
                MessageBox.Show("Không Load được dữ liệu");
            }
        }


    }
}
