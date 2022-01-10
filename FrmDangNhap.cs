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
    public partial class FrmDangNhap : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public FrmDangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            List<String> l = (from tk in db.TaiKhoans where tk.TenDangNhap == txtTenDangNhap.Text select tk.TenDangNhap).ToList();
            List<String> li = (from tk in db.TaiKhoans where tk.TenDangNhap == txtTenDangNhap.Text select tk.Password).ToList();
            List<String> la = (from tk in db.TaiKhoans where tk.TenDangNhap == txtTenDangNhap.Text select tk.Quyen).ToList();
            List<int> id = (from tk in db.TaiKhoans where tk.TenDangNhap == txtTenDangNhap.Text select tk.ID).ToList();
            if (txtTenDangNhap.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản hoặc mật khẩu !", "Thông báo !");
                return;
            }
            if (li.Count != 0 && li[0].ToString() == txtMatKhau.Text)
            {
                DangNhap myMain = new DangNhap(txtTenDangNhap.Text, txtMatKhau.Text);
                FrmMain main = new FrmMain();
                main.taikhoan = l[0].ToString();
                main.quyen = la[0].ToString();
                main.Tag = myMain;
                main.magv = id[0];
                
                main.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác !", "Thông báo !");
            }
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
