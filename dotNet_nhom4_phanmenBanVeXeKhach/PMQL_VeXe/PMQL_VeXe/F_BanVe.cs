using DTO;
using Microsoft.Win32.SafeHandles;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PMQL_VeXe
{
    public partial class F_BanVe : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private void F_BanVe_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();
            LoadDGV();
         
           
            lCBx_TyuenDuong();
            string[] ThanhToan = { "onl", "Quay", "Web" };

            cbxThanhToan.Items.AddRange(ThanhToan);
            cbxThanhToan.SelectedIndex = 0;
        }

        public F_BanVe()
        {
            InitializeComponent();

        }
        public void Alert(string noidung,string name)
        {
            TB_Mess frm = new TB_Mess();

            frm.showAlter(noidung,name);
        }
        private void DGVVE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if (DGVVE.Rows.Count > 0)
                {
                    int i = DGVVE.CurrentRow.Index;

                    txtLoTrinh.Text = DGVVE.Rows[i].Cells[0].Value.ToString();
                    txtMaXe.Text = DGVVE.Rows[i].Cells[3].Value.ToString();
                    decimal giaVe = Convert.ToDecimal(DGVVE.Rows[i].Cells[5].Value);
                    txtGia.Text = giaVe.ToString("#,##0.##");
                    DGVVE.Rows.RemoveAt(DGVVE.Rows.Count - 1);
                }
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu");
            }
           
        }

        public void LoadDGV()
        {
            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "EXEC LayVeSauNgayHomNay ";
                adapter.SelectCommand = cmd;
                table.Clear();
                adapter.Fill(table);
                DGVVE.DataSource = table;
            }
            catch
            {
               //MessageBox.Show("Lỗi Load Data Lên Bảng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Re_Click(object sender, EventArgs e)
        {
            LoadDGV();
           
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string SDT = txtSDT.Text.Trim();
                if (SDT != null)
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "select * from dbo_KhachHang where IdKhach='" + SDT.Trim() + "'";
                    adapter.SelectCommand = cmd;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string ten = reader["TenKhach"].ToString();
                        txtName.Text = ten;
                    }
                    else
                    {
                        txtName.Text = "Không tìm thấy tên";
                    }
                    reader.Close(); 
                }
            }
            catch
            {
                MessageBox.Show("Lỗi Tim Kiếm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            //try
            //{

                if ((string.IsNullOrEmpty(txtLoTrinh.Text)) || (string.IsNullOrEmpty(txtMaXe.Text)))
                {
                    MessageBox.Show("Vui Lòng Chọn ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    if (string.IsNullOrEmpty(txtSDT.Text))
                    {
                        MessageBox.Show("Vui Lòng Nhập Số Điện Thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(cbx_Lich.Text))
                        {
                            MessageBox.Show("Vui Lòng Chọn Tuyến !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                                if (txtSoLuong.Text != null)
                                {

                                        DialogResult dlr = MessageBox.Show( "\n\tMua Vé   ", "Xác Nhận ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (dlr == DialogResult.Yes)
                                        {
                                            decimal soThuc = decimal.Parse(txtGia.Text.Trim());
                                            DateTime ngayThang = DateTime.ParseExact(dtp_Lich.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                            DateTime gio = DateTime.ParseExact(cbxGio.Text.Trim(), "HH:mm:ss", CultureInfo.InvariantCulture);


                                            cmd = con.CreateCommand();

                                            int soluong = int.Parse(txtSoLuong.Text.Trim());
                                            for (int x = 1; x <= soluong; x++)
                                            {

                                                    Random rand = new Random();
                                                    string kytu = "V";
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
                                                cmd.CommandText = @"insert into dbo_BangVeXe values ('" + Ma.Trim() + " ',GETDATE(),'320000.00','1','" + cbxThanhToan.Text.Trim() + "','" + txtLoTrinh.Text.Trim()+ "','" + txtMaXe.Text.Trim() + "','NV003','" + ngayThang.ToString("yyyy/MM/dd") + "','" + txtSDT.Text.Trim() + "','" + gio.ToString("HH:mm:ss") + "')" +
                                                        "EXEC TruSoGhe @MaLichTrinh = '" + txtLoTrinh.Text.Trim() + "', @SoLuongTru =" + int.Parse(txtSoLuong.Text.Trim()) + "";
                                                cmd.ExecuteNonQuery();
                                                 MessageBox.Show("Mua Vé :", "Thông  Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                            }

                                            LoadDGV();
                                            this.Alert("Thành Công", "Bán Vé ");
                                        }
                                        else
                                        {
                                            MessageBox.Show("Đã hủy", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                }
                                else
                                {
                                    MessageBox.Show("Nhập Số Lượng");
                                }
                         }
                    }
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Lỗi Mua Vé", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

      

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            txtSDT.Text = string.Empty; 
            txtLoTrinh.Text = string.Empty;
            txtGia.Text = string.Empty;
            txtName.Text = string.Empty;    
          
        }

        public void lCBx_TyuenDuong()
        {
            try
            {

                SqlCommand sqlCmd = new SqlCommand("select * from dbo_TuyenDuong", con);
                con = new SqlConnection(str);
                con.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {

                    cbx_Lich.Items.Add(sqlReader["TenTuyenDuong"].ToString());
                    cbx_Lich.SelectedIndex = 0;
                }

                sqlReader.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi Đọc Load CBX Tuyến", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public void loadGio()
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("EXEC TimGioSauNgayHomNay   @TenLichTrinh=N'" + cbx_Lich.Text.Trim() + "'", con);
                con = new SqlConnection(str);
                con.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    //cbxGio.Items.Clear();
                    cbxGio.Items.Add(sqlReader["Gio"].ToString());
                    cbxGio.SelectedIndex = 0;
                }
                sqlReader.Close();

            }
            catch
            {
                MessageBox.Show("Lỗi Đọc CBX Tuyến", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void cbx_Lich_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand("EXEC TimGioSauNgayHomNay   @TenLichTrinh=N'" + cbx_Lich.Text.Trim() + "'", con);
                con = new SqlConnection(str);
                con.Open();
                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    //cbxGio.Items.Clear();
                    cbxGio.Items.Add(sqlReader["Gio"].ToString());
                    cbxGio.SelectedIndex = 0;
                }
                sqlReader.Close();

            }
            catch
            {
                MessageBox.Show("Lỗi Đọc CBX Tuyến", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
      
        

        private void cbxGio_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "EXEC TimVeSauNgayHomNay  @Gio='"+cbxGio.Text+"' , @TenLichTrinh=N'"+cbx_Lich.Text+"'";
                adapter.SelectCommand = cmd;
                table.Clear();
                adapter.Fill(table);
                DGVVE.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Lỗi Đọc CBX Giờ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void dtp_Lich_ValueChanged(object sender, EventArgs e)
        {

            DateTime ngayThang = DateTime.ParseExact(dtp_Lich.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //try
            //{
            cmd = con.CreateCommand();
                cmd.CommandText = "EXEC TimVeTheoNgay @TenLichTrinh=N'"+cbx_Lich.Text.Trim()+"' , @NgayKhoiHanh='"+ngayThang.ToString("yyyy/MM/dd")+"'";
                adapter.SelectCommand = cmd;
                table.Clear();
                adapter.Fill(table);
                DGVVE.DataSource = table;
            //loadGio();
            //}
            //catch
            //{
            //    MessageBox.Show("Lỗi Đọc CBX Giờ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}



