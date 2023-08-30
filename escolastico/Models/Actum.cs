using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Actum
{
    public string IdAct { get; set; } = null!;

    public string IdAsi { get; set; } = null!;

    public string IdPar { get; set; } = null!;

    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();

    public virtual ICollection<HistorialAcademico> HistorialAcademicos { get; set; } = new List<HistorialAcademico>();

    public virtual Asignatura IdAsiNavigation { get; set; } = null!;

    public virtual Paralelo IdParNavigation { get; set; } = null!;
}
