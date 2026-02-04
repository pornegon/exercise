public class Anagram
{
    private string baseWord;
    public Anagram(string baseWord)
    {
        this.baseWord = baseWord;
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var results = new List<string>();
        foreach (string test in potentialMatches)
        {
            if (test.ToLower() == baseWord.ToLower())
                continue;
            bool match = true;
            foreach (char c in test)
                if (!baseWord.ToLower().Contains(Char.ToLower(c)) || baseWord.Count(a => Char.ToLower(a) == Char.ToLower(c)) != test.Count(a => Char.ToLower(a) == Char.ToLower(c))) match = false;
            if (test.Length == baseWord.Length && match)
                results.Add(test);
        }
        return results.ToArray();
    }
}