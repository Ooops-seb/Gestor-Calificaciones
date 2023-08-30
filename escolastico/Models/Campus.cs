using System;
using System.Collections.Generic;

namespace escolastico.Models;

public partial class Campus
{
    public string IdCam { get; set; } = null!;

    public string NombreCam { get; set; } = null!;

    public string DireccionCam { get; set; } = null!;

    public virtual ICollection<Alumno> Alumnos { get; set; } = new List<Alumno>();
}
