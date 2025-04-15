using EmployeeMgt.Domain.Dto;
using EmployeeMgt.Domain.Dto.Employee;

namespace EmployeeMgt.Domain.Implementation.Service
{
    public interface IEmployeeService
    {
        Task<ResponseModel<bool>> CreateEmployee(CreateEmployeeDto request);
        Task<ResponseModel<bool>> DeleteEmployee(Guid id);
        Task<ResponseModel<EmployeeDto>> GetEmployee(Guid id);
        Task<ResponseModel<List<EmployeeDto>>> GetEmployees();
        Task<ResponseModel<bool>> UpdateEmployee(UpdateEmployeeDto request);
    }
}