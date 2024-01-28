using EmployeeManagement.Repositories.Interfaces;

namespace EmployeeManagement.Repositories;

public class AttendanceRepository(ManageEmployeesContext dbContext) : IAttendanceRepository
{
    public List<Attendance> GetAttendancesByEmployeeId(int employeeId)
    {
        return dbContext.Attendances
            .Where(a => a.EmployeeId == employeeId)
            .ToList();
    }
    
    public async Task<Attendance?> GetAttendanceById(int attendanceId)
    {
        return await dbContext.Attendances.FindAsync(attendanceId);
    }

    public async Task<Attendance> CreateAttendance(Attendance attendance)
    {
        var createdAttendance =  await dbContext.Attendances.AddAsync(attendance);
        await dbContext.SaveChangesAsync();
        return createdAttendance.Entity;
    }

    public async Task<Attendance> UpdateAttendance(Attendance attendance)
    {
        var updatedAttendance = dbContext.Attendances.Update(attendance).Entity;
        await dbContext.SaveChangesAsync();
        return updatedAttendance;
    }

    public async Task<int> DeleteAttendance(Attendance attendance)
    {
        var deletedAttendance = dbContext.Attendances.Remove(attendance).Entity;
        await dbContext.SaveChangesAsync();
        return deletedAttendance.AttendanceId;
    }
}