using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace escolastico.Models;

public partial class PrjEscolasticoContext : DbContext
{
    public PrjEscolasticoContext()
    {
    }

    public PrjEscolasticoContext(DbContextOptions<PrjEscolasticoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdm).HasName("id_adm_pk");

            entity.ToTable("administrador");

            entity.Property(e => e.IdAdm)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_adm");
            entity.Property(e => e.ApellidoAdm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_adm");
            entity.Property(e => e.CedulaAdm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cedula_adm");
            entity.Property(e => e.CorreoAdm)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_adm");
            entity.Property(e => e.FechaNacimientoAdm)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento_adm");
            entity.Property(e => e.GeneroAdm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero_adm");
            entity.Property(e => e.IdUsr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_usr");
            entity.Property(e => e.NombreAdm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_adm");
            entity.Property(e => e.TelefonoAdm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono_adm");

            entity.HasOne(d => d.IdUsrNavigation).WithMany(p => p.Administradors)
                .HasForeignKey(d => d.IdUsr)
                .HasConstraintName("id_administrador_usr");
        });

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlu).HasName("id_alu_pk");

            entity.ToTable("alumno");

            entity.Property(e => e.IdAlu)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_alu");
            entity.Property(e => e.ApellidoAlu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_alu");
            entity.Property(e => e.CedulaAlu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cedula_alu");
            entity.Property(e => e.CorreoAlu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_alu");
            entity.Property(e => e.FechaNacimientoAlu)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento_alu");
            entity.Property(e => e.GeneroAlu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero_alu");
            entity.Property(e => e.IdUsr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_usr");
            entity.Property(e => e.NombreAlu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_alu");
            entity.Property(e => e.ObservacionesAlu)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("observaciones_alu");
            entity.Property(e => e.TelefonoAlu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono_alu");

            entity.HasOne(d => d.IdUsrNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdUsr)
                .HasConstraintName("id_alumno_usr");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.IdPro).HasName("id_pro_pk");

            entity.ToTable("profesor");

            entity.Property(e => e.IdPro)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_pro");
            entity.Property(e => e.ApellidoPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido_pro");
            entity.Property(e => e.CedulaPro)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cedula_pro");
            entity.Property(e => e.CorreoPro)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("correo_pro");
            entity.Property(e => e.FechaNacimientoPro)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento_pro");
            entity.Property(e => e.GeneroPro)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero_pro");
            entity.Property(e => e.IdUsr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_usr");
            entity.Property(e => e.NombrePro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_pro");
            entity.Property(e => e.ObservacionesPro)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("observaciones_pro");
            entity.Property(e => e.TelefonoPro)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono_pro");

            entity.HasOne(d => d.IdUsrNavigation).WithMany(p => p.Profesors)
                .HasForeignKey(d => d.IdUsr)
                .HasConstraintName("id_profesor_usr");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsr).HasName("id_usr_pk");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_usr");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("date")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.PasswordUsr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password_usr");
            entity.Property(e => e.UsuarioUsr)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("usuario_usr");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
