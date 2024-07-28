namespace GUI.Models;

public class Leg
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public FlightStatus Type { get; set; }
    public int CrossingTime { get; set; }
    public ICollection<Flight> CurrectFlights { get; set; }
}