using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sales.Services.Model;

namespace Sales.Repositories.Data
{
    public partial class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SaleRecord> SaleRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<SaleRecord>(entity =>
            {
                entity.HasIndex(e => e.Region, "IX_SaleRecords_Region");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.ItemType)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderPriority)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Region)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.SalesChannel)
                    .HasMaxLength(255)
                    .IsFixedLength(true);

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalProfit).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalRevenue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitCost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
