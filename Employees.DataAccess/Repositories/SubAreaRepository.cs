using Employees.DataAccess.Models;
using Employees.DataAccess.Models.Tables;
using Employees.Domain.Abstractions;
using Employees.Models.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Employees.DataAccess.Repositories
{
    public class SubAreaRepository : ISubArea
    {
        private readonly IConfiguration _configuration;
        public SubAreaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<SubArea> ListarSubAreas()
        {
            List<SubArea> subAreas;
            List<subarea_tbl> subAreaList;

            using (MyDbContext context = new MyDbContext(_configuration))
            {
                subAreaList = context.subarea.FromSqlRaw("[dbo].[getSubAreas] {0}", 1).ToList();
            }

            subAreas = (from a in subAreaList
                        select new SubArea()
                         {
                             IdSubArea = a.id,
                             SubAreaName = a.subarea_name,
                             SubAreaEstado = a.estado,
                             Area = new Area() 
                             {
                                 IdArea = a.id_area
                             },
                             Created = a.created_at,
                             Updated = a.updated_at
                         }).ToList();

            return subAreas;
        }
    }
}
