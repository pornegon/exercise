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
        var oper = new List<(string op, string arg1, string arg2)>();
        var rej = new List<int>();
        var V = new int?[N];



        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string operation = inputs[0];
            string arg1 = inputs[1];
            string arg2 = inputs[2];
            oper.Add((operation, arg1, arg2));
        }

        Console.Error.WriteLine(string.Join(",", oper));

        foreach (var tuple in oper)
        {   
            int i = oper.IndexOf(tuple);
            if (V[i] == null)
            {
                Count(i);
            }
            Console.WriteLine(V[i]);
        }

        void Count(int i)
        {
            string op = oper[i].op;
            string arg1 = oper[i].arg1;
            string arg2 = oper[i].arg2;
            int a1 = check(arg1);
            int a2 = check(arg2);

            if (op == "VALUE") V[i] = a1;
            if (op == "ADD")  V[i] = (a1+a2);
            if (op == "SUB")  V[i] = (a1-a2);
            if (op == "MULT")  V[i] = (a1*a2);
        }

        int check(string arg)
        {
            int a;
            if (arg.Contains('$'))
            {
                int R = Int32.Parse(arg.Substring(1));
                if (V[R] == null) Count(R);
                return V[R] ?? 0;
            }
            else Int32.TryParse(arg, out a);
            return a;
        }
    }
}
