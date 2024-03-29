﻿using System;
using System.Collections.Generic;
using EmployeeManagement.Entities;

namespace EmployeeManagement.Entities;

public partial class EmployeeDepartment
{
    public int EmployeeDepartmentId { get; set; }

    public int EmployeeId { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
