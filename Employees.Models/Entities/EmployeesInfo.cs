using System;

namespace Employees.Models.Entities
{
    public class EmployeesInfo
    {
        public int JobNumber { get; set; }
        public string JobTitlePosition { get; set; }
        public string JobDescription { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
