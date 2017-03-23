using System;
using System.Threading;

namespace ThreadsDemo
{
    class InterlockedDemo
    {
        static int _value;

        internal static void ShowDemo()
        {
            Console.WriteLine("Start of Interlocked Demo\n");

            Thread thread1 = new Thread(A);
            Thread thread2 = new Thread(A);
            thread1.Start(1);
            thread2.Start(2);
            thread1.Join();
            thread2.Join();
            Console.WriteLine(_value);

            Console.WriteLine("End of Interlocked Demo\n\n");
        }

        static void A(object num)
        {
            // Add one then subtract two.
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId + " Init: " + _value);
            Interlocked.Increment(ref _value);
            Thread.Sleep(1000 * (int)num);
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId + " Increment: " + _value);
            Interlocked.Decrement(ref _value);
            Thread.Sleep(1000 * (int)num);
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId + " Decrement 1: " + _value);
            Interlocked.Decrement(ref _value);
            Thread.Sleep(1000 * (int)num);
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId + " Decrement 2: " + _value);
        }
    }
}
