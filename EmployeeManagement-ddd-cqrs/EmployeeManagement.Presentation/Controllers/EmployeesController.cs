using EmployeeManagement.Application.Employees.Commands.CreateEmployee;
using EmployeeManagement.Application.Employees.Queries.GetAllEmployees;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Services.Interfaces;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Presentation.Controllers
{
    public class EmployeesController : BaseController
    {
        private IEmployeeService _employeeRepository;
        IMediator _mediator { get; }

        public EmployeesController(IMediator mediator, IEmployeeService employeeRepository)
        {
            _mediator = mediator;
            _employeeRepository = employeeRepository;
        }
        // GET: Employees
        public ActionResult Index()
        {
            IEnumerable<Employee> employees = _mediator.Send(new GetAllEmployeesQuery()).Result;
            return View(employees);
        }
        public ActionResult fill() {
            _employeeRepository.Insert(new Employee {
                FirstName = "amine"
            });
            return View(nameof(Index));
        }
    
        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            var model = _employeeRepository.GetById(id);
            return View(model);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee model)
        {
            CreateEmployeeCommand newemployee = new CreateEmployeeCommand()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                level = model.level,
                PersonalNumber = model.PersonalNumber
            };
            var  result = _mediator.Send(newemployee);

            if (!CheckModelValidation(result))
            {
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _employeeRepository.GetById(id);
            return View(model);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                _employeeRepository.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult RaiseLevel(int id)
        {
            var model = _employeeRepository.GetById(id);
            _employeeRepository.RaiseLevel(model);
             return RedirectToAction(nameof(Index));
        }
       
    }
}