using System;
using System.Collections.Generic;
using System.Text;
using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : Base
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        T GetById(int id);
        IList<T> GetAll();
    }
}
