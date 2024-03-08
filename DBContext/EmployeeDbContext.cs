using System;
using System.Collections.Generic;
using Mamsys_Employee_API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mamsys_Employee_API.DBContext
{
    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
        }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
             
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeFirstName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeLastName)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeMiddleName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
