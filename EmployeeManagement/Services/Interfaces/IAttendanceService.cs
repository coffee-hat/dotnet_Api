using EmployeeManagement.Dto.Attendance;

namespace EmployeeManagement.Services.Interfaces;

public interface IAttendanceService
{
    Task<int> CreateAttendance(EditAttendance editAttendance);
    Task<int> DeleteAttendance(int attendanceId);
    Task<int> UpdateAttendance(int attendanceId, EditAttendance editAttendance);
    List<ReadAttendance> GetAttendances(int employeeId);
}