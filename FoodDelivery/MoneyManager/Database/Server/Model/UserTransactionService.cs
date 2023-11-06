using Microsoft.EntityFrameworkCore;
using MoneyManager.Database.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Database.Server.Model
{
    public class UserTransactionService
    {
        private readonly ApplicationDbSQliteContext _context;

        public UserTransactionService(ApplicationDbSQliteContext context)
        {
            _context = context;
        }

        //public async Task<List<UserTransaction>> getAllTransactions() => await _context.UserTransactions.ToListAsync();
    }
}
