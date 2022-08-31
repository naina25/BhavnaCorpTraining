using System;
using partialClass;

namespace TASK_1
{
    class Program:employee
    {
        static void Main(string[] args)
        {
            //--------partial clasees----------
            partialCls bookDetails = new partialCls("XYZ", 2020);
            bookDetails.displayDetails();

            //----------from employee class------
            employee obj = new employee();

            obj.age = int.Parse(Console.ReadLine());
            obj.name = Console.ReadLine();
            obj.empid = int.Parse(Console.ReadLine());

            Console.WriteLine("name: " + obj.name + " age: " + obj.age + " empid: " + obj.empid);

            //we can set the salary value using the set method in employee class
            obj.getSalary = 20000;
            Console.WriteLine(obj.getSalary);

            //we can access protected members using the inherited class, which is program here (inheriting from employee class)
            Program obj2 = new Program();
            obj2.email = Console.ReadLine();
            Console.WriteLine(obj2.email);



            //---------method overloading------------
            overloadingCls newobj = new overloadingCls();
            int a = 50, b = 20;
            float d = 10;
            double c = 5;

            newobj.sub(a, b);
            newobj.sub(a, d);
            newobj.sub(b, c);



            //-----------method overriding------------
            employee emp = new employee();

            Console.WriteLine("Enter employee details - id, name, age");
            emp.empid = int.Parse(Console.ReadLine());
            emp.name = Console.ReadLine();
            emp.age = int.Parse(Console.ReadLine());

            emp.showDetails();

            department dept = new department();

            Console.WriteLine("Enter department details - dept id, dept name, number of employees");
            dept.dept_id = int.Parse(Console.ReadLine());
            dept.dept_name = Console.ReadLine();
            dept.number_of_employees = int.Parse(Console.ReadLine());

            dept.showDetails();
        }
    }
}
