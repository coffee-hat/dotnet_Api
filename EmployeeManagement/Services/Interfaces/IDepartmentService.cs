using EmployeeManagement.Dto.Department;

namespace EmployeeManagement.Services.Interfaces;

public interface IDepartmentService
{
    Task<ReadDepartment> CreateDepartmentAsync(CreateDepartment department);
    
    //Task<ReadDepartment> DeleteDepartmentAsync(CreateDepartment department);
}