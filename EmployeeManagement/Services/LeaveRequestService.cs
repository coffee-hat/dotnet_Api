using EmployeeManagement.Dto.Attendance;
using EmployeeManagement.Dto.LeaveRequest;
using EmployeeManagement.Entities;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Utils.Enum;
using EmployeeManagement.Utils.Exception;

namespace EmployeeManagement.Services;

public class LeaveRequestService(ILeaveRequestRepository leaveRequestRepository) : ILeaveRequestService
{
    public async Task<int> CreateLeaveRequest(EditLeaveRequest editLeaveRequest)
    {
        var statusId = await GetLeaveRequestStatusId(LeaveRequestStatusEnum.Pending);
        var leaveRequestToCreate = new LeaveRequest
        {
            EmployeeId = editLeaveRequest.EmployeeId,
            RequestDate = editLeaveRequest.RequestDate,
            StartDate = editLeaveRequest.StartDate,
            EndDate = editLeaveRequest.EndDate,
            LeaveRequestStatusId = statusId
        };
        var leaveRequestCreated = await leaveRequestRepository.CreateLeaveRequest(leaveRequestToCreate);
        
        return leaveRequestCreated.LeaveRequestId;
    }

    public async Task<int> DeleteLeaveRequest(int leaveRequestId)
    {
        var leaveRequest = await GetLeaveRequestEntity(leaveRequestId);
        return await leaveRequestRepository.DeleteLeaveRequest(leaveRequest);
    }

    public Task<int> UpdateLeaveRequest(int leaveRequestId, EditLeaveRequest editLeaveRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ReadLeaveRequest>> GetLeaveRequests(int employeeId)
    {
        var leaveRequest = leaveRequestRepository.GetLeaveRequestByEmployeeId(employeeId);

        var readLeaveRequestList = new List<ReadLeaveRequest>();
        foreach (var lr in leaveRequest)
        {
            var readLeaveRequest = await GetReadLeaveRequest(lr);
            readLeaveRequestList.Add(readLeaveRequest);
        }
        
        return readLeaveRequestList;
    }
    
    private async Task<LeaveRequest> GetLeaveRequestEntity(int leaveRequestId)
    {
        var attendance = await leaveRequestRepository.GetLeaveRequestById(leaveRequestId);
        return attendance ?? throw new ApiException(404, $"no leaveRequest found with id: {leaveRequestId}");
    }

    private async Task<int> GetLeaveRequestStatusId(LeaveRequestStatusEnum status)
    {
        var leaveRequestStatusList = await leaveRequestRepository.GetLeaveRequestStatus();
        
        var leaveRequestStatus = leaveRequestStatusList.FirstOrDefault(lrs =>
            string.Equals(lrs.Status, status.ToString(), StringComparison.CurrentCultureIgnoreCase));
        if (leaveRequestStatus is null)
        {
            throw new ApiException(500, $"Internal error: cannot find leaver request status {status} id");
        }

        return leaveRequestStatus.LeaveRequestStatusId;
    }
    
    private async Task<LeaveRequestStatusEnum> GetLeaveRequestStatusEnum(int id)
    {
        var leaveRequestStatusList = await leaveRequestRepository.GetLeaveRequestStatus();
        
        var leaveRequestStatus = leaveRequestStatusList.FirstOrDefault(lrs => lrs.LeaveRequestStatusId == id);
        if (leaveRequestStatus is null)
        {
            throw new ApiException(500, $"Internal error: cannot find leaver request status with id {id}");
        }

        return Enum.Parse<LeaveRequestStatusEnum>(leaveRequestStatus.Status);
    }
    
    private async Task<ReadLeaveRequest> GetReadLeaveRequest(LeaveRequest leaveRequest)
    {
        var statusEnum = await GetLeaveRequestStatusEnum(leaveRequest.LeaveRequestStatusId);
        return new ReadLeaveRequest
        {
           Id = leaveRequest.LeaveRequestId,
           EmployeeId = leaveRequest.EmployeeId,
           RequestDate = leaveRequest.RequestDate,
           StartDate = leaveRequest.StartDate,
           EndDate = leaveRequest.EndDate,
           StatusEnum = statusEnum
        };
    }
}