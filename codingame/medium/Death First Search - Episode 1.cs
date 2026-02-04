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
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        //List<int> node1 = new List<int>();
        //List<int> node2 = new List<int>();
        Dictionary<int, List<int>> links = new Dictionary<int, List<int>>();
        int[] gates = new int[E];

        for (int i = 0; i < N; i++) links[i] = new List<int>();

        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            links[N1].Add(N2);
            links[N2].Add(N1);
        }
        //Console.Error.WriteLine($"{String.Join( ", ",links[0])}   {String.Join( ", ",links[11])}");
        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            gates[i] = EI;
            Console.Error.WriteLine($"gate: {EI} connects: {String.Join( ", ",links[EI])}");
        }
        // game loop
        while (true)
       {
           int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Bobnet agent is positioned this turn'
           int imin = int.MaxValue;
           int[] sever = new int[N];
           foreach (int gate in gates)
           {
             var q = new Queue<int>();
             int i = 1;
             int j = 0;
             q.Enqueue(gate);
             int hop = q.Count;
             int node = 0;
             while (q.Contains(SI) == false)
             {
                node = q.Dequeue();
                links[node].ForEach(node => q.Enqueue(node));
                j++;
                if (q.Contains(SI)) break;
                if (j == hop)
                {
                    j=0;
                    hop = q.Count;
                    Console.Error.WriteLine(i+" hops, queued "+string.Join(", ", q));
                    i++;
                }
             }
             if (i < imin)
             {
                imin = i;
                sever[imin] = node;
             }
             Console.Error.WriteLine($"gate: {gate} connects: {node} in {i} hops");
           }
        Console.WriteLine($"{sever[imin]} {SI}");

   
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // Example: 0 1 are the indices of the nodes you wish to sever the link between
            
        }
    }
}
