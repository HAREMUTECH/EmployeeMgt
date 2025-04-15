using EmployeeMgt.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMgt.Domain.Dto.Employee
{
    public class UpdateEmployeeDto
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "MiddleName is required")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(20, 100, ErrorMessage = "Age must be between 20 and 100")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }
    }
}
