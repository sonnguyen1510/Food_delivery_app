using Microsoft.EntityFrameworkCore;

using MoneyManager.Database.SQLite.Model;
using System.Collections.Generic;

namespace MoneyManager.Database.Server
{
    public class ApplicationDbSQliteContext : DbContext
    {
        public ApplicationDbSQliteContext(DbContextOptions<ApplicationDbSQliteContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite();
        
        public DbSet<Transaction> Transaction { get; set; }
        
    }
}