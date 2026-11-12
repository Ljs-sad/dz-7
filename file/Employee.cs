namespace file
{
    public class Employee
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public TypeDepartment Department { get; set; }
        public Employee Manager { get; set; }
        public Employee(string name, string jobTitle, TypeDepartment department, Employee manager)
        {
            Name = name;
            JobTitle = jobTitle;
            Department = department;
            Manager = manager;
        }

    }
}
