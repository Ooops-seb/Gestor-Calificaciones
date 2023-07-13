﻿using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Administrador
{
    public string IdAdm { get; set; } = null!;

    public string? CedulaAdm { get; set; }

    public string? NombreAdm { get; set; }

    public string? ApellidoAdm { get; set; }

    public DateTime? FechaNacimientoAdm { get; set; }

    public string? TelefonoAdm { get; set; }

    public string? CorreoAdm { get; set; }

    public string? GeneroAdm { get; set; }

    public int? IdUsr { get; set; }

    public virtual Usuario? IdUsrNavigation { get; set; }
}
