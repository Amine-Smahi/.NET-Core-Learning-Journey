using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagement.Application
{
    public class CommandResult
    {
        public bool Successful { get; set; }

        public Exception Exception { get; set; }

        public List<ValidationFailure> errors { get; set; }

        public static CommandResult Success()
        {
            return new CommandResult { Successful = true };
        }

        public static CommandResult Success(dynamic objectId)
        {
            return new CommandResult { Successful = true, ObjectId = objectId };
        }

        public dynamic ObjectId { get; set; }

        public static CommandResult Error(Exception exception)
        {
            return new CommandResult { Successful = false, Exception = exception };
        }
        public static CommandResult ErrorValidation(IList<ValidationFailure> validationErrors)
        {
            return new CommandResult { Successful = false, errors = validationErrors.ToList() };
        }
    }
}
