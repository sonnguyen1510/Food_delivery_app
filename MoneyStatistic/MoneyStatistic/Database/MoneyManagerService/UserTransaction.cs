using System;
using System.Collections.Generic;

namespace MoneyStatistic.Database.MoneyManagerService;

public partial class UserTransaction
{
    public decimal Id { get; set; }

    public string? Title { get; set; }

    public string? TransType { get; set; }

    public string? TransIcon { get; set; }

    public TimeSpan? CreTime { get; set; }

    public DateTime? CreDate { get; set; }

    public decimal? Amount { get; set; }

    public decimal? UserId { get; set; }

    public bool? Status { get; set; }

    public virtual User? User { get; set; }
}
