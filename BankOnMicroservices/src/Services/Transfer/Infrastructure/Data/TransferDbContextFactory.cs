using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Transfer.Infrastructure.Data
{
    public class TransferDbContextFactory : IDesignTimeDbContextFactory<TransferDbContext>
    {
        public TransferDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TransferDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=TransferDB;Trusted_Connection=True;MultipleActiveResultSets=True");

            return new TransferDbContext(optionsBuilder.Options);
        }
    }
}
