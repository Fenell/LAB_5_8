using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using A_DAL.DomainModels;

namespace A_DAL.Context
{
    public partial class QLBHContext : DbContext
    {
        public QLBHContext()
        {
        }

        public QLBHContext(DbContextOptions<QLBHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cungcap> Cungcaps { get; set; } = null!;
        public virtual DbSet<Danhmuc> Danhmucs { get; set; } = null!;
        public virtual DbSet<Donhang> Donhangs { get; set; } = null!;
        public virtual DbSet<DonhangChitiet> DonhangChitiets { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<Sanpham> Sanphams { get; set; } = null!;
        public virtual DbSet<Shipper> Shippers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CFK23F4\\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donhang>(entity =>
            {
                entity.HasOne(d => d.Khachhang)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.KhachhangId)
                    .HasConstraintName("FK__Donhang__Khachha__5EBF139D");

                entity.HasOne(d => d.Nhanvien)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.NhanvienId)
                    .HasConstraintName("FK__Donhang__Nhanvie__5FB337D6");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Donhangs)
                    .HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("FK__Donhang__Shipper__60A75C0F");
            });

            modelBuilder.Entity<DonhangChitiet>(entity =>
            {
                entity.HasOne(d => d.Donhang)
                    .WithMany(p => p.DonhangChitiets)
                    .HasForeignKey(d => d.DonhangId)
                    .HasConstraintName("FK__DonhangCh__Donha__5CD6CB2B");

                entity.HasOne(d => d.Sanpham)
                    .WithMany(p => p.DonhangChitiets)
                    .HasForeignKey(d => d.SanphamId)
                    .HasConstraintName("FK__DonhangCh__Sanph__5DCAEF64");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.NhanviennId)
                    .HasName("PK__Nhanvien__92550447D920D1C2");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasOne(d => d.Cungcap)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.CungcapId)
                    .HasConstraintName("FK__Sanpham__Cungcap__5AEE82B9");

                entity.HasOne(d => d.Danhmuc)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.DanhmucId)
                    .HasConstraintName("FK__Sanpham__Danhmuc__5BE2A6F2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
