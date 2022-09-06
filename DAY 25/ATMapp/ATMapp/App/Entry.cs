using ATMapp.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATMapp.App
{
    class Entry
    {
        static void Main(string[] args)
        {
            AppScreen.Welcome();
            long cardNumber = Validator.Convert<long>("your card number");
            Console.WriteLine($"Your name is {cardNumber}");

            Utility.PressEnterToContinue();
        }
    }
}
