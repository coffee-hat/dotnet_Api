using EmployeeManagement.Entities;
using EmployeeManagement.Infrastructure;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories;

public class EmployeeRepository(EmployeeManagementDbContext dbContext) : IEmployeeRepository
{
    public async Task<List<Employee>> GetEmployees()
    {
        return await dbContext.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeById(int employeeId)
    {
        return await dbContext.Employees.FindAsync(employeeId);
    }

    public async Task<Employee> CreateEmployee(Employee employee)
    {
        var createdEmployee =  await dbContext.Employees.AddAsync(employee);
        await dbContext.SaveChangesAsync();
        return createdEmployee.Entity;
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
}