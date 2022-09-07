using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace ATMapp.UI
{
    public static class Utility
    {
        private static CultureInfo culture = new CultureInfo("en-IN");
        public static string GetSecretInput(string prompt)
        {
            bool isPrompt = true;
            string asterics = "";

            //this object will change the immutability of string
            StringBuilder input = new StringBuilder();

            while (true)
            {
                if (isPrompt)
                    Console.WriteLine(prompt);
                isPrompt = false;
                ConsoleKeyInfo inputKey = Console.ReadKey(true); //inputkey will store the values of keypress from keyboard along with alt, shift etc.
                    
                    if(inputKey.Key == ConsoleKey.Enter)
                    {
                        if(input.Length == 6)
                        {
                            break;
                        }
                        else
                        {
                            PrintMessage("\nPlease enter 6 digits.", false);
                            isPrompt = true;
                            input.Clear();
                            continue;
                        }
                    }
                    if(inputKey.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input.Remove(input.Length - 1, 1);
                    }
                    else if(inputKey.Key != ConsoleKey.Backspace)
                    {
                        input.Append(inputKey.KeyChar);
                        Console.Write(asterics + "*");
                    }
                
            }
            return input.ToString();
        }

        public static void PrintDotAnimation(int timer = 10)
        {
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            Console.Clear();
        }

        public static void PrintMessage(string msg, bool success = true)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;

            PressEnterToContinue();
        }


        public static string GetUserInput(string prompt)
        {
            Console.WriteLine($"Enter {prompt}");
            return Console.ReadLine();
        }
        public static void PressEnterToContinue()
        {
            Console.WriteLine("\nPress Enter to continue...\n");
            Console.ReadLine();
        }

        public static string FormatAmount(decimal amt)
        {
            //string.format takes 3 arguments, one i currency info, that is coming from cultre object, defined above in this class, second decimal plaes, third one is amount
            return String.Format(culture, "{0:c2}", amt);
        }
    }
}
