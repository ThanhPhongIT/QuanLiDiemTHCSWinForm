
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

    public partial class FrmDiem : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        private string _mamon;

        public string mamon
        {
            get { return _mamon; }
            set { _mamon = value; }
        }

        private int _magv;

        public int magv
        {
            get { return _magv; }
            set { _magv = value; }
        }
        public FrmDiem()
        {
            InitializeComponent();
        }


        private void FrmDiem_Load(object sender, EventArgs e)
        {

            var query = (from phancong in db.PhanCongs
                         where phancong.MaGV == magv
                         join mh in db.MonHocs on phancong.TenMon equals mh.TenMon
                         select new
                         {
                             
                             phancong.TenMon,
                             mh.MaMon
                         }).Distinct();
            var query1 = (from phancong in db.PhanCongs
                         where phancong.MaGV == magv
                         join mh in db.MonHocs on phancong.TenMon equals mh.TenMon
                         select new
                         {
                             phancong.TenLop,
                             
                         }).Distinct();

            cbTenMon.DataSource = query.ToList();
            cbTenMon.DisplayMember = "TenMon";
            cbTenMon.ValueMember = "TenMon";

            cbTenLop.DataSource = query1.ToList();
            cbTenLop.DisplayMember = "TenLop";
            cbTenLop.ValueMember = "TenLop";
            var hk = (from PhanCong in db.PhanCongs
                      where PhanCong.TenLop == cbTenLop.Text
                      select PhanCong.HocKy).Distinct();

            cbHocKy.DataSource = hk.ToList();

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNhapDiem_Click_1(object sender, EventArgs e)
        {
            List<string> mamon1 = (from phancong in db.PhanCongs
                                              where phancong.MaGV == magv
                                              join mh in db.MonHocs on phancong.TenMon equals mh.TenMon
                                              select mh.MaMon).ToList();
            
            FrmNhapDiem nhapdiem = new FrmNhapDiem();
            nhapdiem.tenmon = cbTenMon.SelectedValue.ToString();
            nhapdiem.mamon = mamon1[0].ToString();
             nhapdiem.tenlop = cbTenLop.SelectedValue.ToString();

            nhapdiem.hocky = cbHocKy.SelectedValue.ToString();
            nhapdiem.Show();
        }
    }
}
