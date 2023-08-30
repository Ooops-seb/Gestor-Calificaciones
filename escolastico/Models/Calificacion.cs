using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Calificacion
{
    public string IdCal { get; set; } = null!;

    public string IdAlu { get; set; } = null!;

    public string IdAsi { get; set; } = null!;

    public string IdPar { get; set; } = null!;

    public string IdAct { get; set; } = null!;

    public decimal? NotaU1Cal { get; set; }

    public decimal? NotaU2Cal { get; set; }

    public decimal? Notau3Cal { get; set; }

    public byte[]? EditableCal { get; set; }

    public virtual ICollection<HistorialAcademico> HistorialAcademicos { get; set; } = new List<HistorialAcademico>();

    public virtual Actum IdActNavigation { get; set; } = null!;

    public virtual Alumno IdAluNavigation { get; set; } = null!;

    public virtual Asignatura IdAsiNavigation { get; set; } = null!;

    public virtual Paralelo IdParNavigation { get; set; } = null!;
}
