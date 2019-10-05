using FluentValidation;
using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Livraria.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : Base
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser 0.");

            _repository.Delete(id);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser 0.");

            return _repository.GetById(id);
        }

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Update(obj);
            return obj;
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("objeto nulo.");

            validator.ValidateAndThrow(obj);
        }

    }
}
