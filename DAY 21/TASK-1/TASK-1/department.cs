using System;
using System.Collections.Generic;
using System.Text;

namespace TASK_1
{
    public class department
    {
        public int dept_id;
        public string dept_name;
        public int number_of_employees;

        public virtual void showDetails()
        {
            Console.WriteLine("Department details: ");
            Console.WriteLine(this.dept_id + "/" + this.dept_name + "/" + this.number_of_employees);
        }
    }
}
