using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.Controllers
{
    public class BaseController : Controller
    {
        public bool CheckModelValidation(Task<Application.CommandResult> validationResult)
        {
            if (!validationResult.Result.Successful)
            {
                foreach (ValidationFailure failer in validationResult.Result.errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
                return false;
            }
            return true;
        }
    }
}
