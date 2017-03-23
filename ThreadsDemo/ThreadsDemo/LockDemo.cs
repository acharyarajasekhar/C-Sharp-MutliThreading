using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsDemo
{
    class ThreadUnsafe
    {
        static int _val1 = 1, _val2 = 1;

        static void Go()
        {
            if (_val2 != 0) Console.WriteLine(_val1 / _val2);
            _val2 = 0;
        }
    }

    /*
     * 
     This class is not thread-safe: if Go was called by two threads simultaneously, it would be possible to get 
     a division-by-zero error, because _val2 could be set to zero in 
     one thread right as the other thread was in between executing the if statement and Console.WriteLine.
    *
    */

    class ThreadSafeWithLock
    {
        static readonly object _locker = new object();
        static int _val1, _val2;

        static void Go()
        {
            lock (_locker)
            {
                if (_val2 != 0) Console.WriteLine(_val1 / _val2);
                _val2 = 0;
            }
        }
    }

    class ThreadSafeWithMonitor
    {
        static readonly object _locker = new object();
        static int _val1, _val2;

        static void Go()
        {
            Monitor.Enter(_locker);

            if (_val2 != 0) Console.WriteLine(_val1 / _val2);
            _val2 = 0;

            Monitor.Exit(_locker);
        }
    }
}
