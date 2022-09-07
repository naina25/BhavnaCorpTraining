using ATMapp.Domain.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATMapp.Domain.Interfaces
{
    public interface ITransaction
    {
        void InsertTransaction(long _UserBankAccountId, TransactionType _tranType, decimal _tranAmount, string _desc);
        void ViewTransaction();
    }
}
