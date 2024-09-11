using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class User
{
    public int Id { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public int? Phone { get; set; }

    public DateTime Birthday { get; set; }

    public int? AccountId { get; set; }

    public string Email { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public virtual Account? Account { get; set; }
}
