using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Round_Robin
{
    internal class Program
    {
        static void CalcAvgTimeRoundRobin(int[] process  , int[] brust_time, int n , int quantum)
        {
            int time = 0;
            int[] waiting_time = new int[n];

            int[] tmp_brust = (int[])brust_time.Clone();

            while (true)
            {
                bool flag = true;
                for (int i = 0; i < n; i++)
                {
                    if (tmp_brust[i] >0)
                    {
                        flag = false;

                        if (tmp_brust[i] > quantum)
                        {
                            tmp_brust[i] -= quantum;
                            time += quantum;           
                        }
                        else
                        {
                            time += tmp_brust[i];
                            tmp_brust[i] = 0;
                            waiting_time[i] = time - brust_time[i];
                        }
                    }
                }

                if (flag)
                    break;
            }

            int[] turn_around_time = new int[n];

            for (int i = 0; i < n; i++)
            {
                turn_around_time[i] = waiting_time[i] + brust_time[i];
            }

            int total_waiting_time = waiting_time.Sum();
            int total_turn_around_time = turn_around_time.Sum();

            Console.WriteLine("process  brust time waiting time  turn around time");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"p{i + 1}\t\t{brust_time[i]}\t{waiting_time[i]}\t\t{turn_around_time[i]}");
            }
            Console.WriteLine($"the avg waiting time {total_waiting_time/(n*1.0 )}");
            Console.WriteLine($"the avg turn around time {total_turn_around_time/(n*1.0 )}");

        }

        static void Main(string[] args)
        {
            int[] process = { 1, 2, 3 };

            int n = process.Length;
            int[] brust_time = { 10, 5, 8 };

            int quantum = 2;

            CalcAvgTimeRoundRobin(process, brust_time, n, quantum);

        }
    }
}
