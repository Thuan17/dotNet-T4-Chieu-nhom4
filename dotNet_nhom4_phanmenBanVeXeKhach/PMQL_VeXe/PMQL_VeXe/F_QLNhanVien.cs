using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMQL_VeXe
{
    public partial class F_QLNhanVien : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        string str = "Data Source=DESKTOP-OGP3ROS\\SQLEXPRESS;Initial Catalog=QL_VeXe;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public string MaNhanVien_get = F_LogIn.MaNhanVien;
        public string PassNhanVien_get = F_LogIn.Pass;

        public F_QLNhanVien()
        {
            InitializeComponent();
        }

        private void F_QLNhanVien_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(str);
            con.Open();

            string[] ChucNang = { "Nhân Viên Bán Vé", "Hotline", "Tài Xế", "Quản Lý" };

            cbxChucNang.Items.AddRange(ChucNang);
            cbxChucNang.SelectedIndex = 0;
            loadTenNhanVien();

            LoadDGV();
        }

        public void loadTenNhanVien()
        {


        }
        public void Alert(string noidung, string name)
        {
            TB_Mess frm = new TB_Mess();

            frm.showAlter(noidung, name);
        }
        private void picAvtar_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                picAvtar.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }


        }
        byte[] PathToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();

            //img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            img.Save(m, picAvtar.Image.RawFormat);
            return m.ToArray();
        }

        public void LoadDGV()
        {

            cmd = con.CreateCommand();
            cmd.CommandText = "select MaNhanVien, TenNV, Luong ,Role,CCCD,Img from dbo_NhanVien";
            adapter.SelectCommand = cmd;
            table.Clear();
            adapter.Fill(table);
            kryptonDataGridView1.DataSource = table;

        }

        private void picAvtar_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                picAvtar.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = kryptonDataGridView1.CurrentRow.Index;
            txtMa.Text = kryptonDataGridView1.Rows[i].Cells[0].Value.ToString();
            txtName.Text = kryptonDataGridView1.Rows[i].Cells[1].Value.ToString();
            txtLuong.Text = kryptonDataGridView1.Rows[i].Cells[2].Value.ToString();
            //if (kryptonDataGridView1.SelectedRows[i].Cells[5].Value.ToString() != "")
            //{
            //    MemoryStream m = new MemoryStream((byte[])kryptonDataGridView1.SelectedRows[i].Cells[5].Value);
            //    picAvtar.Image = Image.FromStream(m);
            //}
            //else
            //{
            //    picAvtar.Image = null;
            //}

            txtCCCD.Text = kryptonDataGridView1.Rows[i].Cells[4].Value.ToString();
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            txtMatKhauNhapLai.UseSystemPasswordChar = false;
            btnHien.Visible = true;
            btnAn.Visible = false;
        }

        private void btnHien_Click(object sender, EventArgs e)
        {
            txtMatKhauNhapLai.UseSystemPasswordChar = true;
            btnAn.Visible = true;
            btnHien.Visible = false;
            btnAn.Visible = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadDGV();
            grbMatKhauMoi.Visible = false;
            grbNhapLaiMK.Visible = false;
            btnXacNhan.Visible = false;

        }

        public string MaNhanVienTheoChucNang()
        {
            //string[] ChucNang = { "Nhân Viên Bán Vé", "Hotline", "Tài Xế", "Quản Lý" };
            string selectedValue = cbxChucNang.SelectedItem.ToString();


            Random rand = new Random();

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
            if (selectedValue == "Nhân Viên Bán Vé")
            {
                string kytu = "BV";
                string Ma = kytu + s;
                return Ma;
            }
            else if (selectedValue == "Hotline")
            {
                string kytu = "H";
                string Ma = kytu + s;
                return Ma;
            }
            else if (selectedValue == "Tài Xế")
            {
                string kytu = "TX";
                string Ma = kytu + s;
                return Ma;
            }
            else
            {
                string kytu = "QL";
                string Ma = kytu + s;
                return Ma;
            }
        }
        public string InportRole()
        {
            string selectedValue = cbxChucNang.SelectedItem.ToString();
            if (selectedValue == "Nhân Viên Bán Vé")
            {
                string kytu = "BanVe";
                return kytu;
            }
            else if (selectedValue == "Hotline")
            {
                string kytu = "Hotline";
                return kytu;
            }
            else if (selectedValue == "Tài Xế")
            {
                string kytu = "TaiXe";
                return kytu;
            }
            else
            {
                string kytu = "QuanLy";
                return kytu;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string matKhau1 = txtMatKhau.Text;
            string matKhau2 = txtMatKhauNhapLai.Text;

            try
            {
                if ((string.IsNullOrEmpty(txtName.Text)) || (string.IsNullOrEmpty(txtLuong.Text)))
                {
                    MessageBox.Show("Vui Lòng Không Để Trống ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    if (string.IsNullOrEmpty(cbxChucNang.Text))
                    {
                        MessageBox.Show("Hãy Chọn Chức Năng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtCCCD.Text))
                        {

                            MessageBox.Show("Vui Lòng Nhập CCCD", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if ((string.IsNullOrEmpty(txtMatKhau.Text)) || (string.IsNullOrEmpty(txtMatKhauNhapLai.Text)))
                            {
                                MessageBox.Show("Vui Lòng Nhập Mật Khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                if (matKhau1 != matKhau2)
                                {
                                    MessageBox.Show("Mật Khẩu Không Trùng Nhau", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtMatKhau.Text = null;
                                    txtMatKhauNhapLai.Text = null;

                                }
                                else
                                {
                                    DialogResult dlr = MessageBox.Show("\n\tThêm Nhân Viên   ", "Xác Nhận ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dlr == DialogResult.Yes)
                                    {

                                        DateTime ngayThang = DateTime.ParseExact(DTPNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                        string Tien = txtLuong.Text.Trim();
                                        string thapphan = ".00";
                                        string TienLuong = Tien + thapphan;


                                        decimal soThuc = decimal.Parse(TienLuong.Trim());

                                        cmd = con.CreateCommand();

                                        Random rand = new Random();
                                        string kytu = "NV";
                                        string Ma = "";
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
                                            Ma += list[temp];
                                            list.RemoveAt(temp);

                                        }
                                        byte[] b = PathToByteArray(picAvtar.Image);

                                        cmd.CommandText = @"insert into dbo_NhanVien values('" + Ma.Trim() + "',N'" + txtMatKhau.Text.Trim() + "',N'" + txtName.Text.Trim() + "',@hinh,21,'" + soThuc + "','" + ngayThang.ToString("yyyy/MM/dd") + "','" + InportRole() + "','" + txtCCCD.Text.Trim() + "',GETDATE())";
                                        cmd.Parameters.Add("@hinh", b);
                                        cmd.ExecuteNonQuery();
                                        InsertHistory("Thêm Nhân Viên " + txtMa.Text.Trim() + " Tên Nhân Viên " + txtName.Text.Trim() + " ");

                                        LoadDGV();
                                        grbMatKhauMoi.Visible = false;
                                        grbNhapLaiMK.Visible = false;
                                        btnXacNhan.Visible = false;
                                        this.Alert("Thành Công", "Thêm Nhân Viên ");

                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {


            }
        }


        public void InsertHistory(string NoiDung)
        {

            cmd = con.CreateCommand();
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

            cmd.CommandText = @"insert into dbo_History values('" + Ma + "',N'" + NoiDung + "','ad123',GetDate()) ";
            cmd.ExecuteNonQuery();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string matKhau1 = txtMatKhau.Text;
            string matKhau2 = txtMatKhauNhapLai.Text;
            try
            {

                if ((string.IsNullOrEmpty(txtName.Text)) || (string.IsNullOrEmpty(txtLuong.Text)))
                {
                    MessageBox.Show("Vui Lòng Chọn ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    if (string.IsNullOrEmpty(cbxChucNang.Text))
                    {
                        MessageBox.Show("Hãy Chọn Chức Năng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtCCCD.Text))
                        {

                            MessageBox.Show("Vui Lòng Nhập CCCD", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            DialogResult dlr = MessageBox.Show("\n\tSửa Nhân Viên   ", "Xác Nhận ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dlr == DialogResult.Yes)
                            {

                                DateTime ngayThang = DateTime.ParseExact(DTPNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                string Tien = txtLuong.Text.Trim();
                                string thapphan = ".00";
                                string TienLuong = Tien + thapphan;


                                decimal soThuc = decimal.Parse(txtLuong.Text.Trim());

                                cmd = con.CreateCommand();
                                byte[] b = PathToByteArray(picAvtar.Image);

                                cmd.CommandText = @"update dbo_NhanVien set TenNV=N'" + txtName.Text.Trim() + "' , Luong='" + soThuc + "' , Role='TaiXe',Brithday='" + ngayThang.ToString("yyyy/MM/dd") + "' ,Img=@hinh where MaNhanVien='" + txtMa.Text.Trim() + "' ";
                                cmd.Parameters.Add("@hinh", b);
                                cmd.ExecuteNonQuery();
                                InsertHistory("Cập Nhật Nhân Viên " + txtMa.Text.Trim() + " ");
                                LoadDGV();
                                this.Alert("Thành Công", "Sửa Nhân Viên");

                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi Sửa Nhân Viên ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grbMatKhauMoi.Visible = true;
            grbNhapLaiMK.Visible = true;
            btnXacNhan.Visible = true;
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            LoadDGV();
            grbMatKhauMoi.Visible = false;
            grbNhapLaiMK.Visible = false;
            btnXacNhan.Visible = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }
    }
}
