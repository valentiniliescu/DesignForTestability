using System.Collections.Generic;

namespace designIssueExample
{
    public class EmployeeStoreInMemory : IEmployeeStore
    {
        private readonly List<Employee> _employees;

        public EmployeeStoreInMemory()
        {
            _employees = new List<Employee>();
        }

        public void Add(IEnumerable<Employee> employees)
        {
            _employees.AddRange(employees);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }
    }
}