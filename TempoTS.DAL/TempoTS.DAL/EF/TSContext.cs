using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TempoTS.Models.Entities;

namespace TempoTS.DAL.EF
{
    public class TSContext : DbContext
    {
        public TSContext()
        {

        }

        public TSContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Server=(localdb)\mssqllocaldb;Database=TempoTSRemodel;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<Payroll>(entity =>
            {
                entity.Property(e => e.Salary).HasColumnType("money");
                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<TimeClock>(entity =>
            {
                entity.Property(e => e.ClockIn).HasColumnType("datetime");
                entity.Property(e => e.ClockOut).HasColumnType("datetime");
                entity.Property(e => e.InLunch).HasColumnType("datetime");
                entity.Property(e => e.OutLunch).HasColumnType("datetime");
                entity.Property(e => e.TotalHours).HasColumnType("datetime")
                    .HasComputedColumnSql("([ClockOut] - [ClockIn]) - ([OutLunch] - [InLunch])");
            });
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Payroll> Payrolls { get; set; }
        public virtual DbSet<TimeClock> TimeClocks { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
