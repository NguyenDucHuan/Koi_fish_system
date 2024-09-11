using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class DiscountPound
{
    public int DiscountId { get; set; }

    public int AccountId { get; set; }

    public int Amount { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Discount Discount { get; set; } = null!;
}
