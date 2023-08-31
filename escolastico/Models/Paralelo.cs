using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Paralelo
{
    public string IdPar { get; set; } = null!;

    public string? NombrePar { get; set; }

    public string HorarioPar { get; set; } = null!;

    public byte? AlumnosRegistradosPar { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
