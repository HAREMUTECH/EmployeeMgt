using EmployeeMgt.Domain.Dto.EmployeeAddress;
using EmployeeMgt.Domain.Enums;

namespace EmployeeMgt.Domain.Dto.Employee
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }

        public List<EmployeeAddressDto> EmployeeAddresses { get; set; }
    }
}
