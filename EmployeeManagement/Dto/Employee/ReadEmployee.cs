namespace EmployeeManagement.Dto.Employee;

public class ReadEmployee
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }
    
    public string email { get; set; }
    
    public string phoneNumber { get; set; }
    
    public string position { get; set; }
}