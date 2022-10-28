using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdminPanelProject.Models
{
    public partial class AdminPanelProjectContext : DbContext
    {
        public AdminPanelProjectContext()
        {
        }

        public AdminPanelProjectContext(DbContextOptions<AdminPanelProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminInformation> AdminInformations { get; set; } = null!;
        public virtual DbSet<CustomerInformation> CustomerInformations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=AdminPanelProject;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminInformation>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Admin_Information");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CustomerInformation>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Customer_Information");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.BusinessType)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LoanPurpose)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
