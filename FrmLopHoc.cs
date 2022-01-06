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
    public partial class FrmLopHoc : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public FrmLopHoc()
        {
            InitializeComponent();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Kiểm tra dữ liệu người dùng nhập

        private bool ValidData()
        {
            if (txtTenLop.Text == "")
            {
                errorProvider1.SetError(txtTenLop, "Bạn phải nhập tên lớp học!");
                txtTenLop.Focus();
                return false;
            }
            else
            {
                try
                {
                    if (txtTenLop.Text.Length > 50)
                    {
                        errorProvider1.SetError(txtTenLop, "Tên lớp tối đa 50 ký tự!");
                        txtTenLop.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            if (txtKhoi.Text == "")
            {
                errorProvider1.SetError(txtKhoi, "Bạn phải nhập niên khóa!");
                txtKhoi.Focus();
                return false;
            }
            if (txtSiSo.Text == "")
            {
                errorProvider1.SetError(txtSiSo, "Bạn phải nhập sĩ số!");
                txtSiSo.Focus();
                return false;
            }
            else
            {
                try
                {
                    int.Parse(txtSiSo.Text);
                    if (int.Parse(txtSiSo.Text) < 0)
                    {
                        errorProvider1.SetError(txtSiSo, "Bạn phải nhập sĩ số >0 !");
                        txtSiSo.Focus();
                        return false;
                    }
                }
                catch
                {
                    errorProvider1.SetError(txtSiSo, "Bạn phải nhập sĩ số là số nguyên!");
                    txtSiSo.Focus();
                    return false;
                }
            }
            if (cboMaGV.Text == "")
            {
                errorProvider1.SetError(cboMaGV, "Bạn phải chọn giáo viên chủ nhiệm!");
                cboMaGV.Focus();
                return false;
            }

            return true;
        }

        #endregion
        private void btnChiTietLopHoc_Click(object sender, EventArgs e)
        {
            if (ValidData())
            {
                FrmChiTietLopHoc chitietlophoc = new FrmChiTietLopHoc();
                Lop mychitietlophoc = new Lop(int.Parse(MaLop.Text), txtTenLop.Text, Convert.ToInt32(cboMaGV.SelectedValue), txtSiSo.Text, cboMaGV.Text, txtKhoi.Text, txtNamhoc.Text);
                //truyền đối tượng 
                chitietlophoc.Tag = mychitietlophoc;
                chitietlophoc.Show();
            }
        }
        private void XoaTB()
        {
            txtTenLop.Clear();
            txtSiSo.Clear();
            txtKhoi.Clear();
            txtNamhoc.Clear();
            cboMaGV.Text = "";
        }

        private void LoadCBGV() 
        {
            db.GiaoViens.Load();
            cboMaGV.DataSource = db.GiaoViens.Local;
            cboMaGV.DisplayMember = "HoTen";
            cboMaGV.ValueMember = "MaGV";
        }
        private void FrmLopHoc_Load(object sender, EventArgs e)
        {
            Kiemtra();
            LoadCBGV();
            XoaTB();
            HienThiDuLieu();
        }
        private void Kiemtra()
        {
            DangNhap truyendl = (DangNhap)this.Tag;
            var dn = (from tk in db.TaiKhoans
                      where (tk.Quyen == "User" && tk.TenDangNhap == truyendl.TenDangNhap)
                      select tk).SingleOrDefault();
            if (dn != null)
            {
                btnSua.Visible = false;
                btnThem.Visible = false;
                Delete.Visible = false;
            }
            else
            {
                btnSua.Visible = true;
                btnThem.Visible = true;
                Delete.Visible = true;
            }
        }
        private void HienThiDuLieu()
        {

            //Lấy dữ liệu từ bảng Lop
            var query = from lh in db.Lops
                        join gv in db.GiaoViens on lh.MaGV equals gv.MaGV
                        select new
                        {
                            malop=lh.MaLop,
                            tenlop = lh.TenLop,
                            ss = lh.Siso,
                            khoi = lh.khoi,
                            MaGVCN = lh.MaGV,
                            tenGVCN = gv.HoTen,
                            namhoc=lh.Namhoc,
                        };
            dgvDSLopHoc.Rows.Clear();
            //Hiển thị lên datagrid view
            foreach (var item in query)
            {
                dgvDSLopHoc.Rows.Add(item.malop,item.tenlop, item.ss, item.MaGVCN, item.tenGVCN,item.khoi,item.namhoc);
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            Lop lh = db.Lops.SingleOrDefault(l => l.TenLop == txtTenLop.Text);
            if (lh != null)
            {
                MessageBox.Show("Lỗi trùng tên lớp học!", "Thông báo");
            }
            else
            {
                try
                {
                    if (ValidData())
                    {
                        //Tạo lớp mới
                        Lop lMoi = new Lop();
                        //gán thuộc tính cho đối tượng là dữ liệu user nhập vào
                        lMoi.TenLop = txtTenLop.Text;
                        lMoi.Siso = txtSiSo.Text;
                        lMoi.khoi = txtKhoi.Text;
                        lMoi.HoTenGVCN = cboMaGV.Text;
                        lMoi.MaGV = Convert.ToInt32(cboMaGV.SelectedValue);
                        lMoi.Namhoc = txtNamhoc.Text;
                        //Thêm lớp mới vào tập hợp Lops của context
                        db.Lops.Add(lMoi);
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
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                //Lấy ra lớp muốn sửa
                Lop lhSua = db.Lops.SingleOrDefault(lh => lh.TenLop == txtTenLop.Text);
                if (lhSua == null)
                    throw new Exception("Không tìm thấy lớp muốn sửa!");
                if (ValidData())
                {
                    //Sửa thông tin của lớp học
                    lhSua.Siso = txtSiSo.Text;
                    lhSua.khoi = txtKhoi.Text;
                    lhSua.HoTenGVCN = cboMaGV.Text;
                    lhSua.MaGV = Convert.ToInt32(cboMaGV.SelectedValue);
                    lhSua.Namhoc = txtNamhoc.Text;
                    //Lưu thay đổi vào cơ sở dữ liệu
                    
                    db.SaveChanges();
                    //Hiển thị lại dữ liệu
                    HienThiDuLieu();
                    XoaTB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void dgvDSLopHoc_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmChiTietLopHoc chitietlophoc = new FrmChiTietLopHoc();
            Lop mychitietlophoc = new Lop(int.Parse(MaLop.Text), txtTenLop.Text, Convert.ToInt32(cboMaGV.SelectedValue), txtSiSo.Text, cboMaGV.Text, txtKhoi.Text, txtNamhoc.Text);
            //truyền đối tượng 
            chitietlophoc.Tag = mychitietlophoc;
            chitietlophoc.Show();
        }

        //lấy dữ liệu DataGridView
        private void dgvDSLopHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvDSLopHoc.Columns[e.ColumnIndex].Name == "Delete")
            {
                try
                {
                    if (MessageBox.Show("Bạn chắc chắn muốn xóa Lớp học này!", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Lop lhxoa = (from lh in db.Lops
                                            where (lh.MaLop.ToString() == MaLop.Text)
                                            select lh).FirstOrDefault();
                        if (lhxoa == null) throw new Exception("Không tìm thấy Lớp học muốn xóa!");
                        //Xóa đối tượng khỏi tập hợp 
                        db.Lops.Remove(lhxoa);
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
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtTenGVCN_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDSLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            var dr = dgvDSLopHoc.CurrentRow;
            MaLop.Text = dr.Cells[0].Value.ToString();
            txtTenLop.Text = dr.Cells[1].Value.ToString();
            txtSiSo.Text = dr.Cells[2].Value.ToString();
            cboMaGV.Text = dr.Cells[3].Value.ToString();
            txtKhoi.Text = dr.Cells[5].Value.ToString();
            txtNamhoc.Text = dr.Cells[6].Value.ToString();
        }
    }
}