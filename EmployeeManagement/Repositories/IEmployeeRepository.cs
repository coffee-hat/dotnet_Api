using EmployeeManagement.Entities;

namespace EmployeeManagement.Repositories;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetEmployees();
    Task<Employee?> GetEmployeeById(int employeeId);
    Task<Employee> CreateEmployee(Employee employee);
    Task<Employee> UpdateEmployeeById(int employeeId, Employee employee);
    Task<int> DeleteEmployeeById(Employee employee);
}