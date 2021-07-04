using Employees.DataAccess.Models;
using Employees.Domain.Abstractions;
using Employees.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Employees.DataAccess.Models.Tables;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;

namespace Employees.DataAccess.Repositories
{
    public class EmployeesRepository : IEmployee
    {
        private readonly IConfiguration _configuration;

        public EmployeesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Employee> ListarEmpleados()
        {
            List<Employee> empleados;
            List<employee_tbl> empList;
            using (MyDbContext context = new MyDbContext(_configuration))
            {
                empList = context.employee.FromSqlRaw($"[dbo].[getAllEmployees]").ToList();
            }
            empleados = (from e in empList
                         select new Employee()
                         {
                             IdEmployee = e.id,
                             DocumentType = new EmployeeDocument()
                             {
                                 idDoc = e.id_doc,
                                 docType = e.doc_name
                             },
                             Document = e.doc,
                             EmployeeName = e.name,
                             EmployeeLastName = e.lastname,
                             Created = e.created_at,
                             Updated = e.updated_at,
                             Subarea = new SubArea() 
                             {
                                 IdSubArea = e.idsubarea,
                                 SubAreaName = e.subarea_name,
                                 Area = new Area()
                                 {
                                     IdArea = e.idarea,
                                     AreaName = e.area_name
                                 }
                             }

                         }).ToList();

            return empleados;
        }
        public async Task<bool> ActualizarEmpleado(Employee emp)
        {
            if(emp.IdEmployee != null) {
                try
                {
                    var empData = new SqlParameter("@empData", JsonConvert.SerializeObject(emp));
                    var sp = new SqlParameter("@SP", _configuration["UpdateSPEmp"]);
                    using (MyDbContext context = new MyDbContext(_configuration))
                    {
                        await Task.Run(() => {
                            context.Database.ExecuteSqlRaw($"EXEC @SP @empData",
                             sp,
                             empData);
                        }).ConfigureAwait(false);
                    }
                    return true;
                }
                catch (Exception)
                {
                    //*Save Error log*//
                    return false;
                }
            }
            return false;
        }
    }
}
