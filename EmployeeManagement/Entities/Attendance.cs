﻿using System;
using System.Collections.Generic;

namespace EmployeeManagement;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public DateTime ArrivingDate { get; set; }

    public DateTime? DepartureDate { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
