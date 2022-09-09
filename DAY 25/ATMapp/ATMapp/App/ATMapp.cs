using ATMapp.Domain.Entities;
using ATMapp.Domain.enums;
using ATMapp.Domain.Interfaces;
using ATMapp.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ATMapp
{
    public class ATMapp:IUserLogin, IuserAccntActions, ITransaction

    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;
        private List<Transaction> _listoftransation;
        private const decimal minimumKeptAmount = 500;

        public void Run()
        {
            AppScreen.Welcome();
            CheckUserCardNumAndPass();
            AppScreen.WelcomeCustomer(selectedAccount.FullName);
            AppScreen.DisplayAppMenu();
            ProcessMenuoption();

        }

        public void CheckUserCardNumAndPass()
        {
            bool isCorrectLogin = false;

            while(isCorrectLogin == false)
            {
                UserAccount inputAccount = AppScreen.UserLoginForm();

                AppScreen.LoginProgress();

                foreach (UserAccount account in userAccountList)
                {
                    selectedAccount = account;
                    if (inputAccount.CardNumber.Equals(selectedAccount.CardNumber))
                    {
                        selectedAccount.TotalLogin++;

                        if (inputAccount.CardPin.Equals(selectedAccount.CardPin))
                        {
                            selectedAccount = account;

                            if(selectedAccount.isLocked || selectedAccount.TotalLogin > 3)
                            {
                                //print a lock message
                                AppScreen.PrintLockScreen();
                            }
                            else
                            {
                                selectedAccount.TotalLogin = 0;
                                isCorrectLogin = true;
                                break;
                            }
                        }
                        break;

                    }
                }
                if (isCorrectLogin == false)
                {
                    Utility.PrintMessage("\nInvalid Card Number or PIN", false);
                    selectedAccount.isLocked = selectedAccount.TotalLogin == 3;
                    if (selectedAccount.isLocked)
                    {
                        AppScreen.PrintLockScreen();
                    }
                }
                Console.Clear();
            }
            
        }

        //----------------------------InitialiseData Method-----------------------------
        public void InitialiseData()
        {
            userAccountList = new List<UserAccount>
            {
                new UserAccount{id=1, FullName="Naina Upadhyay", AccountNumber=12345, CardNumber=321321, CardPin=123123, AccountBalance=50000.00m, isLocked=false},
                new UserAccount{id=2, FullName="Neha Singh", AccountNumber=456789, CardNumber=654654, CardPin=456456, AccountBalance=40000.00m, isLocked=false},
                new UserAccount{id=1, FullName="Anjali Saini", AccountNumber=123555, CardNumber=987987, CardPin=789789, AccountBalance=30000.00m, isLocked=true}
            };
            _listoftransation = new List<Transaction>();
        }

        private void ProcessMenuoption()
        {
            switch(Validator.Convert<int>("an option:"))
            {
                case (int)AppMenu.CheckBalance:
                    CheckBalance();
                    break;
                case (int)AppMenu.PlaceDeposit:
                    PlaceDeposits();
                    break;
                case (int)AppMenu.MakeWithdrawal:
                    MakeWithDrawal();
                    break;
                case (int)AppMenu.InternalTransfer:
                    Console.WriteLine("Making interal transfer...");
                    break;
                case (int)AppMenu.ViewTransaction:
                    Console.WriteLine("Viewing Transaction...");
                    break;
                case (int)AppMenu.Logout:
                    AppScreen.LoginProgress();
                    Utility.PrintMessage("You have successfully Logged out. Please collect your ATM card.");
                    Run();

                    break;
                default:
                    Utility.PrintMessage("Invalid Option.", false);
                    break;
            }
        }

        public void CheckBalance()
        {
            Utility.PrintMessage($"Your Account Balance is: {Utility.FormatAmount(selectedAccount.AccountBalance)}");
        }

        public void PlaceDeposits()
        {
            Console.WriteLine("\nOnly multiples of 500 and 1000 INR allowed");
            var transaction_amt = Validator.Convert<int>($"amount { AppScreen.cur}");

            //simulate counting
            Console.WriteLine("\nChecking and Counting bank notes.");
            Utility.PrintDotAnimation();
            Console.WriteLine("");

            //some gaurd clause
            if(transaction_amt <= 0)
            {
                Utility.PrintMessage("Amount needs to be greater than zero. Try Again", false);
                return;
            }
            if(transaction_amt % 500 != 0)
            {
                Utility.PrintMessage("Enter deposit amount in multiples of 500 or 1000. Try Again", false);
                return;
            }
            if(PreviewBankNotesCOUNT(transaction_amt) == false)
            {
                Utility.PrintMessage($"You have cancelled your action.", false);
                return;
            }

            //bind transaction details to transaction object
            InsertTransaction(selectedAccount.id, TransactionType.Deposit, transaction_amt, "");

            //update account balance
            selectedAccount.AccountBalance += transaction_amt;

            //print success message
            Utility.PrintMessage($"Your deposits of {Utility.FormatAmount(transaction_amt)} was successful!!", true);



        }

        public void MakeWithDrawal()
        {
            var transaction_amt = 0;
            int selectedAmount = AppScreen.SelectAmount();
            if (selectedAmount == -1)
            {
                selectedAmount = AppScreen.SelectAmount();
            }
            else if (selectedAmount != 0)
            {
                transaction_amt = selectedAmount;
            }
            else
            {
                transaction_amt = Validator.Convert<int>($"amount Rs.");
            }

            //input validation
            if(transaction_amt <= 0)
            {
                Utility.PrintMessage("Amount needs to be greater than zero. Try Again", false);
                return;
            }
            if(transaction_amt % 500 != 0)
            {
                Utility.PrintMessage("You can only withdraw amount in multiples of 500 or 1000. Try Again", false);
                return;
            }
            //Business logic validations

            if(transaction_amt > selectedAccount.AccountBalance)
            {
                Utility.PrintMessage($"Withdrawal failed. Your balance is too low to withdraw {Utility.FormatAmount(transaction_amt)}",false);
                return;
            }
            if((selectedAccount.AccountBalance - transaction_amt) < minimumKeptAmount)
            {
                Utility.PrintMessage($"Withdrawal Failed. Your Account needs to have a minimum of  {Utility.FormatAmount(minimumKeptAmount)}");
                return;
            }

            //Bond withdrawal details to transaction object
            InsertTransaction(selectedAccount.id, TransactionType.Withdrawal, transaction_amt, "");
            //update account balance
            selectedAccount.AccountBalance -= transaction_amt;
            //success message
            Utility.PrintMessage($"You have successfully withdrawn {Utility.FormatAmount(transaction_amt)}.", true);
        }

        private bool PreviewBankNotesCOUNT(int amount)
        {
            int thouNotesCount = amount / 1000;
            int fiveHundredNotesCnt = (amount % 1000) / 500;

            Console.WriteLine("\nSummary");
            Console.WriteLine("-----------");
            Console.WriteLine($"{AppScreen.cur}1000 X {thouNotesCount} = {1000 * thouNotesCount} ");
            Console.WriteLine($"{AppScreen.cur}500 X {fiveHundredNotesCnt} = {500 * fiveHundredNotesCnt}");
            Console.WriteLine($"Total Amount: {Utility.FormatAmount(amount)}\n\n");

            int opt = Validator.Convert<int>("1 to confirm");
            return opt.Equals(1);
        }

        public void InsertTransaction(long _UserBankAccountId, TransactionType _tranType, decimal _tranAmount, string _desc)
        {
            //create a new transaction object
            var transaction = new Transaction()
            {
                TransactionID = Utility.GetTransactionId(),
                UserBankAccountID = _UserBankAccountId,
                TransactionDate = DateTime.Now,
                TransactionType = _tranType,
                TransactionAmt = _tranAmount,
                Description = _desc
            };

            //add transaction object to the list
            _listoftransation.Add(transaction);
        }

        public void ViewTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
