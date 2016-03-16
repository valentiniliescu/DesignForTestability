using System;
using System.Collections.Generic;

namespace designIssueExample
{
    public class EmployeeStoreDatabase : IEmployeeStore
    {
        private const int EmployeeIdColumnIndex = 0;
        private const int EmployeeNameColumnIndex = 1;
        private const int EmployeeAgeColumnIndex = 2;
        private const int EmployeeIsSalariedColumnIndex = 3;

        private FakeSqlConnection _connection;

        public EmployeeStoreDatabase(FakeSqlConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            _connection = connection;
        }

        public void Add(IEnumerable<Employee> employees)
        {
            //TODO: use INSERT INTO to add the employees to the database
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            string query = "select * from employee, employee_role inner join employee.Id == employee_role.EmployeeId";

            List<Employee> result = new List<Employee>();
            using (FakeSqlCommand sqlCommand = new FakeSqlCommand(query, _connection))
            {
                FakeSqlDataReader reader;
                int retryCount = 5;

                while (true)
                {
                    try
                    {
                        reader = sqlCommand.ExecuteReader();
                        break;
                    }
                    catch (Exception)
                    {
                        if (retryCount-- == 0) throw;
                    }
                }

                while (reader.Read())
                {
                    int id = reader.GetInt32(EmployeeIdColumnIndex);
                    string name = reader.GetString(EmployeeNameColumnIndex);
                    int age = reader.GetInt32(EmployeeAgeColumnIndex);
                    bool isSalaried = reader.GetBoolean(EmployeeIsSalariedColumnIndex);

                    yield return new Employee { Name = name, Id = id, Age = age, IsSalaried = isSalaried };
                }
            }
        }
    }
}
