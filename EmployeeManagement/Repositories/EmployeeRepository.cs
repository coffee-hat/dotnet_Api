using System.Data;
using EmployeeManagement.Entities;
using EmployeeManagement.Exception;
using EmployeeManagement.Infrastructure;
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

    public Task<Employee> UpdateEmployeeById(int employeeId, Employee employee)
    {
        throw new NotImplementedException();
    }

    public async Task<int> DeleteEmployeeById(Employee employee)
    {
        var deletedEmployee = dbContext.Employees.Remove(employee).Entity;
        await dbContext.SaveChangesAsync();
        return deletedEmployee.EmployeeId;
    }
}