using System.Collections.Generic;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void RaiseLevel(Employee employee);
    }
}
