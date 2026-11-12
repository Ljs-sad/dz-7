namespace file
{
    public class DepartmentHead : Employee
    {
        public DepartmentHead(string name, string jobTitle, TypeDepartment department, Employee manager)
            : base(name, jobTitle, department, manager)
        {
        }
    }
}
