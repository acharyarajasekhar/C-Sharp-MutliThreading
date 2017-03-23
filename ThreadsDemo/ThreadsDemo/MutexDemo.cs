using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsDemo
{
    class MutexDemo
    {
        /* 
         * A Mutex is like a C# lock, but it can work across multiple processes. 
           In other words, Mutex can be computer-wide as well as application-wide.
         *
        */

        static Mutex m1 = new Mutex(true, "MyMutexDemo");

        static void Main(string[] args)
        {

            if (IsInstance())
            {
                Console.WriteLine("New Instance created...");
            }
            else
            {
                Console.WriteLine("Instance already acquired...");
            }

            Console.ReadLine();
        }

        static bool IsInstance()
        {
            return m1.WaitOne(5000, false);
        }
    }
}
