using EmployeeManagement.Entities;
using EmployeeManagement.Utils.Enum;

namespace EmployeeManagement.Repositories.Interfaces;

public interface ILeaveRequestRepository
{
    List<LeaveRequest> GetLeaveRequestByEmployeeId(int employeeId);
    Task<LeaveRequest?> GetLeaveRequestById(int employeeId);
    Task<LeaveRequest> CreateLeaveRequest(LeaveRequest leaveRequest);
    Task<LeaveRequest> UpdateLeaveRequest(LeaveRequest leaveRequest);
    Task<int> DeleteLeaveRequest(LeaveRequest leaveRequest);
    Task<List<LeaveRequestStatus>> GetLeaveRequestStatus();
}