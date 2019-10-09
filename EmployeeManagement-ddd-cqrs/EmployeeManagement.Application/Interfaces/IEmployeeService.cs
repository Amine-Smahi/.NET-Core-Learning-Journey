using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        void Insert(Employee employee);
        IList<Employee> GetAll();
        Employee GetById(int id);
        void Update(Employee employee);
        void Delete(int id);
        void RaiseLevel(Employee employee);
    }
}
