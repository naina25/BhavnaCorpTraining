using System;
using System.Collections.Generic;
using System.Text;

namespace TASK_1
{
    public class employee:department
    {
        public int empid { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        private double salary { get; set; }
        protected string email { get; set; }

        //private data members can be accessed using public methods
        public double getSalary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }

        public override void showDetails()
        {
            Console.WriteLine("employees details: ");
            Console.WriteLine(this.empid + "/" + this.name + "/" + this.age);
        }
    }
}
