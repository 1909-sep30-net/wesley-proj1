using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace demo.DataAccess
{
    class randomDbContext : DbContext
    {
        public randomDbContext()
        {

        }

        public randomDbContext(DbContextOptions<randomDbContext> options) : base(options)
        {

        }

        public DbSet<random> random { get; set; }
        public DbSet<randomtype> randomtype { get; set; }
        //public DbSet<randomtypejoin> randomtypejoin { get; set; }
        //  (there is a DbContext.Set<randomtypejoin>() that would let us get the set anyway

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<random>(entity =>
            {
                entity.Property(e => e.Id)
                .UseIdentityColumn();   //IDENTITY column

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(64);

                entity.Property(e => e.Height)
                .IsRequired();

                entity.Property(e => e.Weight)
                .IsRequired();
            });

            modelBuilder.Entity<randomtype>(entity =>
            {
                entity.Property(e => e.id)
                .UseIdentityColumn();

                entity.Property(e => e.name)
                .IsRequired()
                .HasMaxLength(64);
            });

            modelBuilder.Entity<randomtypejoin>(entity =>
            {
                //composite key (config with c# anonymous type)
                entity.HasKey(e => new { e.randomId, e.randomtypeId });

                entity.HasOne(et => et.ran)
                    .WithMany(e => e.randomtypejoins)
                    .HasForeignKey()
            });
        }
    }
}
