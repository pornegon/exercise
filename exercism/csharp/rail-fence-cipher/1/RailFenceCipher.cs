public class RailFenceCipher
{
    private int rails;
    public RailFenceCipher(int rails)
    {
        this.rails = rails;
    }

    public string Encode(string input) 
    {
    if (rails <= 1) return input;
    
    List<char>[] fence = new List<char>[rails];
    for (int i = 0; i < rails; i++)
        fence[i] = new List<char>();
    
    int rail = 0;
    int dir = 1;
    
    foreach (char ch in input)
    {
        fence[rail].Add(ch);
        
        if (rail == 0 && dir == -1)
            dir = 1;
        else if (rail == rails - 1 && dir == 1)
            dir = -1;
        
        rail += dir;
    }

    string result = "";
        for (int i = 0; i < rails; i++)
            result += string.Join("", fence[i]);
    return result;

    }
    
    public string Decode(string input)
    {
    if (rails <= 1) return input;

    int[] railLengths = new int[rails];
    int L = input.Length;
    string[] encoded = new string[rails];
    string result = "";
    int rail = 0;
    int dir = 1;
        
        for (int i = 0; i < input.Length; i++)
        {
            railLengths[rail]++;
            
            if (rail == 0)
                dir = 1;
            else if (rail == rails - 1)
                dir = -1;
            
            rail += dir;
        }

        for (int i = 0; i < rails; i++)
        {
            encoded[i] = input.Remove(railLengths[i]);
            input = input.Substring(railLengths[i]);
            Console.WriteLine(encoded[i]);
        }

        dir = 1;
        rail = 0;
        int[] railIndices = new int[rails];

        for (int i = 0; i < L; i++)
        {
            
            result += encoded[rail][railIndices[rail]];
            Console.WriteLine(result);
           railIndices[rail]++;
            
            
            if (rail == 0)
            { 
                dir = 1;
            }
            
            else if (rail == rails-1)
            {
                dir = -1;
            }
            
            rail += dir;
        }
        
    return result;
    }
   
}