class WeighingMachine
{
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
    // TODO: define the 'Precision' property
    public int Precision { get ; }

    // TODO: define the 'Weight' property
    public double _weight;
    public double Weight {get => _weight;
                           set => _weight = value < 0 
                            ? throw new ArgumentOutOfRangeException(nameof(value), "Weight cannot be negative") 
                            : value; }

    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment { get; set; } = 5;

    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight { get
        {
            double displayWeight = _weight - TareAdjustment;
            // Use string.Format instead of interpolation to avoid any parsing issues
            return string.Format("{0:F" + Precision + "} kg", displayWeight);
        }
                                }
}
