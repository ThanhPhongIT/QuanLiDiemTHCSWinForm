namespace QuanLiDiemHocSinhTHCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocSinh")]
    public partial class HocSinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocSinh()
        {
            Diems = new HashSet<Diem>();
        }

        [Key]
        public int MaHS { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(10)]
        public string Khoa { get; set; }

        public int? MaLop { get; set; }

        [StringLength(50)]
        public string TenLop { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(5)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string QueQuan { get; set; }

        [StringLength(10)]
        public string SoDienThoai { get; set; }

        [StringLength(30)]
        public string PhuHuynh { get; set; }

        [StringLength(30)]
        public string DCPhuHuynh { get; set; }

        [StringLength(10)]
        public string SDTPhuHuynh { get; set; }

        [StringLength(30)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diem> Diems { get; set; }

        public virtual DiemTongKet DiemTongKet { get; set; }

        public virtual Lop Lop { get; set; }
    }
}
