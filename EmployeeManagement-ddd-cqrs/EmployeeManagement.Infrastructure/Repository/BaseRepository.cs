using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private CrudDDDContext context;

        public BaseRepository(CrudDDDContext context)
        {
            this.context = context;
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(GetById(id));
        }

        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async void SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IList<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void Update(T obj)
        {
            context.Set<T>().Update(obj);
        }
        public void Dispose()
        {
            context.Dispose();
        }

    }
}
