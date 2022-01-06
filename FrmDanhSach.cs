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
    public partial class FrmDanhSach : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public FrmDanhSach()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDanhSach_Load(object sender, EventArgs e)
        {
            //foreach (var item in db.HocSinhs)
            //{
            //    cboTenLop.Items.Remove(item.TenLop);
            //    cboTenLop.Items.Add(item.TenLop);
            //}
            db.Lops.Load();
            cboTenLop.DataSource = db.Lops.Local;
            cboTenLop.DisplayMember = "TenLop";
            cboTenLop.ValueMember = "MaLop";
            HienThiDuLieu();
        }
        private void HienThiDuLieu()
        {
            //Lấy dữ liệu từ bảng Tài Khoản
            var query = from hs in db.HocSinhs
                        select new
                        {
                            ma = hs.MaHS,
                            ten = hs.HoTen,
                            khoa = hs.Khoa,
                            tenL = hs.TenLop,
                            gt = hs.GioiTinh,
                            ns = hs.NgaySinh,
                            sdt = hs.SoDienThoai,
                            qq = hs.QueQuan,
                            ph = hs.PhuHuynh,
                            dcPH = hs.DCPhuHuynh,
                            sdtPH = hs.SDTPhuHuynh,
                            gc = hs.GhiChu,
                        };
            dgvDSHS.Rows.Clear();
            //Hiển thị lên datagrid view
            foreach (var item in query)
            {
                dgvDSHS.Rows.Add(item.ma, item.ten, item.tenL, item.khoa, item.gt, item.ns, item.sdt, item.qq, item.ph, item.dcPH, item.sdtPH, item.gc);
            }
        }

        private void cboTenLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = from hs in db.HocSinhs
                       where hs.TenLop == cboTenLop.Text
                       select new
                       {
                           ma = hs.MaHS,
                           ten = hs.HoTen,
                           khoa = hs.Khoa,
                           tenL = hs.TenLop,
                           gt = hs.GioiTinh,
                           ns = hs.NgaySinh,
                           sdt = hs.SoDienThoai,
                           qq = hs.QueQuan,
                           ph = hs.PhuHuynh,
                           dcPH = hs.DCPhuHuynh,
                           sdtPH = hs.SDTPhuHuynh,
                           gc = hs.GhiChu,
                       };
            dgvDSHS.Rows.Clear();
            //Hiển thị lên datagrid view
            foreach (var items in list)
            {
                dgvDSHS.Rows.Add(items.ma, items.ten, items.tenL, items.khoa, items.gt, items.ns, items.sdt, items.qq, items.ph, items.dcPH, items.sdtPH, items.gc);
            }
        }
        
    }
}
