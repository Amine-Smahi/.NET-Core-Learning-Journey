using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Personal Number")]
        public string PersonalNumber { get; set; }

        [Display(Name = "Employee level")]
        public int level { get; set; } = 0;
    }
}
