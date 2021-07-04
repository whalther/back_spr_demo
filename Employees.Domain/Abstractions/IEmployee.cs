using Employees.Models.Entities;
using Employees.Models.Generics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.Abstractions
{
    public interface IEmployee
    {
        List<Employee> ListarEmpleados();
        Task<bool> ActualizarEmpleado(Employee emp);
    }
}
