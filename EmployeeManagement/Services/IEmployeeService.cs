using EmployeeManagement.Dto.Employee;

namespace EmployeeManagement.Services;

public interface IEmployeeService
{
    ReadEmployee CreateEmployee(CreateEmployee employee);
    
    Task DeleteEmployeeById(int employeeId);
}
