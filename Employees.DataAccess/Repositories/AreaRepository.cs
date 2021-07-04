using Employees.DataAccess.Models;
using Employees.DataAccess.Models.Tables;
using Employees.Domain.Abstractions;
using Employees.Models.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Employees.DataAccess.Repositories
{
    public class AreaRepository : IArea
    {
        private readonly IConfiguration _configuration;
        public AreaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Area> ListarAreas()
        {
            List<Area> areas;
            List<area_tbl> areaList;

            using (MyDbContext context = new MyDbContext(_configuration))
            {
                areaList = context.area.FromSqlRaw("[dbo].[getAreas] {0}", 1).ToList();
            }

            areas = (from a in areaList
                     select new Area()
                     {
                         IdArea = a.id,
                         AreaName = a.area_name,
                         AreaEstado = a.estado,
                         Created = a.created_at,
                         Updated = a.updated_at
                     }).ToList();

            return areas;
        }
    }
}
