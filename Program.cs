using System;

namespace designIssueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Yucky yucky = new Yucky();
            var filter = new EmployeeFilterByNamePrefix("T");

            var employees = yucky.GetEmployees(filter, new FakeSqlConnection());

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

        }
    }
}
