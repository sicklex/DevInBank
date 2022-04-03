using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevInBank.AccountSystem.Enums.Enumerators;

namespace DevInBank.AccountSystem.Entities
{
    public class InvestmentAccount : Account
    {
        public List<Investments> InvestmentsList { get; set; }
        public decimal AnnualIncome { get; private set; }
        public int AnnualIncomeValue { get; private set; }


        public InvestmentAccount(string name, string cpf, string adress, decimal monthlyIncome, int accoutNumber, AgenciesEnum agencies, AccountTypeEnum accountType)
            : base(name, cpf, adress, monthlyIncome, accoutNumber, agencies, accountType)
        {
            InvestmentsList = new List<Investments>();
            AnnualIncome = AnnualIncome;
        }

        public void LCI()
        {
            Console.WriteLine("Agora preciso saber o valor que deseja investir");
            var investmentValue = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o tempo que deseja deixar o seu dinheiro investido ? (Em meses)");
            var investmentTime = int.Parse(Console.ReadLine());

            if (investmentTime < 6)
            {
                throw new Exception("O tempo de investimento precisa ser de 6");
            }
            var finalMonthOfInvestment = DateTime.Now.Month + investmentTime;

            var investmentInDays = Math.Round(investmentTime * 30.417);

            var timeFees = Math.Pow(1 + 0.0214f / 100, investmentInDays);

            var investmentTotal = timeFees * investmentValue;

            var profitsInDays = (investmentTotal - investmentValue) / investmentInDays;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"O seu investimento foi de {investmentValue:C2} com o juros de 0.0214% ao dia, Seu rendimento diario seria {profitsInDays:C2} com o total de {investmentTotal:C2}\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Deseja efetuar o investimento ?");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");
            var chosedOption = int.Parse(Console.ReadLine());
            if (chosedOption  == 1)
            {
                var createInvestment = new Investments(investmentValue, "LCI", DateTime.Now, finalMonthOfInvestment);
                InvestmentsList.Add(createInvestment);
                Console.WriteLine($"Parabens {Name} pelo seu mais novo investimento");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ok, estarei disponivel caso queira fazer outra simulação, aperte qualquer tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void LCA()
        {
            Console.WriteLine("Agora preciso saber o valor que deseja investir");
            var investmentValue = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o tempo que deseja deixar o seu dinheiro investido ? (Em meses)");
            var investmentTime = int.Parse(Console.ReadLine());

            if (investmentTime < 12)
            {
                throw new Exception("O tempo de investimento precisa ser maior que 12");
            }
            var finalMonthOfInvestment = DateTime.Now.Month + investmentTime;

            var investmentInDays = Math.Round(investmentTime * 30.417);

            var timeFees = Math.Pow(1 + 0.0239F / 100, investmentInDays);

            var investmentTotal = timeFees * investmentValue;

            var profitsInDays = (investmentTotal - investmentValue) / investmentInDays;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"O seu investimento foi de {investmentValue:C2} com o juros de 0.0239% ao dia, Seu rendimento diario seria {profitsInDays:C2} com o total de {investmentTotal:C2}\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Deseja efetuar o investimento ?");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");
            var chosedOption = int.Parse(Console.ReadLine());
            if (chosedOption == 1)
            {
                var createInvestment = new Investments(investmentValue, "LCA", DateTime.Now, finalMonthOfInvestment);
                InvestmentsList.Add(createInvestment);
                Console.WriteLine($"Parabens {Name} pelo seu mais novo investimento");
                Console.ReadKey();
                Console.Clear();

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ok, estarei disponivel caso queira fazer outra simulação, aperte qualquer tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void CDB()
        {
            Console.WriteLine("Agora preciso saber o valor que deseja investir");
            var investmentValue = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual o tempo que deseja deixar o seu dinheiro investido ? (Em meses)");
            var investmentTime = int.Parse(Console.ReadLine());

            if (investmentTime < 12)
            {
                Console.Clear();
                throw new Exception("O tempo de investimento precisa ser maior que 12");
            }
            var finalMonthOfInvestment = DateTime.Now.Month + investmentTime;

            var investmentInDays = Math.Round(investmentTime * 30.417);

            var timeFees = Math.Pow(1 + 0.0265F / 100, investmentInDays);

            var investmentTotal = timeFees * investmentValue;

            var profitsInDays = (investmentTotal - investmentValue) / investmentInDays;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"O seu investimento foi de {investmentValue:C2} com o juros de 0.0265% ao dia, Seu rendimento diario seria {profitsInDays:C2} com o total de {investmentTotal:C2}\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Deseja efetuar o investimento ?");
            Console.WriteLine("[1] Sim");
            Console.WriteLine("[2] Não");
            var chosedOption = int.Parse(Console.ReadLine());
            if (chosedOption == 1)
            {
                var createInvestment = new Investments(investmentValue, "CDB", DateTime.Now, finalMonthOfInvestment);
                InvestmentsList.Add(createInvestment);
                Console.WriteLine($"Parabens {Name} pelo seu mais novo investimento");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Ok, estarei disponivel caso queira fazer outra simulação, aperte qualquer tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}
