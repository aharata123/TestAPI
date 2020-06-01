using System;
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

        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TypeAsset> TypeAssets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=SlicingPie");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.ToTable("Asset");

                entity.Property(e => e.AssetId)
                    .HasColumnName("AssetID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeAsset).HasColumnType("datetime");

                entity.Property(e => e.TypeAssetId).HasColumnName("TypeAssetID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Asset__CompanyID__1DE57479");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Asset__MemberID__1ED998B2");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Asset__ProjectID__1FCDBCEB");

                entity.HasOne(d => d.TypeAsset)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.TypeAssetId)
                    .HasConstraintName("FK__Asset__TypeAsset__20C1E124");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.HasIndex(e => e.CompanyName)
                    .HasName("UQ__Company__9BCE05DC7CD13EFB")
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

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.HasIndex(e => e.Account)
                    .HasName("UQ__Member__B0C3AC4656FC7191")
                    .IsUnique();

                entity.Property(e => e.MemberId)
                    .HasColumnName("MemberID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Account)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Job)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Member__CompanyI__21B6055D");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Member__RoleID__22AA2996");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Members)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Member__StatusID__239E4DCF");
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
                    .HasConstraintName("FK__Project__Company__24927208");
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
