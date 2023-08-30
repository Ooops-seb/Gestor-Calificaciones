using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Profesor
{
    public string IdPro { get; set; } = null!;

    public string? CedulaPro { get; set; }

    public string? NombrePro { get; set; }

    public string? ApellidoPro { get; set; }

    public DateTime? FechaNacimientoPro { get; set; }

    public string? DireccionPro { get; set; }

    public string? TelefonoPro { get; set; }

    public string? CorreoPro { get; set; }

    public string? GeneroPro { get; set; }

    public string? ObservacionesPro { get; set; }

    public string? UsuarioUsr { get; set; }

    public virtual ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();

    public virtual Usuario? UsuarioUsrNavigation { get; set; }
}
