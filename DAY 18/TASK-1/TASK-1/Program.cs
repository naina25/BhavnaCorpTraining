using System;

namespace TASK_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your choice - Press 1 for customers details, Press 2 for produts details");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Customer custObj = new Customer();
                    Console.WriteLine("Enter the customers details: ");
                    custObj.custId = int.Parse(Console.ReadLine());
                    custObj.custName = Console.ReadLine();
                    custObj.gender = Console.ReadLine();
                    custObj.showDetails();
                    break;
                case "2":
                    Products prodObj = new Products();
                    Console.WriteLine("Enter the products details: ");
                    prodObj.prodId = int.Parse(Console.ReadLine());
                    prodObj.prodName = Console.ReadLine();
                    prodObj.prodQuantity = Console.ReadLine();
                    prodObj.prodBrand = Console.ReadLine();
                    prodObj.showDetails();
                    break;

            }
        }
    }
}
