using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLiDiemHocSinhTHCS.Models
{
    public partial class QLDiemTHCSContext : DbContext
    {
        public QLDiemTHCSContext()
            : base("name=QLDiemTHCSContext")
        {
        }

        public virtual DbSet<DangNhap> DangNhaps { get; set; }
        public virtual DbSet<Diem> Diems { get; set; }
        public virtual DbSet<DiemTongKet> DiemTongKets { get; set; }
        public virtual DbSet<GiaoVien> GiaoViens { get; set; }
        public virtual DbSet<HocSinh> HocSinhs { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<PhanCong> PhanCongs { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DangNhap>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<DangNhap>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Diem>()
                .Property(e => e.MaMon)
                .IsUnicode(false);

            modelBuilder.Entity<Diem>()
                .Property(e => e.NamHoc)
                .IsUnicode(false);

            modelBuilder.Entity<Diem>()
                .Property(e => e.HocKy)
                .IsUnicode(false);

            modelBuilder.Entity<Diem>()
                .Property(e => e.DiemMieng)
                .IsUnicode(false);

            modelBuilder.Entity<Diem>()
                .Property(e => e.DiemMiengl2)
                .IsUnicode(false);

            modelBuilder.Entity<Diem>()
                .Property(e => e.Diem15phut)
                .IsUnicode(false);

            modelBuilder.Entity<Diem>()
                .Property(e => e.Diem15phutl2)
                .IsUnicode(false);

            modelBuilder.Entity<Diem>()
                .Property(e => e.Diem45phut)
                .IsUnicode(false);

            modelBuilder.Entity<Diem>()
                .Property(e => e.DiemHocKy)
                .IsUnicode(false);

            modelBuilder.Entity<DiemTongKet>()
                .Property(e => e.NamHoc)
                .IsUnicode(false);

            modelBuilder.Entity<GiaoVien>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<HocSinh>()
                .Property(e => e.Khoa)
                .IsUnicode(false);

            modelBuilder.Entity<HocSinh>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<HocSinh>()
                .Property(e => e.SDTPhuHuynh)
                .IsUnicode(false);

            modelBuilder.Entity<HocSinh>()
                .HasOptional(e => e.DiemTongKet)
                .WithRequired(e => e.HocSinh);

            modelBuilder.Entity<Lop>()
                .Property(e => e.Siso)
                .IsUnicode(false);

            modelBuilder.Entity<Lop>()
                .Property(e => e.khoi)
                .IsUnicode(false);

            modelBuilder.Entity<Lop>()
                .Property(e => e.Namhoc)
                .IsUnicode(false);

            modelBuilder.Entity<MonHoc>()
                .Property(e => e.MaMon)
                .IsUnicode(false);

            modelBuilder.Entity<PhanCong>()
                .Property(e => e.TenLop)
                .IsUnicode(false);

            modelBuilder.Entity<PhanCong>()
                .Property(e => e.NamHoc)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.Quyen)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasOptional(e => e.GiaoVien)
                .WithRequired(e => e.TaiKhoan);
        }
    }
}
