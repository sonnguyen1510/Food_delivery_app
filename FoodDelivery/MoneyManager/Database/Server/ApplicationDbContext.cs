using Microsoft.EntityFrameworkCore;
using MoneyManager.Database.Server.Model;
using System.Collections.Generic;

namespace MoneyManager.Database.Server
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