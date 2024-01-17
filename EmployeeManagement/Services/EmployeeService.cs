using EmployeeManagement.Dto.Employee;
using EmployeeManagement.Entities;
using EmployeeManagement.Repositories;

namespace EmployeeManagement.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public ReadEmployee CreateEmployee(CreateEmployee employee)
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
        var employeeCreated = employeeRepository.CreateEmployee(employeeToCreate);

        var result = employeeCreated.Result;
        return new ReadEmployee()
        {
            FirstName = result.FistName,
            LastName = result.LastName,
            BirthDate = result.BirthDate,
            email = result.Email,
            phoneNumber = result.PhoneNumber ?? "",
            position = result.Position ?? ""
        };
    }

    public Task DeleteEmployeeById(int employeeId)
    {
        throw new NotImplementedException();
    }
}