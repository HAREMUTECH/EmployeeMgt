using EmployeeMgt.Domain.Data;
using EmployeeMgt.Domain.Dto;
using EmployeeMgt.Domain.Dto.Employee;
using EmployeeMgt.Domain.Implementation.Repository;
using Microsoft.Extensions.Logging;
using Serilog;

namespace EmployeeMgt.Domain.Implementation.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IAsyncRepository<Employee, Guid> _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IAsyncRepository<Employee, Guid> employeeRepository, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<ResponseModel<bool>> CreateEmployee(CreateEmployeeDto request)
        {
            try
            {
                //string json = JsonSerializer.Serialize(request);
                _logger.LogInformation(@$"Employee created successfully : 
                                                 DataCreation Request:
                                                 {request}");

                if (request == null)
                {
                    return ResponseModel<bool>.Failure("Bad request");
                }

                // Get a employee by name
                var phone = await _employeeRepository.GetByAsync(p => p.Phone == request.Phone);

                if (phone != null)
                {
                    return ResponseModel<bool>.Failure("Phone number already exists");
                }

                // Get a employee by email
                var email = await _employeeRepository.GetByAsync(u => u.Email == request.Email);

                if (email != null)
                {
                    return ResponseModel<bool>.Failure("Email already exists");
                }


                var employee = new Employee
                {
                    Age = request.Age,
                    Datecreated = DateTime.UtcNow,
                    DateModified = DateTime.UtcNow,
                    Description = request.Description,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    MiddleName = request.MiddleName,
                    Phone = request.Phone,
                    Gender = request.Gender,
                    Title = request.Title
                };

                _employeeRepository.Add(employee);
                if (await _employeeRepository.SaveChangesAsync())
                {
                    _logger.LogInformation("Employee created successfully");
                    return ResponseModel<bool>.Success(true, "Employee created successfully");
                }
                else
                {
                    _logger.LogInformation("Error creating employee");
                    return ResponseModel<bool>.Failure("Error creating employee");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employee ");
                return ResponseModel<bool>.Failure("Error creating employee");
            }
        }

        public async Task<ResponseModel<bool>> UpdateEmployee(UpdateEmployeeDto request)
        {
            try
            {
                if (request == null)
                {
                    return ResponseModel<bool>.Failure("Bad request");
                }
                var employee = await _employeeRepository.GetByIdAsync(request.Id);
                if (employee == null)
                {
                    return ResponseModel<bool>.Failure("Employee not found");
                }


                employee.Age = request.Age;
                employee.FirstName = request.FirstName;
                employee.LastName = request.LastName;
                employee.MiddleName = request.MiddleName;
                employee.Phone = request.Phone;
                employee.Email = request.Email;
                employee.Description = request.Description;
                employee.Gender = request.Gender;
                employee.Title = request.Title;


                _employeeRepository.Update(employee);
                if (await _employeeRepository.SaveChangesAsync())
                {
                    _logger.LogInformation("Employee Updated successfully");
                    return ResponseModel<bool>.Success(true, "Employee Updated successfully");
                }
                else
                {
                    _logger.LogInformation("Error Updating employee");
                    return ResponseModel<bool>.Failure("Error Updating employee");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating employee");
                return ResponseModel<bool>.Failure("Error Updating employee");
            }
        }

        public async Task<ResponseModel<bool>> DeleteEmployee(Guid id)
        {
            try
            {

                var employee = await _employeeRepository.GetByIdAsync(id);
                if (employee == null)
                {
                    return ResponseModel<bool>.Failure("Employee not found");
                }

                _employeeRepository.Delete(employee);
                if (await _employeeRepository.SaveChangesAsync())
                {
                    _logger.LogInformation("Employee Deleted successfully");
                    return ResponseModel<bool>.Success(true, "Employee Deleted successfully");
                }
                else
                {
                    _logger.LogInformation("Error Deleting employee");
                    return ResponseModel<bool>.Failure("Error Deleting employee");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Deleting employee");
                return ResponseModel<bool>.Failure("Error Deleting employee");
            }
        }

        public async Task<ResponseModel<EmployeeDto>> GetEmployee(Guid id)
        {
            try
            {

                var employee = await _employeeRepository.GetByIdAsync(id);
                if (employee == null)
                {
                    return ResponseModel<EmployeeDto>.Failure("Employee not found");
                }


                var result = new EmployeeDto
                {
                    MiddleName = employee.FirstName,
                    Title = employee.LastName,
                    Gender = employee.Gender,
                    Description = employee.Description,
                    Email = employee.Email,
                    Age = employee.Age,
                    FirstName = employee.FirstName,
                    Id = employee.Id,
                    Phone = employee.Phone,
                    LastName = employee.LastName
                };

                return ResponseModel<EmployeeDto>.Success(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Deleting employee");
                return ResponseModel<EmployeeDto>.Failure("Error Deleting employee");
            }
        }

        public async Task<ResponseModel<List<EmployeeDto>>> GetEmployees()
        {
            try
            {

                var employees = await _employeeRepository.ListAllAsync();
                if (employees == null)
                {
                    return ResponseModel<List<EmployeeDto>>.Failure("Employee not found");
                }

                var result = employees.Select(x => new EmployeeDto
                {
                    Age = x.Age,
                    Description = x.Description,
                    Email = x.Email,
                    Gender = x.Gender,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Id = x.Id,
                    MiddleName = x.MiddleName,
                    Phone = x.Phone,
                    Title = x.Title

                }).ToList();

                return ResponseModel<List<EmployeeDto>>.Success(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching employee record");
                return ResponseModel<List<EmployeeDto>>.Failure("Error fetching employee record");
            }
        }
    }
}