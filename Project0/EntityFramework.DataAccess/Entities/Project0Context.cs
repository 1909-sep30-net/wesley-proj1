using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFramework.DataAccess.Entities
{
    public partial class Project0Context : DbContext
    {
        public Project0Context()
        {
        }

        public Project0Context(DbContextOptions<Project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Merchandise> Merchandise { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderInfo> OrderInfo { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "Proj0");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.MerchId, e.LocationId })
                    .HasName("PK_Inven");

                entity.ToTable("Inventory", "Proj0");

                entity.Property(e => e.MerchId).HasColumnName("MerchID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Locat__54CB950F");

                entity.HasOne(d => d.Merch)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.MerchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Merch__53D770D6");
            });

            modelBuilder.Entity<Merchandise>(entity =>
            {
                entity.ToTable("Merchandise", "Proj0");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.MerchId })
                    .HasName("PK_OrdDet");

                entity.ToTable("OrderDetails", "Proj0");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.MerchId).HasColumnName("MerchID");

                entity.HasOne(d => d.Merch)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.MerchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Merch__50FB042B");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Order__5006DFF2");
            });

            modelBuilder.Entity<OrderInfo>(entity =>
            {
                entity.ToTable("OrderInfo", "Proj0");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderInfo)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderInfo__Custo__4C364F0E");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.OrderInfo)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderInfo__Store__4D2A7347");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "Proj0");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
