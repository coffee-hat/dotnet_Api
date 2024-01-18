using EmployeeManagement.Dto.LeaveRequest;

namespace EmployeeManagement.Services.Interfaces;

public interface ILeaveRequestService
{
    Task<int> CreateLeaveRequest(EditLeaveRequest editLeaveRequest);
    Task<int> DeleteLeaveRequest(int leaveRequestId);
    Task<int> UpdateLeaveRequest(int leaveRequestId, EditLeaveRequest editLeaveRequest);
    Task<List<ReadLeaveRequest>> GetLeaveRequests(int employeeId);
}