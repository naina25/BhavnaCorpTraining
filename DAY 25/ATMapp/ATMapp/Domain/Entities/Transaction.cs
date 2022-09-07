using ATMapp.Domain.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATMapp.Domain.Entities
{
    public class Transaction
    {
        public long TransactionID { get; set; }
        public long UserBankAccountID { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType TransactionType{ get; set; }
        public string Description { get; set; }
        public Decimal TransactionAmt  { get; set; }

    }
}
