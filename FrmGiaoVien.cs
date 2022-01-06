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
using QuanLiDiemHocSinhTHCS.Models;

namespace QuanLiDiemHocSinhTHCS
{
    public partial class FrmGiaoVien : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public FrmGiaoVien()
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
            if (cboMaGV.Text == "")
            {
                errorProvider1.SetError(cboMaGV, "Bạn phải nhập chọn mã giáo viên!");
                cboMaGV.Focus();
                return false;
            }
            if (txtTenGV.Text == "")
            {
                errorProvider1.SetError(txtTenGV, "Bạn phải nhập Tên giáo viên!");
                txtTenGV.Focus();
                return false;
            }
            else
            {
                try
                {
                    if (txtTenGV.Text.Length > 50)
                    {
                        errorProvider1.SetError(txtTenGV, "Tên giáo viên tối đa 50 ký tự");
                        txtTenGV.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            if (cboGioitinh.Text == "")
            {
                errorProvider1.SetError(cboGioitinh, "Bạn phải nhập giới tính!");
                cboGioitinh.Focus();
                return false;
            }
            if (txtSDT.Text == "")
            {
                errorProvider1.SetError(txtSDT, "Bạn phải nhập số điện thoại!");
                txtSDT.Focus();
                return false;
            }
            else
            {
                try
                {
                    if (txtSDT.Text.Length > 10 && txtSDT.Text.Length < 10)
                    {
                        errorProvider1.SetError(txtSDT, "Số điện thoại không hợp lệ!");
                        txtSDT.Focus();
                        return false;
                    }
                }
                catch
                {
                }
            }

            if (txtTrinhdo.Text == "")
            {
                errorProvider1.SetError(txtTrinhdo, "Bạn phải nhập Trình độ học vấn!");
                txtTrinhdo.Focus();
                return false;
            }
            else
            {
                try
                {
                    if (txtTrinhdo.Text.Length > 30)
                    {
                        errorProvider1.SetError(txtTrinhdo, "tối đa 30 ký tự");
                        txtTrinhdo.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            //if (cobMonDay.Text == "")
            //{
            //    errorProvider1.SetError(txtGhiChu, "Bạn phải nhập môn dạy!");
            //    cobMonDay.Focus();
            //    return false;
            //}
            //else
            //{
            //    try
            //    {
            //        if (cobMonDay.Text.Length > 30)
            //        {
            //            errorProvider1.SetError(cobMonDay, "tối đa 30 ký tự");
            //            cobMonDay.Focus();
            //            return false;
            //        }
            //    }
            //    catch (Exception ex)
            //    { MessageBox.Show(ex.Message); }
            //}
            if (txtDiaChi.Text == "")
            {
                errorProvider1.SetError(txtDiaChi, "Bạn phải nhập địa chỉ!");
                txtDiaChi.Focus();
                return false;
            }
            else
            {
                try
                {
                    if (txtDiaChi.Text.Length > 120)
                    {
                        errorProvider1.SetError(txtDiaChi, "Địa chỉ tối đa 120 ký tự");
                        txtDiaChi.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            return true;
        }

        private void XoaTB()
        {
            txtTenGV.Clear();
            cboGioitinh.Text = "";
            txtSDT.Clear();
            txtTrinhdo.Clear();
            txtDiaChi.Clear();
            dtpNgaySinh.Value = DateTime.Today;
        }
        #endregion
        private void XoaPC()
        {
            PhanCong xoapc = (from pc in db.PhanCongs
                              where (pc.MaGV == int.Parse(cboMaGV.Text))
                              select pc).FirstOrDefault();
            //Xóa đối tượng khỏi tập hợp 
            db.PhanCongs.Remove(xoapc);
            //Cập nhật thay đổi vào csdl    
            db.SaveChanges();
        }
        private void suaLop()
        {
            Lop sua = (from lh in db.Lops
                       where (lh.MaGV == int.Parse(cboMaGV.Text))
                       select lh).FirstOrDefault();
            //Sửa thông tin 
            sua.MaGV = int.Parse(Tr.Text);
            sua.HoTenGVCN = Tr.Text;
            //Lưu thay đổi vào cơ sở dữ liệu
            db.SaveChanges();
        }
        private void FrmGiaoVien_Load(object sender, EventArgs e)
        {
            db.MonHocs.Load();
            cobMonDay.DataSource = db.MonHocs.Local;
            cobMonDay.DisplayMember = "TenMon";
            cobMonDay.ValueMember = "TenMon";
            HienThiDuLieu();
            DangNhap truyendl = (DangNhap)this.Tag;
            var dn = (from tk in db.TaiKhoans
                      where (tk.TenDangNhap == truyendl.TenDangNhap)
                      select tk).SingleOrDefault();
            if (dn != null)
            {
                cboMaGV.Text = dn.ID.ToString();
            }
            KiemTra();
            XoaTB();
        }
        private void KiemTra()
        {
            DangNhap truyendl = (DangNhap)this.Tag;
            var dn = (from tk in db.TaiKhoans
                      where (tk.TenDangNhap == truyendl.TenDangNhap && tk.Quyen == "Admin")
                      select tk).SingleOrDefault();
            if (dn != null)
            {
                btnSua.Visible = true;
                btnThem.Visible = true;
                btnXoa.Visible = true;
                btnCapNhat.Visible = true;
            }
            else
            {
                btnSua.Visible = true;
                btnThem.Visible = false;
                btnXoa.Visible = false;
                btnCapNhat.Visible = true;
            }
        }
        private void HienThiDuLieu()
        {
            //Lấy dữ liệu từ bảng GiaoVien
            var query = from gv in db.GiaoViens
                        select new
                        {
                            ma = gv.MaGV,
                            ten = gv.HoTen,
                            gt = gv.GioiTinh,
                            ns = gv.NgaySinh,
                            sdt = gv.SoDienThoai,
                            md = gv.MonDay,
                            td = gv.TrinhDo,
                            dc = gv.DiaChi,
                            gc = gv.GhiChu,
                        };
            dgvDSGiaoVien.Rows.Clear();
            //Hiển thị lên datagrid view
            foreach (var item in query)
            {
                dgvDSGiaoVien.Rows.Add(item.ma, item.ten, item.gt, item.ns, item.sdt, item.md, item.td, item.dc, item.gc);
            }
            foreach (var item in db.TaiKhoans)
            {
                cboMaGV.Items.Remove(item.ID);
                cboMaGV.Items.Add(item.ID);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            DangNhap truyendl = (DangNhap)this.Tag;
            var dn = (from tk in db.TaiKhoans
                      join gv in db.GiaoViens on tk.ID equals gv.MaGV
                      where (tk.TenDangNhap == truyendl.TenDangNhap && tk.ID == Convert.ToInt32(cboMaGV.Text))
                      select tk).SingleOrDefault();
            if (dn == null)
            {
                MessageBox.Show("Bạn không thay đổi thông tin giáo viên này", "Thông báo");
            }
            else
            {
                try
                {
                    //Lấy ra giáo viên muốn sửa
                    GiaoVien gvSua = db.GiaoViens.SingleOrDefault(gv => gv.MaGV == int.Parse(cboMaGV.Text));
                    if (ValidData())
                    {
                        //Sửa thông tin của giáo viên
                        gvSua.HoTen = txtTenGV.Text;
                        gvSua.GioiTinh = cboGioitinh.Text;
                        gvSua.NgaySinh = dtpNgaySinh.Value;
                        gvSua.SoDienThoai = txtSDT.Text;
                        gvSua.MonDay = cobMonDay.Text;
                        gvSua.TrinhDo = txtTrinhdo.Text;
                        gvSua.DiaChi = txtDiaChi.Text;
                        gvSua.GhiChu = txtGhiChu.Text;
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
        }

        private void dgvDSGiaoVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    int index = e.RowIndex;
            //    if (index < 0)
            //    {
            //        //MessageBox.Show("Không có dòng được chọn!", "Thông báo");
            //    }
            //    else
            //    {
            //        DataGridViewRow dr = dgvDSGiaoVien.Rows[index];
            //        cboMaGV.Text = dr.Cells[0].Value.ToString();
            //        txtTenGV.Text = dr.Cells[1].Value.ToString();
            //        cboGioitinh.Text = dr.Cells[2].Value.ToString();
            //        dtpNgaySinh.Text = dr.Cells[3].Value.ToString();
            //        txtSDT.Text = dr.Cells[4].Value.ToString();
            //        txtMonDay.Text = dr.Cells[5].Value.ToString();
            //        txtTrinhdo.Text = dr.Cells[6].Value.ToString();
            //        txtDiaChi.Text = dr.Cells[7].Value.ToString();
            //        txtGhiChu.Text = dr.Cells[8].Value.ToString();
            //    }
            //}
            //catch (Exception ex)
            //{ MessageBox.Show(ex.Message); }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa giáo viên này", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //lấy ra giáo viên muốn xóa
                    GiaoVien gvXoa = (from s in db.GiaoViens
                                      where (s.MaGV.ToString() == cboMaGV.Text)
                                      select s).FirstOrDefault();
                    if (gvXoa == null)
                    {
                        MessageBox.Show("Không tìm thấy giáo viên muốn xóa!", "Thông báo");
                    }
                    //Xóa đối tượng khỏi tập hợp
                    //XoaPC();
                    //suaLop();
                    db.GiaoViens.Remove(gvXoa);
                    //Cập nhật thay đổi vào csdl    
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            DangNhap truyendl = (DangNhap)this.Tag;
            var dn = (from gv in db.GiaoViens          
                      where (gv.MaGV.ToString() == cboMaGV.Text)
                      select gv).SingleOrDefault();
            if (dn != null)
            {
                MessageBox.Show("Trùng mã giáo viên!", "Thông báo");
            }
            else
            {
                try
                {
                    if (ValidData())
                    {
                        //Tạo giáo viên mới
                        GiaoVien gv = new GiaoVien();
                        //gán thuộc tính cho đối tượng là dữ liệu user nhập vào
                        gv.MaGV = int.Parse(cboMaGV.Text);
                        gv.HoTen = txtTenGV.Text;
                        gv.GioiTinh = cboGioitinh.Text;
                        gv.NgaySinh = dtpNgaySinh.Value;
                        gv.SoDienThoai = txtSDT.Text;
                        gv.MonDay = cobMonDay.Text;
                        gv.TrinhDo = txtTrinhdo.Text;
                        gv.DiaChi = txtDiaChi.Text;
                        gv.GhiChu = txtGhiChu.Text;
                        //Thêm giaovien mới vào tập hợp GiaoViens của context
                        db.GiaoViens.Add(gv);
                        //Cập nhật lên csdl
                        db.SaveChanges();
                        //Hiển thị lại dữ liệu lên datagrid view
                        HienThiDuLieu();
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DangNhap truyendl = (DangNhap)this.Tag;
            var dn = (from tk in db.TaiKhoans
                      join gv in db.GiaoViens on tk.ID equals gv.MaGV
                      where (tk.TenDangNhap == truyendl.TenDangNhap && tk.ID == int.Parse(cboMaGV.Text))
                      select gv).SingleOrDefault();
            if (dn == null)
            {
                MessageBox.Show("Bạn không thể thêm giáo viên khác!", "Thông báo");
            }
            else
            {
                try
                {
                    if (ValidData())
                    {
                        //Tạo giáo viên mới
                        GiaoVien gvSua = new GiaoVien();
                        foreach (var item in db.GiaoViens)
                        {
                            if (item.MaGV == int.Parse(cboMaGV.Text))
                            {
                                throw new Exception("Đã cập nhật thông tin!");
                            }
                        }
                        //gán thuộc tính cho đối tượng là dữ liệu user nhập vào
                        gvSua.MaGV = int.Parse(cboMaGV.Text);
                        gvSua.HoTen = txtTenGV.Text;
                        gvSua.GioiTinh = cboGioitinh.Text;
                        gvSua.NgaySinh = dtpNgaySinh.Value;
                        gvSua.SoDienThoai = txtSDT.Text;
                        gvSua.MonDay = cobMonDay.Text;
                        gvSua.TrinhDo = txtTrinhdo.Text;
                        gvSua.DiaChi = txtDiaChi.Text;
                        gvSua.GhiChu = txtGhiChu.Text;
                        //Thêm giaovien mới vào tập hợp GiaoViens của context
                        db.GiaoViens.Add(gvSua);
                        //Cập nhật lên csdl
                        db.SaveChanges();
                        //Hiển thị lại dữ liệu lên datagrid view
                        HienThiDuLieu();
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void dgvDSGiaoVien_SelectionChanged(object sender, EventArgs e)
        {
            var dr = dgvDSGiaoVien.CurrentRow;
            cboMaGV.Text = dr.Cells[0].Value.ToString();
            txtTenGV.Text = dr.Cells[1].Value.ToString();
            cboGioitinh.Text = dr.Cells[2].Value.ToString();
            dtpNgaySinh.Text = dr.Cells[3].Value.ToString();
            txtSDT.Text = dr.Cells[4].Value.ToString();
            cobMonDay.Text = dr.Cells[5].Value.ToString();
            txtTrinhdo.Text = dr.Cells[6].Value.ToString();
            txtDiaChi.Text = dr.Cells[7].Value.ToString();
            txtGhiChu.Text = dr.Cells[8].Value.ToString();
        }
    }
}
