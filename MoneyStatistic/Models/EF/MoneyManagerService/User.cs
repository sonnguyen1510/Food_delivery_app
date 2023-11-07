using System;
using System.Collections.Generic;

namespace Models.EF.MoneyManagerService;

public partial class User
{
    public decimal Id { get; set; }

    public string? Fullname { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<UserTransaction> UserTransactions { get; set; } = new List<UserTransaction>();
}
