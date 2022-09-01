using System;
using System.Collections.Generic;
using System.Text;

namespace TASK_2
{
    public class Productcls:Iproducts
    {
        public int prod_id { get; set; }
        public string prod_name { get; set; }
        public int prod_qty { get; set; }
        public int prod_price { get; set; }
        public int c_id { get; set; }

        public bool isExists(int price)
        {
            if(price < 500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
