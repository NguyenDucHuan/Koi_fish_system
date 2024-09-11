using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Component
{
    public int ComponentId { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public string Description { get; set; } = null!;

    public int? ComponentTypeId { get; set; }

    public virtual ComponentType? ComponentType { get; set; }

    public virtual ICollection<PondComponent> PondComponents { get; set; } = new List<PondComponent>();
}
