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
            ATMapp atmapp = new ATMapp();
            atmapp.InitialiseData();
            atmapp.Run();

        }
    }
}
