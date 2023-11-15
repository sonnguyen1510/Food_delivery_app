using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyStatistic.Pages.Analysis.Object
{
    public class Transaction_byWeek
    {
        public string startDate {  get; set; }
        public string endDate { get; set; }

        public List<Transaction_byDay> transaction_ByDays { get; set; } = new List<Transaction_byDay>();

        public int numOfIncome { get; set; } = 0;

        public int numOfExpense { get; set; } = 0;

        public decimal TotalIncome { get; set; } = 0;

        public decimal TotalExpense { get; set; } = 0;

        public decimal TotalWeekIncome()
        {
            foreach (var item in transaction_ByDays)
            {
                this.TotalIncome += item.incomeAmountCal();
            }
            return this.TotalIncome;
        }

        public decimal TotalWeekExpense()
        {
            foreach (var item in transaction_ByDays)
            {
                this.TotalExpense += item.expenseAmountCal();
            }

            return this.TotalExpense;
        }
    }
}
