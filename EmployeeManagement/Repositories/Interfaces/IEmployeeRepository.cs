using EmployeeManagement.Entities;

namespace EmployeeManagement.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetEmployees();
    Task<Employee?> GetEmployeeById(int employeeId);
    Task<Employee> CreateEmployeeAsync(Employee employeeToCreate);
    Task<Employee> UpdateEmployee(Employee employee);
    Task<int> DeleteEmployee(Employee employee);
    Task<Employee> GetEmployeeByEmailAsync(string employeeEmail);
    Task<EmployeeDepartment> AddEmployeeToDepartment(int employeeId, int departmentId);
    Task<EmployeeDepartment> GetEmployeeDepartment(int employeeId, int departmentId);
}