using System.Collections.Generic;
using System.Linq;
using MeklaAPI.Entities;
using MeklaAPI.Models;

namespace MeklaAPI.Repositories {
    public interface IMeklaRepository {
        Mekla GetSingle (int id);
        void Add (Mekla item);
        void Delete (int id);
        Mekla Update (int id, Mekla item);
        IQueryable<Mekla> GetAll (QueryParameters queryParameters);

        ICollection<Mekla> GetRandomMeal ();
        int Count ();

        bool Save ();
    }
}