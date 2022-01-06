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
            var hk = (from PhanCong in db.PhanCongs
                      where PhanCong.TenLop == cboLop.Text
                      select PhanCong.HocKy).Distinct();

            cbohk.DataSource = hk.ToList();
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
        
    }
}
