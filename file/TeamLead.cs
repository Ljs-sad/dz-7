namespace file
{
    public class TeamLead: Employee
    {
        public TeamLead(string name, string jobTitle, TypeDepartment department, Employee manager)
            : base(name, jobTitle, department, manager)
        {
        }
    }
}
