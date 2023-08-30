using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Asignatura
{
    public string IdAsi { get; set; } = null!;

    public string NombreAsi { get; set; } = null!;

    public byte CreditosAsi { get; set; }

    public string IdPro { get; set; } = null!;

    public virtual ICollection<Actum> Acta { get; set; } = new List<Actum>();

    public virtual ICollection<Calificacion> Calificacions { get; set; } = new List<Calificacion>();

    public virtual ICollection<HistorialAcademico> HistorialAcademicos { get; set; } = new List<HistorialAcademico>();

    public virtual Profesor IdProNavigation { get; set; } = null!;

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();

    public virtual ICollection<Paralelo> Paralelos { get; set; } = new List<Paralelo>();
}
