using Employees.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Domain.Abstractions
{
    public interface IEmployee
    {
        List<Employee> ListarEmpleados();
        Task<bool> ActualizarEmpleado(Employee emp);
    }
}
