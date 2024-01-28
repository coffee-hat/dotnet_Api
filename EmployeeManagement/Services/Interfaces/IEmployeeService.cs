using EmployeeManagement.Dto.Employee;

namespace EmployeeManagement.Services.Interfaces;

public interface IEmployeeService
{
    Task<CreateEmployee> CreateEmployee(CreateEmployee employee);
    Task<int> DeleteEmployee(int employeeId);
    Task<int> UpdateEmployee(int employeeId, UpdateEmployee employee);
    Task<ReadEmployee> GetEmployee(int employeeId);
    Task<List<ReadEmployee>> GetEmployees();
    Task<EmployeeDepartment> AddEmployeeToDepartment(int employeeId, int departmentId);
}
