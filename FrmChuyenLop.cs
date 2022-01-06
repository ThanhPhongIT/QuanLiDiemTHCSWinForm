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
    public partial class FrmChuyenLop : Form
    {
        QLDiemTHCSContext db = new QLDiemTHCSContext();
        public FrmChuyenLop()
        {
            InitializeComponent();
        }

        private void FrmChuyenLop_Load(object sender, EventArgs e)
        {
            Lop truyendl = (Lop)this.Tag;
            var dn  = from hs in db.HocSinhs
                      where hs.MaLop == truyendl.MaLop
                      select hs;
            cboMaHS.DataSource = dn.ToList();
            cboMaHS.DisplayMember = "HoTen";
            cboMaHS.ValueMember = "MaHS";

            db.Lops.Load();
            List<Lop> lops = new List<Lop>();
            foreach(var lop in db.Lops.Local)
            {
                if(lop.MaLop != truyendl.MaLop)
                {
                    lops.Add(lop);
                }
            }
            cboLop.DataSource = lops;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
        }
        private void btnChuyen_Click(object sender, EventArgs e)
        {
            try
            {
                //Lấy ra học sinh muốn sửa
                HocSinh hsSua = db.HocSinhs.SingleOrDefault(hs => hs.MaHS.ToString() == cboMaHS.SelectedValue.ToString());
                //Sửa thông tin 
                hsSua.MaLop = Convert.ToInt32(cboLop.SelectedValue);
                hsSua.TenLop = cboLop.Text;
                //Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();
                //Hiển thị lại dữ liệu
                btnThoat_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
