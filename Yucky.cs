using System;
using System.Collections.Generic;
using System.Linq;

namespace designIssueExample
{
    using EmployeeFilter = Func<Employee, bool>;

    public class Yucky
    {
        public IEnumerable<Employee> GetEmployees(EmployeeFilter filter, IEmployeeStore store)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            if (store == null)
            {
                throw new ArgumentNullException("store");
            }

            return store.GetAllEmployees().Where(filter);
        }
    }
}
