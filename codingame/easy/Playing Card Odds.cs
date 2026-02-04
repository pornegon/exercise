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
        string[] inputs = Console.ReadLine().Split(' ');
        int R = int.Parse(inputs[0]);
        int S = int.Parse(inputs[1]);

        Dictionary<char, List<char>> deck = new Dictionary<char, List<char>>();
        char[] suits = {'C','D','H','S'};
        string ranks = "23456789TJQKA";
        for (int i = 0; i < 4; i++)
        {
            char suit = suits[i];
            deck.Add(suit, ranks.ToCharArray().ToList());
            Console.Error.WriteLine(String.Join(',', deck[suit]));

        }
        for (int i = 0; i < R; i++)
        {
            string removed = Console.ReadLine();
            Console.Error.WriteLine(removed);
            var re = removed.ToCharArray();
            var resuit = (suits.Intersect(re).Count() > 0) ? suits.Intersect(re) : suits;
            var justsuit = (suits.Intersect(re).Count() == re.Count()) ? re : null;
            Console.Error.WriteLine("resuits: "+String.Join(',', resuit));
            var rerank = re.Except(suits).ToList();
            if (justsuit == null) 
            { 
                foreach (char c in resuit)
                {
                    var newrank = deck[c].Except(rerank).ToList();
                    deck[c] = newrank; 
                    Console.Error.WriteLine(c+" now "+String.Join(',', newrank));
                }
            }
            else foreach (char c in justsuit)
                    deck[c].Clear();
        }
        int count = 0;
        foreach (char c in suits) count += deck[c].Count();
        Console.Error.WriteLine(count);
        int check = 0;

        for (int i = 0; i < S; i++)
        {
            string sought = Console.ReadLine();
            var co = sought.ToCharArray();
            var cosuit = (suits.Intersect(co).Count() > 0) ? suits.Intersect(co) : suits;
            var justsuit = (suits.Intersect(co).Count() == co.Count()) ? co : null;
            var corank = co.Except(suits).ToList();
            Console.Error.WriteLine("sought "+sought+" is "+String.Join(',', cosuit)+" of "+String.Join(',', corank));
            if (justsuit == null) 
            {
                foreach (char c in cosuit)
                {
                    var intersect = deck[c].Intersect(corank).ToList();
                    Console.Error.WriteLine("found "+String.Join(',', intersect)+"in "+c);
                    check += intersect.Count();
                    var newrank = deck[c].Except(corank).ToList();
                    deck[c] = newrank; 
                     Console.Error.WriteLine(check);
                }
            }
            else foreach (char c in justsuit)
                {
                    check += deck[c].Count();
                     Console.Error.WriteLine(check);
                    deck[c].Clear();
                }
            
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(Convert.ToInt32(100*check/count)+"%");

    
        
    }
}
