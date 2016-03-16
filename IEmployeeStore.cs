using System.Collections.Generic;

namespace designIssueExample
{
    public interface IEmployeeStore
    {
        void Add(IEnumerable<Employee> employees);
        IEnumerable<Employee> GetAllEmployees();
    }
}
