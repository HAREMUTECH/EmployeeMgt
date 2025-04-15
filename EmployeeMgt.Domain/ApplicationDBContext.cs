using EmployeeMgt.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMgt.Domain
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }

    }
}
