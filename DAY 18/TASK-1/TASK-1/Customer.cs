using System;
using System.Collections.Generic;
using System.Text;

namespace TASK_1
{
    class Customer : Icommon
    {

        public int custId;
        public string custName, gender;
        public void showDetails()
        {
            Console.WriteLine(this.custId + "/" + this.custName + "/" + this.gender);
        }
    }
}
