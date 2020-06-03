﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestAPI.Models
{
    public partial class SWD_SlicingPieProjectContext : DbContext
    {
        public SWD_SlicingPieProjectContext()
        {
        }

        public SWD_SlicingPieProjectContext(DbContextOptions<SWD_SlicingPieProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectDetail> ProjectDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SliceAsset> SliceAssets { get; set; }
        public virtual DbSet<StackHolder> StackHolders { get; set; }
        public virtual DbSet<StackHolerDetail> StackHolerDetails { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TermSlouse> TermSlice { get; set; }
        public virtual DbSet<TypeAsset> TypeAssets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Name=SlicingPie");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.HasIndex(e => e.CompanyName)
                    .HasName("UQ__Company__9BCE05DC9A05BF74")
                    .IsUnique();

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ComapnyIcon).IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Project__Company__60A75C0F");
            });

            modelBuilder.Entity<ProjectDetail>(entity =>
            {
                entity.HasKey(e => new { e.TermId, e.ProjectId })
                    .HasName("PK__ProjectD__566B85A83EAD1531");

                entity.ToTable("ProjectDetail");

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectDetails)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectDe__Proje__619B8048");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.ProjectDetails)
                    .HasForeignKey(d => d.TermId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProjectDe__TermI__628FA481");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.NameRole)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SliceAsset>(entity =>
            {
                entity.HasKey(e => e.AssetId)
                    .HasName("PK__Asset__4349237288ED6B0F");

                entity.ToTable("SliceAsset");

                entity.Property(e => e.AssetId)
                    .HasColumnName("AssetID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AssetStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StackHolerId)
                    .HasColumnName("StackHolerID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.Property(e => e.TimeAsset).HasColumnType("datetime");

                entity.Property(e => e.TypeAssetId).HasColumnName("TypeAssetID");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.SliceAssets)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Asset__ProjectID__5441852A");

                entity.HasOne(d => d.StackHoler)
                    .WithMany(p => p.SliceAssets)
                    .HasForeignKey(d => d.StackHolerId)
                    .HasConstraintName("FK__Asset__CFID__534D60F1");

                entity.HasOne(d => d.Term)
                    .WithMany(p => p.SliceAssets)
                    .HasForeignKey(d => d.TermId)
                    .HasConstraintName("FK__Asset__TermID__5629CD9C");

                entity.HasOne(d => d.TypeAsset)
                    .WithMany(p => p.SliceAssets)
                    .HasForeignKey(d => d.TypeAssetId)
                    .HasConstraintName("FK__Asset__TypeAsset__5535A963");
            });

            modelBuilder.Entity<StackHolder>(entity =>
            {
                entity.HasKey(e => e.StackHolerId)
                    .HasName("PK__StackHol__9069B99F0B09681E");

                entity.ToTable("StackHolder");

                entity.HasIndex(e => e.Shaccount)
                    .HasName("UQ__StackHol__55E5D2B8CBBDFA30")
                    .IsUnique();

                entity.Property(e => e.StackHolerId)
                    .HasColumnName("StackHolerID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Shaccount)
                    .HasColumnName("SHAccount")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Shemail)
                    .HasColumnName("SHEmail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Shname)
                    .HasColumnName("SHName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Shpassword)
                    .HasColumnName("SHPassword")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShphoneNo)
                    .HasColumnName("SHPhoneNo")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.StackHolders)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__StackHold__RoleI__6383C8BA");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.StackHolders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__StackHold__Statu__6477ECF3");
            });

            modelBuilder.Entity<StackHolerDetail>(entity =>
            {
                entity.HasKey(e => new { e.StackHolerId, e.CompanyId })
                    .HasName("PK__StackHol__42B0C85B59285658");

                entity.ToTable("StackHolerDetail");

                entity.Property(e => e.StackHolerId)
                    .HasColumnName("StackHolerID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShemailVerify)
                    .HasColumnName("SHEmailVerify")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Shimage)
                    .HasColumnName("SHImage")
                    .IsUnicode(false);

                entity.Property(e => e.Shjob)
                    .HasColumnName("SHJob")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShmarketSalary).HasColumnName("SHMarketSalary");

                entity.Property(e => e.ShnameForCompany)
                    .HasColumnName("SHNameForCompany")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Shsalary).HasColumnName("SHSalary");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.StackHolerDetails)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StackHole__Compa__656C112C");

                entity.HasOne(d => d.StackHoler)
                    .WithMany(p => p.StackHolerDetails)
                    .HasForeignKey(d => d.StackHolerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__StackHole__Stack__66603565");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TermSlouse>(entity =>
            {
                entity.HasKey(e => e.TermId)
                    .HasName("PK__TermOfCo__410A2E453FBBCDAC");

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermTimeFrom).HasColumnType("datetime");

                entity.Property(e => e.TermTimeTo).HasColumnType("datetime");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TermSlice)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__TermOfCom__Compa__6754599E");
            });

            modelBuilder.Entity<TypeAsset>(entity =>
            {
                entity.ToTable("TypeAsset");

                entity.Property(e => e.TypeAssetId)
                    .HasColumnName("TypeAssetID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MultiplierType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.NameAsset)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
