using EmployeeManagement.Entities;
using EmployeeManagement.Infrastructure;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Utils.Enum;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories;

public class LeaveRequestRepository(EmployeeManagementDbContext dbContext) : ILeaveRequestRepository
{
    public List<LeaveRequest> GetLeaveRequestByEmployeeId(int employeeId)
    {
        return dbContext.LeaveRequests
            .Where(a => a.EmployeeId == employeeId)
            .ToList();
    }
    
    public async Task<LeaveRequest?> GetLeaveRequestById(int leaveRequestId)
    {
        return await dbContext.LeaveRequests.FindAsync(leaveRequestId);
    }

    public async Task<LeaveRequest> CreateLeaveRequest(LeaveRequest leaveRequest)
    {
        var createdLeaveRequests =  await dbContext.LeaveRequests.AddAsync(leaveRequest);
        await dbContext.SaveChangesAsync();
        return createdLeaveRequests.Entity;
    }

    public async Task<LeaveRequest> UpdateLeaveRequest(LeaveRequest leaveRequest)
    {
        var updatedLeaveRequests = dbContext.LeaveRequests.Update(leaveRequest).Entity;
        await dbContext.SaveChangesAsync();
        return updatedLeaveRequests;
    }

    public async Task<int> DeleteLeaveRequest(LeaveRequest leaveRequest)
    {
        var deletedLeaveRequests = dbContext.LeaveRequests.Remove(leaveRequest).Entity;
        await dbContext.SaveChangesAsync();
        return deletedLeaveRequests.LeaveRequestId;
    }

    public async Task<List<LeaveRequestStatus>> GetLeaveRequestStatus()
    {
        return await dbContext.LeaveRequestStatuses.ToListAsync();
    }
}