using Microsoft.EntityFrameworkCore;
using MeklaAPI.Entities;

namespace MeklaAPI.Repositories {
    public class MeklaDbContext : DbContext {
        public MeklaDbContext (DbContextOptions<MeklaDbContext> options) : base (options) {

        }

        public DbSet<Mekla> Meklas { get; set; }

    }
}