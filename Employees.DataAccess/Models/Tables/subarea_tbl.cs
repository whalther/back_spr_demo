using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.DataAccess.Models.Tables
{
    public partial class subarea_tbl
    {
        public int id { get; set; }
        public string subarea_name { get; set; }
        public int id_area { get; set; }
        public int estado { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
