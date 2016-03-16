using System;

namespace designIssueExample
{
    public interface IEmployeeFilter
    {
        bool Is(Employee employee);
    }

    public class EmployeeFilterByNamePrefix : IEmployeeFilter
    {
        private string _namePrefix;

        public EmployeeFilterByNamePrefix(string namePrefix)
        {
            if (namePrefix == null)
            {
                throw new ArgumentNullException("namePrefix");
            }

            _namePrefix = namePrefix;
        }

        public bool Is(Employee employee)
        {
            return employee != null && employee.Name.StartsWith(_namePrefix);
        }
    }

    public class EmployeeFilterExemptOnly : IEmployeeFilter
    {
        public bool Is(Employee employee)
        {
            return employee != null && employee.Age >= 40 && employee.IsSalaried;
        }
    }
}
