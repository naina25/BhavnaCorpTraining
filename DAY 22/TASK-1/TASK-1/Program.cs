using System;

namespace TASK_1
{
    class Program
    {
        //defining delegates of functions
        public delegate void addDelegate(int a, int b);
        public delegate string greetingsDelegate(string name);

        public void add(int x, int y)
        {
            Console.WriteLine(@"The sum of {0} and {1} is {2}", x, y, (x + y));

        }
        public static string Greetings(string name)
        {
            return "Hello " + name;
        }

        //--------------------generic delegates-------------------

        //returning function
        public static double Addnumber1(int x, float y, double z)
        {
            return x + y + z;
        }
        //printing function
        public static void Addnumber2(int x, float y, double z)
        {
            Console.WriteLine(x + y + z);
        }
        //conditional returning functions
        public static bool checkLength(string name)
        {
            if (name.Length > 5)
            {
                return true;
            }
            return false;
        }
        //defining delegates
        //public delegate double Addnum1delegate(int x, float y, double z);   //func generic delegate
        //public delegate void Addnum2delegate(int x, float y, double z);     //action generic delegate
        //public delegate bool checkLendelegate(string name);                 //predicate generic delegate
        static void Main(string[] args)
        {
            Program obj = new Program();

            //------------normal function calling---------

            //obj.add(100, 200);
            //string msg = Program.Greetings("Pranaya");
            //Console.WriteLine(msg);

            //----------instantiating delegate (delegate takes function as an argument)----------
            addDelegate ad = new addDelegate(obj.add);
            greetingsDelegate gd = new greetingsDelegate(Greetings);

            //---------invoking delegate----------------
            ad(100, 200);
            string s = gd("Mohit");
            Console.WriteLine(s);

            //-----------instanriating generic delegate-------------

            //Addnum1delegate obj1 = new Addnum1delegate(Addnumber1);
            //double result1 = obj1.Invoke(12, 12.25f, 91.02);
            //Console.WriteLine(result1);

            //Addnum2delegate obj2 = new Addnum2delegate(Addnumber2);
            //obj2.Invoke(10, 12.25f, 68.03);

            //checkLendelegate obj3 = new checkLendelegate(checkLength);
            //bool status = obj3.Invoke("Nainaaa");
            //Console.WriteLine(status);

            //--------we can use this below also code, instead of defining and instantiating the generic delegates -------
            Func<int, float, double, double> obj1 = new Func<int, float, double, double>(Addnumber1);
            double res = obj1.Invoke(10, 20.25f, 30.90);
            Console.WriteLine(res);

            Action<int, float, double> obj2 = new Action<int, float, double>(Addnumber2);
            obj2.Invoke(10, 10.23f, 64.0);

            Predicate<string> obj3 = new Predicate<string>(checkLength);
            bool status = obj3.Invoke("Nainaa");
            Console.WriteLine(status);
        }
    }
}
