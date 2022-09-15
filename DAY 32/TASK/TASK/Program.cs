using System;

namespace TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            logic obj = new logic();
            Console.WriteLine(obj.factorial(5));
            Console.WriteLine(obj.prime(10));
            
        }
    }
}
