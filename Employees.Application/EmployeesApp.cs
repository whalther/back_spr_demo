using Employees.DataAccess.Models;
using Employees.DataAccess.Repositories;
using Employees.Domain.Abstractions;
using Employees.Domain.Services;
using Employees.Models.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application
{
    public class EmployeesApp
    {
        private readonly IConfiguration _configuration;
        public EmployeesApp(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Employee> ListarEmpelados()
        {
            IEmployee empRepo = new EmployeesRepository(_configuration);
            EmployeesService empService = new EmployeesService();

            return empService.ListarEmpleados(empRepo);
        }
        public async Task<bool> ActualizarEmpleado(Employee emp)
        {
            IEmployee empRepo = new EmployeesRepository(_configuration);
            EmployeesService empService = new EmployeesService();

            return await empService.ActualizarEmpleado(empRepo, emp);
        }
    }
}
