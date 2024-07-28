namespace GUI.Models;

public class FlightLog
{
    public int Id { get; set; }
    public int FlightId { get; set; }
    public Flight Flight { get; set; }
    public int LegId { get; set; }
    public Leg Leg { get; set; }
    public DateTime In { get; set; }
    public DateTime? Out { get; set; }
}