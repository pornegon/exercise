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
 record Position(int X, int Y, int W, int H)
{
    public Position[] Next()
    => [new (X + 1 < W ? X + 1 : 0, Y, W, H), 
        new (X - 1 >= 0 ? X - 1 : W - 1, Y, W, H), 
        new (X, Y + 1 < H ? Y + 1 : 0, W, H), 
        new (X, Y - 1 >= 0 ? Y - 1 : H - 1, W, H)];
}
class Solution
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int w = int.Parse(inputs[0]);
        int h = int.Parse(inputs[1]);

        var maze = new char[h,w];
        int mov = 1;

        var q = new Queue<Position>();

        for (int i = 0; i < h; i++)
        {
            string ROW = Console.ReadLine();
            int j = 0;
            Console.Error.WriteLine(ROW);
            foreach (char c in ROW) 
            {
                if (c == 'S') 
                {
                    q.Enqueue(new Position(i,j,h,w)); 
                    maze[i,j] = '0';
                }
                else maze[i,j] = c;  
                j++;
            }
        }

        while (q.Any())
        {
            int step = q.Count;
            while (step > 0)
            {
                var cur = q.Dequeue();


                var point = (char)(mov+'0');
                if (mov > 9) point = (char)(mov+55);

                foreach (var next in cur.Next())
                {
                    if (maze[next.X,next.Y] == '.')
                    {
                        q.Enqueue(next);
                        maze[next.X,next.Y] = point;
                    }
                }
                step--;
            }
            mov++;
        }

        


        for (int i = 0; i < h; i++)
        {

            // Write an answer using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            for (int j = 0; j < w; j++) Console.Write(maze[i,j]);
            Console.WriteLine();
        }
    }
}
