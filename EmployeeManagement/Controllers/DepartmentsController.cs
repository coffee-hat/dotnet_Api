using EmployeeManagement.Dto.Department;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    // POST api/<DepartmentsController>
    [HttpPost]
    public async Task<ActionResult<ReadDepartment>> Post([FromBody] CreateDepartment department)
    {
        if (department == null || string.IsNullOrWhiteSpace(department.Name)
                               || string.IsNullOrWhiteSpace(department.Address) || string.IsNullOrWhiteSpace(department.Description))
        {
            return BadRequest("Echec de création d'un departement : les informations sont null ou vides");
        }

        try
        {
            var departmentCreated = await _departmentService.CreateDepartmentAsync(department);
            return Ok(departmentCreated);
        }
        catch (System.Exception ex)
        {
            return Problem(ex.Message);
        }
    }
    
    /*[HttpPost]
    public async Task<ActionResult<ReadDepartment>> Post([FromBody] CreateDepartment department)
    {
        if (department == null || string.IsNullOrWhiteSpace(department.Name)
                               || string.IsNullOrWhiteSpace(department.Address) || string.IsNullOrWhiteSpace(department.Description))
        {
            return BadRequest("Echec de création d'un departement : les informations sont null ou vides");
        }

        try
        {
            var departmentCreated = await _departmentService.CreateDepartmentAsync(department);
            return Ok(departmentCreated);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }*/
}