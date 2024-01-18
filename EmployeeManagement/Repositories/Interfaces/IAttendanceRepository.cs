using EmployeeManagement.Entities;

namespace EmployeeManagement.Repositories.Interfaces;

public interface IAttendanceRepository
{
    List<Attendance> GetAttendancesByEmployeeId(int employeeId);
    Task<Attendance?> GetAttendanceById(int attendanceId);
    Task<Attendance> CreateAttendance(Attendance attendance);
    Task<Attendance> UpdateAttendance(Attendance attendance);
    Task<int> DeleteAttendance(Attendance attendance);
}