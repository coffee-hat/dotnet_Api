using EmployeeManagement.Dto.Employee;
using EmployeeManagement.Entities;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Utils.Exception;

namespace EmployeeManagement.Services;

public class EmployeeService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository) : IEmployeeService
{
    public async Task<CreateEmployee> CreateEmployee(CreateEmployee employee)
    {
        /*var findEmployee = await employeeRepository.GetEmployeeByEmailAsync(employee.email);
        if (findEmployee != null) 
        {
            throw new Exception("Email need to by unique");
        }*/
        var employeeToCreate = new Employee
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            PhoneNumber = employee.phoneNumber,
            Email = employee.email,
            Position = employee.position
        };
        var employeeCreated = await employeeRepository.CreateEmployeeAsync(employeeToCreate);
        
        return employee;
    }

    public async Task<int> DeleteEmployee(int employeeId)
    {
        var employee = await GetEmployeeEntity(employeeId);
        return await employeeRepository.DeleteEmployee(employee);
    }
    
    public async Task<int> UpdateEmployee(int employeeId, UpdateEmployee employee)
    {
        var currentEmployee = await employeeRepository.GetEmployeeById(employeeId);
        if (currentEmployee is null)
        {
            throw new ApiException(404, $"no employee found with id: {employeeId}");
        }
        var findEmployee = await employeeRepository.GetEmployeeByEmailAsync(employee.email);
        if (findEmployee != null) 
        {
            throw new ApiException("Email need to by unique");
        }

        currentEmployee.FirstName = employee.FirstName;
        currentEmployee.LastName = employee.LastName;
        currentEmployee.BirthDate = employee.BirthDate;
        currentEmployee.Email = employee.email;
        currentEmployee.PhoneNumber = employee.phoneNumber;
        currentEmployee.Position = employee.position;
        var newEmployee = await employeeRepository.UpdateEmployee(currentEmployee);
        return newEmployee.EmployeeId;
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
    
    public async Task<EmployeeDepartment> AddEmployeeToDepartment(int employeeId,int departmentId)
    {
        var currentEmployee = await employeeRepository.GetEmployeeById(employeeId)
            ?? throw new ApiException($"employee don't exist : {employeeId}");
        var currentDepartment = await departmentRepository.GetDepartmentByIdAsync(departmentId)
            ?? throw new Exception($"department don't exist : {departmentId}");

        if (currentEmployee == null && currentDepartment ==  null) 
        {
            throw new ApiException("Error can't add employee in department");
        }

        var currentEmployeeInDepartment = await employeeRepository.GetEmployeeDepartment(currentEmployee.EmployeeId, currentDepartment.DepartmentId);
        if (currentEmployeeInDepartment != null)
        {
            throw new ApiException("current employee have already a department");
        }

        var addEmployee = await employeeRepository.AddEmployeeToDepartment(currentEmployee.EmployeeId, currentDepartment.DepartmentId);
        return addEmployee;
    }
    
    private static ReadEmployee GetReadEmployee(Employee employee)
    {
        return new ReadEmployee
        {
            Id = employee.EmployeeId,
            FirstName = employee.FirstName,
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