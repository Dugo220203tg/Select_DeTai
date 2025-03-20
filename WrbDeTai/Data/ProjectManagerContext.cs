using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WrbDeTai.Data;

public partial class ProjectManagerContext : DbContext
{
    public ProjectManagerContext()
    {
    }

    public ProjectManagerContext(DbContextOptions<ProjectManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-4AS3J3K\\LOCALHOST;Initial Catalog=ProjectManager;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("Account");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.CreatedUser).HasMaxLength(50);
            entity.Property(e => e.ModifiedUser).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.StudentId)
                .HasMaxLength(12)
                .HasColumnName("StudentID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .HasMaxLength(12)
                .HasColumnName("StudentID");
            entity.Property(e => e.Address).HasMaxLength(350);
            entity.Property(e => e.ClassName).HasMaxLength(8);
            entity.Property(e => e.Description).HasMaxLength(350);
            entity.Property(e => e.EmailAddress).HasMaxLength(150);
            entity.Property(e => e.ImageUrl).HasMaxLength(350);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(11);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teacher");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Department).HasMaxLength(250);
            entity.Property(e => e.EmailAddress).HasMaxLength(250);
            entity.Property(e => e.ImageUrl).HasMaxLength(350);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(11);
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Test");

            entity.Property(e => e.Col1)
                .HasMaxLength(150)
                .HasColumnName("col1");
            entity.Property(e => e.Col2)
                .HasMaxLength(250)
                .HasColumnName("col2");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.ToTable("Topic");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.StudentId)
                .HasMaxLength(50)
                .HasColumnName("StudentID");
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.TopicName).HasMaxLength(350);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
