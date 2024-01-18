using EmployeeManagement.Dto.Attendance;
using EmployeeManagement.Entities;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Utils.Exception;

namespace EmployeeManagement.Services;

public class AttendanceService(IAttendanceRepository attendanceRepository) : IAttendanceService
{
    public async Task<int> CreateAttendance(EditAttendance editAttendance)
    {
        var attendanceToCreate = new Attendance
        {
            EmployeeId = editAttendance.EmployeeId,
            DepartureDate = editAttendance.DepartureDate,
            ArrivingDate = editAttendance.ArrivingDate
        };
        var attendanceCreated = await attendanceRepository.CreateAttendance(attendanceToCreate);
        
        return attendanceCreated.AttendanceId;
    }

    public async Task<int> DeleteAttendance(int attendanceId)
    {
        var attendance = await GetAttendanceEntity(attendanceId);
        return await attendanceRepository.DeleteAttendance(attendance);
    }

    public Task<int> UpdateAttendance(int attendanceId, EditAttendance editAttendance)
    {
        throw new NotImplementedException();
    }

    public List<ReadAttendance> GetAttendances(int employeeId)
    {
        var attendances = attendanceRepository.GetAttendancesByEmployeeId(employeeId);
        return attendances.Select(GetReadAttendance).ToList();
    }
    
    private async Task<Attendance> GetAttendanceEntity(int attendanceId)
    {
        var attendance = await attendanceRepository.GetAttendanceById(attendanceId);
        return attendance ?? throw new ApiException(404, $"no attendance found with id: {attendanceId}");
    }
    
    private static ReadAttendance GetReadAttendance(Attendance attendance)
    {
        return new ReadAttendance
        {
            Id = attendance.AttendanceId,
            EmployeeId = attendance.EmployeeId,
            ArrivingDate = attendance.ArrivingDate,
            DepartureDate = attendance.DepartureDate
        };
    }
}