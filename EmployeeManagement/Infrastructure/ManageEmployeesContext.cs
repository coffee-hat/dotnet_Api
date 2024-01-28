using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EmployeeManagement;

public partial class ManageEmployeesContext : DbContext
{
    public ManageEmployeesContext()
    {
    }

    public ManageEmployeesContext(DbContextOptions<ManageEmployeesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

    public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }

    public virtual DbSet<LeaveRequestStatus> LeaveRequestStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=example;database=ManageEmployees", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.3.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PRIMARY");

            entity.HasIndex(e => e.EmployeeId, "EmployeeId");

            entity.Property(e => e.ArrivingDate).HasColumnType("datetime");
            entity.Property(e => e.DepartureDate).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Attendances_ibfk_3");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PRIMARY");

            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(30);
            entity.Property(e => e.Position).HasMaxLength(150);
        });

        modelBuilder.Entity<EmployeeDepartment>(entity =>
        {
            entity.HasKey(e => e.EmployeeDepartmentId).HasName("PRIMARY");

            entity.HasIndex(e => e.DepartmentId, "DepartmentId");

            entity.HasIndex(e => e.EmployeeId, "EmployeeId");

            entity.HasOne(d => d.Department).WithMany(p => p.EmployeeDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EmployeeDepartments_ibfk_2");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeDepartments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EmployeeDepartments_ibfk_1");
        });

        modelBuilder.Entity<LeaveRequest>(entity =>
        {
            entity.HasKey(e => e.LeaveRequestId).HasName("PRIMARY");

            entity.HasIndex(e => e.EmployeeId, "EmployeeId");

            entity.HasIndex(e => e.LeaveRequestStatusId, "LeaveRequestStatusId");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.LeaveRequests)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("LeaveRequests_ibfk_1");

            entity.HasOne(d => d.LeaveRequestStatus).WithMany(p => p.LeaveRequests)
                .HasForeignKey(d => d.LeaveRequestStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("LeaveRequests_ibfk_2");
        });

        modelBuilder.Entity<LeaveRequestStatus>(entity =>
        {
            entity.HasKey(e => e.LeaveRequestStatusId).HasName("PRIMARY");

            entity.ToTable("LeaveRequestStatus");

            entity.Property(e => e.Status).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
