namespace EmployeeManagement.Dto.Attendance;

public class EditAttendance
{
    public int EmployeeId { get; set; }
    
    public DateTime ArrivingDate { get; set; }
    
    public DateTime DepartureDate { get; set; }
}