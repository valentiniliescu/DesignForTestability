using System;

namespace designIssueExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Yucky yucky = new Yucky();
            var filter =  EmployeeFilterFactory.CreateFilterByNamePrefix("T");
            var store = new EmployeeStoreDatabase(new FakeSqlConnection());

            var employees = yucky.GetEmployees(filter, store);

            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

        }
    }
}
