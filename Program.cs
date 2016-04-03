using System;

namespace designIssueExample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var yucky = new Yucky();
            var filter = EmployeeFilterFactory.CreateFilterByNamePrefix("T");
            var store = new EmployeeStoreDatabase(new FakeSqlConnection());

            var employees = yucky.GetEmployees(filter, store);

            foreach (var employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
    }
}