using DevInBank.AccountSystem.Entities;
using System.Transactions;
using static DevInBank.AccountSystem.Enums.Enumerators;

namespace DevInBank.AccountSystem
{
    public abstract class Account

    {
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Adress { get; private set; }
        public decimal MonthlyIncome { get; private set; }
        public int AccoutNumber { get; private set; }
        public decimal Balance { get; protected set; }
        public AgenciesEnum Agencies { get; private set; }
        public AccountTypeEnum typeOfAccount { get; private set; }
        public List<Transactions> TransactionList { get; private set; }

        protected Account(string name, string cpf, string adress, decimal monthlyIncome, int accoutNumber, AgenciesEnum agencies, AccountTypeEnum accountType)
        {
            Name = name;
            Cpf = cpf;
            Adress = adress;
            MonthlyIncome = monthlyIncome;
            AccoutNumber = accoutNumber + 1;
            Balance = 0;
            Agencies = agencies;
            typeOfAccount = accountType;
            TransactionList = new List<Transactions>();
        }

        public virtual void Withdraw(decimal amount, Account account)
        {
            if (amount > Balance)
            {
                throw new Exception("Saque não efetuado devido a falta de saldo");
            }
            Balance -= amount;
            TransactionList.Add(new Transactions(AccoutNumber, amount, "Saque"));
            Console.WriteLine($"Efetuado o saque de{amount:C2}R$ ");
        }

        public void BalanceInfo()
        {
            Console.WriteLine($"Seu saldo é {Balance:C2}\n");
        }

        public void Deposit(decimal amount, Account ToAccount)
        {
            ToAccount.Balance +=  amount;
            TransactionList.Add(new Transactions(ToAccount.AccoutNumber, amount, "Deposito"));
        }

        public void BankStatement()
        {
            Console.Clear();
            Console.WriteLine($"Ola {Name}. \n");

            foreach (var transaction in TransactionList)
            {
                if(TransactionList.Count == 0)
                {
                    Console.WriteLine("Lista de transações vazia");
                }

                if (transaction.TransactionType == "Corrente" || transaction.TransactionType == "Deposito")
                {
                    Console.WriteLine($"Tipo da transação ------> {transaction.TransactionType}\n");
                    Console.WriteLine($"Data da transação ------> {transaction.DateTime}\n");
                    Console.WriteLine($"Valor da Transação -----> `{transaction.Value:C2}\n");
                }
                if (transaction.TransactionType == "Transferencia")
                {
                    Console.WriteLine($"Tipo da transação ------> {transaction.TransactionType}\n");
                    Console.WriteLine($"Data da transação ------> {transaction.DateTime}\n");
                    Console.WriteLine($"Transação da conta-----> {transaction.FromAccount}\n");
                    Console.WriteLine($"Valor da Transação -----> {transaction.Value:C2}\n");
                }
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public BankTransfer? Transfer(Account ToAccount, Account FromAccount, decimal amount)
        {
            var CurrentAccount = FromAccount as CurrentAccount;
            var CurrentAccountBalance = CurrentAccount.Balance + CurrentAccount.Overdraft;

            if (ToAccount.AccoutNumber == FromAccount.AccoutNumber)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não e possivel fazer transferencia para a mesma conta.\n");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }

            if(FromAccount.typeOfAccount == AccountTypeEnum.Corrente && CurrentAccountBalance > amount )
            {
                Console.Clear();
                throw new Exception("Não foi possivel efetuar a transferencia saldo insuficiente\n");
            }

            FromAccount.Balance -= amount;
            ToAccount.Balance += amount;

            var CurrentTransaction = new Transactions(AccoutNumber, ToAccount.AccoutNumber, amount, "Transferencia");
            TransactionList.Add(CurrentTransaction);
            ToAccount.TransactionList.Add(CurrentTransaction);
            Console.Clear();
            Console.WriteLine("Transferencia concluida com sucesso\n");

            return new BankTransfer(AccoutNumber, ToAccount.AccoutNumber, amount);
        }

        public void ChangeInfos()
        {
            Console.WriteLine("O que deseja mudar [1] Name [2]Endereço [3] Renda mensal");
            var option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("Digite o novo nome");
                    Name = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Digite o novo endereço");
                    Adress = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Digite sua nova renda mensal");
                    MonthlyIncome =decimal.Parse(Console.ReadLine());
                    break;
            }
        }
    }

}



