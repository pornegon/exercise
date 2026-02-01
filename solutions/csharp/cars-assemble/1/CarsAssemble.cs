static class AssemblyLine
{
    public static double SuccessRate(int x)
    {
        if (x==0) return 0;
        if (x>0 && x<5) return 1;
        if (x>4 && x<9) return 0.9;
        if (x==9) return 0.8;
        if (x==10) return 0.77;
        else return 0;
        
    }
    
    public static double ProductionRatePerHour(int speed) => 221*speed*SuccessRate(speed);
        
    public static int WorkingItemsPerMinute(int speed) => (int)(ProductionRatePerHour(speed)/60);
}
