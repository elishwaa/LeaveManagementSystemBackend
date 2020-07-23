using Moq;
using NUnit.Framework;
using System;
using LeaveManagementSystemService;
using LeaveManagementSystemRepository;
using LeaveManagementSystemModels;

namespace LeaveManagementSystemTest
{
    [TestFixture]
    public class ServiceTest
    {

        [Test]
        public void EmployeeService_Should_Add_Employee()
        {
            var repository = new Mock<IEmployeeRepository>();
            var employeeService = new EmployeeService(repository.Object);

            //Act
            repository.Setup(x => x.Add(It.IsAny<EmployeeAddRequest>())).Returns(true);
            var result = employeeService.Add(new EmployeeAddRequest());
            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void EmployeeService_Should_Get_Employee()
        {
            var repository = new Mock<IEmployeeRepository>();
            var employeeService = new EmployeeService(repository.Object);
            var employee = new Employee { Id = 1 };

            //Act
            repository.Setup(x => x.Get(1)).Returns(employee);
            var result = employeeService.Get(1); ;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employee.Id, result.Id);
        }
    }
}
