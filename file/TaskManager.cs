namespace file
{
    public class TaskManager
    {
        private readonly List<string> _tasksArchive = new List<string>();

        public void AssignTask(Task task, Employee sender, Employee receiver)
        {
            Console.WriteLine($"От {sender.Name} ({sender.JobTitle}) даётся задача '{task.Name}' {receiver.Name} ({receiver.JobTitle})");

            string comment;

            if (receiver != null && receiver.Manager == sender)
            {
                comment = "Задача успешно назначена";
                Console.WriteLine($"- {receiver.Name} берёт задачу.\n");
            }
            else
            {
                comment = "отправитель не является прямым руководителем или его заместителем";
                Console.WriteLine($"- {receiver.Name} отклоняет задачу (по причине: {comment}).\n");
            }

            _tasksArchive.Add($"Задача: {task.Name}, \nОтправитель: {sender.Name}, \nПолучатель: {receiver.Name}, \nКомментарий: {comment}\n");
        }
    }
}
