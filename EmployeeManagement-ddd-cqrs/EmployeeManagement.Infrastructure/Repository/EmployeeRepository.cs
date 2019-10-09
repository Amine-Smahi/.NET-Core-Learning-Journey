using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private CrudDDDContext _context;

        public EmployeeRepository(CrudDDDContext context) : base(context)
        {
            _context = context;
        }

        public void RaiseLevel(Employee employee)
        {
            employee.level += 1;
            _context.Set<Employee>().Update(employee);
        }
    }
}
