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
    public partial class FrmMain : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public static FrmQuanLyTaiKhoan qltaikhoan;
        public static FrmGiaoVien giaovien;
        public static FrmLopHoc lophoc;
        private String _quyen;

        public String quyen
        {
            get { return _quyen; }
            set { _quyen = value; }
        }

        private String _taikhoan;

        public String taikhoan
        {
            get { return _taikhoan; }
            set { _taikhoan = value; }
        }
        private int _magv;

        public int magv
        {
            get { return _magv; }
            set { _magv = value; }
        }
        

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = taikhoan;

            if (quyen != "Admin" || quyen != "User")
            {
                quảnLýTàiKhoảnToolStripMenuItem.Enabled = true;
                quảnLýMônHọcToolStripMenuItem.Enabled = true;
                quảnLýLớpHọcToolStripMenuItem.Enabled = true;
                quảnLýHọcSinhToolStripMenuItem.Enabled = true;
                quảnLíGiáoViênToolStripMenuItem.Enabled = true;
                quảnLýĐiểmToolStripMenuItem.Enabled = true;
                thốngKêĐiểmToolStripMenuItem.Enabled = true;
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDoiMatKhau doimatkhau = new FrmDoiMatKhau();
            doimatkhau.tendangnhap = taikhoan;
            doimatkhau.MdiParent = this;
            doimatkhau.Show();
        }

        private void quảnLýTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap truyendl = (DangNhap)this.Tag;
            var dn = (from tk in db.TaiKhoans
                      where (tk.TenDangNhap == truyendl.TenDangNhap && tk.Quyen == "Admin")
                      select tk).FirstOrDefault();

            if (dn != null)
            {
                if (qltaikhoan == null || qltaikhoan.IsDisposed)
                {
                    qltaikhoan = new FrmQuanLyTaiKhoan();
                    qltaikhoan.MdiParent = this;
                    
                    qltaikhoan.Tag = truyendl;
                    qltaikhoan.Show();
                }
            }
            else
            {
                MessageBox.Show("không có quyên truy cập!", "Thông báo!");
            }
        }

        private void quảnLýHọcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHocSinh hocsinh = new FrmHocSinh();
            hocsinh.MdiParent = this;
            hocsinh.Quyen = quyen;
            hocsinh.Show();
        }

        private void quảnLíGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap truyendl = (DangNhap)this.Tag;
            if (giaovien == null || giaovien.IsDisposed)
            {
                giaovien = new FrmGiaoVien();
                giaovien.MdiParent = this;
                giaovien.TenDangNhap = taikhoan;
                giaovien.Quyen = quyen;
                giaovien.Tag = truyendl;
                giaovien.Show();
            }
        }

        private void quảnLýMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMonHoc monhoc = new FrmMonHoc();
            monhoc.MdiParent = this;
            monhoc.Quyen = quyen;
            monhoc.Show();
        }

        private void quảnLýĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDiem diem = new FrmDiem();
            diem.magv = magv;
            diem.MdiParent = this;
            diem.Show();
        }

        private void quảnLýĐiểmTổngKếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDiemTongKet diemtk = new FrmDiemTongKet();
            diemtk.MdiParent = this;
            diemtk.Show();
        }

        private void xemDanhSáchHọcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDanhSach xemds = new FrmDanhSach();
            xemds.MdiParent = this;
            xemds.Show();
        }

        private void thốngKêĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmThongKeDiem tkdiem = new FrmThongKeDiem();
            tkdiem.MdiParent = this;
            tkdiem.Show();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTimKiem timkiem = new FrmTimKiem();
            timkiem.MdiParent = this;
            timkiem.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
            FrmDangNhap dangnhap = new FrmDangNhap();

        }

        private void quảnLýLớpHọcToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DangNhap truyendl = (DangNhap)this.Tag;
            if (lophoc == null || lophoc.IsDisposed)
            {
                lophoc = new FrmLopHoc();
                lophoc.MdiParent = this;
                lophoc.Tag = truyendl;
                lophoc.Show();
            }
        }

        private void phânCôngGiáoViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap truyendl = (DangNhap)this.Tag;
            FrmPhanCongGV phancong = new FrmPhanCongGV();
            phancong.MdiParent = this;
            phancong.Tag = truyendl;
            phancong.Show();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
