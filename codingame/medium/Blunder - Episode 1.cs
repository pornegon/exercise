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
public record pos(int x, int y)
{
    public pos Move(string i)
    => i switch
    {
        "SOUTH" => new(x, y+1),
        "EAST" => new(x+1, y),
        "NORTH" => new(x, y-1),
        "WEST" => new(x-1, y),
    };
}
class Solution
{
    static void Main(string[] args)
    {
        string[] pri = {"SOUTH", "EAST", "NORTH", "WEST"};
        int mov = 0;
        string[] inputs = Console.ReadLine().Split(' ');
        Console.Error.WriteLine(string.Join(",", inputs));
        int L = int.Parse(inputs[0]);
        int C = int.Parse(inputs[1]);

        bool beer = false;
        bool inv = false;
        bool[] last = {false,false,false};
        int breakcount = 0;
        int breakc = 0;
        
        var q = new Queue<pos>();
        var been = new List<(pos, string,int, bool, bool)>();

        var T = new List<pos>();

        var grid = new char[C,L];
        
        for (int i = 0; i < L; i++)
        {
            string row = Console.ReadLine().Trim();
            Console.Error.WriteLine(row);
            for (int j = 0; j < C; j++)
            {
            grid[j,i] = row[j];
            if (row[j] == '@') q.Enqueue(new pos(j,i));
            if (row[j] == 'T') T.Add(new pos(j,i));
            }
        }


        while (q.Count > 0)
        {
            var pos = q.Dequeue();

            string dir = pri[mov];
            var newpos = pos.Move(dir);
            
            var symbol = grid[newpos.x,newpos.y];

            if (symbol == '$') 
            {
                been.Add((pos, dir,breakc, beer, inv));
                break;
            }

            if (symbol == '#' || (symbol == 'X' && !beer))
            {
                mov = -1;
                while (symbol == '#' || (symbol == 'X' && !beer))
                {
                    mov++;
                    dir = pri[mov];
                    newpos = pos.Move(pri[mov]);
                    symbol = grid[newpos.x,newpos.y];
            Console.Error.WriteLine(dir+"   "+symbol+"  "+newpos);
                }
            }
                foreach (string direction in pri)
                {   
                    if (symbol == direction[0])
                    {
                        mov = Array.IndexOf(pri, direction);
                        Console.Error.WriteLine(symbol+"   "+mov);
                    }
                }
                if (symbol == 'B') beer = !beer;
                if (symbol == 'X' && beer)
                {
                     grid[newpos.x,newpos.y] = ' ';
                     breakc++;
                     Console.Error.WriteLine($"broke {breakc} boxes");
                }
                if (symbol == 'T') 
                {
                    int i = T.IndexOf(newpos);
                    newpos = i == 0 ? T[1] : T[0];
                    Console.Error.WriteLine(symbol+"  tele# "+i+"    "+newpos);
                }
                if (symbol == 'I') 
                {
                    Array.Reverse(pri); 
                    inv = !inv;             
                    mov = Array.IndexOf(pri, dir); 
                    Console.Error.WriteLine(string.Join(",", pri));
                }
                q.Enqueue(newpos);
                if (been.Contains((pos,dir,breakc,beer,inv)))
                {
                    if (last[0] == false) 
                    {
                        last[0] = true;
                        last[1] = beer;
                        last[2] = inv;
                        breakcount = breakc;
                    }
                    else if (last[1] == beer && last[2] == inv && breakc == breakcount)
                    {
                        been.Clear();
                        break;
                    }
                    else 
                    {
                        last[0] = false;
                    }
                }

            
             been.Add((pos, dir,breakc,beer,inv));
            Console.Error.WriteLine(newpos+" "+dir+" "+symbol+"  "+breakc);
            }
        Console.Error.WriteLine();

        if (!been.Any()) Console.WriteLine("LOOP");
        else for (int i=0; i<been.Count; i++)
        {
            Console.WriteLine(been[i].Item2);
        }
            
                
        

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }
}

