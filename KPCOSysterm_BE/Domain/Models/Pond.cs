using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Pond
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Decription { get; set; } = null!;

    public double PondDepth { get; set; }

    public double Area { get; set; }

    public string Location { get; set; } = null!;

    public string Shape { get; set; } = null!;

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<PondComponent> PondComponents { get; set; } = new List<PondComponent>();

    public virtual ICollection<PondDecoration> PondDecorations { get; set; } = new List<PondDecoration>();
}
