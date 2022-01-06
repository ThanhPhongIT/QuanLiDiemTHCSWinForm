using QuanLiDiemHocSinhTHCS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiDiemHocSinhTHCS
{
    public partial class FrmMonHoc : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        private string quyen;

        public string Quyen
        {
            get { return quyen; }
            set { quyen = value; }
        }

        #region Kiểm tra dữ liệu người dùng nhập
        private bool ValidData()
        {
            if (txtMaMon.Text == "")
            {
                errorProvider1.SetError(txtMaMon, "Bạn phải nhập chọn mã môn học!");
                txtMaMon.Focus();
                return false;
            }
            if (txtTenMon.Text == "")
            {
                errorProvider1.SetError(txtTenMon, "Bạn phải nhập Tên môn học!");
                txtTenMon.Focus();
                return false;
            }
            if (txtSoTiet.Text == "")
            {
                errorProvider1.SetError(txtSoTiet, "Bạn phải nhập số tiết!");
                txtSoTiet.Focus();
                return false;
            }
            else
            {
                try
                {
                    int sotiet = Convert.ToInt32(txtSoTiet.Text);

                }
                catch
                {
                    errorProvider1.SetError(txtSoTiet, "Bạn phải nhập số tiết là số!");
                    txtSoTiet.Focus();
                    return false;
                }
            }
                return true;
        }
        private void XoaTB()
        {
            txtMaMon.Clear();
            txtTenMon.Text = "";
            txtGhiChu.Clear();
            
        }
        #endregion

        public FrmMonHoc()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HienThiDuLieu()
        {
            var monhoc = db.MonHocs.ToList();
            dgvMonHoc.DataSource = monhoc;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            var monh = (from mh in db.MonHocs
                      where (mh.MaMon == txtMaMon.Text)
                      select mh).SingleOrDefault();
            if (monh != null)
            {
                MessageBox.Show("Trùng mã môn học!", "Thông báo");
            }
            else
            {
                try
                {
                    if (ValidData())
                    {
                        //Tạo giáo viên mới
                        MonHoc monhoc = new MonHoc();
                        //gán thuộc tính cho đối tượng là dữ liệu user nhập vào
                        monhoc.MaMon = txtMaMon.Text;
                        monhoc.TenMon = txtTenMon.Text;
                        monhoc.SoTiet = Convert.ToInt32(txtSoTiet.Text);
                        monhoc.GhiChu = txtGhiChu.Text;
                        
                        //Thêm giaovien mới vào tập hợp GiaoViens của context
                        db.MonHocs.Add(monhoc);
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void FrmMonHoc_Load(object sender, EventArgs e)
        {
            if (Quyen == "Admin")
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
            HienThiDuLieu();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
                try
                {
                    //Lấy ra môn học muốn sửa
                    MonHoc monhocsua = db.MonHocs.SingleOrDefault(mh => mh.MaMon == txtMaMon.Text);
                    if (ValidData())
                    {
                    if(monhocsua == null)
                    {
                        MessageBox.Show("Mã môn học không tồn tại để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        //Sửa thông tin của môn học
                        monhocsua.MaMon = txtMaMon.Text;
                        monhocsua.TenMon = txtTenMon.Text;
                        monhocsua.SoTiet = Convert.ToInt32(txtSoTiet.Text);
                        monhocsua.GhiChu = txtGhiChu.Text;

                        //Lưu thay đổi vào cơ sở dữ liệu
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvMonHoc.SelectedRows
            .OfType<DataGridViewRow>()
            .Where(row => !row.IsNewRow)
            .ToArray();

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                foreach (var row in selectedRows)
                {
                    
                    string masv = row.Cells["mamon"].Value.ToString();
                    var monhoc = db.MonHocs.FirstOrDefault(mh => mh.MaMon == masv);
                    
                    
                    if (monhoc == null)
                    {
                        MessageBox.Show("Không tồn tại môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        db.MonHocs.Remove(monhoc);
                        db.SaveChanges();
                    }
                }

                dgvMonHoc.ClearSelection();
                HienThiDuLieu();
                XoaTB();
            }
        }

        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            var dr = dgvMonHoc.CurrentRow;
            txtMaMon.Text = dr.Cells["mamon"].Value.ToString();
            txtTenMon.Text = dr.Cells["tenmon"].Value.ToString();
            txtSoTiet.Text = dr.Cells["sotiet"].Value.ToString();
            txtGhiChu.Text = dr.Cells["ghichu"].Value.ToString();
        }
    }
}
