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

        var rooms = new Dictionary<int, (int money, int a, int b)>();
        var memo = new Dictionary<int, int>();

        for (int i = 0; i < N; i++)
        {
            string room = Console.ReadLine();
            Console.Error.WriteLine(room);
            var r = room.Split(" ");
            var r2 = new int[r.Length];
            for (int j = 0; j < r.Length; j++)
            {
                if (Int32.TryParse(r[j], out int num)) r2[j] = num;
                else r2[j] = -1;
            }
            rooms[r2[0]] = (r2[1], r2[2], r2[3]);
        }

        int max = FindMax(0);
        Console.WriteLine(max);

        int FindMax(int roomId)
        {
            if (memo.ContainsKey(roomId))
                return memo[roomId];
            
            var (money, doorA, doorB) = rooms[roomId];
            
            if (doorA == -1 && doorB == -1)
            {
                memo[roomId] = money;
                return money;
            }
            
            // Recursive cases
            int maxFromA = 0;
            int maxFromB = 0;
            
            if (doorA != -1)
                maxFromA = FindMax(doorA);
            
            if (doorB != -1)
                maxFromB = FindMax(doorB);
            
            // Take the better of the two paths + current room money
            int result = money + Math.Max(maxFromA, maxFromB);
            memo[roomId] = result;
            
            return result;
        }
       
    }
}
