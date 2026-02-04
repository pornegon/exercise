class RemoteControlCar
{
    public int distance = 0;
    public int charge = 100;
    
    public static RemoteControlCar Buy() => new RemoteControlCar();
        
    public string DistanceDisplay() => $"Driven {distance} meters";

    public string BatteryDisplay() => charge > 0 ? $"Battery at {charge}%" : "Battery empty";

    public void Drive()
    {
        if (charge > 0)
        {
            distance += 20;
            charge -= 1;
        }
    }
}
