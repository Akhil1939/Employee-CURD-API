using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CURD.Models
{
    public partial class employeeContext : DbContext
    {
        public employeeContext()
        {
        }

        public employeeContext(DbContextOptions<employeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=PCT78\\SQLSERVER2017;Database=employee;User Id=sa;Password=Tatva@123;Trusted_Connection=true;Trust Server Certificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__departme__DCA65974EFEA2B45");

                entity.ToTable("department");

                entity.HasIndex(e => e.DeptName, "UQ__departme__C7D39AE167F80D6E")
                    .IsUnique();

                entity.Property(e => e.DeptId).HasColumnName("dept_id");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("dept_name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__employee__1299A861EE0B093E");

                entity.ToTable("employee");

                entity.HasIndex(e => e.EmpEmail, "UQ__employee__3D542B08E7EAA66F")
                    .IsUnique();

                entity.Property(e => e.EmpId).HasColumnName("emp_id");

                entity.Property(e => e.EmpDeptId).HasColumnName("emp_dept_id");

                entity.Property(e => e.EmpEmail)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("emp_email");

                entity.Property(e => e.EmpMobile).HasColumnName("emp_mobile");

                entity.Property(e => e.EmpName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("emp_name");

                entity.Property(e => e.EmpSalary).HasColumnName("emp_salary");

                entity.HasOne(d => d.EmpDept)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmpDeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_dept_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
