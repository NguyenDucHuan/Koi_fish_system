using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PondComponent
{
    public int PondId { get; set; }

    public int ComponentId { get; set; }

    public int Amount { get; set; }

    public virtual Component Component { get; set; } = null!;

    public virtual Pond Pond { get; set; } = null!;
}
