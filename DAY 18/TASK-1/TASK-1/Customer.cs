using System;
using System.Collections.Generic;
using System.Text;

namespace TASK_1
{
    class Customer : Icustomers
    {

        public int custId, custAge;
        public string custName, gender, prodBought;

        public void custDetails()
        {
            Console.WriteLine("Enter your personal details");
            this.custId = int.Parse(Console.ReadLine());
            this.gender = Console.ReadLine();
            this.prodBought = Console.ReadLine();
            this.gender = Console.ReadLine();
            this.custAge = int.Parse(Console.ReadLine());
        }

        public void showCustDetails()
        {
            Console.WriteLine("Your entered details are: ");
            Console.WriteLine(this.custId + "/" + this.gender + "/" + this.prodBought. + "/" + this.custAge + "/" + this.custName);
        }
    }
}
