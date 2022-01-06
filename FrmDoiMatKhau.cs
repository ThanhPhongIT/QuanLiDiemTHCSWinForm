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
    public partial class FrmDoiMatKhau : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }
        private String _tendangnhap;

        public String tendangnhap
        {
            get { return _tendangnhap; }
            set { _tendangnhap = value; }
        }
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu cũ!", "Thông báo !");
                return;
            }
            List<String> li = (from tk in db.TaiKhoans where tk.TenDangNhap == txtTenDangNhap.Text select tk.Password).ToList();
            if (li.Count != 0 && li[0].ToString() == txtMatKhau.Text)
            {
                if (txtMatKhauMoi.Text == "" || txtNhapLaiMatKhau.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu mới hoặc nhập lại mật khẩu mới!", "Thông báo !");
                    return;
                }
                if (txtMatKhauMoi.Text == txtNhapLaiMatKhau.Text)
                {
                    TaiKhoan tksua = db.TaiKhoans.SingleOrDefault(tk => tk.TenDangNhap == txtTenDangNhap.Text);
                    tksua.Password = txtMatKhauMoi.Text;
                    db.SaveChanges();
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo !");
                }
                else
                {
                    MessageBox.Show("Mật Khẩu mới và nhập lại mật khẩu phải giống nhau!", "Thông báo !");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không chính xác !", "Thông báo !");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = tendangnhap;
        }
    }
}
