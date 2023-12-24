using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFS
{
    internal class Program
    {
        static void AvgWaitingTime(int[] processes, int n, int[] brust_time)
        {
            int[] waiting_time = new int[n];
            int[] turnaround_time = new int[n + 1];

            for (int i = 1; i < n; i++)
            {
                waiting_time[i] = waiting_time[i - 1] + brust_time[i - 1];
            }
            for (int i = 1; i <= n; i++)
            {
                turnaround_time[i] = turnaround_time[i - 1] + brust_time[i - 1];
            }

            int total_waiting_time = waiting_time.Sum();
            int total_turnaround_time = turnaround_time.Sum();

            Console.WriteLine("process  brust_time  waiting_time  turnaround_time");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"p{i + 1}\t\t{brust_time[i]}\t\t{waiting_time[i]}\t\t{turnaround_time[i + 1]}");
            }

            Console.WriteLine($"Avarge of the waiting time {total_waiting_time / (n * 1.0)}");
            Console.WriteLine($"Avarge of the turnaround time {total_turnaround_time / (n * 1.0)}");
        }

        static void Main(string[] args)
        {
            int[] processes = { 1, 2, 3 };
            int n = processes.Length;

            int[] brust_time = { 24, 3, 4 };


            AvgWaitingTime(processes, n, brust_time);

        }
    }
}
