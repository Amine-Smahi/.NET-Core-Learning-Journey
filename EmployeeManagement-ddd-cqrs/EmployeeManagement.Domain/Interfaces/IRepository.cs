using System;
using System.Collections.Generic;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        T GetById(int id);
        IList<T> GetAll();
        void SaveChanges();
    }
}
