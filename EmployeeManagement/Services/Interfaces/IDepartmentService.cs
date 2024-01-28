using EmployeeManagement.Dto.Department;

namespace EmployeeManagement.Services.Interfaces;

public interface IDepartmentService
{
    Task<ReadDepartment> CreateDepartmentAsync(CreateDepartment department);
    Task<int> DeleteDepartmentById(int departmentId);

    Task<List<ReadDepartment>> GetDepartments();

    Task UpdateDepartmentAsync(int departmentId, UpdateDepartment department);
}