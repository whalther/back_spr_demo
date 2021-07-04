using Employees.Domain.Abstractions;
using Employees.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.DataAccess.Test.MockRepositories
{
    public class EmployeesRespositoryMock : IEmployee
    {
        public Task<bool> ActualizarEmpleado(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> ListarEmpleados()
        {
            List<Employee> emps = new List<Employee>();
            emps.Add(new Employee()
            {
                IdEmployee = Guid.NewGuid(),
                EmployeeName = "Juan",
                EmployeeLastName = "Martinez",
                Created = DateTime.Now
            });

            return emps;
        }     
    }
}
