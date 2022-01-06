namespace QuanLiDiemHocSinhTHCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lop")]
    public partial class Lop
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lop()
        {
            HocSinhs = new HashSet<HocSinh>();
        }

        [Key]
        public int MaLop { get; set; }

        [StringLength(50)]
        public string TenLop { get; set; }

        [StringLength(10)]
        public string Siso { get; set; }

        public int? MaGV { get; set; }

        [StringLength(50)]
        public string HoTenGVCN { get; set; }

        [StringLength(30)]
        public string khoi { get; set; }

        [StringLength(30)]
        public string Namhoc { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }

        public Lop(int MaLop, string TenLop, int MaGv, string Siso, string HoTenGvcn, string Khoi, string Namhoc)
        {
            this.MaLop = MaLop;
            this.TenLop = TenLop;
            this.MaGV = MaGv;
            this.Siso = Siso;
            this.HoTenGVCN = HoTenGvcn;
            this.khoi = Khoi;
            this.Namhoc = Namhoc;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocSinh> HocSinhs { get; set; }
    }
}
