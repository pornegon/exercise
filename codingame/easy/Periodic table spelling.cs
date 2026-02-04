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
        string word = Console.ReadLine();
        List<string> results = new List<string>();

        string[] table = new string("H He Li Be B C N O F Ne Na Mg Al Si P S Cl Ar K Ca Sc Ti V Cr Mn Fe Co Ni Cu Zn Ga Ge As Se Br Kr Rb Sr Y Zr Nb Mo Tc Ru Rh Pd Ag Cd In Sn Sb Te I Xe Cs Ba La Ce Pr Nd Pm Sm Eu Gd Tb Dy Ho Er Tm Yb Lu Hf Ta W Re Os Ir Pt Au Hg Tl Pb Bi Po At Rn Fr Ra Ac Th Pa U Np Pu Am Cm Bk Cf Es Fm Md No Lr Rf Db Sg Bh Hs Mt Ds Rg Cn Nh Fl Mc Lv Ts Og")
        .Split(" ");

        Find(0, "");

        Console.WriteLine (results.Count > 0 ? string.Join("\n", results) : "none");

        void Find(int i, string cur)
        {
            if (i >= word.Length) 
            {
                results.Add(cur);
                return;
            }

            string uno = word.Substring(i,1).ToLower();
            foreach (string s in table)
            {
                if (s.ToLower() == uno) 
                {
                    Find(i+1, cur+s);
                    Console.Error.WriteLine(cur+s);
                }
            }
            if (i+1 < word.Length)
            {
            string dos = word.Substring(i,2).ToLower();
                foreach (string s in table)
                {
                    if (s.ToLower() == dos) 
                    {
                        Find(i+2, cur+s);
                        Console.Error.WriteLine(cur+s);
                    }
                }
            }
        }

       
        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

    }
}
