using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.AccountSystem.Entities
{
    public class BankTransfer
    {
        public int ToAccount { get; private set; }
        public int FromAccount { get; private set; }
        public decimal Value { get; private set; }
        public DateTime DateTime { get; private set; }


        public BankTransfer(int toAccount, int fromAccount, decimal value)
        {
            ToAccount = toAccount;
            FromAccount = fromAccount;
            Value = value;
            DateTime = DateTime.Now;
        }
    }
}
