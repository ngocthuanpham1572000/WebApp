﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Areas.Admin.Data;

namespace WebApp.Migrations
{
    [DbContext(typeof(EcommerceDB))]
    partial class EcommerceDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApp.Areas.Admin.Models.LoaiSP", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaLoai");

                    b.ToTable("LoaiSP");
                });

            modelBuilder.Entity("WebApp.Areas.Admin.Models.Member", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Rule")
                        .HasColumnType("int");

                    b.HasKey("Username");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("WebApp.Areas.Admin.Models.SanPham", b =>
                {
                    b.Property<int>("MaSP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Hinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LoaiSP")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("NgaySX")
                        .HasColumnType("datetime2");

                    b.Property<string>("SN")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("MaSP");

                    b.HasIndex("LoaiSP");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("WebApp.Areas.Admin.Models.SanPham", b =>
                {
                    b.HasOne("WebApp.Areas.Admin.Models.LoaiSP", "LSP")
                        .WithMany()
                        .HasForeignKey("LoaiSP");
                });
#pragma warning restore 612, 618
        }
    }
}
