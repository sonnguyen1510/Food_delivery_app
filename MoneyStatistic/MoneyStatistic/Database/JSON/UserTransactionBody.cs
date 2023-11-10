namespace MoneyStatistic.Database.JSON
{
    public class UserTransactionBody
    {

        public string? Title { get; set; }

        public string? TransType { get; set; }

        public string? TransIcon { get; set; }

        public string? CreTime { get; set; }

        public string? CreDate { get; set; }

        public decimal? Amount { get; set; }

        public decimal? UserId { get; set; }

        public bool? Status { get; set; }
    }
}
