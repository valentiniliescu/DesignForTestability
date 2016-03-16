using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using designIssueExample;

namespace designIssueExampleTests
{
    [TestClass]
    public class YuckyTests
    {
        [TestMethod]
        [Ignore]
        public void GetEmployees_ShouldThrowOnNullFilter()
        {
            // TODO: add test when adding a employee store simulator
        }

        [TestMethod]
        public void GetEmployees_ShouldThrowOnNullStore()
        {
            Action a = () => new Yucky().GetEmployees(new EmployeeFilterExemptOnly(), null);
            a.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void GetEmployees_ShouldFilterByName()
        {
            Yucky yucky = new Yucky();
            var filter = new EmployeeFilterByNamePrefix("T");
            var store = new EmployeeStoreDatabase(new FakeSqlConnection());
            var employees = yucky.GetEmployees(filter, store);

            employees.Should().BeEquivalentTo(new Employee[] {
                new Employee {Name = "Ted theRed", Id = 35323, Age = 16, IsSalaried = false},
                new Employee {Name = "Tina Turnbull", Id = 35323, Age = 18, IsSalaried = false}
            });
        }

        [TestMethod]
        public void GetEmployees_ShouldFilterByExemption()
        {
            Yucky yucky = new Yucky();
            var filter = new EmployeeFilterExemptOnly();
            var store = new EmployeeStoreDatabase(new FakeSqlConnection());
            var employees = yucky.GetEmployees(filter, store);

            employees.Should().BeEquivalentTo(new Employee[] {
                new Employee {Name = "Fred Flintstone", Id = 35323, Age = 42, IsSalaried = true}
            });
        }
    }
}
