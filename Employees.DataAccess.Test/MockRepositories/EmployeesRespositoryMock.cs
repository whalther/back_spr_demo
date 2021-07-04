using Employees.Domain.Abstractions;
using Employees.Models.Entities;
using System;
using System.Collections.Generic;

namespace Employees.DataAccess.Test.MockRepositories
{
    public class EmployeesRespositoryMock : IEmployee
    {
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
        /*public EmployeesInfo CreateJob(EmployeesInfo jobInfo)
        {
           return jobInfo;
        }

        public EmployeesInfo DeleteJob(EmployeesInfo jobInfo)
        {
           return jobInfo;
        }

        public List<EmployeesInfo> ListJobs()
        {
           List<EmployeesInfo> jobs = new List<EmployeesInfo>();
           jobs.Add(new EmployeesInfo()
           {
               JobNumber = 1,
               JobTitlePosition = "Data Scientist",
               JobDescription = "A data scientist is a professional responsible for collecting, analyzing and interpreting extremely large amounts of data.",
               CreatedAt = DateTime.Now,
               ExpiresAt = DateTime.Now.AddDays(3)
           });
           jobs.Add(new EmployeesInfo()
           {
               JobNumber = 2,
               JobTitlePosition = "Software Developer",
               JobDescription = "A software developer is a company or person that creates software - either completely, or with other companies or people.",
               CreatedAt = DateTime.Now,
               ExpiresAt = DateTime.Now.AddDays(3)
           });
           jobs.Add(new EmployeesInfo()
           {
               JobNumber = 3,
               JobTitlePosition = " Information Security Analyst",
               JobDescription = "Information security analysts design and implement security measures to protect an organization's computer networks and systems.",
               CreatedAt = DateTime.Now,
               ExpiresAt = DateTime.Now.AddDays(3)
           });
           return jobs;
        }

        public EmployeesInfo UpdateJob(EmployeesInfo jobInfo)
        {
           return jobInfo;
        }*/

    }
}
