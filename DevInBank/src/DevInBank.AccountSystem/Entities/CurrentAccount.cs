using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevInBank.AccountSystem.Enums.Enumerators;

namespace DevInBank.AccountSystem.Entities
{
    public class CurrentAccount : Account
    {
        public decimal Overdraft { get; private set; }


        public CurrentAccount(string name, string Cpf, string adress, decimal monthlyIncome, int accoutNumber, AgenciesEnum agencies, AccountTypeEnum typeOfAccount)
            : base(name, Cpf, adress, monthlyIncome, accoutNumber, agencies, typeOfAccount)
        {
            Overdraft = 0.1m * monthlyIncome;
        }


        public override void Withdraw(decimal amount, Account account)
        {
            if (amount > Balance + Overdraft)
            {
                throw new Exception("Saque não efetuado devido a falta de saldo");
            }

            Balance -= amount;
            Overdraft -= (amount + Overdraft) - Balance;
            TransactionList.Add(new Transactions(AccoutNumber, amount, "Saque"));
            Console.WriteLine($"Efetuado o saque de{amount:C2}R$ ");
        }

        public void Test()
        {

        }
    }

}
