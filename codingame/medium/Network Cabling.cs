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
        Console.Error.WriteLine(N);
        long[] x = new long[N];
        long[] y = new long[N];
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            Console.Error.WriteLine(string.Join(",", inputs));
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            x[i] = X;
            y[i] = Y;
        }
        long[] yM = y;
        Array.Sort(yM);
        long xs = x.Max() - x.Min();
        long ym = yM[N/2];
        
         for (int i = 0; i < N; i++)
         {
            xs+= Math.Abs(y[i] - ym);
         }



        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(xs);
    }
}
