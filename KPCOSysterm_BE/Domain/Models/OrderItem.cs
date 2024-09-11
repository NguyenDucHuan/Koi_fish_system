using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public double TotalPrice { get; set; }

    public int? OrderId { get; set; }

    public int? ServiceId { get; set; }

    public int? PondId { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Pond? Pond { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual Service? Service { get; set; }
}
