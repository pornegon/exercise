static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance < 0) return 3.213f;
        if (balance >= 0 && balance < 1000) return 0.5f;
        if (balance >= 1000 && balance < 5000) return 1.621f;
        else return 2.475f;
        
    }

    public static decimal Interest(decimal balance) => balance*Convert.ToDecimal(InterestRate(balance))/100;

    public static decimal AnnualBalanceUpdate(decimal balance) => balance+Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance) 
          {
        int years = 0;
        decimal currentBalance = balance;
        
        while (currentBalance < targetBalance)
        {
            currentBalance = AnnualBalanceUpdate(currentBalance);
            years++;
        }
        
        return years;
    }
}
