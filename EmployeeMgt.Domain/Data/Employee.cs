using EmployeeMgt.Domain.Enums;

namespace EmployeeMgt.Domain.Data
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public ICollection<EmployeeAddress> EmployeeAddresses { get; set; } = new HashSet<EmployeeAddress>();
    }

}
