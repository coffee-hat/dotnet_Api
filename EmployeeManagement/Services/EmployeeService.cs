using EmployeeManagement.Dto.Employee;
using EmployeeManagement.Entities;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Utils.Exception;

namespace EmployeeManagement.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public async Task<int> CreateEmployee(EditEmployee employee)
    {
        var employeeToCreate = new Employee()
        {
            FistName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            Email = employee.email,
            PhoneNumber = employee.phoneNumber,
            Position = employee.position
        };
        var employeeCreated = await employeeRepository.CreateEmployee(employeeToCreate);
        
        return employeeCreated.EmployeeId;
    }

    public async Task<int> DeleteEmployee(int employeeId)
    {
        var employee = await GetEmployeeEntity(employeeId);
        return await employeeRepository.DeleteEmployee(employee);
    }
    
    public Task<int> UpdateEmployee(int employeeId, EditEmployee employee)
    {
        throw new NotImplementedException();
        /*var currentEmployee = await employeeRepository.GetEmployeeById(employeeId);
        if (employee is null)
        {
            throw new ApiException(404, $"no employee found with id: {employeeId}");
        }

        employeeRepository.UpdateEmployee(employee);*/
    }

    public async Task<ReadEmployee> GetEmployee(int employeeId)
    {
        var employee = await GetEmployeeEntity(employeeId);
        return GetReadEmployee(employee);
    }
    
    public async Task<List<ReadEmployee>> GetEmployees()
    {
        var employees =  await employeeRepository.GetEmployees();
        return employees.Select(GetReadEmployee).ToList();
    }
    
    private static ReadEmployee GetReadEmployee(Employee employee)
    {
        return new ReadEmployee
        {
            FirstName = employee.FistName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            email = employee.Email,
            phoneNumber = employee.PhoneNumber ?? "",
            position = employee.Position ?? ""
        };
    }

    private async Task<Employee> GetEmployeeEntity(int employeeId)
    {
        var employee = await employeeRepository.GetEmployeeById(employeeId);
        return employee ?? throw new ApiException(404, $"no employee found with id: {employeeId}");
    }
}