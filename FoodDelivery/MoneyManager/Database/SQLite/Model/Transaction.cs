using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Database.SQLite.Model
{
    public class Transaction
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string TransType { get; set; }
        public string TransIcon { get; set; }
        public TimeSpan CreTime { get; set; }
        public DateTime CreDate { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
    }
}
