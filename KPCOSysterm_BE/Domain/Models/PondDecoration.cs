using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class PondDecoration
{
    public int DecorationId { get; set; }

    public int PondId { get; set; }

    public int AreaAmount { get; set; }

    public virtual Decoration Decoration { get; set; } = null!;

    public virtual Pond Pond { get; set; } = null!;
}
