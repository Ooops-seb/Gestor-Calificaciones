using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Titulacion
{
    public string IdTit { get; set; } = null!;

    public string NombreTit { get; set; } = null!;

    public short? CreditosTotalesTit { get; set; }

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
