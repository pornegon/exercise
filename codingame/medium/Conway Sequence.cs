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
        //int R = int.Parse(Console.ReadLine());
        string R = Console.ReadLine();
        string RO = "";
        if (R.Length > 1 && R[1] != '1') RO += (R[1]);
        int L = int.Parse(Console.ReadLine());
        string LR = "";
    for (int i = 2; i < L+1; i++)
    {
    int k = 1;
        for (int j = 0; j < R.Length; j+=2)
        {
            if (j+2 < R.Length && R[j] == R[j+2])
            {
                k++;
            }
            else 
            {
                LR += k+" "+R[j]+" ";
                k = 1;
            }
        }
    R = LR;
    LR="";
    }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(R.TrimEnd()+RO);
    }
}
