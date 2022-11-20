using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUD_net2.models
{
    public partial class CRUD_EF_2Context : DbContext
    {
        public CRUD_EF_2Context()
        {
        }

        public CRUD_EF_2Context(DbContextOptions<CRUD_EF_2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Conductor> Conductors { get; set; } = null!;
        public virtual DbSet<Matricula> Matriculas { get; set; } = null!;
        public virtual DbSet<Sancione> Sanciones { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.ToTable("Conductor");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.Conductors)
                    .HasForeignKey(d => d.IdMatricula)
                    .HasConstraintName("FK__Conductor__IdMat__267ABA7A");
            });

            modelBuilder.Entity<Matricula>(entity =>
            {
                entity.ToTable("Matricula");

                entity.Property(e => e.FechaExpedicion).HasColumnType("date");

                entity.Property(e => e.Numero)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ValidaHasta).HasColumnType("date");
            });

            modelBuilder.Entity<Sancione>(entity =>
            {
                entity.ToTable("Sanciones");

                entity.Property(e => e.FechaActual)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Observacion).IsUnicode(false);

                entity.Property(e => e.Sancion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Conductor)
                    .WithMany()
                    .HasForeignKey(d => d.ConductorId)
                    .HasConstraintName("FK__Sanciones__Condu__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
