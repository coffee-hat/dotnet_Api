using EmployeeManagement.Dto.Department;
using EmployeeManagement.Dto.Employee;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpPost]
    public ActionResult<ReadDepartment> Post([FromBody] CreateEmployee employee)
    {
        try
        {
            var employeeCreated = employeeService.CreateEmployee(employee);
            return Ok(employeeCreated);
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpDelete("{employeeId}")]
    public async Task<ActionResult<int>> Delete([FromQuery] int employeeId)
    {
        if (employeeId <= 0)
        {
            return BadRequest("error creation employee with this body");
        }

        try
        {
            var result = await employeeService.DeleteEmployee(employeeId);
            return Ok(result);
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpGet("{employeeId}")]
    public async Task<ActionResult<int>> Get([FromQuery] int employeeId)
    {
        if (employeeId <= 0)
        {
            return BadRequest("error creation employee with this body");
        }

        try
        {
            var result = await employeeService.GetEmployee(employeeId);
            return Ok(result);
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ReadEmployee>>> Get()
    {
        try
        {
            var result = await employeeService.GetEmployees();
            return Ok(result);
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
}