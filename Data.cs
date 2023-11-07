using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyStatistic.Database.SQLite.Models;

namespace MoneyStatistic.Data
{
    public class Data
    {
        public static List<Transaction> getListData()
        {
            List<Transaction> data = new List<Transaction>();

            data.Add(new Transaction
            {
                Id = "01",
                Title = "Food&Dring",
                TransType = "expense",
                TransIcon = "Food&Dring",
                CreTime = TimeSpan.Parse("00:00:00"),
                CreDate = DateTime.Parse("2021-06-12"),
                Amount = 500,
                Status = true
            });

            data.Add( new Transaction
            {
                Id = "02",
                Title = "Bussiness",
                TransType = "income",
                TransIcon = "Bussiness",
                CreTime = TimeSpan.Parse("10:10:00"),
                CreDate = DateTime.Parse("2021-06-11"),
                Amount = 1000,
                Status = true
            });

            data.Add( new Transaction
            {
                Id = "03",
                Title = "Shopping",
                TransType = "expense",
                TransIcon = "Shopping",
                CreTime = TimeSpan.Parse("20:30:00"),
                CreDate = DateTime.Parse("2021-06-10"),
                Amount = 200,
                Status = true
            });

            data.Add( new Transaction
            {
                Id = "04",
                Title = "Salary",
                TransType = "income",
                TransIcon = "Salary",
                CreTime = TimeSpan.Parse("11:25:00"),
                CreDate = DateTime.Parse("2021-06-09"),
                Amount = 3000,
                Status = true
            });

            data.Add( new Transaction
            {
                Id = "05",
                Title = "Electricity bill",
                TransType = "expense",
                TransIcon = "Bill",
                CreTime = TimeSpan.Parse("09:00:00"),
                CreDate = DateTime.Parse("2021-06-08"),
                Amount = 1600,
                Status = true
            });

            return data;
        }
    }
}
