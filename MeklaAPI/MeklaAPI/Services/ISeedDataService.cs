using MeklaAPI.Repositories;
using System.Threading.Tasks;

namespace MeklaAPI.Services
{
    public interface ISeedDataService
    {
        Task Initialize(MeklaDbContext context);
    }
}
