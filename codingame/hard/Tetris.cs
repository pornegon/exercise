Tetrisusing System;
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
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int SW = int.Parse(inputs[0]);
        int SH = int.Parse(inputs[1]);
        Console.Error.WriteLine(SW+"   "+SH);
        var fig = new char[SW, SH];

        for (int i = 0; i < SH; i++)
        {
            string SROW = Console.ReadLine();
            Console.Error.WriteLine(i+"   "+SROW);
            for (int j = 0; j < SROW.Length; j++)
                fig[j, i] = SROW[j];
        }

        inputs = Console.ReadLine().Split(' ');
        int FW = int.Parse(inputs[0]);
        int FH = int.Parse(inputs[1]);
        var grid = new string[FH];
        int X = 0;
        int Y = 0;
        int ans = 0;

        for (int i = 0; i < FH; i++)
        {
            string FROW = Console.ReadLine();
            Console.Error.WriteLine(i+"   "+FROW);
            grid[i] = FROW;
            if (FROW.Contains('*') && FROW.Count(c => c == '.') >= SW && X == 0 && Y == 0)
            {
                X = FROW.IndexOf('.');
                Y = i; //bottom left
            }
        }
        Console.Error.WriteLine($"entry coords {X}, {Y}");

        while (!Seek(ref X, ref Y) && grid[Y].Count(c => c == '.') >= SW)
        {
            X++;
        }
        Y -= (SH-1); //top left, counting rows from the top
         Console.Error.WriteLine($" we {Y} now");
        for (int i = 0; i < SH; i++)
        {
            char[] griddo = grid[Y+i].ToCharArray();
            for (int j = 0; j < SW; j++)
            {
                griddo[X+j] = fig[j,i] == '*' ? '*' : griddo[X+j];
            }
            Console.Error.WriteLine((Y+i)+"  "+string.Join("",griddo));
            if (griddo.All(c => c == '*'))
                ans++;
        }
        Console.WriteLine($"{X} {FH-Y-1}");
        Console.WriteLine(ans);


        bool Seek(ref int X, ref int Y)
        {
            for (int h = 0; h < SH; h++)
            {
                if (Y-h >= 0)
                    for (int i = 0; i < SW; i++)
                    {
                        char p = fig[i, SH-1-h];
                        if (p == '*' && grid[Y+1-h][X+i] == '*')
                            {
                                Console.Error.WriteLine($"stuck at {X+i}, {Y+1}");
                                return false;
                            }
                    }
            }
            Y++;
            Console.Error.WriteLine($"onwards to {X}, {Y}");
            if (Y+1 >= FH)
                return true;
            Seek(ref X, ref Y);
            return true;
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }
}
