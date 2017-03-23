using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CountDownEventDemo.ShowDemo();
            InterlockedDemo.ShowDemo();

            Console.WriteLine("Enter any key to exit...");
            Console.ReadKey();
        }
    }
}
