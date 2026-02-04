using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int C = int.Parse(Console.ReadLine());
        Console.Error.WriteLine(C);
        int[] B = new int[N];
        int[] res = new int[N];
        int TB = 0;
        for (int i = 0; i < N; i++)
        {
            int b = int.Parse(Console.ReadLine());
            TB += b;
            B[i] = b;
        }
        
        Console.Error.WriteLine(TB+":   "+string.Join(",",B));

        
        Array.Sort(B);
        if (C > TB) 
        Console.WriteLine("IMPOSSIBLE");
        else
        {
            foreach (int c in B)
            {
                int avg = C/N;
                if (c > avg)
                {
                    Console.WriteLine(avg);
                    C -= avg;
                }
                else
                {
                    Console.WriteLine(c);
                    C -= c;
                }
                N--;
            }


        }


    


        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }
}
