using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees.Application;
using Employees.Models.Entities;
using Employees.Models.Generics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EmployeesNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubAreaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SubAreaApp _subAreaApp;
        public SubAreaController(IConfiguration configuration)
        {
            _configuration = configuration;
            _subAreaApp = new SubAreaApp(_configuration);
        }
        [HttpPost]
        [Authorize]
        [Route("ListSubArea")]
        public Result ListarSubAreas()
        {            
            List<SubArea> subAreas = _subAreaApp.ListarSubAreas();
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("SubAreas", subAreas);

            try
            {
                return new Result()
                {
                    code = 200,
                    status = "ok",
                    message = "Lista de Sub Areas",
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
