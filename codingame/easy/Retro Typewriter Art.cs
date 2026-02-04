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
        string[] key = {"sp", "bS", "sQ", "nl"};
        string[] code = {" ", "\\", "'", "\n"};
        string addseg = "";
        string ans = "";
        string[] T = Console.ReadLine().Split(" ");
        Console.Error.WriteLine(string.Join(",",T));
        foreach (string seg in T)
        {   
            for (int i = 0; i < key.Length; i++)
            {
                if (seg.Contains(key[i])) 
                {
                    addseg = code[i];
                    if (!int.TryParse(seg.Replace(key[i],string.Empty), out int a))
                    {
                        ans += addseg;
                        break;
                    }
                    else 
                    {
                        for (int j = 0; j < a; j++)
                        {
                        ans += addseg;
                        }
                    break;
                    }
                }
            }
            if (addseg.Length == 0)
            {
                addseg = seg[^1].ToString();
                if (int.TryParse(seg.Remove(seg.Length-1), out int a)) 
                {
                    for (int j = 0; j < a; j++) ans += addseg;
                }
            }
            addseg = "";

        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(ans);
    }
}
