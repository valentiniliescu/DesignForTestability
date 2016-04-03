using designIssueExample;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace designIssueExampleTests
{
    [TestClass]
    public class YuckyTests
    {
        private IEmployeeStore _CreateEmployeeStoreInMemory()
        {
            var store = new EmployeeStoreInMemory();
            store.Add(new Employee[] {
                new Employee { Id = 35323, Name = "Fred Flintstone", Age = 42, IsSalaried = true },
                new Employee { Id = 35323, Name = "Barney Rubble", Age = 38, IsSalaried = true },
                new Employee { Id = 35323, Name = "Ted theRed", Age = 16, IsSalaried = false },
                new Employee { Id = 35323, Name = "Tina Turnbull", Age = 18, IsSalaried = false }
            });

            return store;
        }

        [TestMethod]
        public void GetEmployees_ShouldThrowOnNullFilter()
        {
            Action a = () => new Yucky().GetEmployees(null, new EmployeeStoreInMemory());
            a.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void GetEmployees_ShouldThrowOnNullStore()
        {
            Action a = () => new Yucky().GetEmployees(EmployeeFilterFactory.FilterExemptOnly, null);
            a.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void GetEmployees_ShouldFilterByName()
        {
            Yucky yucky = new Yucky();
            var filter =  EmployeeFilterFactory.CreateFilterByNamePrefix("T");
            var store = _CreateEmployeeStoreInMemory();
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
            var filter = EmployeeFilterFactory.FilterExemptOnly;
            var store = _CreateEmployeeStoreInMemory();
            var employees = yucky.GetEmployees(filter, store);

            employees.Should().BeEquivalentTo(new Employee[] {
                new Employee {Name = "Fred Flintstone", Id = 35323, Age = 42, IsSalaried = true}
            });
        }
    }
}
