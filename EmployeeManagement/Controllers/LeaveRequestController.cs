using EmployeeManagement.Dto.LeaveRequest;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController(ILeaveRequestService leaveRequestService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ReadLeaveRequest>> Post([FromBody] EditLeaveRequest leaveRequest)
    {
        try
        {
            var result = await leaveRequestService.CreateLeaveRequest(leaveRequest);
            return Ok(result);
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpDelete("{leaveRequestId}")]
    public async Task<ActionResult<int>> Delete(int leaveRequestId)
    {
        if (leaveRequestId <= 0)
        {
            return BadRequest("error creation employee with this body");
        }

        try
        {
            var result = await leaveRequestService.DeleteLeaveRequest(leaveRequestId);
            return Ok(result);
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
    
    [HttpGet("{employeeId}")]
    public async Task<ActionResult<List<ReadLeaveRequest>>> Get(int employeeId)
    {
        if (employeeId <= 0)
        {
            return BadRequest("error creation employee with this body");
        }

        try
        {
            var result = await leaveRequestService.GetLeaveRequests(employeeId);
            return Ok(result);
        }
        catch (System.Exception e)
        {
            return Problem(e.Message);
        }
    }
}