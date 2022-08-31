using System;
using System.Collections.Generic;
using System.Text;

namespace partialClass
{
    public partial class partialCls
    {
        public void displayDetails()
        {
            Console.WriteLine("Book title is: " + book);
            Console.WriteLine("Publish year is: " + publish_year);
        }
    }
}
