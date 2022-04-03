
using DevInBank.AccountSystem;
using DevInBank.AccountSystem.Entities;
using DevInBank.AccountSystem.Enums;

var Engine = new BankFlowEngine();
bool running = true;
Engine.CreateLists();

var systemDate = DateTime.Now;
while (running == true)
{
    try
    {
        Console.WriteLine($"O horario do sistema e {systemDate}");
        Console.WriteLine("Escolha uma opção \n");
        Console.WriteLine("[1] Conta existente");
        Console.WriteLine("[2] Criar conta");
        Console.WriteLine("[3] Informações de uma Conta Especifica");
        Console.WriteLine("[4] Relatórios do sistema");
        Console.WriteLine("[5] Trocar dados cadastrais de uma conta expecifica");
        var chosedOption = int.Parse(Console.ReadLine());

        switch (chosedOption)
        {
            case 1:
                Console.WriteLine("Digite o numero de sua conta");
                var TypedAccountNumber = int.Parse(Console.ReadLine());
                var verifyAccountExistence = Engine.Accounts.FirstOrDefault(account => account.AccoutNumber == TypedAccountNumber);

                if (verifyAccountExistence == null)
                    throw new Exception("Essa conta não Existe");

                Console.WriteLine(verifyAccountExistence.AccoutNumber);

                Engine.TypeOfAccount(verifyAccountExistence);
                break;
            case 2:
                Engine.AccountCreation();
                Console.WriteLine("Aperte qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
                break;
            case 3:
                Console.WriteLine("Digite o numero de sua conta");
                TypedAccountNumber = int.Parse(Console.ReadLine());
                var account = Engine.Accounts.FirstOrDefault(account => account.AccoutNumber == TypedAccountNumber);
                if (account == null)
                {
                    throw new Exception("Essa conta não Existe\n");
                }
                Console.Clear();
                Console.WriteLine($@"Conta de nome {account.Name}.
Agencia: {account.Agencies}.
cpf: {account.Cpf}.
Conta do tipo: {account.typeOfAccount}.
De numero: {account.AccoutNumber}.
");

                break;
            case 4:
                Engine.systemReports();
                break;

            case 5:
                Console.WriteLine("Digite o numero de sua conta");
                TypedAccountNumber = int.Parse(Console.ReadLine());
                account = Engine.Accounts.FirstOrDefault(account => account.AccoutNumber == TypedAccountNumber);
                if (account == null)
                {
                    Console.Clear();
                    throw new Exception("A conta não existe\n");
                }
                else account.ChangeInfos();
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}



