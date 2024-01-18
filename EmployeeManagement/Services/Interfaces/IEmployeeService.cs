using EmployeeManagement.Dto.Employee;

namespace EmployeeManagement.Services.Interfaces;

public interface IEmployeeService
{
    Task<int> CreateEmployee(EditEmployee employee);
    Task<int> DeleteEmployee(int employeeId);
    Task<int> UpdateEmployee(int employeeId, EditEmployee employee);
    Task<ReadEmployee> GetEmployee(int employeeId);
    Task<List<ReadEmployee>> GetEmployees();
}
