using EmployeeManagement.Dto.Employee;

namespace EmployeeManagement.Services.Interfaces;

public interface IEmployeeService
{
    Task<int> CreateEmployee(CreateEmployee employee);
    Task<int> DeleteEmployee(int employeeId);
    Task<int> UpdateEmployee(int employeeId, CreateEmployee employee);
    Task<ReadEmployee> GetEmployee(int employeeId);
    Task<List<ReadEmployee>> GetEmployees();
}
