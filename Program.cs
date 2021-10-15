using SecondaryThreads.Models;
using System;
using System.Threading;

namespace SecondaryThreads
{
    // When you want to programmatically create additional threads to carry on some unit of work,
    // follow this predictable process when using the types of the System.Threading namespace:
    // 1. Create a method to be the entry point for the new thread.
    // 2. Create a new ParameterizedThreadStart(or ThreadStart) delegate, passing the
    // address of the method defined in step 1 to the constructor.
    // 3. Create a Thread object, passing the ParameterizedThreadStart/ThreadStart delegate
    // as a constructor argument.
    // 4. Establish any initial thread characteristics (name, priority, etc.).
    // 5. Call the Thread.Start() method. This starts the thread at the method referenced
    // by the delegate created in step 2 as soon as possible.
    class Program
    {
        static void Main()
        {
            Console.WriteLine("***** The Amazing Thread App *****\n");
            Console.Write("Do you want [1] or [2] threads? ");
            string threadCount = Console.ReadLine();

            // Name the current thread.
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            // Display Thread info.
            Console.WriteLine("-> {0} is executing Main()", Thread.CurrentThread.Name);

            // Make worker class.
            Printer p = new Printer();
            switch (threadCount)
            {
                case "2":
                    // Now make the thread.
                    Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;
                case "1":
                    p.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("I don't know what you want...you get 1 thread.");
                    goto case "1";
            }

            // Do some additional work.
            Console.WriteLine("This is on the main thread, and we are finished.");
        }
    }
}