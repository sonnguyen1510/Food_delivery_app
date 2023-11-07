using Microsoft.EntityFrameworkCore;
using MoneyStatistic.Database.Service.Model;
using System.Collections.Generic;

namespace MoneyStatistic.Database.Service
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        

        public DbSet<UserTransaction> UserTransactions { get; set; }
    }
}