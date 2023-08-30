using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Usuario
{
    public string UsuarioUsr { get; set; } = null!;

    public string PasswordUsr { get; set; } = null!;

    public virtual ICollection<Administrador> Administradors { get; set; } = new List<Administrador>();

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();

    public virtual ICollection<Profesor> Profesors { get; set; } = new List<Profesor>();
}
