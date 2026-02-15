public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    { 
        try
        {
            long res = checked(@base * multiplier);
            return "" + res;
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float result = @base * multiplier;
        
        return float.IsInfinity(result) || float.IsNaN(result)
            ? "*** Too Big ***"
            : result.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            decimal res = checked(salaryBase * multiplier);
            return "" + res;
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}
