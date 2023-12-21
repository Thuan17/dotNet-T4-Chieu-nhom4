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
using System.Xml.Linq;

namespace PMQL_VeXe
{
    public partial class F_QLXe : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public F_QLXe()
        {
            InitializeComponent();
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {

        }


        public void Alert(string noidung, string name)
        {
            TB_Mess frm = new TB_Mess();

            frm.showAlter(noidung, name);
        }



        private void F_QLXe_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            loadDGVXe();
            loadCBXMaXe();


            loadCBXTaiXe();
            LoadCBXSoGhe();
        }
        public void loadCacXeKhongCoLich()
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "exec XuatCacXeChuaCoLich";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            DGVXE.DataSource = table;
            txtBienSo.Text = string.Empty;
        }
        public void LoadCBXSoGhe()
        {
            string[] soGhe = { "45", "22", "16" };
            cbxSoGhe.Items.AddRange(soGhe);
            cbxSoGhe.SelectedIndex = 0;
            List<string> Items = new List<string>();
            foreach (var item in cbxSoGhe.Items)
            {
                if (!Items.Contains(item.ToString()))
                {
                    Items.Add(item.ToString());
                }
            }
            cbxSoGhe.Items.Clear();
            cbxSoGhe.Items.AddRange(Items.ToArray());
        }


        public void TimMaXeTrong()
        {
            SqlCommand sqlCmd = new SqlCommand("exec XuatMaTaiXeChuaCoXe", con);
            con = new SqlConnection(str);
            con.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                cbxTaiXe.Items.Add(sqlReader["MaNhanVien"].ToString());
                cbxTaiXe.SelectedIndex = 0;
                List<string> Items = new List<string>();
                foreach (var item in cbxTaiXe.Items)
                {
                    if (!Items.Contains(item.ToString()))
                    {
                        Items.Add(item.ToString());
                    }
                }
                cbxTaiXe.Items.Clear();
                cbxTaiXe.Items.AddRange(Items.ToArray());
                cbxTaiXe.SelectedIndex = 0;

            }
            sqlReader.Close();
        }
        public void loadCBXTaiXe()
        {
            TimMaXeTrong();
        }
        private void loadDGVXe()
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from dbo_Xe";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            DGVXE.DataSource = table;

        }

        private void loadCBXMaXe()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM dbo_Xe", con);
            con = new SqlConnection(str);
            con.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                cbxMaSo.Items.Add(sqlReader["MaXe"].ToString());
                cbxMaSo.SelectedIndex = 0;


            }

            sqlReader.Close();

        }
        private void DGVXE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DGVXE.CurrentRow.Index;
            txtBienSo.Text = DGVXE.Rows[i].Cells[0].Value.ToString();

            cbxMaSo.Text = DGVXE.Rows[i].Cells[2].Value.ToString();
        }

      


        private void btnRes_Click(object sender, EventArgs e)
        {
            loadDGVXe();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtBienSo.Text = string.Empty;
            btnXacNhan.Visible = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtBienSo.Text)) || (string.IsNullOrEmpty(cbxTaiXe.Text)))
            {
                MessageBox.Show("Vui Lòng Chọn ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                if (string.IsNullOrEmpty(cbxSoGhe.Text))
                {
                    MessageBox.Show("Hay Chọn Số Ghế", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult dlr = MessageBox.Show("\n\tThêm Xe   ", "Xác Nhận ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        cmd = con.CreateCommand();
                        cmd.CommandText = @"insert into dbo_Xe values('"+txtBienSo.Text.Trim()+"',"+int.Parse(cbxSoGhe.Text.Trim())+",'"+cbxTaiXe.Text.Trim()+"')";
                        cmd.ExecuteNonQuery();

                       
                        loadDGVXe();
                        TimMaXeTrong();
                        InsertHistory("Thêm Xe Mới:" + txtBienSo.Text.Trim() + " Nhân Viên:" + cbxTaiXe.Text.Trim()+ "");
                        this.Alert("Thành Công", "Thêm Xe Thành Công  ");
                        btnXacNhan.Visible = false; 
                        txtBienSo.Text=string.Empty;
                       
                    }
                }
            }
        }




        private void btnTim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBienSo.Text.Trim()))
            {
                MessageBox.Show("Vui Lòng Nhập Biển Số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "select * from dbo_Xe where MaXe='" + txtBienSo.Text.Trim() + "'";
                SqlDataReader sqlReader = cmd.ExecuteReader();
                if (sqlReader.Read())
                {
                    adapter.SelectCommand = cmd;
                    table.Clear();
                    adapter.Fill(table);
                    DGVXE.DataSource = table;

                }
                else
                {
                    MessageBox.Show("Không Thấy Xe");
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtBienSo.Text)))
            {
                MessageBox.Show("Vui Lòng Nhập Biển Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try 
                {
                    DialogResult dlr = MessageBox.Show("\nXóa Xe   ", "Xác Nhận ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        cmd = con.CreateCommand();
                        cmd.CommandText = "delete dbo_Xe Where MaXe = '" + txtBienSo.Text.Trim() + " '";
                        adapter.SelectCommand = cmd;
                        table.Clear();
                        adapter.Fill(table);
                        DGVXE.DataSource = table;
                        this.Alert("Hủy Xe", "Thông Báo");
                        loadDGVXe();
                        TimMaXeTrong();
                        InsertHistory("Xóa Xe:" + txtBienSo.Text.Trim() + "");
                    }
                }
                catch
                {
                    MessageBox.Show("Xe Đã Có Lịch");
                }
            }
        }

        private void DGVXE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DGVXE.CurrentRow.Index;
            txtBienSo.Text = DGVXE.Rows[i].Cells[0].Value.ToString();
        }


        public void InsertHistory(string NoiDung)
        {

            cmd = con.CreateCommand();
            Random rand = new Random();
            string kytu = "HTXe";
            string s = "";
            int temp = 8;
            string number;
            int num = 8;
            number = num.ToString();
            List<int> list = new List<int>();
            for (int i = 0; i <= 5; i++)
            {
                list.Add(i);
                //list.Add(rand.Next(a));
            }
            //random
            for (int i = 0; i <= 5; i++)
            {
                temp = rand.Next(list.Count);
                s += list[temp];
                list.RemoveAt(temp);

            }

            string Ma = kytu + s;



            cmd.CommandText = @"insert into dbo_History values('" + Ma + "',N'" + NoiDung + "','ad123',GETDATE())";
            cmd.ExecuteNonQuery();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if ((string.IsNullOrEmpty(txtBienSo.Text)))
            {
                MessageBox.Show("Vui Lòng Nhập Biển Số", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult dlr = MessageBox.Show("Cập Nhật Xe   ", "Xác Nhận ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlr == DialogResult.Yes)
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "update dbo_Xe set SoGhe=" + int.Parse(cbxSoGhe.Text.Trim()) + " , MaNhanVien='" + cbxTaiXe.Text.Trim() + "' where MaXe='" + txtBienSo.Text.Trim() + "'";
                    adapter.SelectCommand = cmd;
                    table.Clear();
                    adapter.Fill(table);
                    DGVXE.DataSource = table;
                    this.Alert("Cập Nhật", "Thông Báo");
                    loadDGVXe();
                    TimMaXeTrong();
                    InsertHistory("Cập Nhật Xe:" + txtBienSo.Text.Trim() + "");
                }

            }

        }

      
        private void btnLoadXeTrong_Click(object sender, EventArgs e)
        {
            txtBienSo.Text = string.Empty;  
            loadCacXeKhongCoLich();
            btnEdit.Visible = true;
            btnXoa.Visible = true;
        }
    }
}
