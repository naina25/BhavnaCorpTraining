using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Assessment7.Models;

namespace Assessment7.Data
{
    public partial class cabContext : DbContext
    {
        public cabContext()
        {
        }

        public cabContext(DbContextOptions<cabContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Finance> Finance { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Maintainance> Maintainance { get; set; }
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Travel> Travel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);initial catalog=cab; trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
