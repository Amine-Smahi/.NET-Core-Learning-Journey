using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Livraria.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Infra.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Base
    {
        private LivrariaDbContext context = new LivrariaDbContext();

        public void Delete(int id)
        {
            context.Set<T>().Remove(GetById(id));
            context.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
