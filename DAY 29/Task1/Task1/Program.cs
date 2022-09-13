using System;

namespace Task1
{
    public class cat
    {
        public void run()
        {
            Console.WriteLine("Cat is running");
        }
    }

    public class rat
    {
        public void run()
        {
            Console.WriteLine("Rat is running");
        }
    }

    public class user
    {
        public string name { get; set; }
        private string[] emailIDs = new string[10];
        public string contact { get; set; }
        public string this[int index]
        {
            get { return emailIDs[index]; }
            set { emailIDs[index] = value; }
        }

    }

    public class employee
    {
        public string name { get; set; }
        public int age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                //-----------caller method information concept------------
                //logInfo();

                //--------dynamic object creation---------
                //cat c = new cat();
                //rat r = new rat();
                //common(c);
                //common(r);

                //BigInteger b = new BigInteger(5565737673643477563);

                //var book = new Tuple<string, string, double>("C# in depth", "Manish", 200);
                //var book = Tuple.Create("C# in depth", "Manish", 200);
                //Console.WriteLine("-------------Book's Record--------------");
                //Console.WriteLine("Title " + book.Item1 + " Writer " + book.Item2 + " price " + book.Item3);

                //multi argumented method calling
                //var (name, email) = show();
                //Console.WriteLine(name + " " + email);


                //var user = new user
                //{
                //    [1] = "naina@gmail.com",
                //    [2] = "mohit@gmail.com",
                //    [3] = "asish@gmail.com",
                //    [4] = "anu@gmail.com",
                //    name = "Naina2525",
                //    contact = "9887876576"
                //};


                //string name = "Naina";
                //var date = DateTime.Now;

                //normal string writing method
                //Console.WriteLine("Hello " + name + " Today is " + date);
                //string interpolation
                //Console.WriteLine($"Hello {name} it is {date}");
                //Console.WriteLine("Hello {0} today is {1}", name, date);

                //ternary operator------------
                //employee emp = null;
                //string employee = (emp != null) ? emp.name : null;
                //Console.WriteLine(employee);

                //we can pass null to the integer type argument here due to the  use of '?' in its definition
                sum(4, null);

            }

            //due to this '?' here, we can either give null to 'y' or its required value i.e. int
            static void sum(int x, int? y)
            {
                Console.WriteLine(x);
                Console.WriteLine(y);
            }

            //multi argumented method
            static (string name, string email) show()
            {
                return ("Irfan", "irfan@gmail.com");
            }

            //implementation of dynamic object - keyword dynamic says that it can accept any type of object of any class
            static void common(dynamic obj)
            {
                obj.run();
            }

            //This below method is giving us the caller method information of this function at runtime.
            static void logInfo([CallerMemberName] string methodName = "", [CallerLineNumberAttribute] int linenumber = 0, [CallerFilePath] string path = "")
            {
                Console.WriteLine("Welcome to c#");
                Console.WriteLine("Method Name: " + methodName);
                Console.WriteLine("Line Number: " + linenumber);
                Console.WriteLine("File Path: " + path);
            }
        }
    }
}
