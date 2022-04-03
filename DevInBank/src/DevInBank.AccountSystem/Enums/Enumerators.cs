using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.AccountSystem.Enums
{
    public class Enumerators
    {
        public enum AgenciesEnum
        {
           Florianópolis , São_José , Biguaçu 
        }

        public enum AccountTypeEnum
        {
            Corrente = 1 , Poupança = 2, Investimento = 3
        }

        public enum AnualIncomeInfoEnum
        {
            LCI,LCA,CDB
        }
    }
}
