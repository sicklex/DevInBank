using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.AccountSystem.Entities
{
    public class Investments
    {
        public decimal ApplicationValue { get; set; }
        public string ApplicationType { get; set; }
        public DateTime ApplicationDate { get; set; }

        public int WithdrawDate { get; set; }

        public Investments(decimal applicationValue, string applicationType, DateTime applicationDate, int withdrawDate)
        {
            ApplicationValue = applicationValue;
            ApplicationType = applicationType;
            ApplicationDate = applicationDate;
            WithdrawDate = withdrawDate;
        }
    }
}
