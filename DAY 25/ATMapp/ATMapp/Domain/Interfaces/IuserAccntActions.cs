using System;
using System.Collections.Generic;
using System.Text;

namespace ATMapp.Domain.Interfaces
{
    public interface IuserAccntActions
    {
        void CheckBalance();
        void PlaceDeposits();
        void MakeWithDrawal();
    }
}
