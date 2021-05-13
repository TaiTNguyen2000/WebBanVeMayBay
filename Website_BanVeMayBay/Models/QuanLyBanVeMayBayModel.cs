using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website_BanVeMayBay.Models
{
    public partial class QuanLyBanVeMayBayModel : DbContext
    {
        public QuanLyBanVeMayBayModel()
            : base("name=QuanLyBanVeMayBayEntities")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<HangHangKhong> HangHangKhongs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<SanBay> SanBays { get; set; }
        public virtual DbSet<ChuyenBay> ChuyenBays { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>()
                .Property(e => e.DonGia)
                .IsFixedLength();

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<ChuyenBay>()
                .Property(e => e.GiaBan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChuyenBay>()
                .HasMany(e => e.ChiTietDonHangs)
                .WithRequired(e => e.ChuyenBay)
                .WillCascadeOnDelete(false);
        }
    }
}