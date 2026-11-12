namespace MetodichkaTumakov
{
    internal class Program
    {
        static decimal GetDecimal(string prompt)
        {
            Console.Write(prompt);
            decimal summ;
            while (!decimal.TryParse(Console.ReadLine(), out summ) || summ <= 0)
            {
                Console.Write("Ошибка! Введите число больше нуля: ");
            }
            return summ;
        }
        public static void Task1()
        {
            Console.WriteLine("- Упражение 8.1 (дополнение к 7.1 - 7.)-");
            Console.WriteLine("-  Создание банковского счёта  -");

            decimal balance;
            Console.WriteLine("\nВведите баланс: ");
            while (!decimal.TryParse(Console.ReadLine(), out balance) || balance < 0)
            {
                Console.Write("Ошибка. Введите положительное число: ");
            }

            Console.WriteLine("\nВыберите тип счёта:\n" +
                "1 - Текущий\n2 - Сберегательный\n");

            AccountType type = AccountType.Current;
            bool flag = false;

            do
            {
                Console.Write("Введите цифру (1 или 2): ");
                string input = Console.ReadLine();
                int choice;

                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            type = AccountType.Current;
                            flag = true;
                            break;
                        case 2:
                            type = AccountType.Savings;
                            flag = true;
                            break;
                        default:
                            Console.WriteLine("Ошибка: Введите число от 1 до 2.");
                            flag = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: Нужно ввести цифру.");
                    flag = false;
                }

            } while (!flag);

            BankAccount account1 = new BankAccount(balance, type);
            BankAccount account2 = new BankAccount(balance, type);

            Console.WriteLine("\nСчёт успешно создан!");
            account1.PrintInfo();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- Меню ---");
                Console.WriteLine("1. Пополнить счет");
                Console.WriteLine("2. Снять деньги");
                Console.WriteLine("3. Показать баланс");
                Console.WriteLine("4. Перевести деньги с одного счёта на другой");
                Console.WriteLine("0. Выйти");
                Console.Write("Выберите действие: ");

                string menuInput = Console.ReadLine();

                if (int.TryParse(menuInput, out int action))
                {
                    switch (action)
                    {
                        case 1:
                            decimal depsumm = GetDecimal("Введите сумму для пополнения: ");
                            account1.Deposit(depsumm);
                            break;
                        case 2:
                            decimal witsumm = GetDecimal("Введите сумму для снятия: ");
                            account1.Withdraw(witsumm);
                            break;
                        case 3:
                            account1.PrintInfo();
                            break;
                        case 4:
                            decimal summaFromTo = GetDecimal("Введите сумму для перевода: ");
                            account2.FromAccountToAccount(account1, summaFromTo);
                            break;
                        case 0:
                            exit = true;
                            Console.WriteLine("Выход.");
                            break;
                        default:
                            Console.WriteLine("Ошибка: Такого пункта нет в меню.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите номер пункта меню (цифру).");
                }
                Console.ReadKey();
            }

            Console.ReadKey();
        }
        public static void Task2()
        {
            Console.WriteLine("\n- Упражнение 8.2 -");
            Console.WriteLine("Введите непустую строку: ");
            string str = Console.ReadLine();
            string revers = Methods.Reverse(str);
            Console.WriteLine($"Перевернутая строка: {revers}");
            Console.ReadKey();
        }
        public static void Task3()
        {
            Console.WriteLine("\n- Упражнение 8.3 -");

            string pathFiles = "..\\..\\..\\Files";
            List<string> fileNames = Directory.GetFiles(pathFiles).Select(Path.GetFileNameWithoutExtension).ToList();

            Console.Write("Имеющиеся файлы (поиск и копирование идёт в .txt):\n");
            foreach (var nameFile in fileNames)
            {
                Console.Write($"{nameFile}\n");
            }

            Console.Write("\nВведите название файла: ");
            string nameFileEnter = Console.ReadLine();

            if (string.IsNullOrEmpty(nameFileEnter))
            {
                Console.WriteLine("Ошибка. Имя файла не может быть пустым.");
                return;
            }

            if (!fileNames.Contains(nameFileEnter))
            {
                Console.WriteLine("Данного файла не существует.");
            }
            else
            {
                string pathOutputFile = $"..\\..\\..\\Files\\{nameFileEnter}_Output.txt";

                string pathFile = $"..\\..\\..\\Files\\{nameFileEnter}.txt";
                string textFileInital = File.ReadAllText(pathFile);

                string upperFileContent = textFileInital.ToUpper();

                File.WriteAllText(pathOutputFile, upperFileContent);

                Console.WriteLine($"Создан файл с копией содержимого с заглавными буквами : {pathOutputFile}");
            }
            Console.ReadKey();  
        }
        public static void Task4()
        {
            Console.WriteLine("\n- Упражнение 8.4 -");

            int number = 20;
            string text = "Привет!";
            DateTime data = DateTime.Now;
            int[] array = { 1, 2, 3 };
            object nullObj = null;

            Console.WriteLine($"Проверка с оператором 'as':\n" +
                $"Int: {Methods.CheckWithAs(number)}\n" +
                $"String: {Methods.CheckWithAs(text)}\n" +
                $"DateTime: {Methods.CheckWithAs(data)}\n" +
                $"Array: {Methods.CheckWithAs(array)}\n" +
                $"Null: {Methods.CheckWithAs(nullObj)}");

            Console.WriteLine($"\nПроверка с оператором 'is':\n" +
                $"Int: {Methods.CheckWithIs(number)}\n" +
                $"String: {Methods.CheckWithIs(text)}\n" +
                $"DateTime: {Methods.CheckWithIs(data)}\n" +
                $"Array: {Methods.CheckWithIs(array)}\n" +
                $"Null: {Methods.CheckWithIs(nullObj)}");

            Console.ReadKey();
        }
        public static void Homework1()
        {
            Console.WriteLine("\n- Домашнее задание 8.1 -");

            string pathfile = "..\\..\\..\\files\\EmailsFile.txt";

            string[] textFile = File.ReadAllLines(pathfile);
            string pathNewFile = "..\\..\\..\\files\\EmailsFileNew.txt";

            for (int i = 0; i < textFile.Length; i++)
            {
                string line = textFile[i];
                Methods.SearchMail(ref line);
                textFile[i] = line;
            }
            File.WriteAllLines(pathNewFile, textFile);

            Console.WriteLine($"Содержание выходного файла: ");
            string[] newTextFile = File.ReadAllLines(pathNewFile);
            foreach (string line in newTextFile)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }
        public static void HomeWork2()
        {
            Console.WriteLine("\n- Домашнее задание 8.2 -");

            Song song1 = new Song();
            song1.SetAuthor("Бюро");
            song1.SetName("Реки зацветут");

            Song song2 = new Song();
            song2.SetAuthor("guntor");
            song2.SetName("Звёзды налету");
            
            Song song3 = new Song();
            song3.SetAuthor("RASVET");
            song3.SetName("Дождь");

            Song song4 = new Song();      
            song4.SetAuthor("RASVET");
            song4.SetName("Юность");

            Console.WriteLine($"Сравнение первой и второй песни: {song1.Equals(song2)}");
            Console.WriteLine("\nВывод песен: ");

            song2.SetPrev(song1);
            song3.SetPrev(song2);
            song4.SetPrev(song3);

            Song current = song4;

            while (current != null)
            {
                Console.WriteLine(current.Title());
                current = current.GetPrev();
            }

            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Homework1();
            HomeWork2();
        }
    }
}
