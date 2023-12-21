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

namespace PMQL_VeXe
{
    public partial class F_QLVe : Form
    {


        SqlConnection con;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public F_QLVe()
        {
            InitializeComponent();
        }
        public void Alert(string noidung, string name)
        {
            TB_Mess frm = new TB_Mess();

            frm.showAlter(noidung, name);
        }

        public void loadDGVXe()
        {
            cmd = con.CreateCommand();
            cmd.CommandText = "select * from dbo_BangVeXe";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            DGVVe.DataSource = table;
        }


        private void F_Ve_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();

            string[] CheDe = { "Tuần", "Ngày", "Tháng" };

            cbxTheo.Items.AddRange(CheDe);
            cbxTheo.SelectedIndex = 0;
            loadDGVXe();
        }

        

        private void btnTim_Click(object sender, EventArgs e)
        {
            string SDT = txtSDT.Text;
            string maVe = txtMaVe.Text;
            if (SDT!=string.Empty )
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "select * from dbo_BangVeXe where IdKhach='" + SDT + "'";
                adapter.SelectCommand = cmd;
                table.Clear();
                adapter.Fill(table);
                DGVVe.DataSource = table;
            }
            else if (  maVe != string.Empty)
            {
                cmd = con.CreateCommand();
                cmd.CommandText = "select * from dbo_BangVeXe where MaVe ='"+ maVe + "'";
                adapter.SelectCommand = cmd;
                table.Clear();
                adapter.Fill(table);
                DGVVe.DataSource = table;
            }
            else
            {

                MessageBox.Show("Vui Lòng Nhập");
            }
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            loadDGVXe();
         }

        private void btnHuy_Click(object sender, EventArgs e)
        {


            if ((string.IsNullOrEmpty(txtSDT.Text)) || (string.IsNullOrEmpty(txtLichTrinh.Text)))
            {
                MessageBox.Show("Vui Lòng Nhập Thông Tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {

                Random rand = new Random();
                string kytu = "H";
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
                string txt = "Hủy Vé :";
                string Noidung = txt + txtMaVe.Text.Trim();
                try
                {
                    if (txtMaVe.Text != string.Empty && txtMaVe.Text != string.Empty)
                    {
                        DialogResult dlr = MessageBox.Show("Mã Vé :" + txtMaVe.Text.Trim() + "\nHủy Vé   ", "Xác Nhận ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dlr == DialogResult.Yes)
                        {
                            cmd = con.CreateCommand();
                            cmd.CommandText = "delete from dbo_BangVeXe where   IdKhach='" + txtSDT.Text.Trim() + "'and  MaVe ='" + txtMaVe.Text.Trim() + "'" +
                                "insert into dbo_History values('" + Ma + "',N'" + Noidung + "','ad123',GetDate())" +
                                "EXEC CongSoGhe @MaLichTrinh = '" + txtLichTrinh.Text.Trim() + "', @SoLuongCong =" + int.Parse(txtSoLuong.Text.Trim()) + "";

                            adapter.SelectCommand = cmd;
                            table.Clear();
                            adapter.Fill(table);
                            DGVVe.DataSource = table;
                            this.Alert("Hủy Vé", "Thông Báo");
                            loadDGVXe();
                            txtMaVe.Text = string.Empty;    
                        }

                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch { MessageBox.Show("Lỗi Hệ Thống"); }

            }


        }

        private void DGVVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = DGVVe.CurrentRow.Index;

            txtMaVe.Text = DGVVe.Rows[i].Cells[0].Value.ToString();
            txtSDT.Text = DGVVe.Rows[i].Cells[9].Value.ToString();
            txtLichTrinh.Text = DGVVe.Rows[i].Cells[5].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
            txtSDT.Text = null;
            txtLichTrinh.Text=null; 
            txtMaVe.Text=null;  
        }

        private void DTPNgayMua_ValueChanged(object sender, EventArgs e)
        {

            DateTime ngayThang = DateTime.ParseExact(DTPNgayMua.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime gio = DateTime.ParseExact(cbxGio.Text.Trim(), "HH:mm:ss", CultureInfo.InvariantCulture);

            cmd = con.CreateCommand();
            cmd.CommandText = "select * from dbo_BangVeXe where MaVe ='" + ngayThang.ToString("yyyy/MM/dd") + "'";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            DGVVe.DataSource = table;
        }

        private void cbxTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbxTheo.SelectedItem.ToString();
            if (selectedValue == "Ngày")
            {
                try
                {
                    cmd = con.CreateCommand();
                    cmd.CommandText = "EXEC XuatVeTrongNgayHomNay ";
                    adapter.SelectCommand = cmd;
                    table.Clear();
                    adapter.Fill(table);
                    DGVVe.DataSource = table;
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
                    cmd.CommandText = "EXEC XuatBangVeTrong7Ngay  ";
                    adapter.SelectCommand = cmd;
                    table.Clear();
                    adapter.Fill(table);
                    DGVVe.DataSource = table;
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
                    cmd.CommandText = " EXEC XuatVeTrongThangHienTai ";
                    adapter.SelectCommand = cmd;
                    table.Clear();
                    adapter.Fill(table);
                    DGVVe.DataSource = table;
                }
                catch
                {
                    MessageBox.Show("Lỗi Load Data Theo Tháng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
