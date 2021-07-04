using Employees.DataAccess.Repositories;
using Employees.Domain.Abstractions;
using Employees.Domain.Services;
using Employees.Models.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Application
{
    public class AreaApp
    {
        private readonly IConfiguration _configuration;
        public AreaApp(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Area> ListarAreas()
        {
            IArea areaRepo = new AreaRepository(_configuration);
            AreaService areaService = new AreaService();

            return areaService.ListarAreas(areaRepo);
        }
    }
}
