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
        int n = int.Parse(Console.ReadLine());
        int delta = 0;
        int vmax = 0;
        int[] inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        for (int i = 0; i < n; i++)
        {
            if (inputs[i] > vmax)
            {
            vmax = inputs[i];
            int vmin = inputs.Skip(i).Min();
            delta = Math.Min(delta, vmin-inputs[i]);
            }
        }


        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(delta);
    }
}
