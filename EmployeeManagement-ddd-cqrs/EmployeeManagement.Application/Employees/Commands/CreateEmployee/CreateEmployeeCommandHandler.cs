using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Services.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace EmployeeManagement.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CommandResult>
    {
        private IEmployeeService _employeeRepository { get;  }

        public CreateEmployeeCommandHandler(IEmployeeService employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<CommandResult> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
               
            CreateEmployeeCommandValidation validator = new CreateEmployeeCommandValidation();

            ValidationResult results = validator.Validate(request);

                Employee entry = new Employee
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Address = request.Address,
                    level = request.level,
                    PersonalNumber = request.PersonalNumber
                };
            if (results.IsValid)
            {
                _employeeRepository.Insert(entry);
            }
            else
            {
               return CommandResult.ErrorValidation(results.Errors);
                  //  ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
            }
            return CommandResult.Success();
        }
    }
}
