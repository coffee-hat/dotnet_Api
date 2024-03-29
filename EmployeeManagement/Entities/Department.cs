﻿using System;
using System.Collections.Generic;

namespace EmployeeManagement;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; } = new List<EmployeeDepartment>();
}
