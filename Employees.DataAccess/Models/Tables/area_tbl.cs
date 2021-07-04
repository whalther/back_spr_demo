using System;

namespace Employees.DataAccess.Models.Tables
{
    public partial class area_tbl
    {
        public int id { get; set; }
        public string area_name { get; set; }
        public int estado { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
