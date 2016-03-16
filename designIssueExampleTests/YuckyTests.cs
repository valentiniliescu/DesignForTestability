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
        public void GetEmployees_ShouldThrowOnByNameFilterTypeAndNullFilter()
        {
            Action a = () => new Yucky().GetEmployees(null, null);
            a.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void GetEmployees_ShouldFilterByName()
        {
            Yucky yucky = new Yucky();
            var filter = new EmployeeFilterByNamePrefix("T");
            var employees = yucky.GetEmployees(filter, new FakeSqlConnection());

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
            var employees = yucky.GetEmployees(filter, new FakeSqlConnection());

            employees.Should().BeEquivalentTo(new Employee[] {
                new Employee {Name = "Fred Flintstone", Id = 35323, Age = 42, IsSalaried = true}
            });
        }
    }
}
