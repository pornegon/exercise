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

record pos(int x, int y)
{
    public pos Seek(int i)
    {
        return i switch
    { 
        0 => new (x+1,y),
        1 => new (x-1,y),
        2 => new (x,y+1),
        3 => new (x,y-1),
        4 => new (x-1,y-1),
        5 => new (x+1,y+1),
        6 => new (x+1,y-1),
        7 => new (x-1,y+1),
    };
    }
}


class Solution
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int height = int.Parse(inputs[0]);
        int width = int.Parse(inputs[1]);
        
        var grid = new char[width,height];

        for (int i = 0; i < height; i++)
        {
            string row = Console.ReadLine();
            Console.Error.WriteLine(row);
            for (int j = 0; j < width; j++)
            grid[j,i] = char.ToLower(row[j]);
        }
        string wordss = Console.ReadLine();
        Console.Error.WriteLine(wordss);
        string[] words = wordss.Split(' ').OrderByDescending(s => s.Length).ToArray();
        Console.Error.WriteLine(words[0]);
    
        
        var result = TryPlace(words[0], grid);
        
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (char.IsUpper(result[j,i]))   Console.Write(result[j,i]);
                else Console.Write(' ');

            }
            Console.WriteLine();
        }

        char[,] TryPlace(string word, char[,] grid)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {   
                //Console.Error.Write(" Y="+i+" X="+j);
                    for (int m = 0; m < 8; m++)
                    {
                    var cur = new pos(x,y);
                    var newgrid = (char[,])grid.Clone();
                    int endX = (word.Length-1)*cur.Seek(m).x - (word.Length-2)*x ;
                    int endY = (word.Length-1)*cur.Seek(m).y - (word.Length-2)*y;
                    if (endX < 0 || endX >= width  || endY < 0 || endY >= height) continue;

                        for (int k = 0; k < word.Length; k++)
                        {
                            if (newgrid[cur.x,cur.y] == char.ToLower(word[k]) || newgrid[cur.x,cur.y] == word[k] || newgrid[cur.x,cur.y] == '.')
                            {
                            newgrid[cur.x,cur.y] = word[k];
                            cur = cur.Seek(m);
                            }
                            else break;
                            if (k == (word.Length-1)) 
                            {
                                Console.Error.WriteLine();
                                Console.Error.Write($"{word} with {m} at {cur.x},{cur.y}");
                                int l = Array.IndexOf(words, word);
                                if (l+1 == words.Length) 
                                {   
                                    Console.Error.WriteLine("YUPIIEEEEE");
                                    return newgrid;
                                }
                                Console.Error.WriteLine($"trying {words[l+1]}");
                                var result = TryPlace(words[l+1], newgrid);
                                
                                if (result != null)
                                {
                                return result;  // Return successful grid from recursion
                                }
                            }
                        }
                    }
                }
            }
        return null;
        }


        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }
}
