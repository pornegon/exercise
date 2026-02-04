public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
       List<int> sum = new List<int>();
        foreach (int mult in multiples)
        {    
            if (mult == 0) continue;
            int j = max % mult == 0 ? (int)(max/mult)-1 : (int)(max/mult);
            for (int i = 0; i<=j; i++)
                if (!sum.Contains(mult*i)) sum.Add(mult*i);
        }
        return sum.Sum();
    }
}