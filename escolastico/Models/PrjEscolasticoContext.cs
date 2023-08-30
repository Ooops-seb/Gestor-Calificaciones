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

    public virtual DbSet<Actum> Acta { get; set; }

    public virtual DbSet<Administrador> Administradors { get; set; }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Asignatura> Asignaturas { get; set; }

    public virtual DbSet<Auditorium> Auditoria { get; set; }

    public virtual DbSet<Calificacion> Calificacions { get; set; }

    public virtual DbSet<Campus> Campuses { get; set; }

    public virtual DbSet<HistorialAcademico> HistorialAcademicos { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

    public virtual DbSet<Paralelo> Paralelos { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Titulacion> Titulacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actum>(entity =>
        {
            entity.HasKey(e => e.IdAct).HasName("id_act_pk");

            entity.Property(e => e.IdAct)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_act");
            entity.Property(e => e.IdAsi)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_asi");
            entity.Property(e => e.IdPar)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_par");

            entity.HasOne(d => d.IdAsiNavigation).WithMany(p => p.Acta)
                .HasForeignKey(d => d.IdAsi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_asi_act_fk");

            entity.HasOne(d => d.IdParNavigation).WithMany(p => p.Acta)
                .HasForeignKey(d => d.IdPar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_par_act_fk");
        });

        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.IdAdm).HasName("id_adm_pk");

            entity.ToTable("Administrador");

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
            entity.Property(e => e.DireccionAdm)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("direccion_adm");
            entity.Property(e => e.FechaNacimientoAdm)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento_adm");
            entity.Property(e => e.GeneroAdm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero_adm");
            entity.Property(e => e.NombreAdm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_adm");
            entity.Property(e => e.TelefonoAdm)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono_adm");
            entity.Property(e => e.UsuarioUsr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuario_usr");

            entity.HasOne(d => d.UsuarioUsrNavigation).WithMany(p => p.Administradors)
                .HasForeignKey(d => d.UsuarioUsr)
                .HasConstraintName("usuario_usr_adm_fk");
        });

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlu).HasName("id_alu_pk");

            entity.ToTable("Alumno");

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
            entity.Property(e => e.CreditosAprobadosAlu).HasColumnName("creditos_aprobados_alu");
            entity.Property(e => e.DireccionAlu)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("direccion_alu");
            entity.Property(e => e.FechaNacimientoAlu)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento_alu");
            entity.Property(e => e.GeneroAlu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero_alu");
            entity.Property(e => e.IdCam)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_cam");
            entity.Property(e => e.IdTit)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_tit");
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
            entity.Property(e => e.UsuarioUsr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuario_usr");

            entity.HasOne(d => d.IdCamNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdCam)
                .HasConstraintName("id_cam_alu_fk");

            entity.HasOne(d => d.IdTitNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdTit)
                .HasConstraintName("id_tit_alu_fk");

            entity.HasOne(d => d.UsuarioUsrNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.UsuarioUsr)
                .HasConstraintName("usuario_usr_alu_fk");
        });

        modelBuilder.Entity<Asignatura>(entity =>
        {
            entity.HasKey(e => e.IdAsi).HasName("id_asi_pk");

            entity.ToTable("Asignatura");

            entity.Property(e => e.IdAsi)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_asi");
            entity.Property(e => e.CreditosAsi).HasColumnName("creditos_asi");
            entity.Property(e => e.IdPro)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_pro");
            entity.Property(e => e.NombreAsi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_asi");

            entity.HasOne(d => d.IdProNavigation).WithMany(p => p.Asignaturas)
                .HasForeignKey(d => d.IdPro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_pro_asi_fk");
        });

        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.IdAud).HasName("PK__Auditori__6BE84EABC5434744");

            entity.Property(e => e.IdAud).HasColumnName("id_aud");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Sentencia)
                .IsUnicode(false)
                .HasColumnName("sentencia");
            entity.Property(e => e.TablaAfectada)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("tabla_afectada");
            entity.Property(e => e.Usuario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<Calificacion>(entity =>
        {
            entity.HasKey(e => e.IdCal).HasName("id__cal_pk");

            entity.ToTable("Calificacion");

            entity.Property(e => e.IdCal)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_cal");
            entity.Property(e => e.EditableCal)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("editable_cal");
            entity.Property(e => e.IdAct)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_act");
            entity.Property(e => e.IdAlu)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_alu");
            entity.Property(e => e.IdAsi)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_asi");
            entity.Property(e => e.IdPar)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_par");
            entity.Property(e => e.NotaU1Cal)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("notaU1_cal");
            entity.Property(e => e.NotaU2Cal)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("notaU2_cal");
            entity.Property(e => e.Notau3Cal)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("notau3_cal");

            entity.HasOne(d => d.IdActNavigation).WithMany(p => p.Calificacions)
                .HasForeignKey(d => d.IdAct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_act_cal_fk");

            entity.HasOne(d => d.IdAluNavigation).WithMany(p => p.Calificacions)
                .HasForeignKey(d => d.IdAlu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_alu_cal_fk");

            entity.HasOne(d => d.IdAsiNavigation).WithMany(p => p.Calificacions)
                .HasForeignKey(d => d.IdAsi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_asi_cal_fk");

            entity.HasOne(d => d.IdParNavigation).WithMany(p => p.Calificacions)
                .HasForeignKey(d => d.IdPar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_par_cal_fk");
        });

        modelBuilder.Entity<Campus>(entity =>
        {
            entity.HasKey(e => e.IdCam).HasName("id_cam_pk");

            entity.ToTable("Campus");

            entity.Property(e => e.IdCam)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_cam");
            entity.Property(e => e.DireccionCam)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("direccion_cam");
            entity.Property(e => e.NombreCam)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_cam");
        });

        modelBuilder.Entity<HistorialAcademico>(entity =>
        {
            entity.HasKey(e => e.IdHis).HasName("id_his_pk");

            entity.ToTable("HistorialAcademico");

            entity.Property(e => e.IdHis)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_his");
            entity.Property(e => e.IdAct)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_act");
            entity.Property(e => e.IdAlu)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_alu");
            entity.Property(e => e.IdAsi)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_asi");
            entity.Property(e => e.IdCal)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_cal");
            entity.Property(e => e.IdPar)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_par");

            entity.HasOne(d => d.IdActNavigation).WithMany(p => p.HistorialAcademicos)
                .HasForeignKey(d => d.IdAct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_act_his_fk");

            entity.HasOne(d => d.IdAluNavigation).WithMany(p => p.HistorialAcademicos)
                .HasForeignKey(d => d.IdAlu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_alu_his_fk");

            entity.HasOne(d => d.IdAsiNavigation).WithMany(p => p.HistorialAcademicos)
                .HasForeignKey(d => d.IdAsi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_asi_his_fk");

            entity.HasOne(d => d.IdCalNavigation).WithMany(p => p.HistorialAcademicos)
                .HasForeignKey(d => d.IdCal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_cal_his_fk");

            entity.HasOne(d => d.IdParNavigation).WithMany(p => p.HistorialAcademicos)
                .HasForeignKey(d => d.IdPar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_par_his_fk");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.IdMat).HasName("id_mat");

            entity.ToTable("Matricula");

            entity.Property(e => e.IdMat)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_mat");
            entity.Property(e => e.IdAlu)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_alu");
            entity.Property(e => e.IdAsi)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_asi");
            entity.Property(e => e.IdPar)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_par");

            entity.HasOne(d => d.IdAluNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdAlu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_alu_mat_fk");

            entity.HasOne(d => d.IdAsiNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdAsi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_asi_mat_fk");

            entity.HasOne(d => d.IdParNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdPar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_par_mat_fk");
        });

        modelBuilder.Entity<Paralelo>(entity =>
        {
            entity.HasKey(e => e.IdPar).HasName("id_par_pk");

            entity.ToTable("Paralelo");

            entity.Property(e => e.IdPar)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_par");
            entity.Property(e => e.AlumnosRegistradosPar).HasColumnName("alumnos_registrados_par");
            entity.Property(e => e.HorarioPar)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("horario_par");
            entity.Property(e => e.IdAsi)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_asi");

            entity.HasOne(d => d.IdAsiNavigation).WithMany(p => p.Paralelos)
                .HasForeignKey(d => d.IdAsi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_asi_par_fk");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.IdPro).HasName("id_pro_pk");

            entity.ToTable("Profesor");

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
            entity.Property(e => e.DireccionPro)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("direccion_pro");
            entity.Property(e => e.FechaNacimientoPro)
                .HasColumnType("date")
                .HasColumnName("fecha_nacimiento_pro");
            entity.Property(e => e.GeneroPro)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("genero_pro");
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
            entity.Property(e => e.UsuarioUsr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuario_usr");

            entity.HasOne(d => d.UsuarioUsrNavigation).WithMany(p => p.Profesors)
                .HasForeignKey(d => d.UsuarioUsr)
                .HasConstraintName("usuario_usr_pro_fk");
        });

        modelBuilder.Entity<Titulacion>(entity =>
        {
            entity.HasKey(e => e.IdTit).HasName("int_tit_pk");

            entity.ToTable("Titulacion");

            entity.Property(e => e.IdTit)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id_tit");
            entity.Property(e => e.CreditosTotalesTit).HasColumnName("creditos_totales_tit");
            entity.Property(e => e.NombreTit)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre_tit");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioUsr).HasName("usuario_usr_pk");

            entity.ToTable("Usuario");

            entity.Property(e => e.UsuarioUsr)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuario_usr");
            entity.Property(e => e.PasswordUsr)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("password_usr");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
