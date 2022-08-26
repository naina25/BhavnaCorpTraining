using System;
using System.Collections.Generic;
using System.Text;

namespace TASK_1
{
    public class Order: Iorder
    {
        public int orderId, orderQuan, quanLeft;
        public string productName, paymentType;

        public void getOrderDetails()
        {
            Console.WriteLine("Enter the order details");
            this.orderId = int.Parse(Console.ReadLine());
            this.orderQuan = int.Parse(Console.ReadLine());
            this.quanLeft = int.Parse(Console.ReadLine());
            this.productName = Console.ReadLine();
            this.paymentType = Console.ReadLine();
        }

        public void showOrderDetails()
        {
            Console.WriteLine("Your entered details are: ");
            Console.WriteLine(this.orderId + "/" + this.productName + "/" + this.orderQuan + "/" + this.quanLeft. + "/" + this.paymentType);
        }
    }
}
