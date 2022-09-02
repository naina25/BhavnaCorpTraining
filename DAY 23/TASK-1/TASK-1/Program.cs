using System;
using ClassLibrary;

namespace TASK_1
{
    class Program
    {
        static void changeName(person a, person b)
        {
            a.name = "Naina Upadhyay";
            b.name = "Akanksha Goel";
            Console.WriteLine("Good Evening "+a.name +" "+ b.name);
        }
        static void Main(string[] args)
        {
            //reference type, value type example
            person person1 = new person();
            person person2 = new person();

            person1.name = "Kirti Dubey";
            person2.name = "Anjali Saini";

            //value type
            Console.WriteLine("Good Evening " + person1.name + " and " + person2.name);

            //reference type
            changeName(person1, person2);

            person2 = +person1;
            Console.WriteLine(person2.x + " " + person2.y);

        }
    }
}
