using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SimpleOrderApp.Data
{
    public class SimpleOrderContext : DbContext
    {
        public SimpleOrderContext(DbContextOptions<SimpleOrderContext> options)
            : base(options)
        {
        }

        // dbsets
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add any non-default configuration of the model

            modelBuilder.Entity<LocationEntity>(entity =>
            {
                entity.ToTable("Locations");

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.HasIndex(e => e.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<OrderEntity>(entity =>
            {
                entity.ToTable("Orders");
            });
        }
    }
}
