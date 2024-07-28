namespace GUI.Models;

[Flags]
public enum FlightStatus
{
    None = 0,
    Landing = 1 << 0,
    Arrival = 1 << 1,
    Departure = 1 << 2,
}