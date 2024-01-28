using EmployeeManagement.Dto.Department;
using EmployeeManagement.Services;
using EmployeeManagement.Services.Interfaces;
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
    
    [HttpDelete("{departmentId}")]
    public async Task<ActionResult<int>> Delete(int departmentId)
    {
        if (departmentId <= 0)
        {
            return BadRequest("error delete department with this id");
        }

        try
        {
            var result = await _departmentService.DeleteDepartmentById(departmentId);
            return Ok(result);
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult> GetDepartments()
    {
        return Ok(await _departmentService.GetDepartments());
    }
    
    [HttpPut("{departmentId}")]
    public async Task<IActionResult> PutDepartment(int departmentId,[FromBody] UpdateDepartment department)
    {
        if (department == null || string.IsNullOrWhiteSpace(department.Name)
                               || string.IsNullOrWhiteSpace(department.Address) || string.IsNullOrWhiteSpace(department.Description))
        {
            return BadRequest("Echec de la mise à jour d'un departement : les informations sont null ou vides");
        }

        try
        {
            await _departmentService.UpdateDepartmentAsync(departmentId, department);
            return Ok("update succeeded");
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }
}