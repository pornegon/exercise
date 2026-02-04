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
        int n = int.Parse(Console.ReadLine()); // the number of cards for player 1
        Console.Error.WriteLine(n);
        List<int> p1 = new List<int>();
        List (n, p1);

        Console.Error.WriteLine(string.Join(",",p1));

        int m = int.Parse(Console.ReadLine()); // the number of cards for player 2
        List<int> p2 = new List<int>();
        Console.Error.WriteLine(m);
        List (m, p2);
        
        Console.Error.WriteLine(string.Join(",",p2));

        int ans = 0;
        List<int> bat = new List<int>();
        List<int> bat2 = new List<int>();

        while (p1.Count > 0 && p2.Count > 0)
        {   
            
            bat.Add(p1[0]);
            bat2.Add(p2[0]);
            p1.RemoveAt(0);
            p2.RemoveAt(0);
            if (bat[bat.Count-1] != bat2[bat2.Count-1])
            {
                if (bat[bat.Count-1] > bat2[bat2.Count-1]) 
                {
                    p1.AddRange(bat);
                    p1.AddRange(bat2);
                }
                else 
                {
                    p2.AddRange(bat);
                    p2.AddRange(bat2);
                }
                Console.Error.WriteLine("battle: "+string.Join(",",bat)+" p1: "+string.Join(",",p1)+" p2: "+string.Join(",",p2)+" in "+ans);
                bat.Clear();
                bat2.Clear();
                ans++;
                continue;
            }
            else
            {
                if (p1.Count < 3 || p2.Count < 3)
                {
                    ans = -ans;
                    break;
                }
                bat.AddRange(p1.GetRange(0, 3));
                bat2.AddRange(p2.GetRange(0, 3));
                p1.RemoveRange(0,3);
                p2.RemoveRange(0,3);
                Console.Error.WriteLine("war: "+string.Join(",",bat)+" p1: "+string.Join(",",p1)+" p2: "+string.Join(",",p2)+" in "+ans);
            }
        }


        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");u

        int win = p1.Count > p2.Count ? 1 : 2;
        if (ans > 0) Console.WriteLine(win+" "+ans);
        else Console.WriteLine("PAT");

    void List(int n, List<int> p)
    {
    for (int i = 0; i < n; i++)
    {
       string cardp1 = Console.ReadLine(); // the n cards of player 1
       string card = cardp1.Remove(cardp1.Length-1).Replace("J", "11").Replace("Q", "12").Replace("K", "13").Replace("A", "14");
       p.Add(int.Parse(card)); 
    }
    }

    } 

    
}
