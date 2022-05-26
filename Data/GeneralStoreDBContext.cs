using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



    public partial class GeneralStoreDBContext : DbContext
    {
        public GeneralStoreDBContext()
        {
        }

        public GeneralStoreDBContext(DbContextOptions<GeneralStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DevCustomer> DevCustomers { get; set; } = null!;
        public virtual DbSet<DevProduct> DevProducts { get; set; } = null!;
        public virtual DbSet<DevTransaction> DevTransactions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:GeneralStoreDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DevCustomer>(entity =>
            {
                entity.ToTable("devCustomers");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<DevProduct>(entity =>
            {
                entity.ToTable("devProducts");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<DevTransaction>(entity =>
            {
                entity.ToTable("devTransactions");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.DevTransactions)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__devTransa__Custo__3F466844");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DevTransactions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__devTransa__Produ__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

