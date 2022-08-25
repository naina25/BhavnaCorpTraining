using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array methods
            int[] arr = { 2, 45, 32, 10, 50 };
            int a = 2, b = 4, d = 10;
            double c = 5;

            array arrobj = new array();

            arrobj.printArray(arr);
            Console.WriteLine();

            //Array sort method
            Array.Sort(arr);
            arrobj.printArray(arr);
            Console.WriteLine();

            //Array reverse method
            Array.Reverse(arr);
            arrobj.printArray(arr);
            Console.WriteLine();

            //Method Overloading function calling
            arrobj.add(a, b);
            arrobj.add(a, b, d);
            arrobj.add(d, c);
        }
    }
}
