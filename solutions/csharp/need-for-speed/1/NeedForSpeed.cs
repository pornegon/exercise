class RemoteControlCar
{
    public int speed = 5;
    public int batteryDrain = 2;
    public int battery = 100;
    int driven = 0;
    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }
    
    
    // TODO: define the constructor for the 'RemoteControlCar' class

    public bool BatteryDrained() => battery < batteryDrain;

    public int DistanceDriven() => driven;

    public void Drive()
    {
         if (!BatteryDrained()) 
         {
             driven += speed;
             battery -= batteryDrain;
         }
    }

    public static RemoteControlCar Nitro() =>  new RemoteControlCar(50, 4);
}

class RaceTrack
{
    int distance = 800;
    public RaceTrack(int distance)
    {
        this.distance  = distance;
    }
    // TODO: define the constructor for the 'RaceTrack' class

    public bool TryFinishTrack(RemoteControlCar car) => distance <= car.speed*(car.battery/car.batteryDrain);
}
