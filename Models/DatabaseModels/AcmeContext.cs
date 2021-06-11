using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ACME.Models.DatabaseModels
{
    public partial class AcmeContext : DbContext
    {
        public AcmeContext()
        {
        }

        public AcmeContext(DbContextOptions<AcmeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrators { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientAddress> ClientAddresses { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-43BN61N2;Initial Catalog=acme;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.Property(e => e.AdministratorPassword).IsUnicode(false);

                entity.Property(e => e.AdministratorUsername).IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryDescription).IsUnicode(false);

                entity.Property(e => e.CategoryImageUrl).IsUnicode(false);

                entity.Property(e => e.CategoryName).IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientEmail).IsUnicode(false);

                entity.Property(e => e.ClientName).IsUnicode(false);

                entity.Property(e => e.ClientPassword).IsUnicode(false);

                entity.Property(e => e.ClientSurname).IsUnicode(false);
            });

            modelBuilder.Entity<ClientAddress>(entity =>
            {
                entity.Property(e => e.ClientAddressAddressLine1).IsUnicode(false);

                entity.Property(e => e.ClientAddressAddressLine2).IsUnicode(false);

                entity.Property(e => e.ClientAddressAddressLine3).IsUnicode(false);

                entity.Property(e => e.ClientAddressAddressLine4).IsUnicode(false);

                entity.Property(e => e.ClientAddressPostalCode).IsUnicode(false);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientAddresses)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__clientAdd__clien__4D94879B");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__product__categor__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
