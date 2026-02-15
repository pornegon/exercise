using System.Runtime.InteropServices;
using System.Globalization;


public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location) => 
        TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(appointmentDateDescription), zone(location));
    
    public static TimeZoneInfo zone (Location location)
    {
        string timezoneID = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) switch
        {
                true => location switch
                {
                        Location.NewYork => "Eastern Standard Time",
                        Location.London => "GMT Standard Time",
                        Location.Paris => "W. Europe Standard Time"
                },
                false => location switch
                {
                        Location.NewYork => "America/New_York",
                        Location.London => "Europe/London",
                        Location.Paris => "Europe/Paris"   
                }
        };
        return TimeZoneInfo.FindSystemTimeZoneById(timezoneID);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) => alertLevel switch
    {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddMinutes(-105),
            AlertLevel.Late => appointment.AddMinutes(-30)
    };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location) => 
        zone(location).IsDaylightSavingTime(dt) != zone(location).IsDaylightSavingTime(dt.AddDays(-7));

    public static DateTime NormalizeDateTime(string dtStr, Location location) =>
        DateTime.TryParse(dtStr, cultur(location), DateTimeStyles.None, out DateTime result) ? result : new DateTime(1, 1, 1);
    
    public static CultureInfo cultur(Location location) => location switch
        {
            Location.NewYork => new CultureInfo("en-US"),
            Location.London => new CultureInfo("en-GB"),
            Location.Paris => new CultureInfo("fr-FR"),
            _ => CultureInfo.InvariantCulture
        };
}
