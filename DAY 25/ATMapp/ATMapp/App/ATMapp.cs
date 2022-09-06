using ATMapp.Domain.Entities;
using ATMapp.Domain.Interfaces;
using ATMapp.UI;
using System;
using System.Collections.Generic;

namespace ATMapp
{
    public class ATMapp:IUserLogin

    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;

        public void CheckUserCardNumAndPass()
        {
            bool isCorrectLogin = false;

            UserAccount tempUserAccoount = new UserAccount();
        }

        public void InitialiseData()
        {
            userAccountList = new List<UserAccount>
            {
                new UserAccount{id=1, FullName="Naina Upadhyay", AccountNumber=12345, CardNumber=321321, CardPin=123123, AccountBalance=50000.00m, isLocked=false},
                new UserAccount{id=2, FullName="Neha Singh", AccountNumber=456789, CardNumber=654654, CardPin=456456, AccountBalance=40000.00m, isLocked=false},
                new UserAccount{id=1, FullName="Anjali Saini", AccountNumber=123555, CardNumber=987987, CardPin=789789, AccountBalance=30000.00m, isLocked=true}
            };
        }
        
    }
}
