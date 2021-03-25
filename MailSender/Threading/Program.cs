using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static object lockObject = new object();

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


            //files
            //ver. 1
            //thread for reading

            Thread readingThread = new Thread(() =>
            {
           
                File.Delete("../../students_6.txt");
                using (StreamReader sr = new StreamReader("../../students_6.csv"))
                {
                    while (!sr.EndOfStream)
                    {
                        string textLine = sr.ReadLine();

                        Thread writingThread = new Thread(new ParameterizedThreadStart((x) =>
                        {
                            string line = (string)x;

                            lock (lockObject)
                            {
                                using (StreamWriter sw = new StreamWriter("../../students_6.txt", true))
                                {
                                    sw.WriteLine(line);
                                }
                            }



                        }))
                        {Priority=ThreadPriority.AboveNormal };

                        writingThread.Start(textLine);
                    }
                }
            });

            readingThread.Start();

            Console.ReadKey();
        }
    }
}
