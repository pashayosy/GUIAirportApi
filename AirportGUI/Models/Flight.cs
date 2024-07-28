namespace GUI.Models;

public class Flight
{
    public int Id { get; set; }
    public string Number { get; set; }
    public int PassengersCount { get; set; }
    public string Brand { get; set; }
    public FlightStatus Status { get; set; }
    public Leg CurrentLeg { get; set; }
    public int? LegId { get; set; }
}


