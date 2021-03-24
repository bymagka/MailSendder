using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            while(n != 0)
            {

                //thread with sum counting
                Thread newThread = new Thread(new ParameterizedThreadStart((x) =>
                {
                    int sum = 0;
                    for (int i = 1; i <= (int)x; i++) sum += i;
                    Console.WriteLine($"Sum of {x}: {sum}. Counted by {Thread.CurrentThread.Name}");
                    
                }
                ))
                {Name = "Second thread" };

                newThread.Start(n);

             
                //factorial is counted in main thread
                int factorial = 1;
                for(int i = 1; i <= n; i++)
                {
                    factorial *= i;
                }

                Console.WriteLine($"Factorial of {n} is {factorial}");

                n = int.Parse(Console.ReadLine());
            }

            Console.ReadKey();
        }
    }
}
