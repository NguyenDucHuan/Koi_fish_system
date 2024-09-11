using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class DecorationType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Decoration> Decorations { get; set; } = new List<Decoration>();
}
