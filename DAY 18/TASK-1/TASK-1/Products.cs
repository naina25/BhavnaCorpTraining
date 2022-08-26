using System;
using System.Collections.Generic;
using System.Text;

namespace TASK_1
{
    class Products : Iproducts
    {
        public int prodId;
        public string prodName, prodQuantity, prodBrand;
        public float prodPrice;

        public void prodDetails()
        {
            Console.WriteLine("Enter the product details");
            this.prodId = int.Parse(Console.ReadLine());
            this.prodName = Console.ReadLine();
            this.prodQuantity = Console.ReadLine();
            this.prodBrand = Console.ReadLine();
            this.prodPrice = float.Parse(Console.ReadLine());
        }

        public void showProdDetails()
        {
            Console.WriteLine("Your entered details are: ");
            Console.WriteLine(this.prodId + "/" + this.prodName. + "/" + this.prodQuantity + "/" + this.prodPrice + "/" +this.prodBrand);
        }
    }
}
