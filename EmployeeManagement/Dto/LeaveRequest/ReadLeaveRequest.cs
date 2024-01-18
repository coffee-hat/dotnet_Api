using EmployeeManagement.Utils.Enum;

namespace EmployeeManagement.Dto.LeaveRequest;

public class ReadLeaveRequest
{
    public int Id { get; set; }
    
    public int EmployeeId { get; set; }
    
    public LeaveRequestStatusEnum StatusEnum { get; set; }
    
    public DateTime RequestDate { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
}