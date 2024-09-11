using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Rating
{
    public int Id { get; set; }

    public string Image { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int Star { get; set; }

    public DateTime CreateOn { get; set; }

    public int AccountId { get; set; }

    public int? OrderItemId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual OrderItem? OrderItem { get; set; }
}
