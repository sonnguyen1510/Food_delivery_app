using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyStatistic.Database.SQLiteDB
{
    public class UserLoginStatus
    {
        [PrimaryKey,AutoIncrement]
        public int loginStatusID {  get; set; }

        public string? Username { get; set; }

        public string? fullname {  get; set; }
        public decimal? Id { get; set; }

        public bool? status { get; set; }
    }
}
