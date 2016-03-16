using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designIssueExample
{
    public class EmployeeStoreInMemory : IEmployeeStore
    {
        private List<Employee> _employees;

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
