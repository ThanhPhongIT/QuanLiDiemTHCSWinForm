using QuanLiDiemHocSinhTHCS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiDiemHocSinhTHCS
{
    public partial class FrmHocSinh : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public FrmHocSinh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private string quyen;

        public string Quyen
        {
            get { return quyen; }
            set { quyen = value; }
        }


        private bool ValidData()
        {
            if (txtTenHS.Text == "")
            {
                errorProvider1.SetError(txtTenHS, "Bạn phải nhập tên học sinh!");
                txtTenHS.Focus();
                return false;
            }
            else
            {
                try
                {
                    if (txtTenHS.Text.Length > 50)
                    {
                        errorProvider1.SetError(txtTenHS, "Tên học sinh tối đa 50 ký tự!");
                        txtTenHS.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            return true;
        }

        private void FrmHocSinh_Load(object sender, EventArgs e)
        {
            if (Quyen == "Admin")
            {
                btnSua.Enabled = true;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                btnSua.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
            }
            LoadDataCob();
            HienThiDuLieu();
            XoaTB();
        }

        private void LoadDataCob()
        {
            db.Lops.Load();
            cbTenLop.DataSource = db.Lops.Local;
            cbTenLop.DisplayMember = "TenLop";
            cbTenLop.ValueMember = "MaLop";
        }

        private void HienThiDuLieu()
        {

            //Lấy dữ liệu từ bảng Lop
            var query = from hs in db.HocSinhs
                        join lh in db.Lops on hs.MaLop equals lh.MaLop
                        select new
                        {
                            mahs = hs.MaHS,
                            hoten = hs.HoTen,
                            ngaysinh = hs.NgaySinh,
                            gioitinh = hs.GioiTinh,
                            quequan = hs.QueQuan,
                            tenlop = lh.TenLop,
                            dienthoai = hs.SoDienThoai,
                            tenPhuHuynh = hs.PhuHuynh,
                            sdtPhuHuynh = hs.SDTPhuHuynh,
                            diachi = hs.DCPhuHuynh,
                            ghichu = hs.GhiChu
                        };
            dgvHocSinh.Rows.Clear();
            //Hiển thị lên datagrid view
            foreach (var item in query)
            {
                dgvHocSinh.Rows.Add(item.mahs, item.hoten, item.tenlop,item.ngaysinh, item.gioitinh, item.quequan, item.dienthoai, item.tenPhuHuynh, item.diachi, item.sdtPhuHuynh, item.ghichu);
            }
        }

        private void dgvHocSinh_SelectionChanged(object sender, EventArgs e)
        {
            var dr = dgvHocSinh.CurrentRow;
            txtHS.Text = dr.Cells[0].Value.ToString();
            txtTenHS.Text = dr.Cells[1].Value.ToString();
            cbTenLop.Text = dr.Cells[2].Value.ToString();
            dtNgaySinh.Text = dr.Cells[3].Value.ToString();
            txtQueQuanHS.Text = dr.Cells[5].Value.ToString();
            txtDienThoaiHS.Text = dr.Cells[6].Value.ToString();
            txtTenPH.Text = dr.Cells[7].Value.ToString();
            txtDiaChiHS.Text = dr.Cells[8].Value.ToString();
            txtDienThoaiPH.Text = dr.Cells[9].Value.ToString();
            txtGhiChu.Text = dr.Cells[10].Value.ToString();
            if(dr.Cells[4].Value.ToString() == "Nam")
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HocSinh hsSua = db.HocSinhs.SingleOrDefault(hs => hs.MaHS.ToString() == txtHS.Text);
            if (hsSua == null)
                MessageBox.Show("Không tìm thấy học sinh muốn sửa!");
            else
            {
                try
                {
                    if (ValidData())
                    {
                        hsSua.MaHS = Convert.ToInt32(txtHS.Text);
                        hsSua.HoTen = txtTenHS.Text;
                        hsSua.NgaySinh = dtNgaySinh.Value;
                        if (radNam.Checked == true)
                        {
                            hsSua.GioiTinh = "Nam";
                        }
                        else
                        {
                            hsSua.GioiTinh = "Nữ";
                        }
                        hsSua.QueQuan = txtQueQuanHS.Text;
                        hsSua.MaLop = Convert.ToInt32(cbTenLop.SelectedValue);
                        hsSua.SoDienThoai = txtDienThoaiHS.Text;
                        hsSua.PhuHuynh = txtTenPH.Text;
                        hsSua.SDTPhuHuynh = txtDienThoaiPH.Text;
                        hsSua.DCPhuHuynh = txtDiaChiHS.Text;
                        hsSua.GhiChu = txtGhiChu.Text;
                        db.SaveChanges();
                        //Hiển thị lại dữ liệu lên datagrid view
                        HienThiDuLieu();
                        XoaTB();
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            
        }

        private void XoaTB()
        {
            txtHS.Clear();
            txtTenHS.Clear();
            txtQueQuanHS.Clear();
            txtDienThoaiHS.Clear();
            txtTenPH.Clear();
            txtDiaChiHS.Clear();
            txtDienThoaiPH.Clear();
            txtGhiChu.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
                try
                {
                    if (ValidData())
                    {
                        HocSinh hsMoi = new HocSinh();
                        //hsMoi.MaHS = Convert.ToInt32(txtHS.Text);
                        hsMoi.HoTen = txtTenHS.Text;
                        hsMoi.NgaySinh = dtNgaySinh.Value;
                        if (radNam.Checked == true)
                        {
                            hsMoi.GioiTinh = "Nam";
                        }
                        else
                        {
                            hsMoi.GioiTinh = "Nữ";
                        }
                        hsMoi.QueQuan = txtQueQuanHS.Text;
                        hsMoi.MaLop = Convert.ToInt32(cbTenLop.SelectedValue);
                        hsMoi.SoDienThoai = txtDienThoaiHS.Text;
                        hsMoi.PhuHuynh = txtTenPH.Text;
                        hsMoi.SDTPhuHuynh = txtDienThoaiPH.Text;
                        hsMoi.DCPhuHuynh = txtDiaChiHS.Text;
                        hsMoi.GhiChu = txtGhiChu.Text;
                        //Thêm lớp mới vào tập hợp Lops của context
                        db.HocSinhs.Add(hsMoi);
                        //Cập nhật lên csdl
                        db.SaveChanges();
                        //Hiển thị lại dữ liệu lên datagrid view
                        HienThiDuLieu();
                        XoaTB();
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                HocSinh lhxoa = (from lh in db.HocSinhs
                                 where (lh.MaHS.ToString() == txtHS.Text)
                                 select lh).FirstOrDefault();
                if (lhxoa == null)
                    MessageBox.Show("Không tìm thấy học sinh muốn xóa!");
                else
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa học sinh này!", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                    
                        //Xóa đối tượng khỏi tập hợp 
                        db.HocSinhs.Remove(lhxoa);
                        //Cập nhật thay đổi vào csdl    
                        db.SaveChanges();
                        //Hiển thị lại dữ liệu
                        XoaTB();
                        HienThiDuLieu();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDienThoaiPH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
