using Employees.Domain.Abstractions;
using Employees.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Domain.Services
{
    public class EmployeesService
    {
        public List<Employee> ListarEmpleados(IEmployee empRepo)
        {
            return empRepo.ListarEmpleados();
        }
        public async Task<bool> ActualizarEmpleado(IEmployee empRepo , Employee emp) 
        {
            return await empRepo.ActualizarEmpleado(emp);
        }
    }
}
