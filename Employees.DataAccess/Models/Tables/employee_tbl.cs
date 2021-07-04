using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Employees.DataAccess.Models.Tables
{
    public class employee_tbl
    {
        [Key]
        public Guid id { get; set; }
        public string doc { get; set; }
        public int id_doc { get; set; }
        public string doc_name { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public int id_subarea { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string subarea_name { get; set; }
        public int idsubarea { get; set; }
        public string area_name { get; set; }
        public int idarea { get; set; }
    }
}
