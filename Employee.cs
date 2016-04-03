namespace designIssueExample
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsSalaried { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Age} {IsSalaried}";
        }

        public override bool Equals(object obj)
        {
            var otherEmployee = obj as Employee;
            if (otherEmployee != null)
            {
                return Id == otherEmployee.Id
                       && Name == otherEmployee.Name
                       && Age == otherEmployee.Age
                       && IsSalaried == otherEmployee.IsSalaried;
            }
            return false;
        }
    }
}