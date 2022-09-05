using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment3
{
    public class CommonCls : ICommon
    {
        public void showMsg(string msg)
        {
            Console.WriteLine("Admin logged in Successfully");
        }
    }
}
