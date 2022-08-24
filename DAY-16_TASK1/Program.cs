using System;

namespace DAY_16_TASK1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "", Id = "", College = "", Phone = "", str="";

            string isRepeat = "y";

            while (isRepeat == "y" || isRepeat == "Y")
            {
                Console.WriteLine("Press 1 to enter students details");
                Console.WriteLine("Press 2 to show the details");
                Console.WriteLine("Press 3 to check if a number is palindrome");
                Console.WriteLine("Press 4 to check armstrong number");

                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.WriteLine("Enter Your Name");
                        name = Console.ReadLine();

                        Console.WriteLine("Enter Your Student ID");
                        Id = Console.ReadLine();

                        Console.WriteLine("Enter Your College Name");
                        College = Console.ReadLine();

                        Console.WriteLine("Enter Your Contact Number");
                        Phone = Console.ReadLine();

                        Console.WriteLine("Your details are successfully entered!!");
                        break;
                    case 2:
                        Console.WriteLine("Your entered Name is " + name);
                        Console.WriteLine("Your student id is " + Id);
                        Console.WriteLine("Your College is " + College);
                        Console.WriteLine("Your phone number is " + Phone);
                        break;
                    case 3:
                        Console.WriteLine("Enter a string to check if it's palindrome or not");
                        str = Console.ReadLine();
                        int i = 0, j = str.Length-1;
                        bool ispalin = true; 
                        while (i <= j)
                        {
                            if (str[i] != str[j])
                            {
                                ispalin = false;
                                break;
                            }
                            i++;
                            j--;
                        }
                        if (ispalin == true) {
                            Console.WriteLine("Yes it is palindrome");
                        }
                        else
                        {
                            Console.WriteLine("Not palindrome");
                        }
                        break;

                }
                Console.WriteLine("Do you want to repeat it? y or n");
                isRepeat = Console.ReadLine();
            }
            







        }
    }
}
