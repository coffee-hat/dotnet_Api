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
    public async Task<ActionResult<int>> Delete(int employeeId)
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
    public async Task<ActionResult<int>> Get(int employeeId)
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
    
    [HttpPost("{employeeId}/departments/{departmentId}")]
    public async Task<ActionResult<int>> AddEmployeeToDepartmentAsync(int employeeId, int departmentId)
    {
        if (departmentId < 0)
        {
            return BadRequest("id can't be null");
        }

        try
        {
            var employeeDepartment = await employeeService.AddEmployeeToDepartment(employeeId, departmentId);
            return Ok($"add Employee to department succeeded");

        }
        catch(Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    
    [HttpPut("{employeeId}")]
    public async Task<ActionResult<int>> UpdateEmployee(int employeeId, [FromBody] UpdateEmployee employee)
    {
        try
        {
            var updatedEmployeeId = await employeeService.UpdateEmployee(employeeId, employee);
            return Ok(updatedEmployeeId);
        }
        catch (Exception ex) 
        { 
            return Problem(ex.Message);
        }
    }
}