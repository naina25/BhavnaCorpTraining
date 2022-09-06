using System;
using System.Collections.Generic;
using System.Text;

namespace ATMapp.UI
{
    public static class AppScreen
    {
        internal static void Welcome()
        {
            //clears the console screen
            Console.Clear();
            //sets the title of console window
            Console.Title = "My ATM App";
            //sets the text color for foreground color to white
            Console.ForegroundColor = ConsoleColor.White;

            //sets the welcome message
            Console.WriteLine("\n\n-------------------------------------------Welcome to my ATM app--------------------------------------------\n\n");
            //prompt the user to insert atm card
            Console.WriteLine("Please insert your ATM card");
            Console.WriteLine("Note: Actual ATM machine will accept and validate a physical ATM card, read the card number and validate it");

            Utility.PressEnterToContinue();
        }
       
    }
}
