using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atomus.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Atomus.Models;
using Atomus.Repositories;

namespace Atomus.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void DisplayResultsTest()
        {
            IEnumerable<Employee> employees = new List<Employee>
            {
                new Employee() {FirstName = "Niesha", LastName = "Throssell", City = "Wilmington"},
                new Employee() {FirstName = "Peter", LastName = "Teplica", City = "Marldon"}
            };

            var employeeRepositoryMock = new Moq.Mock<IEmployeeRepository>();

            employeeRepositoryMock.Setup(x => x.GetEmployees()).Returns(employees).Verifiable();

            HomeController controller = new HomeController(employeeRepositoryMock.Object);

            var results = controller.DisplayResults();
           
            employeeRepositoryMock.VerifyAll();
        }
    }
}
