using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiDiemHocSinhTHCS.Models;

namespace QuanLiDiemHocSinhTHCS
{
    public partial class FrmQuanLyTaiKhoan : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public FrmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void XoaGV()
        {
            GiaoVien gvXoa = (from gv in db.GiaoViens
                              where (gv.MaGV == int.Parse(MaID.Text))
                              select gv).FirstOrDefault();
            //Xóa đối tượng khỏi tập hợp 
            db.GiaoViens.Remove(gvXoa);
            //Cập nhật thay đổi vào csdl    
            db.SaveChanges();
        }
        private void FrmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            XoaTB();
            HienThiDuLieu();
        }
        #region Kiểm tra dữ liệu người dùng nhập
        private bool ValidData()
        {
            if (txtTenDN.Text == "")
            {
                errorProvider1.SetError(txtTenDN, "Bạn phải nhập Tên đăng nhập!");
                txtTenDN.Focus();
                return false;
            }
            else
            {
                try
                {
                    if (txtTenDN.Text.Length > 50 && txtTenDN.Text.Length < 5)
                    {
                        errorProvider1.SetError(txtTenDN, "Tên đăng nhập tối thiểu 5 ký tự, tối đa 50 ký tự");
                        txtTenDN.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            if (txtMatKhau.Text == "")
            {
                errorProvider1.SetError(txtMatKhau, "Bạn phải nhập Mật khẩu!");
                txtMatKhau.Focus();
                return false;
            }
            else
            {
                try
                {
                    if (txtMatKhau.Text.Length > 50 && txtMatKhau.Text.Length < 5)
                    {
                        errorProvider1.SetError(txtMatKhau, "Mật khẩu tối thiểu 5 ký tự, tối đa 50 ký tự");
                        txtMatKhau.Focus();
                        return false;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            if (cboQuyen.Text == "")
            {
                errorProvider1.SetError(cboQuyen, "Bạn phải nhập Quyền tài khoản!");
                cboQuyen.Focus();
                return false;
            }
            return true;
        }

        #endregion
        private void XoaTB()
        {
            txtTenDN.Clear();
            txtMatKhau.Clear();
            cboQuyen.Text = " ";
        }
        private void HienThiDuLieu()
        {
            //Lấy dữ liệu từ bảng Tài Khoản
            var query = from tk in db.TaiKhoans
                        select new
                        {
                            id = tk.ID,
                            tdn = tk.TenDangNhap,
                            mk = tk.Password,
                            q = tk.Quyen,
                        };
            dgvQLTaiKhoan.Rows.Clear();
            //Hiển thị lên datagrid view
            foreach (var item in query)
            {
                dgvQLTaiKhoan.Rows.Add(item.id, item.tdn, item.q);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidData())
                {
                    //Tạo tài khoản mới
                    TaiKhoan tkMoi = new TaiKhoan();
                    foreach (var item in db.TaiKhoans)
                    {
                        if (item.TenDangNhap == txtTenDN.Text)
                        {
                            throw new Exception("Lỗi trùng tên đăng nhập");
                        }
                    }
                    //gán thuộc tính cho đối tượng là dữ liệu user nhập vào
                    tkMoi.TenDangNhap = txtTenDN.Text;
                    tkMoi.Password = txtMatKhau.Text;
                    tkMoi.Quyen = cboQuyen.Text;
                    //Thêm tài khoản mới vào tập hợp TaiKhoans của context
                    db.TaiKhoans.Add(tkMoi);
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
        private void btnSua_Click(object sender, EventArgs e)
        {
            var dn = (from tk in db.TaiKhoans
                      where (tk.ID == int.Parse(MaID.Text) && tk.Quyen == "Admin")
                      select tk).FirstOrDefault();
            if (dn != null)
            {
                MessageBox.Show("Bạn không thể sửa tài khoản admin", "Thông báo");
                cboQuyen.Focus();
            }
            else if (txtTenDN.Text == "")
            {
                errorProvider1.SetError(txtTenDN, "chọn tên đăng nhập muốn đổi!");
                txtTenDN.Focus();
            }
            else
            {
                try
                {
                    //Lấy ra Tài khoản muốn sửa
                    TaiKhoan tkSua = db.TaiKhoans.SingleOrDefault(tk => tk.TenDangNhap == txtTenDN.Text);
                    if (tkSua == null)
                        throw new Exception("Không tìm thấy tên đăng nhập muốn sửa!");
                    //Sửa thông tin của tài khoản
                    tkSua.Quyen = cboQuyen.Text;
                    //Lưu thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();
                    //Hiển thị lại dữ liệu
                    HienThiDuLieu();
                    XoaTB();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void dgvQLTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                //MessageBox.Show("Không có dòng chọn", "Thông báo");
            }
            else
            {
                DataGridViewRow dr = dgvQLTaiKhoan.Rows[index];
                MaID.Text = dr.Cells[0].Value.ToString();
                txtTenDN.Text = dr.Cells[1].Value.ToString();
                //txtMatKhau.Text = dr.Cells[2].Value.ToString();
                cboQuyen.Text = dr.Cells[2].Value.ToString();
                if (dgvQLTaiKhoan.Columns[e.ColumnIndex].Name == "Delete")
                {
                    int maxoa = Convert.ToInt32(MaID.Text);
                    var dn = (from tk in db.TaiKhoans
                              where (tk.ID == maxoa && tk.Quyen == "Admin")
                              select tk).FirstOrDefault();
                    if (dn != null)
                    {
                        MessageBox.Show("Bạn không thể xóa tài khoản admin", "Thông báo");
                        cboQuyen.Focus();
                    }
                    else
                    {
                        try
                        {
                            if (MessageBox.Show("Bạn chắc chắn muốn xóa tài khoản này", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                //lấy ra tài khoản muốn xóa
                                TaiKhoan tkXoa = (from tk in db.TaiKhoans
                                                  where (tk.ID == int.Parse(MaID.Text))
                                                  select tk).FirstOrDefault();
                                if (tkXoa == null)
                                {
                                    MessageBox.Show("Không tìm thấy tài khoản muốn xóa", "Thông báo");
                                }
                                else
                                {
                                    //Xóa đối tượng khỏi tập hợp 
                                    XoaGV();
                                    db.TaiKhoans.Remove(tkXoa);
                                    //Cập nhật thay đổi vào csdl    
                                    db.SaveChanges();
                                    //Hiển thị lại dữ liệu
                                    HienThiDuLieu();
                                    XoaTB();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
