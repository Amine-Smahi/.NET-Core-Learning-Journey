using MeklaAPI.Entities;
using MeklaAPI.Repositories;
using System;
using System.Threading.Tasks;

namespace MeklaAPI.Services
{
    public class SeedDataService : ISeedDataService
    {
        public async Task Initialize(MeklaDbContext context)
        {
            context.Meklas.Add(new Mekla() { Calories = 1000, Name = "Lasagne", Created = DateTime.Now });
            context.Meklas.Add(new Mekla() { Calories = 1100, Name = "Hamburger", Created = DateTime.Now });
            context.Meklas.Add(new Mekla() { Calories = 1200, Name = "Spaghetti", Created = DateTime.Now });
            context.Meklas.Add(new Mekla() { Calories = 1300, Name = "Pizza", Created = DateTime.Now });

            await context.SaveChangesAsync();
        }
    }
}
