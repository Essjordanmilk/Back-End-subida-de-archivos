using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class ETITCContext : DbContext
    {
        public ETITCContext()
        {
        }

        public ETITCContext(DbContextOptions<ETITCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Archivo> Archivos { get; set; } = null!;
        public virtual DbSet<Docente> Docentes { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Facultad> Facultads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-D4K75HQ\\SQLEXPRESS; Database=ETITC; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archivo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("archivos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    
                    .HasColumnName("nombre");

                entity.Property(e => e.Ubicacion)
                    .HasColumnType("text")
                    .HasColumnName("ubicacion");
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.IdDoc)
                    .HasName("PK__Docente__3E4114461EE2C1AC");

                entity.ToTable("Docente");

                entity.Property(e => e.IdDoc)
                    .ValueGeneratedNever()
                    .HasColumnName("idDoc");

                entity.Property(e => e.Facultad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("facultad");

                entity.Property(e => e.NombreDoc)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstu)
                    .HasName("PK__Estudian__94688A27A7E4CAAA");

                entity.Property(e => e.IdEstu)
                    .ValueGeneratedNever()
                    .HasColumnName("idEstu");

                entity.Property(e => e.Facultad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("facultad");

                entity.Property(e => e.NombreEstu)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreEstu");
            });

            modelBuilder.Entity<Facultad>(entity =>
            {
                entity.ToTable("Facultad");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Desfacul)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("desfacul");

                entity.Property(e => e.Nombrefacultad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombrefacultad");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
