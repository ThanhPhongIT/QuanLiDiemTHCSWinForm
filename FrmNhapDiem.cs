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
    public partial class FrmNhapDiem : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        private String _mamon;

        public String mamon
        {
            get { return _mamon; }
            set { _mamon = value; }
        }

        private String _tenmon;

        public String tenmon
        {
            get { return _tenmon; }
            set { _tenmon = value; }
        }

        private String _malop;

        public String malop
        {
            get { return _malop; }
            set { _malop = value; }
        }

        private String _tenlop;

        public String tenlop
        {
            get { return _tenlop; }
            set { _tenlop = value; }
        }

        private String _namhoc;

        public String namhoc
        {
            get { return _namhoc; }
            set { _namhoc = value; }
        }

        private String _hocky;

        public String hocky
        {
            get { return _hocky; }
            set { _hocky = value; }
        }
        public FrmNhapDiem()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmNhapDiem_Load(object sender, EventArgs e)
        {
            txtTenMon.Text = tenmon;

            txtTenLop.Text = tenlop;

            txtHocKy.Text = hocky;

            hienthi(/*dgvNhapDiem*/);
        }

        private void hienthi(/*DataGridView dgv*/)
        {

            var query = (from hs in db.HocSinhs

                         join lop in db.Lops on hs.MaLop equals lop.MaLop
                         join phancong in db.PhanCongs on lop.TenLop equals phancong.TenLop
                         join mon in db.MonHocs on phancong.TenMon equals mon.TenMon
                         where lop.TenLop == tenlop && mon.TenMon == tenmon && phancong.HocKy == hocky
                         select new
                         {
                             hs.MaHS,
                             hs.HoTen,
                             lop.Namhoc
                             //diem.DiemMieng,
                             //diem.DiemMiengl2,
                             //diem.Diem15phut,
                             //diem.Diem15phutl2,
                             //diem.Diem45phut,
                             //diem.DiemHocKy

                         }).Distinct();

            dgvNhapDiem.DataSource = query.ToList();
            var monhoc = (from mh in db.MonHocs
                       where mh.TenMon == tenmon
                       select new
                       {
                           mh.TenMon,
                           mh.MaMon
                       }).FirstOrDefault();
            var listDiem = (from hs in db.HocSinhs
                           join diem in db.Diems on hs.MaHS equals diem.MaHS
                           where diem.MaMon == monhoc.MaMon && diem.HocKy == hocky && hs.Lop.TenLop == tenlop
                           select new
                           {
                               hs.MaHS,
                               hs.HoTen,
                               hs.Lop.Namhoc,
                               diem.DiemMieng,
                               diem.DiemMiengl2,
                               diem.Diem15phut,
                               diem.Diem15phutl2,
                               diem.Diem45phut,
                               diem.DiemHocKy
                           }).Distinct().ToList();

            if(listDiem.Count > 0)
            {
                for (int rows = 0; rows < listDiem.Count; rows++)
                {
                    if(listDiem[rows] != null)
                    {
                        dgvNhapDiem.Rows[rows].Cells["diemmieng"].Value = listDiem[rows].DiemMieng;
                    }
                    
                    dgvNhapDiem.Rows[rows].Cells["diemmiengl2"].Value = listDiem[rows].DiemMiengl2;
                    dgvNhapDiem.Rows[rows].Cells["diem15p"].Value = listDiem[rows].Diem15phut;
                    dgvNhapDiem.Rows[rows].Cells["diem15pl2"].Value = listDiem[rows].Diem15phutl2;
                    dgvNhapDiem.Rows[rows].Cells["diem45p"].Value = listDiem[rows].Diem45phut;
                    dgvNhapDiem.Rows[rows].Cells["diemhk"].Value = listDiem[rows].DiemHocKy;
                }
            }
             
        }

        private void dgvNhapDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {



        }



        private void dgvNhapDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvNhapDiem_Enter(object sender, EventArgs e)
        {
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var mon = (from mh in db.MonHocs
                      where mh.TenMon == tenmon
                      select new
                      {
                          mh.TenMon,
                          mh.MaMon
                      }).FirstOrDefault();
            
            for (int rows = 0; rows < dgvNhapDiem.Rows.Count; rows++)
            {
                float diemTBHK = 0;
                int mahs = Convert.ToInt32(dgvNhapDiem.Rows[rows].Cells["MaHS"].Value);
                Diem diemSua = db.Diems.SingleOrDefault(d => d.MaHS == mahs && d.MaMon == mon.MaMon);
                Diem diemMoi = new Diem();
                if (diemSua != null)
                {
                    diemSua.TenHS = dgvNhapDiem.Rows[rows].Cells["hoten"].Value.ToString();
                    if (dgvNhapDiem.Rows[rows].Cells["diemmieng"].Value != null)
                        diemSua.DiemMieng = dgvNhapDiem.Rows[rows].Cells["diemmieng"].Value.ToString();
                    else diemSua.DiemMieng = null;
                    if (dgvNhapDiem.Rows[rows].Cells["diemmiengl2"].Value != null)
                        diemSua.DiemMiengl2 = dgvNhapDiem.Rows[rows].Cells["diemmiengl2"].Value.ToString();
                    else diemSua.DiemMiengl2 = null;
                    if (dgvNhapDiem.Rows[rows].Cells["diem15p"].Value != null)
                        diemSua.Diem15phut = dgvNhapDiem.Rows[rows].Cells["diem15p"].Value.ToString();
                    else diemSua.Diem15phut = null;
                    if (dgvNhapDiem.Rows[rows].Cells["diem15pl2"].Value != null)
                        diemSua.Diem15phutl2 = dgvNhapDiem.Rows[rows].Cells["diem15pl2"].Value.ToString();
                    else diemSua.Diem15phutl2 = null;
                    if (dgvNhapDiem.Rows[rows].Cells["diem45p"].Value != null)
                        diemSua.Diem45phut = dgvNhapDiem.Rows[rows].Cells["diem45p"].Value.ToString();
                    else diemSua.Diem45phut = null;
                    if (dgvNhapDiem.Rows[rows].Cells["diemhk"].Value != null)
                        diemSua.DiemHocKy = dgvNhapDiem.Rows[rows].Cells["diemhk"].Value.ToString();
                    else diemSua.DiemHocKy = null;
                    diemSua.MaHS = Convert.ToInt32(dgvNhapDiem.Rows[rows].Cells["MaHS"].Value);
                    diemSua.MaMon = mon.MaMon;
                    diemSua.HocKy = hocky;
                    diemSua.NamHoc = dgvNhapDiem.Rows[rows].Cells["hoten"].Value.ToString();
                    int c = 0;
                    float dm1, dm2, d15p1, d15p2, d45p, dhk;
                    if (diemSua.Diem45phut != null)
                    {
                        d45p = float.Parse(diemSua.Diem45phut);
                    }
                    else
                        d45p = 0;
                    {

                    }
                    if (diemSua.DiemHocKy != null)
                    {
                        dhk = float.Parse(diemSua.DiemHocKy);
                    }
                    else
                        dhk = 0;
                    {

                    }
                    if (diemSua.DiemMieng != null)
                    {
                        c++;
                        dm1 = float.Parse(diemSua.DiemMieng);
                    }
                    else
                        dm1 = 0;
                    {

                    }
                    if (diemSua.DiemMiengl2 != null)
                    {
                        c++;
                        dm2 = float.Parse(diemSua.DiemMiengl2);
                    }
                    else
                    {
                        dm2 = 0;

                    }
                    if (diemSua.Diem15phut != null)
                    {
                        c++;
                        d15p1 = float.Parse(diemSua.Diem15phut);
                    }
                    else
                    {
                        d15p1 = 0;

                    }
                    if (diemSua.Diem15phutl2 != null)
                    {
                        c++;
                        d15p2 = float.Parse(diemSua.Diem15phutl2);
                    }
                    else
                    {
                        d15p2 = 0;
                    }
                    diemTBHK = (dm1 + dm2 + d15p1 + d15p2 + 2 * d45p + 3 * dhk) / (c + 5);
                    diemSua.DiemTBhocky = diemTBHK;
                    diemSua.DiemTBC = 0;
                    db.SaveChanges();
                }
                else
                {
                    diemMoi.TenHS = dgvNhapDiem.Rows[rows].Cells["hoten"].Value.ToString();
                    if (dgvNhapDiem.Rows[rows].Cells["diemmieng"].Value != null)
                        diemMoi.DiemMieng = dgvNhapDiem.Rows[rows].Cells["diemmieng"].Value.ToString();
                    else diemMoi.DiemMieng = null;
                    if (dgvNhapDiem.Rows[rows].Cells["diemmiengl2"].Value != null)
                        diemMoi.DiemMiengl2 = dgvNhapDiem.Rows[rows].Cells["diemmiengl2"].Value.ToString();
                    else diemMoi.DiemMiengl2 = null;
                    if (dgvNhapDiem.Rows[rows].Cells["diem15p"].Value != null)
                        diemMoi.Diem15phut = dgvNhapDiem.Rows[rows].Cells["diem15p"].Value.ToString();
                    else diemMoi.Diem15phut = null;
                    if (dgvNhapDiem.Rows[rows].Cells["diem15pl2"].Value != null)
                        diemMoi.Diem15phutl2 = dgvNhapDiem.Rows[rows].Cells["diem15pl2"].Value.ToString();
                    else diemMoi.Diem15phutl2 = null;
                    if (dgvNhapDiem.Rows[rows].Cells["diem45p"].Value != null)
                        diemMoi.Diem45phut = dgvNhapDiem.Rows[rows].Cells["diem45p"].Value.ToString();
                    else diemMoi.Diem45phut = null;
                    if (dgvNhapDiem.Rows[rows].Cells["diemhk"].Value != null)
                        diemMoi.DiemHocKy = dgvNhapDiem.Rows[rows].Cells["diemhk"].Value.ToString();
                    else diemMoi.DiemHocKy = null;
                    diemMoi.MaHS = Convert.ToInt32(dgvNhapDiem.Rows[rows].Cells["MaHS"].Value);
                    diemMoi.MaMon = mon.MaMon;
                    diemMoi.HocKy = hocky;
                    diemMoi.NamHoc = dgvNhapDiem.Rows[rows].Cells["hoten"].Value.ToString();
                    int c = 0;
                    float dm1, dm2, d15p1, d15p2, d45p, dhk;
                    if (diemMoi.Diem45phut != null)
                    {
                        d45p = float.Parse(diemMoi.Diem45phut);
                    }
                    else
                        d45p = 0;
                    {

                    }
                    if (diemMoi.DiemHocKy != null)
                    {
                        dhk = float.Parse(diemMoi.DiemHocKy);
                    }
                    else
                        dhk = 0;
                    {

                    }
                    if (diemMoi.DiemMieng != null)
                    {
                        c++;
                        dm1 = float.Parse(diemMoi.DiemMieng);
                    }
                    else
                        dm1 = 0;
                    {

                    }
                    if (diemMoi.DiemMiengl2 != null)
                    {
                        c++;
                        dm2 = float.Parse(diemMoi.DiemMiengl2);
                    }
                    else
                    {
                        dm2 = 0;

                    }
                    if (diemMoi.Diem15phut != null)
                    {
                        c++;
                        d15p1 = float.Parse(diemMoi.Diem15phut);
                    }
                    else
                    {
                        d15p1 = 0;

                    }
                    if (diemMoi.Diem15phutl2 != null)
                    {
                        c++;
                        d15p2 = float.Parse(diemMoi.Diem15phutl2);
                    }
                    else
                    {
                        d15p2 = 0;
                    }

                    diemTBHK = (dm1 + dm2 + d15p1 + d15p2 + 2 * d45p + 3 * dhk) / (c + 5);
                    diemMoi.DiemTBhocky = diemTBHK;
                    diemMoi.DiemTBC = 0;

                    db.Diems.Add(diemMoi);
                    db.SaveChanges();
                }
            }
            MessageBox.Show("Lưu thành công", "Thông báo");
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
