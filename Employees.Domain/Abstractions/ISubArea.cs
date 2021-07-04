using Employees.Models.Entities;
using System.Collections.Generic;

namespace Employees.Domain.Abstractions
{
    public interface ISubArea
    {
        List<SubArea> ListarSubAreas();
    }
}
