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
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // number of columns.
        int H = int.Parse(inputs[1]); // number of rows.

        int[,] rooms = new int[H,W];
        int[] down = new int[]{1,3,7,8,9,12,13};
        
        for (int i = 0; i < H; i++)
        {
            string[] LINE = Console.ReadLine().Split(' '); // represents a line in the grid and contains W integers. Each integer represents one room of a given type.
            for (int j = 0; j < W; j++) rooms [i,j] = Int32.Parse(LINE[j]);
        }
        int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int XI = int.Parse(inputs[0]);
            int YI = int.Parse(inputs[1]);
            string POS = inputs[2];
            if (down.Contains(rooms[YI, XI]) || (rooms[YI, XI] == 4 && POS == "RIGHT") || (rooms[YI, XI] == 5 && POS == "LEFT")) 
            Console.WriteLine($"{XI} {YI+1}");
            else if ((rooms[YI, XI] == 2 && POS == "LEFT") || (rooms[YI, XI] == 6 && POS == "LEFT") || (rooms[YI, XI] == 5 && POS == "TOP") || (rooms[YI, XI] == 11))
            Console.WriteLine($"{XI+1} {YI}");
            else if ((rooms[YI, XI] == 2 && POS == "RIGHT") || (rooms[YI, XI] == 6 && POS == "RIGHT") || (rooms[YI, XI] == 4 && POS == "TOP") || (rooms[YI, XI] == 10))
            Console.WriteLine($"{XI-1} {YI}");



            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // One line containing the X Y coordinates of the room in which you believe Indy will be on the next turn.
        }
    }
}
