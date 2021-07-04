using Employees.DataAccess.Test.MockRepositories;
using Employees.Domain.Abstractions;
using Employees.Domain.Services;
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
        public void CreateJobEmployeeTest()
        {      
            Assert.NotNull(result);
        }
        [Fact]
        public void UpdateEmployeeMockTest()
        {
            Assert.NotNull(result);
        }
        [Fact]
        public void DeleteEmployeeMockTest()
        {   
            Assert.NotNull(result);
        }*/
    }
}
