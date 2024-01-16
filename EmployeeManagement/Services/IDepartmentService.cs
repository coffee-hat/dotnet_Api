﻿using EmployeeManagement.Dto.Department;

namespace EmployeeManagement.Services;

public interface IDepartmentService
{
    Task<ReadDepartment> CreateDepartmentAsync(CreateDepartment department);
}