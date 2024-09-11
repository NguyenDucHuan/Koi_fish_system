using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public double PricePerSquareMeter { get; set; }

    public int? ServiceTypeId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ServiceType? ServiceType { get; set; }
}
