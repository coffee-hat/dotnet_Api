

using EmployeeManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories;

public class EmployeeRepository(ManageEmployeesContext dbContext) : IEmployeeRepository
{
    public async Task<List<Employee>> GetEmployees()
    {
        return await dbContext.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeById(int employeeId)
    {
        return await dbContext.Employees.FindAsync(employeeId);
    }

    public async Task<Employee> CreateEmployeeAsync(Employee employeeToCreate)
    {
        await dbContext.Employees.AddAsync(employeeToCreate);
        dbContext.SaveChanges();

        return employeeToCreate;
    }
    
    public async Task<Employee> GetEmployeeByEmailAsync(string employeeEmail)
    {
        return await dbContext.Employees.FirstOrDefaultAsync(x => x.Email == employeeEmail);
    }

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        var updatedEmployee = dbContext.Employees.Update(employee);
        await dbContext.SaveChangesAsync();
        return updatedEmployee.Entity;
    }

    public async Task<int> DeleteEmployee(Employee employee)
    {
        var deletedEmployee = dbContext.Employees.Remove(employee).Entity;
        await dbContext.SaveChangesAsync();
        return deletedEmployee.EmployeeId;
    }
    
    public async Task<EmployeeDepartment> AddEmployeeToDepartment(int employeeId, int departmentId)
    {
        var employee = await dbContext.Employees.FirstOrDefaultAsync(d => d.EmployeeId == employeeId);
        var department = await dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

        var employeeDepartment = new EmployeeDepartment { EmployeeId = employeeId, DepartmentId = departmentId };

        dbContext.EmployeeDepartments.Add(employeeDepartment);
        await dbContext.SaveChangesAsync();

        return employeeDepartment;
    }
    public async Task<EmployeeDepartment> GetEmployeeDepartment(int employeeId, int departmentId)
    {
        return await dbContext.EmployeeDepartments.FirstOrDefaultAsync(ed => ed.EmployeeId == employeeId && ed.DepartmentId == departmentId);
    }
}