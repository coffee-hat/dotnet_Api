using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Dto.Employee;

public class UpdateEmployee
{
    [StringLength(50)]
    public string FirstName { get; set; }
    
    [StringLength(50)]
    public string LastName { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    [EmailAddress]
    public string email { get; set; }
    
    [Phone]
    public string phoneNumber { get; set; }
    
    [StringLength(150)]
    public string position { get; set; }
}