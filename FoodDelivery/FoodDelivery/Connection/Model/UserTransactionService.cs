using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Connection.Model
{
    public class UserTransactionService
    {
        private readonly ApplicationDbContext _context;

        public UserTransactionService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<List<UserTransaction>> getAllTransactions() => await _context.UserTransactions.ToListAsync();
    }
}
