using System;
using System.Collections.Generic;

namespace MoneyManagerService.EF.MoneyManagerService;

public partial class UserTransaction
{
    public string Id { get; set; } = null!;

    public string? Title { get; set; }

    public string? TransType { get; set; }

    public string? TransIcon { get; set; }

    public TimeSpan? CreTime { get; set; }

    public DateTime? CreDate { get; set; }

    public decimal? Amount { get; set; }

    public bool? Status { get; set; }
}
