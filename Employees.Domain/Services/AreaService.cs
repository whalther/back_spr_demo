using Employees.Domain.Abstractions;
using Employees.Models.Entities;
using System.Collections.Generic;

namespace Employees.Domain.Services
{
    public class AreaService
    {
        public List<Area> ListarAreas(IArea areaRepo)
        {
            return areaRepo.ListarAreas();
        }
    }
}
