using EmployeeManagement.Entities;

namespace EmployeeManagement.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetEmployees();
    Task<Employee?> GetEmployeeById(int employeeId);
    Task<Employee> CreateEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    Task<int> DeleteEmployee(Employee employee);
}