using System;

namespace Task_2
{
    public struct employee
    {
        public int id;
        public string name;
        public double salary;
        public string gender;
    }

    //--------new account class with static variable intialise in it------
    //class account
    //{
    //    public int accno;
    //    public string name;
    //    public static int count = 0; //static keyword ensures that after one compilation it will not redeclared again and again..

    //    public account(int accno, string name)
    //    {
    //        this.accno = accno;
    //        this.name = name;
    //        count++;
    //    }

    //    public void display()
    //    {
    //        Console.WriteLine(count);

    //    }
    //}

    //-------static class example-----
    //public static class myMath
    //{
    //    public static float pi = 3.14f;
    //    public static int cube(int n)
    //    {
    //        return n * n * n;
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            employee[] emp = new employee[2];

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Enter the employee id");
                emp[i].id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the employee name");
                emp[i].name = Console.ReadLine();

                Console.WriteLine("Enter the employee salary");
                emp[i].salary = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter the employee gender");
                emp[i].gender = Console.ReadLine();
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(emp[i].id + " " + emp[i].name + " " + emp[i].salary + " " + emp[i].gender);

            }

            //----------class account-------
            //account a1 = new account(10256, "Naina");
            //account a2 = new account(12323, "Neha");
            //a1.display();
            //a2.display();

            //we can't make object of static class, but we can access variables of static class directly-----
            //-------accessing variables of static class-------
            //Console.WriteLine("Pi value is: " + myMath.pi);
            //Console.WriteLine("Cube:" + myMath.cube(5));
        }
    }
}
