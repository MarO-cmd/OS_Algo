using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Producer_and_consumer
{
    internal class Program
    {

        static Queue<int> buffer = new Queue<int>();
        static int size = 5;

        static int item = 10;

        static void producer()
        {
            for (int i = 0; i < item; i++)
            {
                lock (buffer)
                {
                    if (buffer.Count >= size)
                    {
                        Console.WriteLine("the buffer is fuLL");
                        Monitor.Wait(buffer);
                    }

                    buffer.Enqueue(i);
                    Console.WriteLine($"produced :{i} ");
                    Monitor.Pulse(buffer);
                }
            }

            Thread.Sleep(200);
        }
        static void consumer()
        {
            for (int i = 0; i < item; i++)
            {
                lock (buffer)
                {
                    if (buffer.Count == 0)
                    {
                        Console.WriteLine("the buffer is empty");
                        Monitor.Wait(buffer);
                    }

                    int val = buffer.Dequeue();
                    Console.WriteLine($"consumed :{val} ");
                    Monitor.Pulse(buffer);
                }
            }

            Thread.Sleep(500);
        }



        static void Main(string[] args)
        {



            Thread th1 = new Thread(producer);
            Thread th2 = new Thread(consumer);


            th1.Start();
            th2.Start();
            th1.Join();
            th2.Join();

        }



    }
}
