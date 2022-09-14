using System;
using System.Threading;

namespace TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------information of main thread--------------------
            Thread t1 = Thread.CurrentThread;
            Console.WriteLine("Thread Id:{0}", t1.ManagedThreadId);
            Console.WriteLine("Is Background Thread:{0}", t1.IsBackground);
            Console.WriteLine("Thread Culture:{0}", t1.CurrentCulture);

            //---------------thread creation------------------------------
            // Create thread
            Thread t2 = new Thread(new ThreadStart(PrintInfo));
            // start newly created thread
            t2.Start();
            Console.WriteLine("Thread State: {0}", t2.ThreadState);

            //---------------multi threading------------------------------
            PrintInfo1();
            PrintInfo2();
            Console.ReadLine();

            //--------------------sleep-----------------------------------
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Thread paused for {0} second", 1);
                // Pause thread for 1 second
                Thread.Sleep(1000);
                Console.WriteLine("i value: {0}", i);
            }

            //------------------lock------------------------------------
            Thread tnew1 = new Thread(new ThreadStart(PrintInformation));
            Thread tnew2 = new Thread(new ThreadStart(PrintInformation));
            tnew1.Start();
            tnew2.Start();

            Console.WriteLine("Main thread completed");
        }

        //lock------------------------------------------------------------
        static readonly object pblock = new object();
        static void PrintInformation()
        {
            lock (pblock)
            {
                for (int i = 1; i <= 4; i++)
                {
                    Console.WriteLine("i value: {0}", i);
                    Thread.Sleep(1000);
                }
            }
        }
        static void PrintInfo()
        {
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine("i value: {0}", i);
            }
            Console.WriteLine("Child Thread Completed");
        }

        static void PrintInfo1()
        {
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine("i value: {0}", i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("First method completed");
        }

        static void PrintInfo2()
        {
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine("i value: {0}", i);
            }
            Console.WriteLine("Second method completed");
        }
    }
}
