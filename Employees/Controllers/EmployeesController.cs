using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Employees.Application;
using Employees.DataAccess.Models;
using Employees.Models.Entities;
using Employees.Models.Generics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly EmployeesApp _empApp;
        public EmployeesController(IConfiguration configuration) 
        {
            _configuration = configuration;
            _empApp = new EmployeesApp(_configuration);
        }
        [HttpPost]
        [Authorize]
        [Route("ListEmployees")]
        public Result ListarEmpleados()
        {            
            List<Employee> emp = _empApp.ListarEmpelados();
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Empleados", emp);

            try
            {
                return new Result()
                {
                    code = 200,
                    status = "ok",
                    message = "Lista de empleados",
                    data = data
                };
            }
            catch (Exception e)
            {
                return new Result()
                {
                    status = "error",
                    code = 500,
                    message = e.InnerException.Message
                };
            }  
        }
        [HttpPost]
        [Authorize]
        [Route("UpdateEmployee")]
        public async Task<Result> ActualizarEmpleado(Employee empData)
        {
            bool updated = await _empApp.ActualizarEmpleado(empData);
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Updated", updated);

            try
            {
                return new Result()
                {
                    code = 200,
                    status = "ok",
                    message = "Lista de empleados",
                    data = data
                };
            }
            catch (Exception e)
            {
                return new Result()
                {
                    status = "error",
                    code = 500,
                    message = e.InnerException.Message
                };
            }
        }        
    }
}
