using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Web.WeekLyst.Models
{
    public partial class weeklystContext : DbContext
    {
        public weeklystContext()
        {
        }

        public weeklystContext(DbContextOptions<weeklystContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ficha> Fichas { get; set; }
        public virtual DbSet<Programa> Programas { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.;database=weeklyst;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Ficha>(entity =>
            {
                entity.ToTable("ficha");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NumFicha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("num_ficha");
            });

            modelBuilder.Entity<Programa>(entity =>
            {
                entity.ToTable("programa");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("rol");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
