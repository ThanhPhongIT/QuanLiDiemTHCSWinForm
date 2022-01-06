namespace QuanLiDiemHocSinhTHCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanCong")]
    public partial class PhanCong
    {
        [Key]
        public int IDPC { get; set; }

        public int? MaGV { get; set; }

        [StringLength(50)]
        public string HoTenGV { get; set; }

        [StringLength(30)]
        public string TenMon { get; set; }

        [StringLength(50)]
        public string TenLop { get; set; }

        [StringLength(50)]
        public string HocKy { get; set; }

        [StringLength(50)]
        public string NamHoc { get; set; }

        public virtual GiaoVien GiaoVien { get; set; }
    }
}
