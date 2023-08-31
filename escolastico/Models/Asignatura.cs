using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Asignatura
{
    public string IdAsi { get; set; } = null!;

    public string NombreAsi { get; set; } = null!;

    public byte CreditosAsi { get; set; }

    public string IdPro { get; set; } = null!;

    public virtual Profesor IdProNavigation { get; set; } = null!;

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
