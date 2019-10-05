using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Domain.Entities;

namespace Library.Domain.Interfaces
{
    public interface IServiceBase<T> where T : Base
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;
        T Put<V>(T obj) where V : AbstractValidator<T>;
        void Delete(int id);
        T GetById(int id);
        IList<T> GetAll();
    }
}
