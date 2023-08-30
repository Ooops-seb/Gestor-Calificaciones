using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class HistorialAcademico
{
    public string IdHis { get; set; } = null!;

    public string IdAlu { get; set; } = null!;

    public string IdAsi { get; set; } = null!;

    public string IdAct { get; set; } = null!;

    public string IdPar { get; set; } = null!;

    public string IdCal { get; set; } = null!;

    public virtual Actum IdActNavigation { get; set; } = null!;

    public virtual Alumno IdAluNavigation { get; set; } = null!;

    public virtual Asignatura IdAsiNavigation { get; set; } = null!;

    public virtual Calificacion IdCalNavigation { get; set; } = null!;

    public virtual Paralelo IdParNavigation { get; set; } = null!;
}
