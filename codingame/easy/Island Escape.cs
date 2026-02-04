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
        int[,] ele = new int[N,N];
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
             Console.Error.WriteLine(string.Join(",",inputs));
            for (int j = 0; j < N; j++)
            {
                int elevation = int.Parse(inputs[j]);
                ele[i,j] = elevation;
            }
        }
        var x = new List<int>(new[] {(N+1)/2-1});
        var y = new List<int>(new[] {(N+1)/2-1});
        var D = new Dictionary<int, List<int>>();
        while (x.Count > 0 )
        {
            if (x.Contains(N-1) || y.Contains(N-1))
            {
                Console.WriteLine("yes");
                return;
            }
            CheckPath(x[0]+1,y[0],x);
            CheckPath(x[0]-1,y[0],x);
            CheckPath(x[0],y[0]+1,y);
            CheckPath(x[0],y[0]-1,y);
            x.RemoveAt(0);
            y.RemoveAt(0);
        }
        Console.WriteLine("no");

        void CheckPath(int x1, int y1, List<int> list)
        {   
            if (x1 < N && x1 >= 0 && y1 < N && y1 >= 0)
            {
            Console.Error.WriteLine(x1+" and "+y1);
            if (!D.ContainsKey(x1)) D[x1] = new List<int>();
            if (Math.Abs(ele[x1,y1]-ele[x[0],y[0]]) <= 1 && !D[x1].Contains(y1))
            {
            x.Add(x1);
            y.Add(y1);
            D[x1].Add(y1);
            }
            }
        
        }

    

        
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }
}
