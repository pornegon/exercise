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
        var R = new Dictionary<int, HashSet<string>>();
        int M = 0;
        bool F = false;

        for (int i = 0; i < N; i++)
        {
            string telephone = Console.ReadLine();
            Console.Error.WriteLine(telephone);
            for (int j = 0; j < telephone.Length; j++)
            {
                if (!R.ContainsKey(j)) R[j] = new HashSet<string>();
                string D = telephone.Substring(0, j+1);
                if (R[j].Contains(D) && !F) continue;

                if (!R[j].Contains(D)) 
                {
                    R[j].Add(D);
                }
                F = true;
                M++;
            }
            F = false;
        }
        
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        // The number of elements (referencing a number) stored in the structure.
        Console.WriteLine(M);
    }
}
