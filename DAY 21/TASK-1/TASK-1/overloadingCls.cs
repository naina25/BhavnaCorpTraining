using System;
using System.Collections.Generic;
using System.Text;

namespace TASK_1
{
    public class overloadingCls
    {
        //method overloading functions
        public void sub(int x, int y)
        {
            Console.WriteLine(x - y);
        }

        public void sub(int x, double y)
        {
            Console.WriteLine(x - y);
        }

        public void sub(int x, float z)
        {
            Console.WriteLine(x - z);
        }
    }
}
