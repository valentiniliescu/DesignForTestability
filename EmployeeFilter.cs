using System;

namespace designIssueExample
{
    using EmployeeFilter = Func<Employee, bool>;

    public static class EmployeeFilterFactory
    {
        public static readonly EmployeeFilter FilterExemptOnly = employee => employee != null && employee.Age >= 40 && employee.IsSalaried;

        public static readonly Func<string, EmployeeFilter> CreateFilterByNamePrefix = namePrefix => employee => employee?.Name != null && employee.Name.StartsWith(namePrefix);
    }
}