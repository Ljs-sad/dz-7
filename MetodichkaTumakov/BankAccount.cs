namespace MetodichkaTumakov
{
    public class BankAccount
    {
        private string accountNumber;
        private decimal balance;
        private AccountType accountType;

        public BankAccount(decimal balance, AccountType accountType)
        {
            this.accountNumber = Guid.NewGuid().ToString();
            this.balance = balance;
            this.accountType = accountType;
        }

        public string GetAccountNumber() => accountNumber;
        public decimal GetBalance() => balance;
        public AccountType GetAccountType() => accountType;

        public void SetAccountType(AccountType newAccountType)
        {
            accountType = newAccountType;
        }
        public void SetBalance(decimal newBalance)
        {
            if (newBalance >= 0)
                balance = newBalance;
            else
                Console.WriteLine("Ошибка. Баланс не может быть отрицательным.");
        }

        public void PrintInfo()
        {
            string type = "";
            switch (accountType)
            {
                case AccountType.Current:
                    type = "Текущий";
                    break;
                case AccountType.Savings:
                    type = "Сберегательный";
                    break;
            }
            Console.WriteLine($"\nНомер счёта: {accountNumber}\nБаланс: {balance}\nТип: {type}");
        }

        public void Deposit(decimal summ)
        {
            balance += summ;
            Console.WriteLine($"Счёт пополнен на {summ}. Текущий баланс: {balance}");
        }

        public void Withdraw(decimal summ)
        {
            if (summ > balance)
            {
                Console.WriteLine($"Недостаточно средств! на счету только {balance}.");
            }
            else
            {
                balance -= summ;
                Console.WriteLine($"Снято {summ}. Текущий баланс: {balance}");
            }
        }

        public void FromAccountToAccount(BankAccount fromAccount, decimal summa)
        {
            if (fromAccount.balance >= summa)
            {
                fromAccount.balance -= summa;
                balance += summa;
                Console.WriteLine($"{summa} рублей переведено.");
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счёте отправителя.");
            }
        }
    }
}
