using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime CraeteOn { get; set; }

    public string Status { get; set; } = null!;

    public int? AccountId { get; set; }

    public int? DiscountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
