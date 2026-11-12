namespace file
{
    public class Management : Employee
    {
        public Management(string name, string jobTitle, TypeDepartment department, Employee manager)
            : base(name, jobTitle, department, manager)
        {
        }
    }
}
