using EmployeeManagement.Dto.Employee;

namespace EmployeeManagement.Services.Interfaces;

public interface IEmployeeService
{
    Task<ReadEmployee> CreateEmployee(EditEmployee employee);
    Task<int> DeleteEmployee(int employeeId);
    Task<ReadEmployee> UpdateEmployee(int employeeId, EditEmployee employee);
    Task<ReadEmployee> GetEmployee(int employeeId);
    Task<List<ReadEmployee>> GetEmployees();
}
