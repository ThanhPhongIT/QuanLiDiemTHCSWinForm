namespace QuanLiDiemHocSinhTHCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiemTongKet")]
    public partial class DiemTongKet
    {
        [Key]
        public int MaHS { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHS { get; set; }

        [Required]
        [StringLength(20)]
        public string NamHoc { get; set; }

        public double TrungBinhhk1 { get; set; }

        public double? TrungBinhhk2 { get; set; }

        public double? TongKetCaNam { get; set; }

        public virtual HocSinh HocSinh { get; set; }
    }
}
