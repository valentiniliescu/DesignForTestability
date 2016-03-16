using System.Collections.Generic;

namespace designIssueExample
{
    public interface IEmployeeStore
    {
        IEnumerable<Employee> GetAllEmployees();
    }
}
