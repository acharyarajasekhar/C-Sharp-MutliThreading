using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsDemo
{
    class CountDownEventDemo
    {
        internal static void ShowDemo()
        {
            Console.WriteLine("Start of CountdownEvent Demo\n");

            // Initially it is assumed that the number of threads will be 1
            CountdownEvent countObject = new CountdownEvent(1);

            //fetch number of records from database.
            int totalRecords = 5;
            int[] result = new int[totalRecords];

            countObject.Reset(totalRecords);

            for (int i = 0; i < totalRecords; ++i)
            {
                int j = i;
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    result[j] = j * 10;
                    countObject.Signal();
                });
            }
            Console.WriteLine("Waiting for required number of signals...");

            countObject.Wait();

            foreach (var r in result)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine("End of CountdownEvent Demo\n\n");
        }
    }
}
