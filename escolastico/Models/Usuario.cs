using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Usuario
{
    public string IdUsr { get; set; } = null!;

    public string? UsuarioUsr { get; set; }

    public string? PasswordUsr { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Administrador> Administradors { get; set; } = new List<Administrador>();

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public virtual ICollection<Profesor> Profesors { get; set; } = new List<Profesor>();
}
