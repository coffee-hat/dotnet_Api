using EmployeeManagement.Entities;

namespace EmployeeManagement.Dto.LeaveRequest;

public class EditLeaveRequest
{
    public int EmployeeId { get; set; }
    
    public LeaveRequestStatus? Status { get; set; }
    
    public DateTime RequestDate { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
}