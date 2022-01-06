namespace QuanLiDiemHocSinhTHCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DangNhap")]
    public partial class DangNhap
    {
        [Key]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public DangNhap(string TenDangNhap, string Password)
        {
            this.TenDangNhap = TenDangNhap;
            this.Password = Password;
        }
    }
}
