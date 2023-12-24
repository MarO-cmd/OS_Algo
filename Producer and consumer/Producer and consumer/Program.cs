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
        static int bufferSize = 5;
        static int itemCount = 10;
        static void Producer()  // which produce 
        {
            for (int i = 0; i < itemCount; i++)
            {
                lock (buffer)
                {
                    while (buffer.Count >= bufferSize)
                    {
                        Console.WriteLine("Buffer is full. Producer is waiting...");
                        Monitor.Wait(buffer);
                    }
                    buffer.Enqueue(i);
                    Console.WriteLine("Produced: " + i);
                    // Notify the consumer that an item is available
                    Monitor.Pulse(buffer);
                }
                // Simulate some work done by the producer
                Thread.Sleep(100);
            }
        }
        static void Consumer() // which consume
        {
            for (int i = 0; i < itemCount; i++)
            {
                lock (buffer)
                {
                    while (buffer.Count == 0)
                    {
                        Console.WriteLine("Buffer is empty. Consumer is waiting...");
                        Monitor.Wait(buffer);
                    }
                    int consumedItem = buffer.Dequeue();
                    Console.WriteLine("Consumed: " + consumedItem);
                    // Notify the producer that space is available in the buffer
                    Monitor.Pulse(buffer);
                }
                // Simulate some work done by the consumer
                Thread.Sleep(200);
                
            }
        }

        
        static void Main(string[] args)
        {
            var producerThread = new Thread(Producer);
            var consumerThread = new Thread(Consumer);



            producerThread.Start();
            consumerThread.Start();
            producerThread.Join();
            consumerThread.Join();

            Console.WriteLine("Finished processing.");
        }



        //static Queue<int> buffer = new Queue<int>();
        //static int size = 5;

        //static int item = 10;

        //static void producer()
        //{
        //    for (int i = 0; i < item; i++)
        //    {
        //        lock (buffer)
        //        {
        //            if (buffer.Count >= size)
        //            {
        //                Console.WriteLine("the buffer is fuLL");
        //                Monitor.Wait(buffer);
        //            }

        //            buffer.Enqueue(i);
        //            Console.WriteLine($"produced :{i} ");
        //            Monitor.Pulse(buffer);
        //        }
        //    }

        //    Thread.Sleep(100);
        //}
        //static void consumer()
        //{
        //    for (int i = 0; i < item; i++)
        //    {
        //        lock (buffer)
        //        {
        //            if (buffer.Count == 0)
        //            {
        //                Console.WriteLine("the buffer is empty");
        //                Monitor.Wait(buffer);
        //            }

        //            int val = buffer.Dequeue();
        //            Console.WriteLine($"consumed :{val} ");
        //            Monitor.Pulse(buffer);
        //        }
        //    }

        //    Thread.Sleep(200);
        //}



        //static void Main(string[] args)
        //{



        //    Thread th1 = new Thread(producer);
        //    Thread th2 = new Thread(consumer);


        //    th1.Start();
        //    th2.Start();
        //    th1.Join();
        //    th2.Join();

        //}



    }
}
