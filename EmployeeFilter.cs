using System;

namespace designIssueExample
{
    using EmployeeFilter = Func<Employee, bool>;

    public static class EmployeeFilterFactory
    {
        public static readonly EmployeeFilter FilterExemptOnly = employee => employee != null && employee.Age >= 40 && employee.IsSalaried;

        public static EmployeeFilter CreateFilterByNamePrefix(string namePrefix)
        {
            if (namePrefix == null)
            {
                throw new ArgumentNullException(nameof(namePrefix));
            }

            return employee => employee?.Name != null && employee.Name.StartsWith(namePrefix);
        }
    }
}