using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Dto.Employee;

public class CreateEmployee
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }
    
    [Required]
    [EmailAddress]
    public string email { get; set; }
    [Required]
    [Phone]
    public string phoneNumber { get; set; }
    
    [Required]
    [StringLength(150)]
    public string position { get; set; }
}