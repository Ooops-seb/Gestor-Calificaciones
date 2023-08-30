using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Paralelo
{
    public string IdPar { get; set; } = null!;

    public string HorarioPar { get; set; } = null!;

    public byte AlumnosRegistradosPar { get; set; }

    public string IdAsi { get; set; } = null!;

    public virtual ICollection<Actum> Acta { get; set; } = new List<Actum>();

    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();

    public virtual ICollection<HistorialAcademico> HistorialAcademicos { get; set; } = new List<HistorialAcademico>();

    public virtual Asignatura IdAsiNavigation { get; set; } = null!;

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
