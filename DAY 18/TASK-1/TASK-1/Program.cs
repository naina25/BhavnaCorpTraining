using System;

namespace TASK_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string isRepeat = "y";

            while(isRepeat == "y" || isRepeat == "Y")
            {
                Console.WriteLine("Enter your choice - Press 1 for customers details, Press 2 for produts details, press 3 for order details");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Customer custObj = new Customer();
                        custObj.custDetails();
                        custObj.showCustDetails();
                        break;
                    case "2":
                        Products prodObj = new Products();
                        prodObj.prodDetails();
                        prodObj.showProdDetails();
                        break;
                    case "3":
                        Order orderObj = new Order();
                        orderObj.getOrderDetails();
                        orderObj.showOrderDetails();
                        break;
                    default:
                        Console.WriteLine("Please enter correct choice");
                        break;
                }

                Console.WriteLine("Do you want to repeat? Y or N");

                isRepeat = Console.ReadLine();
            }
            
        }
    }
}
