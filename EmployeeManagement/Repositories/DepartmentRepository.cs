using EmployeeManagement.Entities;
using EmployeeManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly EmployeeManagementDbContext _dbContext;

    public DepartmentRepository(EmployeeManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Department>> GetDepartmentsAsync()
    {
        return await _dbContext.Departments.ToListAsync();
    }

    public async Task<Department> GetDepartmentByIdAsync(int departmentId)
    {
        return await _dbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentId == departmentId);
    }

    public async Task<Department> GetDepartmentByIdWithIncludeAsync(int departmentId)
    {
        return await _dbContext.Departments
            .Include(x => x.EmployeeDepartments)
            .FirstOrDefaultAsync(x => x.DepartmentId == departmentId);
    }

    public async Task<Department> GetDepartmentByNameAsync(string departmentName)
    {
        return await _dbContext.Departments.FirstOrDefaultAsync(x => x.Name == departmentName);
    }

    public async Task UpdateDepartmentAsync(Department departmentToUpdate)
    {
        _dbContext.Departments.Update(departmentToUpdate);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Department> CreateDepartmentAsync(Department departmentToCreate)
    {
        await _dbContext.Departments.AddAsync(departmentToCreate);
        await _dbContext.SaveChangesAsync();

        return departmentToCreate;
    }

    public async Task<Department> DeleteDepartmentByIdAsync(int departmentId)
    {
        var departmentToDelete = await _dbContext.Departments.FindAsync(departmentId);
        _dbContext.Departments.Remove(departmentToDelete);
        await _dbContext.SaveChangesAsync();
        return departmentToDelete;
    }
}

