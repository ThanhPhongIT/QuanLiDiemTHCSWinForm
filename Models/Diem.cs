namespace QuanLiDiemHocSinhTHCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Diem")]
    public partial class Diem
    {
        [Key]
        public int IDDiem { get; set; }

        public int? MaHS { get; set; }

        [StringLength(50)]
        public string TenHS { get; set; }

        [StringLength(5)]
        public string MaMon { get; set; }

        [StringLength(20)]
        public string NamHoc { get; set; }

        [StringLength(50)]
        public string HocKy { get; set; }

        [StringLength(5)]
        public string DiemMieng { get; set; }

        [StringLength(5)]
        public string DiemMiengl2 { get; set; }

        [StringLength(5)]
        public string Diem15phut { get; set; }

        [StringLength(5)]
        public string Diem15phutl2 { get; set; }

        [StringLength(5)]
        public string Diem45phut { get; set; }

        [StringLength(5)]
        public string DiemHocKy { get; set; }

        public double? DiemTBhocky { get; set; }

        public double? DiemTBC { get; set; }

        public virtual HocSinh HocSinh { get; set; }

        public virtual MonHoc MonHoc { get; set; }
    }
}
