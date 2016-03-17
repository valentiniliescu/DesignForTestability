using System;

namespace designIssueExample
{
    using EmployeeFilter = Func<Employee, bool>;

    public static class EmployeeFilterFactory
    {
        public static EmployeeFilter CreateFilterByNamePrefix(string namePrefix)
        {
            if (namePrefix == null)
            {
                throw new ArgumentNullException("namePrefix");
            }

            return (Employee employee) => employee?.Name?.StartsWith(namePrefix) ?? false;
        }

        public static EmployeeFilter CreateFilterExemptOnly()
        {
            return (Employee employee) => employee?.Age >= 40 && (employee?.IsSalaried ?? false);
        }
    }
}
