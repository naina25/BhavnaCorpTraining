using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    class array
    {
        //Constructor method
        public array()
        {
            Console.WriteLine("This statement will be automatically called everytime when a class is instantiated!!");
        }

        public void printArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        //method overloading functions
        public void add(int x, int y)
        {
            Console.WriteLine(x + y);
        }

        public void add(int x, double y)
        {
            Console.WriteLine(x + y);
        }

        public void add(int x, int y, int z)
        {
            Console.WriteLine(x + y + z);
        }
    }
}
