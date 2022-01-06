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
    public partial class FrmPhanCongGV : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public FrmPhanCongGV()
        {
            InitializeComponent();
        }
        private void FrmPhanCongGV_Load(object sender, EventArgs e)
        {
            XoaTB();
            HienThiDuLieu();
            HienThiCbo();
            KiemTra();
        }

        #region Kiểm tra dữ liệu người dùng nhập

        private bool ValidData()
        {
            if (cboLop.Text == "")
            {
                errorProvider1.SetError(cboLop, "Bạn phải nhập mã lớp học!");
                cboLop.Focus();
                return false;
            }
            if (cboMon.Text == "")
            {
                errorProvider1.SetError(cboMon, "Bạn phải nhập mã môn học!");
                cboMon.Focus();
                return false;
            }

            if (cboMaGV.Text == "")
            {
                errorProvider1.SetError(cboMaGV, "Bạn phải nhập mã giáo viên!");
                cboMaGV.Focus();
                return false;
            }
            if (txtNamHoc.Text == "")
            {
                errorProvider1.SetError(txtNamHoc, "Bạn phải nhập Năm học!");
                txtNamHoc.Focus();
                return false;
            }
            return true;
        }

        #endregion
        private void KiemTra()
        {
            DangNhap truyendl = (DangNhap)this.Tag;
            var dn = (from tk in db.TaiKhoans
                      where (tk.TenDangNhap == truyendl.TenDangNhap && tk.Quyen == "Admin")
                      select tk).SingleOrDefault();
            if (dn != null)
            {
                btnThem.Visible = true;
                Delete.Visible = true;
            }
            else
            {
                btnThem.Visible = false;
                Delete.Visible = false;
            }
        }
        private void HienThiCbo()
        {
            foreach (var item in db.Lops)
            {
                cboLop.Items.Remove(item.TenLop);
                cboLop.Items.Add(item.TenLop);
            }
            foreach (var item in db.MonHocs)
            {
                cboMon.Items.Remove(item.TenMon);
                cboMon.Items.Add(item.TenMon);
            }
            db.GiaoViens.Load();
            cboMaGV.DataSource = db.GiaoViens.Local;
            cboMaGV.DisplayMember = "HoTen";
            cboMaGV.ValueMember = "MaGV";
            //foreach (var item in db.GiaoViens)
            //{
            //    cboMaGV.Items.Remove(item.MaGV);
            //    cboMaGV.Items.Add(item.MaGV);
            //}
        }
        private void XoaTB()
        {
            cboMaGV.Text = "";
            cboMon.Text = "";
            cboLop.Text = "";
        }
        private void HienThiDuLieu()
        {
            if (radKH1.Checked == true)
            {
                lblhk.Text = "Phân công học kỳ 1:";
                //Lấy dữ liệu từ bảng LGD 
                var query = from lgd in db.PhanCongs
                            where lgd.HocKy == radKH1.Text
                            select new
                            {
                                pc = lgd.IDPC,
                                MaGV = lgd.MaGV,
                                hoten = lgd.HoTenGV,
                                mon = lgd.TenMon,
                                kh1 = lgd.TenLop,
                                nam = lgd.NamHoc,
                            };
                dgvDSLGD.Rows.Clear();
                //Hiển thị lên datagrid view
                foreach (var item in query)
                {
                    dgvDSLGD.Rows.Add(item.pc, item.MaGV, item.hoten, item.mon, item.kh1, item.nam, item.pc);
                }
            }
            else if (radHK2.Checked == true)
            {
                lblhk.Text = "Phân công học kỳ 2:";
                //Lấy dữ liệu từ bảng LGD 
                var query = from lgd in db.PhanCongs
                            where lgd.HocKy == radHK2.Text
                            select new
                            {
                                pc = lgd.IDPC,
                                MaGV = lgd.MaGV,
                                hoten = lgd.HoTenGV,
                                mon = lgd.TenMon,
                                kh2 = lgd.TenLop,
                                nam = lgd.NamHoc,
                            };
                dgvDSLGD.Rows.Clear();
                //Hiển thị lên datagrid view
                foreach (var item in query)
                {
                    dgvDSLGD.Rows.Add(item.pc, item.MaGV, item.hoten, item.mon, item.kh2, item.nam);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Them()
        {
            try
            {
                if (ValidData())
                {
                    //Tạo pc mới
                    PhanCong pcMoi = new PhanCong();
                    //gán thuộc tính cho đối tượng là dữ liệu user nhập vào
                    pcMoi.MaGV = int.Parse(cboMaGV.Text);
                    pcMoi.HoTenGV = cboMaGV.Text;
                    pcMoi.TenMon = cboMon.Text;
                    pcMoi.TenLop = cboLop.Text;
                    if (radKH1.Checked == true)
                    {
                        pcMoi.HocKy = radKH1.Text;
                    }
                    else if (radHK2.Checked == true)
                    {
                        pcMoi.HocKy = radHK2.Text;
                    }
                    pcMoi.NamHoc = txtNamHoc.Text;
                    //Thêm mới 
                    db.PhanCongs.Add(pcMoi);
                    //Cập nhật lên csdl
                    db.SaveChanges();
                    //Hiển thị lại dữ liệu lên datagrid view
                    XoaTB();
                    HienThiDuLieu();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (radKH1.Checked == true)
            {
                PhanCong pcmoi = (from lgd in db.PhanCongs
                                  where (lgd.MaGV == Convert.ToInt32(cboMaGV.SelectedValue) && lgd.TenLop == cboLop.Text && lgd.HocKy == radKH1.Text && lgd.NamHoc == txtNamHoc.Text)
                                  select lgd).FirstOrDefault();
                if (pcmoi != null)
                {
                    MessageBox.Show("Trùng lịch phân công!", "Thông báo");
                }
                else if (pcmoi == null)
                {
                    Them();
                }
            }
            else if (radHK2.Checked == true)
            {
                PhanCong pcmoi = (from lgd in db.PhanCongs
                                  where (lgd.MaGV == Convert.ToInt32(cboMaGV.SelectedValue) && lgd.TenLop == cboLop.Text && lgd.HocKy == radHK2.Text && lgd.NamHoc == txtNamHoc.Text)
                                  select lgd).FirstOrDefault();
                if (pcmoi != null)
                {
                    MessageBox.Show("Trùng lịch phân công!", "Thông báo");
                }
                else if (pcmoi == null)
                {
                    Them();
                }
            }
        }
        private void dgvDSLGD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                //MessageBox.Show("Không có dòng được chọn!", "Thông báo");
            }
            else
            {
                DataGridViewRow dr = dgvDSLGD.Rows[index];
                PC.Text = dr.Cells[0].Value.ToString();
                cboMaGV.Text = dr.Cells[1].Value.ToString();
                cboMon.Text = dr.Cells[3].Value.ToString();
                cboLop.Text = dr.Cells[4].Value.ToString();
                txtNamHoc.Text = dr.Cells[5].Value.ToString();
                if (dgvDSLGD.Columns[e.ColumnIndex].Name == "Delete")
                {
                    try
                    {
                        if (MessageBox.Show("Bạn chắc chắn muốn xóa phân công này", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            PhanCong lgdxoa = (from lgd in db.PhanCongs
                                               where (lgd.IDPC == int.Parse(PC.Text))
                                               select lgd).FirstOrDefault();
                            if (lgdxoa == null) throw new Exception("Không tìm thấy phân công muốn xóa!");
                            //Xóa đối tượng khỏi tập hợp 
                            db.PhanCongs.Remove(lgdxoa);
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
        }

        private void cboMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            MonHoc kt = (from mh in db.MonHocs
                         where (mh.TenMon == cboMon.Text)
                         select mh).SingleOrDefault();
            if (kt != null)
            {
                foreach (var items in db.GiaoViens)
                {
                    cboMaGV.Items.Remove(items.MaGV);
                    if (items.MonDay == kt.TenMon)
                    {
                        cboMaGV.Items.Add(items.MaGV);
                    }
                }
            }
        }
    }
}
