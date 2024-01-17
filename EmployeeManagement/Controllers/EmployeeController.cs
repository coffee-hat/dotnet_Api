using EmployeeManagement.Dto.Department;
using EmployeeManagement.Dto.Employee;
using EmployeeManagement.Services;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController(IEmployeeService employeeService) : ControllerBase
{
    [HttpPost]
    public ActionResult<ReadDepartment> Post([FromBody] EditEmployee employee)
    {
        if (employee is null)
        {
            return BadRequest("error creation employee with this body");
        }

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
}