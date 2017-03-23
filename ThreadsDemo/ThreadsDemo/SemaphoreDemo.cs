using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsDemo
{
    class SemaphoreDemo
    {

        static Semaphore s1 = new Semaphore(2, 2, "MySemaphoreDemo");

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
            return s1.WaitOne(5000, false);
        }
    }
}
