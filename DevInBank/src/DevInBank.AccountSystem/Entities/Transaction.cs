using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.AccountSystem.Entities
{
    public class Transactions
    {
        public int  ToAccount { get; private set; }
        public int FromAccount { get; private set; }
        public decimal Value { get; private set; }
        public DateTime DateTime { get; private set; }
        public string TransactionType { get; private set; }

        public Transactions(int toAccount, int fromAccount, decimal value,  string transactionType)
        {
            ToAccount = toAccount;
            FromAccount = fromAccount;
            Value = value;
            DateTime = DateTime.Now;
            TransactionType = transactionType;
        }

        public Transactions(int fromAccount, decimal value, string transactionType)
        {
            FromAccount = fromAccount;
            Value = value;
            TransactionType = transactionType;
            DateTime = DateTime.Now;
        }
    }
}
