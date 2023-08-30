using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Matricula
{
    public string IdMat { get; set; } = null!;

    public string IdAlu { get; set; } = null!;

    public string IdAsi { get; set; } = null!;

    public string IdPar { get; set; } = null!;

    public virtual Alumno IdAluNavigation { get; set; } = null!;

    public virtual Asignatura IdAsiNavigation { get; set; } = null!;

    public virtual Paralelo IdParNavigation { get; set; } = null!;
}
