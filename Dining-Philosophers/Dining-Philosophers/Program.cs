using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dining_Philosophers
{

    class philoFork
    {

        bool[] fork = new bool[5];

        public void Get(int left , int right)
        {
            lock (this)
            {
                while (fork[left] || fork[right])
                {
                    Monitor.Wait(this);
                }

                fork[left] = fork[right] = true;

            }
        }
        public void put(int left , int right) 
        {
            lock (this)
            {
                fork[left] = fork[right] = false;
                Monitor.PulseAll(this);
            }
        }
    }
    class philo
    {
        philoFork philofork;
        int n;
        int left, right;
        int eating_time, thinking_time;

        public philo(philoFork philofork, int n, int eating_time, int thinking_time)
        {
            this.philofork = philofork;
            this.n = n;
            this.eating_time = eating_time;
            this.thinking_time = thinking_time;

            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        Thread.Sleep(thinking_time);

                        philofork.Get(left, right);
                        Console.WriteLine($"the philo {n} is eating...");
                        Console.ReadKey();
                        Thread.Sleep(eating_time);
                        philofork.put(left, right);



                    }
                    catch
                    {

                        return;
                    }
                }
            }).Start();

            left = n == 0 ? 4 : (n - 1) % 5;
            right = n % 5;
        }

        //public void work()
        //{

        //    while (true)
        //    {
        //        try
        //        {
        //            Thread.Sleep(thinking_time);

        //            philofork.Get(left, right);
        //            Console.WriteLine("the philo is eating...");
        //            Thread.Sleep(eating_time);
        //            philofork.put(left, right);



        //        }
        //        catch 
        //        {

        //            return;
        //        }
        //    }
        //}
        
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            philoFork fork = new philoFork();


            new philo(fork, 0, 200, 300);
            new philo(fork, 1, 200, 300);
            new philo(fork, 2, 200, 300);
            new philo(fork, 3, 200, 300);
            new philo(fork, 4, 200, 300);
        }
    }
}
