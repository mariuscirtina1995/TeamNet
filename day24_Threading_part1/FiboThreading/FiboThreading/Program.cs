using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FiboThreading
{
    public class Program
    {
        public static void Main(string[] args)
        {

            const int fibo_number = 30;

            //class 
            ThreadState[] doThraed = new ThreadState[fibo_number];
            ManualResetEvent[] events = new ManualResetEvent[fibo_number];
            int[] fibArray = new int[fibo_number];

            // Configure and launch threads using ThreadPool:
            for (int i = 0; i < fibo_number; i++)
            {
                doThraed[i] = new ThreadState()
                {
                    Number = i + 1,
                    Mre = new ManualResetEvent(false),
                    Rezultat = 0,
                };

                events[i] = doThraed[i].Mre;

                ThreadPool.QueueUserWorkItem(ExecuteInForeground, doThraed[i]);
            }

            WaitHandle.WaitAll(events);
            Console.WriteLine("All calculations are complete.");

            // Display the results...
            for (int i = 0; i < fibo_number; i++)
            {
                fibArray[i] = doThraed[i].Rezultat;

                Console.WriteLine("Fibonacci({0}) = {1}", i+1, fibArray[i]);
            }

            Console.ReadLine();
        }

        private static void ExecuteInForeground(object state)
        {

            var thState = (ThreadState)state;
            var mre = thState.Mre;

            thState.Rezultat = CalculateFibonaci(thState.Number);

            Console.WriteLine(String.Format("Thread {0} has calculated {1} for number {2} finished!"
                , Thread.CurrentThread.ManagedThreadId
                , thState.Rezultat
                , thState.Number));

            mre.Set();
        }

        private static int CalculateFibonaci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            return CalculateFibonaci(n - 1) + CalculateFibonaci(n - 2);
        }

        class ThreadState
        {
            public int Number { get; set; }
       
            public ManualResetEvent Mre { get; set; }

            public int Rezultat { get; set; }
        }

    }
}
