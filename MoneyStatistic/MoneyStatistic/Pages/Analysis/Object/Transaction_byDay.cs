using MoneyStatistic.Database.MoneyManagerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyStatistic.Pages.Analysis.Object
{
    public class Transaction_byDay
    {
        public string date { get; set; }
        public List<UserTransaction> IncomeTransaction { get; set; } = new List<UserTransaction>();

        public List<UserTransaction> ExpenseTransaction { get; set; } = new List<UserTransaction>();

        public decimal totalIncome { get; set; } = 0;

        public decimal totalExpense { get; set; } = 0;

        public decimal expenseAmountCal() {
            foreach (var item in ExpenseTransaction)
            {
                this.totalExpense = this.totalExpense + item?.Amount ?? 0;
            }
            return this.totalExpense;
        }

        public decimal incomeAmountCal() {
            foreach (var item in IncomeTransaction)
            {
                this.totalIncome = this.totalExpense + item?.Amount ?? 0;
            }
            return this.totalIncome;
        }
    }
}
