using System;
using System.Threading;

namespace SecondaryThreads.Models
{
    public class Printer
    {
        public void PrintNumbers()
        {
            // Display Thread info.
            Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);

            // Print out numbers.
            Console.Write("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}, ", i);
                Thread.Sleep(200);
            }

            Console.ReadLine();
        }
    }
}