using System;
using System.Collections.Generic;

namespace Lab1.Models.Entities;

public partial class Telefono
{
    public string Num { get; set; } = null!;

    public string? Oper { get; set; }

    public int? Duenio { get; set; }

    public virtual Persona? DuenioNavigation { get; set; }
}
