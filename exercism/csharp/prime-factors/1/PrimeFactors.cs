public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        var fac = new List<long>();
        while (number > 1)
            fac.Add(Loop(ref number));
        return fac.ToArray();
        
        
    }
    
    static int Loop(ref long number)
    {
        int i = 2;
        while (number % i > 0)
            i++;
        number /= i;
        return i;
    }
}