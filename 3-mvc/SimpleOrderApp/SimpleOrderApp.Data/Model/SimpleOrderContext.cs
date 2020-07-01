using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SimpleOrderApp.Data.Model
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

            // with code-first, you can specify initial data (seed data) for the tables as well, right here
            // https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding

            modelBuilder.Entity<LocationEntity>()
                .HasData(new LocationEntity[]
                {
                    new LocationEntity { Id = 1, Name = "cookie shop 1", Stock = 100 },
                    new LocationEntity { Id = 2, Name = "cookie shop 2", Stock = 2 }
                });
        }
    }
}
