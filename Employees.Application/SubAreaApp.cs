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
    public class SubAreaApp
    {
        private readonly IConfiguration _configuration;
        public SubAreaApp(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<SubArea> ListarSubAreas()
        {
            ISubArea subAreaRepo = new SubAreaRepository(_configuration);
            SubAreaService subAreaSerivice = new SubAreaService();

            return subAreaSerivice.ListarSubAreas(subAreaRepo);
        }
    }
}
