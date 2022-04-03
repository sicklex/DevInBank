using DevInBank.AccountSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevInBank.AccountSystem.Entities
{
    public class BankFlowEngine
    {

        public List<Account> Accounts { get; set; }
        public List<Transactions> Transactions { get; set; }

        public void CreateLists()
        {
            Accounts = new List<Account>();
            Transactions = new List<Transactions>();
        }

        public Account? AccountCreation()
        {
            var validate = new Validate();

            Console.WriteLine("Digite Seu nome");
            var accountName = Console.ReadLine();

            bool haveNumber = accountName.Any(char.IsDigit);

            if (haveNumber)
            {
                Console.Clear();
                throw new Exception("Nome não pode conter numero\n");
            }

            if (accountName == "")
            {
                Console.WriteLine("Nome não pode ser vazio");
                return null;
            }

            Console.WriteLine($"Ok {accountName} preciso agora que digite seu endereço ");
            var adress = Console.ReadLine();

            Console.WriteLine("Agora digite seu cpf (###-###-###.##");
            var cpf = Console.ReadLine();

            if (!validate.CpfValidate(cpf))
            {
                Console.WriteLine("Cpf invalido tente novamente");
                return null;
            }

            Console.WriteLine("Preciso saber a sua renda mensal para encontrar as melhores opções de conta para voce.");
            var monthlyIncome = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escolha qual conta deja abrir");
            Console.WriteLine("[1] Conta Corrente.");
            Console.WriteLine("[2] Conta Poupança.");
            Console.WriteLine("[3] Conta Investimento.\n");

            var chosedAccType = int.Parse(Console.ReadLine());

            Console.Write("Em qual agencia deseja criar sua conta\n");

            Console.WriteLine("[1] Florianópolis");
            Console.WriteLine("[2] São José");
            Console.WriteLine("[3] Biguaçu .\n");

            var chosedAgencie = int.Parse(Console.ReadLine());

            switch (chosedAccType)
            {
                // mudar para if
                case 1:
                    var addList = new CurrentAccount(accountName, cpf, adress, monthlyIncome, Accounts.Count, (Enumerators.AgenciesEnum)chosedAgencie, (Enumerators.AccountTypeEnum)chosedAccType);
                    Accounts.Add(addList);
                    Console.Clear();
                    Console.WriteLine($"Parabéns {accountName}, sua conta Corrente foi criada com sucesso, a sua agencia e {chosedAgencie} \n");
                    break;
                case 2:
                    var addListe = new SavingAccount(accountName, cpf, adress, monthlyIncome, Accounts.Count, (Enumerators.AgenciesEnum)chosedAgencie, (Enumerators.AccountTypeEnum)chosedAccType);
                    Accounts.Add(addListe);
                    Console.Clear();
                    Console.WriteLine($"Parabéns {accountName}, sua conta Poupança foi criada com sucesso, a sua agencia e {chosedAgencie} \n");
                    break;
                case 3:
                    var AddList = new InvestmentAccount(accountName, cpf, adress, monthlyIncome, Accounts.Count, (Enumerators.AgenciesEnum)chosedAgencie, (Enumerators.AccountTypeEnum)chosedAccType);
                    Accounts.Add(AddList);
                    Console.Clear();
                    Console.WriteLine($"Parabéns {accountName}, sua conta de Investmentos foi criada com sucesso, a sua agencia e {chosedAgencie} \n");
                    break;
            }
            return null;
        }

        public void TypeOfAccount(Account account)
        {

            if (account.typeOfAccount == Enumerators.AccountTypeEnum.Poupança)
            {
                var ChangeAccountType = account as SavingAccount;
                SavingAccountOptions(ChangeAccountType);
            }

            if (account.typeOfAccount == Enumerators.AccountTypeEnum.Corrente)
            {
                var ChangeAccountType = account as CurrentAccount;
                CurrentAccountOptions(ChangeAccountType);
            }

            if (account.typeOfAccount == Enumerators.AccountTypeEnum.Investimento)
            {
                var ChangeAccountType = account as InvestmentAccount;
                InvestmentAccountOptions(ChangeAccountType);
            }

        }
        public void CurrentAccountOptions(CurrentAccount currentAccount)
        {
            var Account = Accounts.FirstOrDefault(account => account.AccoutNumber == currentAccount.AccoutNumber);

            Console.Clear();
            Console.WriteLine("Conta acessada com Sucesso\n");
            Console.WriteLine("Escolha uma opção\n ");
            Console.WriteLine("[1] Extrato Bancario");
            Console.WriteLine("[2] Saldo");
            Console.WriteLine("[3] Deposito");
            Console.WriteLine("[4] Transferencia");
            Console.WriteLine("[5] Saque");

            var option = int.Parse(Console.ReadLine());
            Options(option, Account);
        }

        public void SavingAccountOptions(SavingAccount typedSavingAccount)
        {
            var AccOnAccountList = Accounts.FirstOrDefault(account => account.AccoutNumber == typedSavingAccount.AccoutNumber);

            Console.Clear();
            Console.WriteLine("Conta acessada com Sucesso\n");
            Console.WriteLine("Escolha uma opção\n ");
            Console.WriteLine("[1] Extrato Bancario");
            Console.WriteLine("[2] Saldo");
            Console.WriteLine("[3] Deposito");
            Console.WriteLine("[4] Transferencia");
            Console.WriteLine("[5] Saque");
            Console.WriteLine("[6] Fazer uma simulação de investimento");
            var option = int.Parse(Console.ReadLine());
            if (option == 6)
            {
                typedSavingAccount.InvestmentSimulation();
            }
            Options(option, AccOnAccountList);
        }

        public void InvestmentAccountOptions(InvestmentAccount account)
        {
            var Account = Accounts.FirstOrDefault(account => account.AccoutNumber == account.AccoutNumber);

            Console.Clear();
            Console.WriteLine("Conta acessada com Sucesso\n");
            Console.WriteLine("Escolha uma opção\n ");
            Console.WriteLine("[1] Extrato Bancario");
            Console.WriteLine("[2] Saldo");
            Console.WriteLine("[3] Deposito");
            Console.WriteLine("[4] Simulação de Investimento");

            var option = int.Parse(Console.ReadLine());

            if (option == 4)
            {
              

                Console.WriteLine($"Ok, {account.Name} qual tipo de simulação deseja efetuar");
                Console.WriteLine("[1] LCI: 8% ao ano, Tempo mínimo de aplicação: 6 meses");
                Console.WriteLine("[2] LCA: 9% ao ano, Tempo mínimo de aplicação: 12 meses");
                Console.WriteLine("[3] CDB: 10% ao ano,Tempo mínimo de aplicação: 36 meses ");
                var chosedInvestimentType = int.Parse(Console.ReadLine());
                if (chosedInvestimentType == 1)
                    account.LCI();
                if (chosedInvestimentType == 2)
                    account.LCA();
                if (chosedInvestimentType == 3)
                    account.CDB();
            }
            else Options(option, Account);

        }

        public void Options(int option, Account account)
        {
            switch (option)
            {
                case 1:
                    account.BankStatement();
                    break;
                case 2:
                    Console.Clear();
                    account.BalanceInfo();
                    CountinueOperation();
                    break;
                case 3:
                    Console.WriteLine("Deseja depositar valor na conta atual ou em uma nova conta ?");
                    Console.WriteLine("[1] Conta Atual");
                    Console.WriteLine("[2] Outra Conta");
                    var AccountOptionChosed = int.Parse(Console.ReadLine());
                    if (AccountOptionChosed == 1)
                    {
                        Console.WriteLine("Digite o valor que deseja depositar");
                        var amount = int.Parse(Console.ReadLine());
                        account.Deposit(amount, account);
                        Console.Clear();
                        Console.WriteLine("Deposito efetuado com sucesso\n");
                        CountinueOperation();
                    }
                    if (AccountOptionChosed == 2)
                    {
                        Console.WriteLine("Digite O numero da conta destino");
                        var typedDestinationAccount = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o valor que deseja depositar");
                        var amount = int.Parse(Console.ReadLine());
                        var typedAccount = Accounts.FirstOrDefault(account => account.AccoutNumber == typedDestinationAccount);
                        account.Deposit(amount, typedAccount);
                    }
                    break;
                case 4:
                    if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday || DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                    {
                        Console.Clear();
                        throw new Exception("Não e possivel efetuar transações no final de semana\n");
                    }
                    Console.WriteLine("Digite o numero da conta que deseja transferir");
                    var destinationAccount = int.Parse(Console.ReadLine());
                    var destinationAccountNumber = Accounts.FirstOrDefault(account => account.AccoutNumber == destinationAccount);

                 
                    if (destinationAccountNumber == null)
                    {
                        Console.Clear();
                        throw new Exception("Conta não existe \n");
                    }
                    else
                    {
                        Console.WriteLine("Digite o valor que deseja transferir");
                        var amount = int.Parse(Console.ReadLine());
                        account.Transfer(destinationAccountNumber, account, amount);
                    }
                    break;
                case 5:
                    Console.WriteLine("Qual valor deseja sacar ?");
                    var withdrawAmount = int.Parse(Console.ReadLine());
                    account.Withdraw(withdrawAmount, account);
                    break;
            }
        }

        public void CountinueOperation()
        {
            Console.WriteLine("Deseja Continuar operação ?\n");
            Console.WriteLine("---------------------------------\n");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");

            var chosedOption = int.Parse(Console.ReadLine());

            if (chosedOption == 1)
                Console.Clear();

            if (chosedOption == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Clear();
                Console.WriteLine("Tenha um bom dia !");
                Environment.Exit(1);
            }

        }
        public void AccountInfos(Account account)
        {
            Console.Clear();
            Console.WriteLine($" Nome:{account.Name} \n Cpf:{account.Cpf} \n Endereço: {account.Adress}\n Agencia: { account.Agencies}\n Tipo de conta:{account.typeOfAccount}\n");
            CountinueOperation();
        }

        public void systemReports()
        {
            Console.Clear();
            Console.WriteLine("Bem vindo aos relatórios do sistema. Oque deseja fazer hoje");
            Console.WriteLine("[1] Listar todas as contas de um tipo");
            Console.WriteLine("[2] LIstar todas as contas com saldo negativo");
            Console.WriteLine("[3] Listar o valor total de investimentos");
            Console.WriteLine("[4] Listar todas as transações de um determinado cliente.");
            var option = int.Parse(Console.ReadLine());
            bool test = false;

            if (option == 1)
            {
                Console.WriteLine("Qual tipo de conta deseja listar [1] Corrente, [2] Poupança [3] Investimento");
                var chosedOption = int.Parse(Console.ReadLine());

                switch (chosedOption)
                {
                    case 1:
                        test = Accounts.Any(account => account.typeOfAccount == Enumerators.AccountTypeEnum.Corrente);
                        if (test)
                        {
                            foreach (var account in Accounts)
                            {

                                if (account.typeOfAccount == Enumerators.AccountTypeEnum.Corrente)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"{account.Name}, {account.Agencies}, {account.AccoutNumber}");

                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            throw new Exception("Não existe conta corrente criada\n");
                        }
                        break;
                    case 2:
                        test = Accounts.Any(account => account.typeOfAccount == Enumerators.AccountTypeEnum.Poupança);
                        if (test)
                        {
                            foreach (var account in Accounts)
                            {
                                if (account.typeOfAccount == Enumerators.AccountTypeEnum.Poupança)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"{account.Name}, {account.Agencies}, {account.AccoutNumber}");
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            throw new Exception("Não existe conta poupança criada\n");
                        }
                        break;
                    case 3:
                        test = Accounts.Any(account => account.typeOfAccount == Enumerators.AccountTypeEnum.Investimento);
                        if (test)
                        {
                            foreach (var account in Accounts)
                            {
                                if (account.typeOfAccount == Enumerators.AccountTypeEnum.Investimento)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"A conta de nome:{account.Name}, da agencia :{account.Agencies},do numero: {account.AccoutNumber}");
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            throw new Exception("Não existe conta investimento criada.\n");
                        }
                        break;
                }
            }

            if (option == 2 && Accounts.Count > 0)
            {
                Console.Clear();
                bool negativeBalanceCheck = Accounts.Any(account => account.Balance < 0);
                if (negativeBalanceCheck)
                {
                    foreach (var account in Accounts)
                    {
                        if (account.Balance < 0)
                        {
                            Console.WriteLine($"A conta de nome: {account.Name}, de numero: {account.AccoutNumber}, da agencia: {account.Agencies},  Tem o saldo de: {account.Balance}");
                        }
                    }
                }
                else { Console.Clear(); throw new Exception("Não existe contas negativadas\n"); };
            }
            if(option == 3)
            {
                foreach(var account in Accounts)
                {
                    Console.Clear();
                    var acessToInvestmentAccount = account as InvestmentAccount;
                    var total = acessToInvestmentAccount.InvestmentsList.Sum(investmentsValue => investmentsValue.ApplicationValue);
                    Console.WriteLine($"A soma de todo o investimento no momento e de: {total:C2}");
                    Console.ReadKey();
                }
            }
            Console.Clear();

            if(option == 4)
            {
                if (Accounts.Count == 0)
                {
                    Console.Clear();
                    throw new Exception("Não existe contas criadas. Aperte qualquer teclar para continuar]\n");
                }

                Console.WriteLine("Digite o numero da conta");
                var accountNumber = int.Parse(Console.ReadLine());

                var getAccount = Accounts.FirstOrDefault(account => account.AccoutNumber == accountNumber);
                
                if (Transactions.Count > 0) {
                    getAccount.TransactionList.ForEach(transaction => { Console.WriteLine($@"Nome:{getAccount.Name}
Conta: {getAccount.AccoutNumber}
Valor: {transaction.Value:C2}
Data: {transaction.DateTime}
Tipo: {transaction.TransactionType}
"); });
                }else
                {
                    Console.Clear();
                    throw new Exception("Não existe transações nessa conta. Aperte qualquer teclar para continuar\n");
                }
            }

        }
       
    }
}





