using System;
using System.Collections.Generic;

namespace MoneyManagerService.EF.MoneyManagerService;

public partial class User
{
    public string Id { get; set; } = null!;

    public string? Fullname { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? TransId { get; set; }

    public bool? Status { get; set; }
}
