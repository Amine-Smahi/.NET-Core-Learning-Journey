using EmployeeManagement.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<CommandResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PersonalNumber { get; set; }
        public int level { get; set; }
    }
}
