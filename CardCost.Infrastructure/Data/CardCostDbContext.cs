using CardCost.Core.Entities;
using CardCost.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CardCost.Infrastructure.Data
{
    public partial class CardCostDbContext : DbContext, ICardCostDbContext
    {
        public CardCostDbContext()
        {
        }

        public CardCostDbContext(DbContextOptions<CardCostDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessUser> AccessUser { get; set; }
        public virtual DbSet<Ccmatrix> Ccmatrix { get; set; }
        public virtual DbSet<Iinlist> Iinlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=CardCostDb; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessUser>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(64)
                    .IsFixedLength();

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(128)
                    .IsFixedLength();

                entity.Property(e => e.Token).HasMaxLength(200);

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            modelBuilder.Entity<Ccmatrix>(entity =>
            {
                entity.ToTable("CCMatrix");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country).HasMaxLength(10);
            });

            modelBuilder.Entity<Iinlist>(entity =>
            {
                entity.ToTable("IINList");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country).HasMaxLength(10);

                entity.Property(e => e.Iin)
                    .HasColumnName("IIN")
                    .HasMaxLength(6);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
