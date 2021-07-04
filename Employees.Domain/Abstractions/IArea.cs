using Employees.Models.Entities;
using System.Collections.Generic;

namespace Employees.Domain.Abstractions
{
    public interface IArea
    {
        List<Area> ListarAreas();
    }
}
