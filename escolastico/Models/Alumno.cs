using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Alumno
{
    public string IdAlu { get; set; } = null!;

    public string? CedulaAlu { get; set; }

    public string? NombreAlu { get; set; }

    public string? ApellidoAlu { get; set; }

    public DateTime? FechaNacimientoAlu { get; set; }

    public string? TelefonoAlu { get; set; }

    public string? CorreoAlu { get; set; }

    public string? GeneroAlu { get; set; }

    public string? ObservacionesAlu { get; set; }

    public string? UsuarioUsr { get; set; }

    public virtual Usuario? UsuarioUsrNavigation { get; set; }
}
