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
    public partial class FrmTimKiem : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public FrmTimKiem()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
            if (rdbMaHS.Checked == true) {
                var query = (from hs in db.HocSinhs
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
                             }).Where(em => em.mahs.ToString().Contains(txtNhap.Text)); 
                dgvHs.Rows.Clear();
                //Hiển thị lên datagrid view
                foreach (var item in query)
                {
                    dgvHs.Rows.Add(item.mahs, item.hoten, item.tenlop, item.ngaysinh, item.gioitinh, item.quequan, item.dienthoai, item.tenPhuHuynh, item.diachi, item.sdtPhuHuynh, item.ghichu);
                }
            }
            else
            {
                var query = (from hs in db.HocSinhs
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
                             }).Where(em => em.hoten.Contains(txtNhap.Text));
                dgvHs.Rows.Clear();
                //Hiển thị lên datagrid view
                foreach (var item in query)
                {
                    dgvHs.Rows.Add(item.mahs, item.hoten, item.tenlop, item.ngaysinh, item.gioitinh, item.quequan, item.dienthoai, item.tenPhuHuynh, item.diachi, item.sdtPhuHuynh, item.ghichu);
                }
            }
            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmTimKiem_Load(object sender, EventArgs e)
        {
            
        }
    }
}
