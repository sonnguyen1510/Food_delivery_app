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
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite();
        

        public DbSet<UserTransaction> Transactions { get; set; }
    }
}