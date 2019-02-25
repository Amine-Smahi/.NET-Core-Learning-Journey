using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using MeklaAPI.Entities;
using MeklaAPI.Helpers;
using MeklaAPI.Models;

namespace MeklaAPI.Repositories {
    public class EfMeklaRepository : IMeklaRepository {
        private readonly MeklaDbContext _MeklaDbContext;

        public EfMeklaRepository (MeklaDbContext MeklaDbContext) {
            _MeklaDbContext = MeklaDbContext;
        }

        public Mekla GetSingle (int id) {
            return _MeklaDbContext.Meklas.FirstOrDefault (x => x.Id == id);
        }

        public void Add (Mekla item) {
            _MeklaDbContext.Meklas.Add (item);
        }

        public void Delete (int id) {
            Mekla Mekla = GetSingle (id);
            _MeklaDbContext.Meklas.Remove (Mekla);
        }

        public Mekla Update (int id, Mekla item) {
            _MeklaDbContext.Meklas.Update (item);
            return item;
        }

        public IQueryable<Mekla> GetAll (QueryParameters queryParameters) {
            IQueryable<Mekla> _allItems = _MeklaDbContext.Meklas.OrderBy (queryParameters.OrderBy,
                queryParameters.IsDescending ());

            if (queryParameters.HasQuery ()) {
                _allItems = _allItems
                    .Where (x => x.Calories.ToString ().Contains (queryParameters.Query.ToLowerInvariant ()) ||
                        x.Name.ToLowerInvariant ().Contains (queryParameters.Query.ToLowerInvariant ()));
            }

            return _allItems
                .Skip (queryParameters.PageCount * (queryParameters.Page - 1))
                .Take (queryParameters.PageCount);
        }

        public int Count () {
            return _MeklaDbContext.Meklas.Count ();
        }

        public bool Save () {
            return (_MeklaDbContext.SaveChanges () >= 0);
        }

        public ICollection<Mekla> GetRandomMeal () {
            List<Mekla> toReturn = new List<Mekla> ();

            toReturn.Add (GetRandomItem ("Starter"));
            toReturn.Add (GetRandomItem ("Main"));
            toReturn.Add (GetRandomItem ("Dessert"));

            return toReturn;
        }

        private Mekla GetRandomItem (string type) {
            return _MeklaDbContext.Meklas
                .Where (x => x.Type == type)
                .OrderBy (o => Guid.NewGuid ())
                .FirstOrDefault ();
        }
    }
}