using System;
using System.Collections.Generic;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services.Business
{
    public class EmployeeService: IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void Insert(Employee employee)
        {
            _employeeRepository.Insert(employee);
            _employeeRepository.SaveChanges();
        }
        public IList<Employee> GetAll()
        {
            IList<Employee> EmployeeList = new List<Employee>();
            EmployeeList = _employeeRepository.GetAll();
            return EmployeeList;
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(id);
        }


        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
            _employeeRepository.SaveChanges();
        }

        public void RaiseLevel(Employee employee)
        {
            _employeeRepository.RaiseLevel(employee);
            _employeeRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
            _employeeRepository.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
