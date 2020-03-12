using Microsoft.EntityFrameworkCore;
using Sharada.StudentMgt.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharada.StudentMgt.Core
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Apply configuration
            modelBuilder.Entity<Student>()
                .HasMany(c => c.Enrollments)
                .WithOne(e => e.Student)
                .IsRequired();

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Student>()
                .HasMany(c => c.Services)
                .WithOne(e => e.Student)
                .IsRequired();

            modelBuilder.Entity<Service>()
                .HasOne(e => e.Student)
                .WithMany(c => c.Services)
                .HasForeignKey(e => e.StudentId);
        }
    }
}
