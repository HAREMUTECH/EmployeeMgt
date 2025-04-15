using EmployeeMgt.Domain.Dto;
using EmployeeMgt.Domain.Dto.Employee;
using EmployeeMgt.Domain.Implementation.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMgt.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmployeeService _employeeService;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
    {
        _logger = logger;
        _employeeService = employeeService;
    }


    [HttpPost("create")]
    [ProducesResponseType(typeof(ResponseModel<bool>), 200)]
    [ProducesResponseType(typeof(ResponseModel), 400)]
    public async Task<IActionResult> CreateAsync([FromForm] CreateEmployeeDto request)
    {
        var result = await _employeeService.CreateEmployee(request);

        return StatusCode(result.StatusCode, result);
    }

    [HttpPut("update")]
    [Authorize]
    [ProducesResponseType(typeof(ResponseModel<bool>), 200)]
    [ProducesResponseType(typeof(ResponseModel), 400)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateEmployeeDto request)
    {
        var result = await _employeeService.UpdateEmployee(request);

        return Ok(result);
    }

    [HttpGet("get-employees")]
    [ProducesResponseType(typeof(ResponseModel<List<EmployeeDto>>), 200)]
    [ProducesResponseType(typeof(ResponseModel), 400)]
    public async Task<IActionResult> GetAllList()
    {
        var result = await _employeeService.GetEmployees();
        return Ok(result);
    }


    [HttpGet, Route("get-employee/{employeeId}")]
    [ProducesResponseType(typeof(ResponseModel<EmployeeDto>), 200)]
    [ProducesResponseType(typeof(ResponseModel), 400)]
    public async Task<IActionResult> GetSingle([FromRoute] Guid employeeId)
    {
        var result = await _employeeService.GetEmployee(employeeId);

        return Ok(result);
    }


    [HttpDelete("delete")]
    [ProducesResponseType(typeof(ResponseModel<EmployeeDto>), 200)]
    [ProducesResponseType(typeof(ResponseModel), 400)]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        var result = await _employeeService.DeleteEmployee(id);

        return Ok(result);
    }
}
