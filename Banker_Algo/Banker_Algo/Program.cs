using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banker_Algo
{
    using System;

    class BankersAlgorithm
    {

        static int process = 5, resourcess = 3;
        static List<int> res = new List<int>();
        static int[,] alloc = new int[,]
        {
            {0,1,0},
            {2,0,0},
            {3,0,2},
            {2,1,1},
            {0,0,2},
        };

        static int[,] max = new int[,]
        {
            {7,5,3},
            {3,2,2},
            {9,0,2},
            {2,2,2},
            {4,3,3},
        };


        static int[] available = new int[] { 3, 3, 2 };
        static int[,] need = new int[process, resourcess];
        static void CalcNeed(int[,] max, int[,] alloc)
        {
            for (int i = 0; i < process; i++)
                for (int j = 0; j < resourcess; j++)
                {
                    need[i, j] = max[i, j] - alloc[i, j];
                }
        }


        static bool IsSafe()
        {

            int count = 0;

            bool[] visted = new bool[process];

            while (count < process)
            {
                bool flag = false;
                for (int i = 0; i < process; i++)
                {

                    if (!visted[i])
                    {
                        bool t = true;
                        for (int j = 0; j < 3; j++)
                        {
                            if (available[j] < need[i, j])
                            {
                                t = false;
                                break;
                            }
                        }
                        if (t)
                        {
                            res.Add(i);
                            for (int k = 0; k < 3; k++)
                            {
                                available[k] += alloc[i, k];
                            }
                            flag = true;
                            visted[i] = true;
                            count++;
                        }
                    }

                }
                if (!flag)
                    break;

            }

            return count == process;
        }

        static void Main(string[] args)
        {
            CalcNeed(max, alloc);

            bool check = IsSafe();

            Console.WriteLine(check ? "the system is safe!" : "the system is unsafe!");

            if (check)
            {
                foreach (int i in res)
                    Console.WriteLine($"p{i}");
            }

        }
    }
}




