using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Models.Entities
{
    public class SubArea
    {
        public int IdSubArea { get; set; }
        public string SubAreaName { get; set; }
        public Area Area { get; set; }
        public int SubAreaEstado { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
