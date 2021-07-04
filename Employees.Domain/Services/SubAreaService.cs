using Employees.Domain.Abstractions;
using Employees.Models.Entities;
using System.Collections.Generic;

namespace Employees.Domain.Services
{
    public class SubAreaService
    {
        public List<SubArea> ListarSubAreas(ISubArea subAreaRepo)
        {
            return subAreaRepo.ListarSubAreas();
        }
    }
}
