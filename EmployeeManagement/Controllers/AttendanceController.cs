using EmployeeManagement.Dto.Attendance;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttendanceController(IAttendanceService attendanceService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ReadAttendance>> Post([FromBody] EditAttendance attendance)
    {
        try
        {
            var result = await attendanceService.CreateAttendance(attendance);
            return Ok(result);
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpDelete("{attendanceId}")]
    public async Task<ActionResult<int>> Delete(int attendanceId)
    {
        if (attendanceId <= 0)
        {
            return BadRequest("error creation employee with this body");
        }

        try
        {
            var result = await attendanceService.DeleteAttendance(attendanceId);
            return Ok(result);
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpGet("{employeeId}")]
    public ActionResult<int> Get(int employeeId)
    {
        if (employeeId <= 0)
        {
            return BadRequest("error creation employee with this body");
        }

        try
        {
            var result = attendanceService.GetAttendances(employeeId);
            return Ok(result);
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
}