namespace file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();

            Management timur = new Management("Тимур", "Генеральный директор", TypeDepartment.Management, null);
            Management rachid = new Management("Рашид", "Финансовый директор", TypeDepartment.Management, timur);
            Management oilham = new Management("О Ильхам", "Директор по автоматизации", TypeDepartment.Management, timur);

            DepartmentHead lukas = new DepartmentHead("Лукас", "Главный бухгалтер", TypeDepartment.Accounting, rachid);

            DepartmentHead orkadiy = new DepartmentHead("Оркадий", "Начальник информационных систем", TypeDepartment.Management, oilham);
            DepartmentHead volodya = new DepartmentHead("Володя", "Заместитель информационных систем", TypeDepartment.Management, orkadiy);

            TeamLead ilschat = new TeamLead("Ильшат", "Главный в секторе системщиков", TypeDepartment.Systems, volodya);
            Worker ivanich = new Worker("Иваныч", "Заместитель в секторе системщиков", TypeDepartment.Systems, ilschat);
            Worker iliya = new Worker("Илья", "Системщик", TypeDepartment.Systems, ivanich);
            Worker genya = new Worker("Женя", "Системщик", TypeDepartment.Systems, ivanich);
            Worker vitya = new Worker("Витя", "Системщик", TypeDepartment.Systems, ivanich);

            TeamLead sergey = new TeamLead("Сергей", "Главный в секторе разработчиков", TypeDepartment.Development, volodya);
            Worker leysan = new Worker("Лейсан", "Заместитель в секторе разработчиков", TypeDepartment.Development, sergey);
            Worker marat = new Worker("Марат", "Разработчик", TypeDepartment.Development, leysan);
            Worker dina  = new Worker("Дина", "Разработчик", TypeDepartment.Development, leysan);
            Worker ildar = new Worker("Ильдар", "Разработчик", TypeDepartment.Development, leysan);
            Worker anton = new Worker("Антон", "Разработчик", TypeDepartment.Development, leysan);

            Task devTask = new Task("Автоматизировать бухгалтерию", TypeDepartment.Development);
            Task sysTask = new Task("Обновить прошивку микроволновок", TypeDepartment.Systems);

            Console.WriteLine("Симуляция назначения задач:\n");

            taskManager.AssignTask(devTask, volodya, sergey);

            taskManager.AssignTask(sysTask, ivanich, vitya);

            taskManager.AssignTask(sysTask, ilschat, vitya);

            taskManager.AssignTask(devTask, lukas, marat);
        }
    }
}
