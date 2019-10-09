using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace EmployeeManagement.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidation : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidation()
        {
            RuleFor(x => x.FirstName).MaximumLength(20).NotEmpty();
            RuleFor(x => x.LastName).MaximumLength(20).NotEmpty();
            RuleFor(x => x.Address).EmailAddress().NotEmpty();
            RuleFor(x => x.PersonalNumber).NotEmpty();
        }
    }
}
