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
    public class AreaController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly AreaApp areaApp;
        public AreaController(IConfiguration configuration)
        {
            Configuration = configuration;
            areaApp = new AreaApp(Configuration);
        }
        [HttpPost]
        [Authorize]
        [Route("ListArea")]
        public Result ListarAreas()
        {            
            List<Area> emp = areaApp.ListarAreas();
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Areas", emp);

            try
            {
                return new Result()
                {
                    code = 200,
                    status = "ok",
                    message = "Lista de Areas",
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
