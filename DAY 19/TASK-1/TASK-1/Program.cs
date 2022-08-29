using System;
using System.Collections.Generic;
using TASK_1.partialClasses;

namespace TASK_1
{
    class Program:employee
    {
        static void Main(string[] args)
        {
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

            //list and forEach loop
            List<int> numbers = new List<int>()
            {
                116,12,345,23,9,867,23,45,12,46,40
            };

            Console.WriteLine("Even numbers are: ");
            List<int> evennumbers = numbers.FindAll(x => (x % 2) == 0);
            foreach (var value in evennumbers)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Even numbers are: ");
            List<int> oddnumbers = numbers.FindAll(x => (x % 2) != 0);
            foreach (var value in oddnumbers)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Numbers multiple of 5: ");
            List<int> mul5 = numbers.FindAll(x => (x % 5) == 0);
            foreach (var value in mul5)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            //list from student.cs class
            List<student> stu = new List<student>
            {
                new student { stuid = 101, name = "Naina", branch = "CSE", age = 23 },
                new student { stuid = 102, name = "Devesh", branch = "IT", age = 21 },
                new student { stuid = 103, name = "Anjali", branch = "ECE", age = 23 },
                new student { stuid = 104, name = "Neha", branch = "CE", age = 22 },           
            };

            foreach (student stus in stu)
            {
                Console.WriteLine(stus.stuid + "/" + stus.name + "/" + stus.branch + "/" + stus.age);
            }

            //partial clasees----------
            sample movie = new sample("XYZ", 2020);
            movie.displayDetails();
        }
    }
}
