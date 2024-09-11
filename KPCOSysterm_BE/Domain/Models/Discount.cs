using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Discount
{
    public int Id { get; set; }

    public string FieldOnDiscount { get; set; } = null!;

    public double DiscountAmount { get; set; }

    public double MinRequireDiscount { get; set; }

    public double MaxTotalDiscount { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int Amount { get; set; }

    public int Remaining { get; set; }

    public virtual ICollection<DiscountPound> DiscountPounds { get; set; } = new List<DiscountPound>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
