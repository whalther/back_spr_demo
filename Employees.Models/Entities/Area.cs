using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Models.Entities
{
    public class Area
    {
        public int IdArea { get; set; }
        public string AreaName { get; set; }
        public int AreaEstado { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
