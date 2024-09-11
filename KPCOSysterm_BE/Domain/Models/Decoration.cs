using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Decoration
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double PricePerSquareMeter { get; set; }

    public int? DecorationTypeId { get; set; }

    public virtual DecorationType? DecorationType { get; set; }

    public virtual ICollection<PondDecoration> PondDecorations { get; set; } = new List<PondDecoration>();
}
