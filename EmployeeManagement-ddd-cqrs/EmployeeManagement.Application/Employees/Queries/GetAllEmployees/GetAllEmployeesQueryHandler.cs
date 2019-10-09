using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Employees.Queries.GetAllEmployees
{
    class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
    {
        private IEmployeeRepository _employeeRepository { get;  }

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return _employeeRepository.GetAll().AsEnumerable();
        }
    }
}
