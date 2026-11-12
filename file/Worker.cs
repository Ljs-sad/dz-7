namespace file
{
    public class Worker: Employee
    {
        public Worker(string name, string jobTitle, TypeDepartment department, Employee manager)
            : base(name, jobTitle, department, manager)
        {
        }
    }
}
