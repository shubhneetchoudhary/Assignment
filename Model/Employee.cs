using System;
using System.Collections.Generic;

namespace Mamsys_Employee_API.Model
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeFirstName { get; set; }
        public string? EmployeeMiddleName { get; set; }
        public string? EmployeeLastName { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public bool? Status { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
