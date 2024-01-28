using EmployeeManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories;

public class DepartmentRepository(ManageEmployeesContext dbContext) : IDepartmentRepository
{
    public async Task<List<Department>> GetDepartmentsAsync()
    {
        return await dbContext.Departments.ToListAsync();
    }

    public async Task<Department> GetDepartmentByIdAsync(int departmentId)
    {
        return await dbContext.Departments.FirstOrDefaultAsync(x => x.DepartmentId == departmentId);
    }

    public async Task<Department> GetDepartmentByIdWithIncludeAsync(int departmentId)
    {
        return await dbContext.Departments
            .Include(x => x.EmployeeDepartments)
            .FirstOrDefaultAsync(x => x.DepartmentId == departmentId);
    }

    public async Task<Department> GetDepartmentByNameAsync(string departmentName)
    {
        return await dbContext.Departments.FirstOrDefaultAsync(x => x.Name == departmentName);
    }

    public async Task UpdateDepartmentAsync(Department departmentToUpdate)
    {
        dbContext.Departments.Update(departmentToUpdate);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Department> CreateDepartmentAsync(Department departmentToCreate)
    {
        await dbContext.Departments.AddAsync(departmentToCreate);
        await dbContext.SaveChangesAsync();

        return departmentToCreate;
    }

    public async Task<Department> DeleteDepartmentByIdAsync(int departmentId)
    {
        var departmentToDelete = await dbContext.Departments.FindAsync(departmentId);
        dbContext.Departments.Remove(departmentToDelete);
        await dbContext.SaveChangesAsync();
        return departmentToDelete;
    }
}

