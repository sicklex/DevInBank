using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevInBank.AccountSystem.Enums.Enumerators;

namespace DevInBank.AccountSystem.Entities
{
    public class SavingAccount : Account
    {

        public decimal SavingIncomes { get; private set; }

        public SavingAccount(string name, string cpf, string adress, decimal monthlyIncome, int accoutNumber, AgenciesEnum agencies, AccountTypeEnum typeOfAccount)
            : base(name, cpf, adress, monthlyIncome, accoutNumber, agencies, typeOfAccount)
        {
        }

        public void InvestmentSimulation()
        {
            Console.WriteLine("Digite A quantidade de tempo que deseja manter o seu dinheiro investido");
            var TimeInvested = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor que sera investido");
            var InvestedValue = Decimal.Parse(Console.ReadLine());
            var fees = (decimal)Math.Pow(1 + 0.5002 / 100, TimeInvested);
            var TotalAmount = fees * InvestedValue;
            Console.WriteLine($"Investimento seria. {TimeInvested} Meses o valor de {InvestedValue} ira render{(TotalAmount - InvestedValue):C2}, Totalizando {TotalAmount:C2}");
        }
    }
}
