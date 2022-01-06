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
    public partial class FrmChiTietLopHoc : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public FrmChiTietLopHoc()
        {
            InitializeComponent();
        }
        private void sohocsinh()
        {
            Lop truyendl = (Lop)this.Tag;
            var dn = (from hs in db.HocSinhs
                      where hs.TenLop == truyendl.TenLop
                      select hs).Count();
            txtSiSo.Text = dn.ToString();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void FrmChiTietLopHoc_Load(object sender, EventArgs e)
        {
            Lop truyendl = (Lop)this.Tag;
            //hiển thị lên các text box
            MaLop.Text = truyendl.MaLop.ToString();
            txtTenLop.Text = truyendl.TenLop;
            txtMaGV.Text = truyendl.MaGV.ToString();
            txtGVCN.Text = truyendl.HoTenGVCN;
            HienThiDuLieu();
            sohocsinh();
        }
        private void HienThiDuLieu()
        {
            Lop truyendl = (Lop)this.Tag;
            //Lấy dữ liệu từ bảng HocSinh
            var query = from hs in db.HocSinhs
                        where hs.MaLop == truyendl.MaLop
                        select new
                        {
                            MãHs = hs.MaHS,
                            TênHọcSinh = hs.HoTen,
                            GiớiTính = hs.GioiTinh,
                            NgàySinh = hs.NgaySinh,
                            ĐịaChỉ = hs.QueQuan,
                            sốđiệnthoại = hs.SoDienThoai,
                            Phụhuynh = hs.PhuHuynh,
                            ĐịachỉPH = hs.DCPhuHuynh,
                            Sdt = hs.SDTPhuHuynh,
                            Ghichú = hs.GhiChu,
                        };
            //Hiển thị lên datagrid view
            dgvDSLop.DataSource = query.ToList();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Lop truyendl = (Lop)this.Tag;
            FrmChuyenLop chuyenlop = new FrmChuyenLop();
            //truyền đối tượng 
            chuyenlop.Tag = truyendl;
            chuyenlop.Show();
            HienThiDuLieu();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
