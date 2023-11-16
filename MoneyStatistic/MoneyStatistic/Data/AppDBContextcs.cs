
using Microsoft.EntityFrameworkCore;

namespace MoneyStatistic.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<LoginCurrent> LoginCurrents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=yourdatabase.db");
        }
    }
}
