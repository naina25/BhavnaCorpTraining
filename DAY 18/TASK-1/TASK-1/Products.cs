using System;
using System.Collections.Generic;
using System.Text;

namespace TASK_1
{
    class Products : Icommon
    {
        public int prodId;
        public string prodName, prodQuantity, prodBrand;
        public void showDetails()
        {
            Console.WriteLine(this.prodId + "/" + this.prodName + "/" + this.prodQuantity+"/"+this.prodBrand);

        }
    }
}
