using Employees.DataAccess.Test.MockRepositories;
using Employees.Domain.Abstractions;
using Employees.Domain.Services;
using Employees.Models.Entities;
using System;
using Xunit;

namespace Employees.DataAccess.Test
{
    public class EmployeesMockTest
    {
        [Fact]
        public void ListEmployeesTest()
        {
            //Arrange
            IEmployee empRepo = new EmployeesRespositoryMock();
            EmployeesService empService = new EmployeesService();
            //Act
            var result = empService.ListarEmpleados(empRepo);
            //Assert
            Assert.NotNull(result);
        }
        /*[Fact]
        public void CreateJobMockTest()
        {
            //Arrange
            IEmployee jobRepo = new JobCRUDRepositoryMock();
            EmployeesService jobService = new EmployeesService();
            EmployeesInfo jobInfo = new EmployeesInfo()
            {
                JobNumber = 1,
                JobTitlePosition = "Data Scientist",
                JobDescription = "A data scientist is a professional responsible for collecting, analyzing and interpreting extremely large amounts of data.",
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(3)
            };
            //Act
            EmployeesInfo result = jobService.CreateJob(jobRepo, jobInfo);
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void UpdateJobMockTest()
        {
            //Arrange
            IEmployee jobRepo = new JobCRUDRepositoryMock();
            EmployeesService jobService = new EmployeesService();
            EmployeesInfo jobInfo = new EmployeesInfo()
            {
                JobNumber = 2,
                JobTitlePosition = "Software Developer",
                JobDescription = "A software developer is a company or person that creates software - either completely, or with other companies or people.",
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(3)
            };
            //Act
            EmployeesInfo result = jobService.UpdateJob(jobRepo, jobInfo);
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void DeleteJobMockTest()
        {
            //Arrange
            IEmployee jobRepo = new JobCRUDRepositoryMock();
            EmployeesService jobService = new EmployeesService();
            EmployeesInfo jobInfo = new EmployeesInfo()
            {
                JobNumber = 3,
                JobTitlePosition = " Information Security Analyst",
                JobDescription = "Information security analysts design and implement security measures to protect an organization's computer networks and systems.",
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(3)
            };
            //Act
            EmployeesInfo result = jobService.DeleteJob(jobRepo, jobInfo);
            //Assert
            Assert.NotNull(result);
        }*/
    }
}
