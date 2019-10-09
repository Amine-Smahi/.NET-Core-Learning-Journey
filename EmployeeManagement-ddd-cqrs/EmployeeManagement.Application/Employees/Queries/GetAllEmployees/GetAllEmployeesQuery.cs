using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.Domain.Entities;
using MediatR;

namespace EmployeeManagement.Application.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
    }
}
