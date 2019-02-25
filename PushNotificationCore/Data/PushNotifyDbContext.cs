using Microsoft.EntityFrameworkCore;
using PushNotificationCore.Models;

namespace PushNotificationCore.Data
{
    public class PushNotifyDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public PushNotifyDbContext(DbContextOptions<PushNotifyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
