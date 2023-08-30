using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Auditorium
{
    public int IdAud { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Usuario { get; set; }

    public string? TablaAfectada { get; set; }

    public string? Sentencia { get; set; }
}
