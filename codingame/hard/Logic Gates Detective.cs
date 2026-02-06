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
        string input = Console.ReadLine();
        Console.Error.WriteLine(input);

        var inp = new Dictionary<string,int>();
            foreach (string pair in input.Split(' '))
            {
                var ele = pair.Split(':');
                inp[ele[0]] = Int32.Parse(ele[1]);
            }

        string outp = Console.ReadLine();
        Console.Error.WriteLine(outp);
        string[] output = outp.Split(' ');
        var seek = ((string[])output.Clone()).ToList();
        var cache = new HashSet<string>();

        var oper = new Dictionary<string,string[]>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string rw = Console.ReadLine();
            string[] row = rw.Split(' ');
            Console.Error.WriteLine(rw);
            oper[row[^1]] = row[0..3];
            if (!inp.ContainsKey(row[0]) && !seek.Contains(row[0]))  seek.Add(row[0]);
            if (!inp.ContainsKey(row[2]) && !seek.Contains(row[2]))  seek.Add(row[2]);
        }

        while (seek.Any(a => output.Contains(a)))
        {
            for (int i = 0; i < seek.Count; i++)
                {
                if (Count(seek[i]))
                    {
                        Console.Error.WriteLine(string.Join(", ",seek));
                        i--;
                    }
                }
            cache.Clear();
        }

        foreach (var var in output)
            Console.Write(inp[var]);

        bool Count(string var)
        {
            Console.Error.WriteLine($"trying {var}");
            if (cache.Contains(var))
                return false;
            cache.Add(var);
            Console.Error.WriteLine(string.Join(",",cache));
            if (inp.ContainsKey(var))
            {
                cache.Remove(var);
                seek.Remove(var);
                return true;
            }
            if (oper.ContainsKey(var))
            {
                Console.Error.WriteLine($"computing {var} = {string.Join(" ", oper[var])}");
                string arg1 = oper[var][0];
                string op = oper[var][1];
                string arg2 = oper[var][2];
                if (inp.ContainsKey(arg1) || inp.ContainsKey(arg2))
                    {
                        int i = inp.ContainsKey(arg1) ?  0 : 2;
                        if (CanBeEzToo(var, oper[var][i]))
                        {
                        cache.Remove(var);
                        seek.Remove(var);
                        return true;
                        }
                    }

                int a1;
                int a2;
                if ((inp.ContainsKey(arg1) || Count(arg1)) && (inp.ContainsKey(arg2) || Count(arg2)))
                {
                    a1 = inp[arg1];
                
                    a2 = inp[arg2];
                    if (op == "or") inp[var] = a1 | a2;
                    if (op == "and") inp[var] = a1 & a2;
                    if (op == "xor") inp[var] = a1 ^ a2;
                    Console.Error.WriteLine($"{var} = {inp[var]}");
                    cache.Remove(var);
                    seek.Remove(var);
                    return true;
                }

            }
            Console.Error.WriteLine($"seeking {var}");
            foreach (var line in oper)
                {
                    if (line.Value.Contains(var))
                    {
                        int i = Array.IndexOf(line.Value, var);
                        int j = i == 0 ? 2 : 0;
                        if (inp.ContainsKey(line.Key))
                        {
                            Console.Error.WriteLine(line.Value[j]+"  "+line.Value[i]);
                            oopsie:
                            if (CanBeEz(var, line, j))
                            {
                                cache.Remove(var);
                                seek.Remove(var);
                                return true;
                            }
                            if (!inp.ContainsKey(line.Value[j]) && !Count(line.Value[j]))
                                continue;
                            if (line.Value[1] == "xor")
                            {
                                inp[var] = inp[line.Value[j]] ^ inp[line.Key];
                                Console.Error.WriteLine($"through xor {var} = {inp[var]}");
                                seek.Remove(var);
                                cache.Remove(var);
                                return true;
                            }
                            if ((line.Value[1] == "or" || line.Value[1] == "and") && inp[line.Key] != inp[line.Value[j]])
                            {
                                inp[var] = inp[line.Key];
                                Console.Error.WriteLine($"through OR {var} = {inp[var]}");
                                cache.Remove(var);
                                seek.Remove(var);
                                return true;
                            }
                        }
                    }
                }
                Console.Error.WriteLine($"cant find {var}");
                return false;
            
        }

        bool CanBeEz(string var, KeyValuePair<string,string[]> line, int j)
        {
            if ((line.Value[1] == "or" && inp[line.Key] == 0) || (line.Value[1] == "and" && inp[line.Key] == 1))
                {
                    inp[var] = inp[line.Key];
                    inp[line.Value[j]] = inp[var];
                    Console.Error.WriteLine($"{var} = {line.Value[j]} = {inp[var]}");
                    return true;
                }
            return false;
        }
    
        bool CanBeEzToo(string var, string arg)
        {
            if ((oper[var][1] == "or" &&  inp[arg] == 1) || (oper[var][1] == "and" &&  inp[arg] == 0))
                {
                    inp[var] = inp[arg];
                Console.Error.WriteLine(var);
                    Console.Error.WriteLine($"{var} = {inp[var]}, quite easily");
                    return true;
                }
            return false;
        }


    }
}
