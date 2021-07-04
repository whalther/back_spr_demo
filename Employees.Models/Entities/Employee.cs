using System;

namespace Employees.Models.Entities
{
    public class Employee
    {
        public Guid IdEmployee { get; set; }
        public EmployeeDocument DocumentType { get; set; }
        public string Document { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public SubArea Subarea { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
