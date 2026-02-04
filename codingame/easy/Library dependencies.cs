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
        int nImp = int.Parse(Console.ReadLine());
        var imp = new List<string>();

        for (int i = 0; i < nImp; i++)
        {
            string import = Console.ReadLine();
            imp.Add(import.Substring(import.IndexOf(' ')+1));
        }
        Console.Error.WriteLine(string.Join(", ", imp));

        int nDep = int.Parse(Console.ReadLine());
        var dep = new Dictionary<string, List<string>>();
        
        for (int i = 0; i < nDep; i++)
        {
            string dependency = Console.ReadLine();
            string a = dependency.Remove(dependency.IndexOf(" "));
            var b = dependency.Substring(dependency.IndexOf(" ")).Replace(" requires ", "").Split(", ").ToList();
            dep[a] = b;
            Console.Error.WriteLine($"{a}:  {string.Join(", ", b)}");
        }
        
        var sort = new List<string>();

        if (Seek(out int I)) Console.WriteLine("Compiled successfully!");
        else
        {
            Console.WriteLine($"Import error: tried to import {imp[I]} but {dep[imp[I]][0]} is required.");
            imp.Sort();
            bool loop = false;
            for (int i = 0; i < imp.Count; i++)
            {
                if (!dep.ContainsKey(imp[i])) 
                {
                    sort.Add(imp[i]);
                    imp.RemoveAt(i);
                    i--;
                }
            }
            Console.Error.WriteLine($"{0}:  {string.Join(", ", sort)}");
            
            if (sort.Count == 0)
                loop = true;
            else
                DFS(ref loop);
            
            Console.Error.WriteLine(string.Join(", ", imp));
            if (loop) 
            {
                Console.WriteLine("Fatal error: interdependencies.");
                return; 
            }
            Console.WriteLine("Suggest to change import order:");
            foreach (var sorted in sort) 
                Console.WriteLine($"import {sorted}");




        }

        bool Seek(out int i)
        {
            for (i = 0; i < imp.Count; i++)
            {
                int b = i;
                if (!dep.ContainsKey(imp[i]) || dep[imp[i]].All(a => imp[..(b+1)].Contains(a)))
                    continue;
                return false;
            }
        return true;
        }

        void DFS(ref bool loop)
        {
            loop = true;
            for (int i = 0; i < imp.Count; i++)
            {
                if (dep[imp[i]].All(a => sort.Contains(a)))
                {
                    loop = false;
                    int ind = 0;
                    foreach (string depe in dep[imp[i]])
                    {
                        ind = Math.Max(ind, sort.IndexOf(depe));
                        Console.Error.WriteLine("sneed");
                    }
                    Console.Error.Write(" og "+ind);
                    while (ind < sort.Count-1 && string.Compare(sort[ind+1], imp[i]) < 0)
                    {
                        ind++;
                        Console.Error.WriteLine("sneed");
                    } 
                    sort.Insert(ind+1, imp[i]);
                    Console.Error.Write($" inserted {imp[i]} at {ind} ");
                    imp.RemoveAt(i);
                }
            }
            if (loop == true) return;
            if (imp.Count > 0) DFS(ref loop);
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }
}
