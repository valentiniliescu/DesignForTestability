using designIssueExample;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace designIssueExampleTests
{
    [TestClass]
    public class EmployeeStoreTests
    {
        private IEmployeeStore _CreateEmployeeStore()
        {
            return new EmployeeStoreInMemory();
        }

        [TestMethod]
        public void Add_ToEmptyStoreShouldAddEmployees()
        {
            var store = _CreateEmployeeStore();
            var employees = new Employee[] {
                new Employee {Name = "Ted theRed", Id = 35323, Age = 16, IsSalaried = false},
                new Employee {Name = "Tina Turnbull", Id = 35323, Age = 18, IsSalaried = false}
            };

            store.Add(employees);

            store.GetAllEmployees().Should().BeEquivalentTo(employees);
        }

        [TestMethod]
        public void Add_MultipleTimesToStoreShouldAddAllEmployees()
        {
            var store = _CreateEmployeeStore();
            var employees1 = new Employee[] {
                new Employee {Name = "Ted theRed", Id = 35323, Age = 16, IsSalaried = false},
                new Employee {Name = "Tina Turnbull", Id = 35323, Age = 18, IsSalaried = false}
            };
            var employees2 = new Employee[] {
                new Employee { Id = 35323, Name = "Fred Flintstone", Age = 42, IsSalaried = true },
                new Employee { Id = 35323, Name = "Barney Rubble", Age = 38, IsSalaried = true },
            };

            store.Add(employees1);
            store.Add(employees2);

            var employees = employees1.Union(employees2);
            store.GetAllEmployees().Should().BeEquivalentTo(employees);
        }
    }
}
