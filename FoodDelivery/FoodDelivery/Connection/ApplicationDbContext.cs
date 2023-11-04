
using FoodDelivery.Connection.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FoodDelivery.Connection
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