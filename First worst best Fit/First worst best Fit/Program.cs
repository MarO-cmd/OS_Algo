using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_worst_best_Fit
{
    internal class Program
    {
        static void FirstFit(int[] block_size , int[] process_size)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < process_size.Length; i++)
            {
                res.Add(-1);
                
                for (int j = 0; j < block_size.Length; j++)
                {

                    if (block_size[j] >= process_size[i])
                    {
                        block_size[j] -= process_size[i];
                        res[i] = j+1 ;
                        break;
                    }
                }
               
                
            }
            Console.WriteLine("process   process size  block no.");
            for (int i = 0; i < process_size.Length; i++)
            {
                Console.WriteLine($"p{i + 1}\t\t{process_size[i]}\t\t" + (res[i] == -1 ? "no block" : res[i].ToString()));
               

            }
        }
        static void bestFit(int[] block_size, int[] process_size)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < process_size.Length; i++)
            {
                res.Add(-1);
                int indx = -1;
                for (int j = 0; j < block_size.Length; j++)
                {

                    if (block_size[j] >= process_size[i])
                    {

                        if (indx == -1)
                        {
                            indx = j;

                        }
                        else if (block_size[j] < block_size[indx])
                            indx = j;


                           
                        
                        
                    }

                }
                if(indx!= -1 )
                {
                    block_size[indx] -= process_size[i];
                    res[i] = indx + 1;
                }
                

            }
            Console.WriteLine("process   process size  block no.");
            for (int i = 0; i < process_size.Length; i++)
            {
                Console.WriteLine($"p{i + 1}\t\t{process_size[i]}\t\t" + (res[i] == -1 ? "no block" : res[i].ToString()));
            }
        }
        static void WorstFit(int[] block_size, int[] process_size)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < process_size.Length; i++)
            {
                res.Add(-1);
                int indx = -1;
                for (int j = 0; j < block_size.Length; j++)
                {

                    if (block_size[j] >= process_size[i])
                    {

                        if (indx == -1)
                        {
                            indx = j;

                        }
                        else if (block_size[j] > block_size[indx])
                            indx = j;
                    }

                }
                if (indx != -1)
                {
                    block_size[indx] -= process_size[i];
                    res[i] = indx + 1;
                }


            }
            Console.WriteLine("process   process size  block no.");
            for (int i = 0; i < process_size.Length; i++)
            {
                Console.WriteLine($"p{i + 1}\t\t{process_size[i]}\t\t" + (res[i] == -1 ? "no block" : res[i].ToString()));


            }
        }

        static void Main(string[] args)
        {
            int[] process_size = { 212, 417, 112, 426 };

            int[] block_size = { 100, 500, 200, 300, 600 };

            WorstFit(block_size, process_size);
        }
    }
}
