using EmployeeManagement.Dto.Employee;
using EmployeeManagement.Entities;
using EmployeeManagement.Exception;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public async Task<ReadEmployee> CreateEmployee(EditEmployee employee)
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
        
        return GetReadEmployee(employeeCreated);
    }

    public async Task<int> DeleteEmployee(int employeeId)
    {
        var employee = await employeeRepository.GetEmployeeById(employeeId);
        if (employee is null)
        {
            throw new ApiException(404, $"no employee found with id: {employeeId}");
        }
        return await employeeRepository.DeleteEmployee(employee);
    }
    
    public Task<ReadEmployee> UpdateEmployee(int employeeId, EditEmployee employee)
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
        
        var employee = await employeeRepository.GetEmployeeById(employeeId);
        if (employee is null)
        {
            throw new ApiException(404, $"no employee found with id: {employeeId}");
        }

        return GetReadEmployee(employee);
    }
    
    public async Task<List<ReadEmployee>> GetEmployees()
    {
        var employees =  await employeeRepository.GetEmployees();

        return employees.Select(e =>
        {
            return GetReadEmployee(e);
        }).ToList();
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
}