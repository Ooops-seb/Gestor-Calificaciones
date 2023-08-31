using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Actum
{
    public string IdAct { get; set; } = null!;

    public string? IdCal { get; set; }

    public virtual Calificacion? IdCalNavigation { get; set; }
}
