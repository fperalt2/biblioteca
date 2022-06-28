using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pt1_mvc.Models
{
    public partial class bibliotecaContext : DbContext
    {
        public bibliotecaContext()
        {
        }

        public bibliotecaContext(DbContextOptions<bibliotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; } = null!;
        public virtual DbSet<Llibre> Llibres { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("autor");

                entity.Property(e => e.Cognoms).HasColumnName("cognoms");

                entity.Property(e => e.Nom).HasColumnName("nom");
            });

            modelBuilder.Entity<Llibre>(entity =>
            {
                entity.ToTable("llibre");

                entity.HasIndex(e => e.AutorId, "IX_FK_autorllibre");

                entity.Property(e => e.AutorId).HasColumnName("autor_Id");

                entity.Property(e => e.Titol).HasColumnName("titol");

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Llibres)
                    .HasForeignKey(d => d.AutorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_autorllibre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
