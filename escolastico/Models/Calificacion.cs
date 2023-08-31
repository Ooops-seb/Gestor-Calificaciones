using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Calificacion
{
    public string IdCal { get; set; } = null!;

    public string IdMat { get; set; } = null!;

    public decimal? NotaU1Cal { get; set; }

    public decimal? NotaU2Cal { get; set; }

    public decimal? Notau3Cal { get; set; }

    public virtual ICollection<Actum> Acta { get; set; } = new List<Actum>();

    public virtual Matricula IdMatNavigation { get; set; } = null!;
}
