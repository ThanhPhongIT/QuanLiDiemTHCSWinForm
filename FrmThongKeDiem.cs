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
    public partial class FrmThongKeDiem : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public FrmThongKeDiem()
        {
            InitializeComponent();
        }

        private void FrmThongKeDiem_Load(object sender, EventArgs e)
        {
            db.Lops.Load();
            cboLop.DataSource = db.Lops.Local;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            db.MonHocs.Load();
            cboMon.DataSource = db.MonHocs.Local;
            cboMon.DisplayMember = "TenMon";
            cboMon.ValueMember = "TenMon";
            var malop = cboLop.SelectedValue.ToString();
            var query = from lop in db.Lops
                        where lop.MaLop.ToString() == malop
                        select new
                        {
                            malop = lop.MaLop,
                            namhoc = lop.Namhoc
                        };

            cboNamHoc.DataSource = query.ToList();
            cboNamHoc.DisplayMember = "namhoc";
            var hk = (from PhanCong in db.PhanCongs
                      where PhanCong.TenLop == cboLop.Text
                      select PhanCong.HocKy).Distinct();

            cbohk.DataSource = hk.ToList();
            hienthiData("Toán");
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            var malop = cboLop.SelectedValue.ToString();
            var query = from lop in db.Lops
                        where lop.MaLop.ToString() == malop
                        select new
                        {
                            malop =lop.MaLop,
                            namhoc =lop.Namhoc
                        };

            cboNamHoc.DataSource = query.ToList();
            cboNamHoc.DisplayMember = "namhoc";
        }

        private void cboMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tenmon = "";
            if (cboLop.Text != null)
            {
                tenmon = "Toán";
            }
            else
            {
                tenmon = cboLop.Text;
            }
            hienthiData(tenmon);
        }

        private void hienthiData(string tenmon)
        {
            var hienthi = (from hs in db.HocSinhs

                           join lop in db.Lops on hs.MaLop equals lop.MaLop
                           join phancong in db.PhanCongs on lop.TenLop equals phancong.TenLop
                           join mon in db.MonHocs on phancong.TenMon equals mon.TenMon
                           where lop.TenLop == cboLop.Text && mon.TenMon == cboMon.Text && phancong.HocKy == cbohk.Text
                           select new
                           {
                               hs.MaHS,
                               hs.HoTen
                           }).Distinct();
            
            var monhoc = (from mh in db.MonHocs
                          where mh.TenMon == tenmon
                          select new
                          {
                              mh.TenMon,
                              mh.MaMon
                          }).FirstOrDefault();
            var listDiem = (from hs in db.HocSinhs
                            join diem in db.Diems on hs.MaHS equals diem.MaHS
                            where diem.MaMon == monhoc.MaMon && diem.HocKy == cbohk.Text && hs.Lop.TenLop == cboLop.Text
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
                                diem.DiemHocKy,
                                diem.DiemTBhocky
                            }).Distinct().ToList();

            if (listDiem.Count > 0)
            {
                for (int rows = 0; rows < listDiem.Count; rows++)
                {
                    if (listDiem[rows] != null)
                    {
                        dgvDiem.Rows[rows].Cells["diemmieng"].Value = listDiem[rows].DiemMieng;
                    }

                    dgvDiem.Rows[rows].Cells["diemmieng2"].Value = listDiem[rows].DiemMiengl2;
                    dgvDiem.Rows[rows].Cells["diem15p1"].Value = listDiem[rows].Diem15phut;
                    dgvDiem.Rows[rows].Cells["diem15p2"].Value = listDiem[rows].Diem15phutl2;
                    dgvDiem.Rows[rows].Cells["diem45p"].Value = listDiem[rows].Diem45phut;
                    dgvDiem.Rows[rows].Cells["diemhk"].Value = listDiem[rows].DiemHocKy;
                    dgvDiem.Rows[rows].Cells["DiemTB"].Value = listDiem[rows].DiemTBhocky;
                    dgvDiem.Rows[rows].Cells["MaHS"].Value = listDiem[rows].MaHS;
                    dgvDiem.Rows[rows].Cells["HoTen"].Value = listDiem[rows].HoTen;
                }
            }
        }
    }
}
