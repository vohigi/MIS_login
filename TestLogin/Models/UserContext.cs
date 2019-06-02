using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestLogin.Models
{
  public class UserContext : DbContext
  {
    public UserContext(DbContextOptions<UserContext> options)
    : base(options)
    { }

    public virtual DbSet<User> User_list { get; set; }
    public virtual DbSet<Declarations> Declarations { get; set; }
    public virtual DbSet<Employees> Employees { get; set; }
    public virtual DbSet<MspList> MspList { get; set; }
    public virtual DbSet<PatientList> PatientList { get; set; }
    public virtual DbSet<UserGroups> UserGroups { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Declarations>(entity =>
      {
        entity.HasKey(e => e.DeclarationId);

        entity.ToTable("declarations", "users");

        entity.HasIndex(e => e.DeclarationId)
                  .HasName("DeclarationID")
                  .IsUnique();

        entity.HasIndex(e => e.EmployeeId)
                  .HasName("EmployeeID");

        entity.HasIndex(e => e.MspId)
                  .HasName("MspID");

        entity.HasIndex(e => e.PatientId)
                  .HasName("PatientID")
                  .IsUnique();

        entity.Property(e => e.DeclarationId)
                  .HasColumnName("DeclarationID")
                  .HasColumnType("int(11)");

        entity.Property(e => e.CreateDate).HasColumnType("date");

        entity.Property(e => e.EmployeeId)
                  .HasColumnName("EmployeeID")
                  .HasColumnType("int(11)");

        entity.Property(e => e.MspId)
                  .HasColumnName("MspID")
                  .HasColumnType("int(11)");

        entity.Property(e => e.PatientId)
                  .HasColumnName("PatientID")
                  .HasColumnType("int(11)");

        entity.Property(e => e.Status)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsUnicode(false);

        entity.HasOne(d => d.Employee)
                  .WithMany(p => p.Declarations)
                  .HasForeignKey(d => d.EmployeeId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("declarations_ibfk_1");

        entity.HasOne(d => d.Msp)
                  .WithMany(p => p.Declarations)
                  .HasForeignKey(d => d.MspId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("declarations_ibfk_2");

        entity.HasOne(d => d.Patient)
                  .WithOne(p => p.Declarations)
                  .HasForeignKey<Declarations>(d => d.PatientId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("declarations_ibfk_3");
      });

      modelBuilder.Entity<Employees>(entity =>
      {
        entity.HasKey(e => e.EmployeeId);

        entity.ToTable("employees", "users");

        entity.HasIndex(e => e.MspId)
                  .HasName("MspID");

        entity.Property(e => e.EmployeeId)
                  .HasColumnName("EmployeeID")
                  .HasColumnType("int(11)")
                  .ValueGeneratedOnAdd();

        entity.Property(e => e.BirthDate).HasColumnType("date");

        entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(24)
                  .IsUnicode(false);

        entity.Property(e => e.EmployeeType).HasColumnType("decimal(1,0)");

        entity.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsUnicode(false);

        entity.Property(e => e.Gender)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsUnicode(false);

        entity.Property(e => e.LastName)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsUnicode(false);

        entity.Property(e => e.MiddleName)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsUnicode(false);

        entity.Property(e => e.MspId)
                  .HasColumnName("MspID")
                  .HasColumnType("int(11)");

        entity.Property(e => e.Phone)
                  .IsRequired()
                  .HasMaxLength(12)
                  .IsUnicode(false);

        entity.Property(e => e.TaxId)
                  .IsRequired()
                  .HasColumnName("TaxID")
                  .HasMaxLength(16)
                  .IsUnicode(false);

        entity.HasOne(d => d.Employee)
                  .WithOne(p => p.Employees)
                  .HasForeignKey<Employees>(d => d.EmployeeId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("employees_ibfk_2");

        entity.HasOne(d => d.Msp)
                  .WithMany(p => p.Employees)
                  .HasForeignKey(d => d.MspId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("employees_ibfk_1");
      });

      modelBuilder.Entity<MspList>(entity =>
      {
        entity.HasKey(e => e.MspId);

        entity.ToTable("msp_list", "users");

        entity.Property(e => e.MspId)
                  .HasColumnName("MspID")
                  .HasColumnType("int(11)");

        entity.Property(e => e.Address)
                  .IsRequired()
                  .HasMaxLength(24)
                  .IsUnicode(false);

        entity.Property(e => e.Edrpou)
                  .IsRequired()
                  .HasMaxLength(10)
                  .IsUnicode(false);

        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(24)
                  .IsUnicode(false);

        entity.Property(e => e.Type)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsUnicode(false);
      });

      modelBuilder.Entity<PatientList>(entity =>
      {
        entity.HasKey(e => e.PatientId);

        entity.ToTable("patient_list", "users");
        entity.HasIndex(e => e.UserID)
                   .HasName("patient_list_ibfk_1").IsUnique();

        entity.Property(e => e.PatientId)
                  .HasColumnName("PatientID")
                  .HasColumnType("int(11)")
                  .ValueGeneratedOnAdd();
        entity.Property(e => e.UserID)
                  .HasColumnName("UserID")
                  .HasColumnType("int(11)");



        entity.Property(e => e.Address)
                  .IsRequired()
                  .HasMaxLength(24)
                  .IsUnicode(false);

        entity.Property(e => e.BirthDate).HasColumnType("date");

        entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(24)
                  .IsUnicode(false);

        entity.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsUnicode(false);

        entity.Property(e => e.Gender)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsUnicode(false);

        entity.Property(e => e.LastName)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsUnicode(false);

        entity.Property(e => e.MiddleName)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsUnicode(false);

        entity.Property(e => e.Phone)
                  .IsRequired()
                  .HasMaxLength(12)
                  .IsUnicode(false);

        entity.Property(e => e.TaxId)
                  .IsRequired()
                  .HasColumnName("TaxID")
                  .HasMaxLength(12)
                  .IsUnicode(false);

        entity.HasOne(d => d.Patient)
                  .WithOne(p => p.PatientList)
                    .HasForeignKey<PatientList>(d => d.UserID)
                    .HasConstraintName("patient_list_ibfk_1");
      });

      modelBuilder.Entity<UserGroups>(entity =>
      {
        entity.HasKey(e => e.UserGroupId);

        entity.ToTable("user_groups", "users");

        entity.Property(e => e.UserGroupId)
                  .HasColumnName("UserGroupID")
                  .HasColumnType("decimal(1,0)");

        entity.Property(e => e.UserGroup)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsUnicode(false);
      });

      modelBuilder.Entity<User>(entity =>
      {
        entity.HasKey(e => e.UserId);

        entity.ToTable("user_list", "users");

        entity.HasIndex(e => e.UserGroup)
                  .HasName("UserGroup");

        entity.Property(e => e.UserId)
                  .HasColumnName("UserID")
                  .HasColumnType("int(11)");

        entity.Property(e => e.Password)
                  .IsRequired()
                  .HasMaxLength(48)
                  .IsUnicode(false);

        entity.Property(e => e.UserGroup).HasColumnType("decimal(1,0)");

        entity.Property(e => e.UserName)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsUnicode(false);

        entity.HasOne(d => d.UserGroupNavigation)
                  .WithMany(p => p.UserList)
                  .HasForeignKey(d => d.UserGroup)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("user_list_ibfk_1");
      });
    }

  }
}
