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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PMQL_VeXe
{
    public partial class F_QLLichTrinh : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public F_QLLichTrinh()
        {
            InitializeComponent();
        }

        private void F_QLLichTrinh_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            string[] Gia = { "3500.00", "4500.00", "2500.00", "1500.00" };

            cbxGia.Items.AddRange(Gia);
            cbxGia.SelectedIndex = 0;

            string[] CheDe = { "Tuần", "Ngày", "Tháng" };

            cbxTheo.Items.AddRange(CheDe);
            cbxTheo.SelectedIndex = 0;



            LoadDGV();

            loadCBXTuyenXe();
            loadDGVLichTrinh();

        }

        public void Alert(string noidung, string name)
        {
            TB_Mess frm = new TB_Mess();

            frm.showAlter(noidung, name);
        }



        private void loadDGVLichTrinh()
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from dbo_BangLichTrinh";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            DGVLichTrinh.DataSource = table;

        }
        private void LoadCbo_TuyenDUong()
        {
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM dbo_TuyenDuong", con);
            con = new SqlConnection(str);
            con.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {

                cbxTuyenXe.Items.Add(sqlReader["TenTuyenDuong"].ToString());
                cbxTuyenXe.SelectedIndex = 0;
            }

            sqlReader.Close();
        }
        List<string> uniqueItems = new List<string>();
        public void loadCBXTimXeTrong()
        {
            DateTime ngayThang = DateTime.ParseExact(DTPLichTrinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime gio = DateTime.ParseExact(cbxGio.Text.Trim(), "HH:mm:ss", CultureInfo.InvariantCulture);
            SqlCommand sqlCmd = new SqlCommand("exec XuatMaXeNgoaiKhungGio @NgayKhoiHanh='" + ngayThang.ToString("yyyy/MM/dd") + "',@Gio='" + gio.ToString("HH:mm:ss") + "'", con);
            con = new SqlConnection(str);
            con.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
                cbxMaXe.Items.Add(sqlReader["MaXe"].ToString());
               

                foreach (var item in cbxMaXe.Items)
                {
                    if (!uniqueItems.Contains(item.ToString()))
                    {
                        uniqueItems.Add(item.ToString());
                    }
                }
                //cbxGio.Items.Clear();
                cbxMaXe.Items.Clear();
                cbxMaXe.Items.AddRange(uniqueItems.ToArray());


                cbxMaXe.SelectedIndex = 0;
            }
            sqlReader.Close();

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }

        public void LoadDGV()
        {
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "select * from dbo_BangLichTrinh";
                adapter.SelectCommand = cmd;
                table.Clear();
                adapter.Fill(table);
                DGVLichTrinh.DataSource = table;
            }
            catch
            {
                //MessageBox.Show("Lỗi Load Data Lên Bảng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbxGio_SelectedIndexChanged(object sender, EventArgs e)
        {

            loadCBXTimXeTrong();
            
        }

        public void loadCBXTuyenXe() 
        {
            SqlCommand sqlCmd = new SqlCommand("select * from dbo_TuyenDuong", con);
            con = new SqlConnection(str);
            con.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            while (sqlReader.Read())
            {
               
                cbxTuyenXe.Items.Add(sqlReader["TenTuyenDuong"].ToString());
                cbxTuyenXe.SelectedIndex = 0;
            }
        }

        private void DTPLichTrinh_ValueChanged(object sender, EventArgs e)
        {
            string[] Gio = { "08:45:00", "20:25:00", "20:15:00", "21:45:00", "21:50:00" };

            cbxGio.Items.AddRange(Gio);
            List<string> Items = new List<string>();
            foreach (var item in cbxGio.Items)
            {
                if (!Items.Contains(item.ToString()))
                {
                    Items.Add(item.ToString());
                }
            }
            //cbxGio.Items.Clear();
            cbxGio.Items.Clear();
            cbxGio.Items.AddRange(Items.ToArray());
           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           

            if ((string.IsNullOrEmpty(txtMaLichTrinh.Text)))
            {
                MessageBox.Show("Vui Lòng Nhập Thông Tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                try
                {

                    DialogResult dlr = MessageBox.Show("\nHủy Lịch Trình   ", "Xác Nhận ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlr == DialogResult.Yes)
                    {
                        cmd = con.CreateCommand();
                        cmd.CommandText = "delete from dbo_BangLichTrinh where MaBangLichTrinh ='"+ txtMaLichTrinh.Text.Trim()+ "'" ;

                       
                        adapter.SelectCommand = cmd;
                        table.Clear();
                        adapter.Fill(table);
                        DGVLichTrinh.DataSource = table;
                        this.Alert("Hủy Lịch Trình", "Thông Báo");
                        LoadDGV();
                          InsertHistory("Hủy Lịch Trình Mã:" + txtMaLichTrinh.Text.Trim() + " Tuyến Đường:" + cbxTuyenXe.Text.Trim() + "");
                        btnSetting.Visible = false;
                    }

                }
                catch
                {
                    LoadDGV();
                    MessageBox.Show("Không Thể Hủy \n Lịch Trình Đã Có Vé", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DGVLichTrinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DGVLichTrinh.CurrentRow.Index;
            cbxTuyenXe.Text = DGVLichTrinh.Rows[i].Cells[1].Value.ToString();
            txtMaLichTrinh.Text = DGVLichTrinh.Rows[i].Cells[0].Value.ToString();
        }

        private void cbxTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            {
                string selectedValue = cbxTheo.SelectedItem.ToString();
                if (selectedValue == "Ngày")
                {
                    try
                    {
                        cmd = con.CreateCommand();
                        cmd.CommandText = "EXEC XuatLichTrinhTrongNgayHomNay  ";
                        adapter.SelectCommand = cmd;
                        table.Clear();
                        adapter.Fill(table);
                        DGVLichTrinh.DataSource = table;
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi Load Data Theo Ngày", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (selectedValue == "Tuần")
                {
                    try
                    {
                        cmd = con.CreateCommand();
                        cmd.CommandText = "EXEC XuatLichTrinhTrong7Ngay   ";
                        adapter.SelectCommand = cmd;
                        table.Clear();
                        adapter.Fill(table);
                        DGVLichTrinh.DataSource = table;
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi Load Data Theo Tuần", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    try
                    {
                        cmd = con.CreateCommand();
                        cmd.CommandText = " EXEC XuatLichTrinhTrongThangHienTai";
                        adapter.SelectCommand = cmd;
                        table.Clear();
                        adapter.Fill(table);
                        DGVLichTrinh.DataSource = table;
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi Load Data Theo Tháng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch 
            {
                MessageBox.Show("Lỗi Load Data Theo Ngày Tuần Tháng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InsertHistory(string NoiDung)
        {

            cmd = con.CreateCommand();
            Random rand = new Random();
            string kytu = "HLT";
            string s = "";
            int temp = 8;
            string number;
            int num = 8;
            number = num.ToString();
            List<int> list = new List<int>();
            for (int i = 0; i <=5; i++)
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

            cmd.CommandText = @"insert into dbo_History values('"+Ma+"',N'"+NoiDung+"','ad123',GETDATE())";
            cmd.ExecuteNonQuery();

        }
        public void loadLTKhongKhach()
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "exec XuatLichTrinhChuaCoKhach";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            DGVLichTrinh.DataSource = table;
        }

        private void btnLoadLichKhongKhach_Click(object sender, EventArgs e)
        {
            loadLTKhongKhach();
            btnSetting.Visible = true;
        }

        private void btnThemLichTrinh_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(cbxTuyenXe.Text)) || (string.IsNullOrEmpty(cbxGio.Text)))
            {
                MessageBox.Show("Vui Lòng Chọn ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                if (string.IsNullOrEmpty(cbxMaXe.Text))
                {
                    MessageBox.Show("Không Thấy Mã Xe", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (string.IsNullOrEmpty(cbxTuyenXe.Text))
                    {
                        MessageBox.Show("Vui Lòng Chọn Tuyến !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DialogResult dlr = MessageBox.Show("\n\tThêm Lịch Trình   ", "Xác Nhận ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlr == DialogResult.Yes)
                        {

                            DateTime ngayThang = DateTime.ParseExact(DTPLichTrinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            DateTime gio = DateTime.ParseExact(cbxGio.Text.Trim(), "HH:mm:ss", CultureInfo.InvariantCulture);
                            decimal soThuc = decimal.Parse(cbxGia.Text.Trim());

                            cmd = con.CreateCommand();

                            Random rand = new Random();
                            string kytu = "LT";
                            string s = "";
                            int temp = 8;
                            string number;
                            int num = 8;
                            number = num.ToString();
                            List<int> list = new List<int>();
                            for (int i = 0; i <= 7; i++)
                            {
                                list.Add(i);
                                //list.Add(rand.Next(a));
                            }
                            //random
                            for (int i = 0; i <= 7; i++)
                            {
                                temp = rand.Next(list.Count);
                                s += list[temp];
                                list.RemoveAt(temp);

                            }
                            string Ma = kytu + s;
                            cmd.CommandText = @"insert into dbo_BangLichTrinh values('" + Ma + "',N'" + cbxTuyenXe.Text.Trim() + "','" + ngayThang.ToString("yyyy/MM/dd") + " ','" + cbxMaXe.Text.Trim() + "',45,'" + soThuc + "','" + gio.ToString("HH:mm:ss") + "')";
                            cmd.ExecuteNonQuery();
                            uniqueItems.Clear();
                            cbxMaXe.Text = null;
                            LoadDGV();
                            //InsertHistory("Thêm Lịch Trình Mã:" + Ma + " Tuyến Đường:" + cbxTuyenXe.Text.Trim() + "");
                            this.Alert("Thành Công", "Thêm Lịch Trinh Thành Công  ");
                            btnSetting.Visible = false; 
                        }
                        else
                        {
                            MessageBox.Show("Đã hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }
                }
            }
        }
        //xhua xong
        private void btnEdit_Click(object sender, EventArgs e)
        {
           

               
                    if (string.IsNullOrEmpty(cbxTuyenXe.Text))
                    {
                        MessageBox.Show("Vui Lòng Chọn Tuyến !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtMaLichTrinh.Text))
                        {
                            MessageBox.Show("Không Có Mã Lịch Trình !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }   
                        else
                        {

                            DialogResult dlr = MessageBox.Show("\n\tCập Nhật Lịch Trình   ", "Xác Nhận ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlr == DialogResult.Yes)
                            {

                                DateTime ngayThang = DateTime.ParseExact(DTPLichTrinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                               
                                decimal soThuc = decimal.Parse(cbxGia.Text.Trim());

                                cmd = con.CreateCommand();
                                cmd.CommandText = @"update dbo_BangLichTrinh set TenLichTrinh='" + cbxTuyenXe.Text.Trim() + "' ,GiaVe='" + decimal.Parse(cbxGia.Text.Trim()) + "' where MaBangLichTrinh='" + txtMaLichTrinh.Text.Trim() + "'";
                                cmd.ExecuteNonQuery();
                                uniqueItems.Clear();
                                cbxMaXe.Text = null;
                                LoadDGV();
                                InsertHistory("Cập Nhật Lịch Trình Mã:" + txtMaLichTrinh.Text.Trim() + " Tuyến Đường:" + cbxTuyenXe.Text.Trim() + "");
                                this.Alert("Thành Công", "Đã Cập Nhật  ");
                            }
                            else
                            {
                                MessageBox.Show("Đã Hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }    
                    }
                
            
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            txtMaLichTrinh.Text = string.Empty;
            loadLTKhongKhach();
            btnThemLichTrinh.Visible = true;
            btnXoa.Visible = true;
            btnEdit.Visible = true;
        }

        private void btnTimMa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLichTrinh.Text))
            {
                MessageBox.Show("Vui Lòn Nhập Mã ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "select * from dbo_BangLichTrinh where MaBangLichTrinh='" + txtMaLichTrinh.Text.Trim() + "'";
                adapter.SelectCommand = cmd;
                table.Clear();
                adapter.Fill(table);
                DGVLichTrinh.DataSource = table;
            }   
        }
    }
}
