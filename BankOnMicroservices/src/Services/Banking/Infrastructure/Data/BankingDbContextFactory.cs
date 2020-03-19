using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Banking.Infrastructure.Data
{
    public class BankingDbContextFactory : IDesignTimeDbContextFactory<BankingDbContext>
    {
        public BankingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BankingDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=BankingDB;Trusted_Connection=True;MultipleActiveResultSets=True");

            return new BankingDbContext(optionsBuilder.Options);
        }
    }
}
