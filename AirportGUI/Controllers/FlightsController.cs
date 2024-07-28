using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using GUI.Models;

namespace AirportGUI.Controllers;


public class FlightsController : Controller
{
    private readonly HttpClient _httpClient;

    public FlightsController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IActionResult> Dashboard()
    {
        var legsResponse = await _httpClient.GetStringAsync("http://localhost:5084/api/FlightOperations/legs");
        var flightLogsResponse = await _httpClient.GetStringAsync("http://localhost:5084/api/FlightOperations/logs");
        var flightsResponse = await _httpClient.GetStringAsync("http://localhost:5084/api/FlightOperations/flights");

        var legs = JsonConvert.DeserializeObject<List<Leg>>(legsResponse);
        var flightLogs = JsonConvert.DeserializeObject<List<FlightLog>>(flightLogsResponse);
        var flights = JsonConvert.DeserializeObject<List<Flight>>(flightsResponse);

        var model = new DashboardViewModel
        {
            Legs = legs,
            FlightLogs = flightLogs,
            Flights = flights
        };

        return View(model);
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetStringAsync("http://localhost:5084/api/FlightOperations/flights");
        var flights = JsonConvert.DeserializeObject<List<Flight>>(response);
        var filteredFlights = flights.Where(f => f.CurrentLeg?.Id != -1 && f.CurrentLeg?.Id != 10).ToList();
        return View(filteredFlights);
    }

    public async Task<IActionResult> Update()
    {
        var response = await _httpClient.GetStringAsync("http://localhost:5084/api/FlightOperations/flights");
        var flights = JsonConvert.DeserializeObject<List<Flight>>(response);
        var filteredFlights = flights.Where(f => f.CurrentLeg?.Id != -1 && f.CurrentLeg?.Id != 10).ToList();
        return PartialView("_FlightTable", filteredFlights);
    }

    public async Task<IActionResult> Logs()
    {
        var response = await _httpClient.GetStringAsync("http://localhost:5084/api/FlightOperations/logs");
        var logs = JsonConvert.DeserializeObject<List<FlightLog>>(response);
        var filteredLogs = logs.Where(l => l.LegId != -1 && l.LegId != 10).ToList();
        return View(logs);
    }

    public async Task<IActionResult> UpdateLogs()
    {
        var response = await _httpClient.GetStringAsync("http://localhost:5084/api/FlightOperations/logs");
        var logs = JsonConvert.DeserializeObject<List<FlightLog>>(response);
        var filteredLogs = logs.Where(l => l.LegId != -1 && l.LegId != 10).ToList();
        return PartialView("_FlightLogTable", logs);
    }

    public async Task<IActionResult> Legs()
    {
        var response = await _httpClient.GetStringAsync("http://localhost:5084/api/FlightOperations/legs");
        var legs = JsonConvert.DeserializeObject<List<Leg>>(response);
        return View(legs);
    }

    public async Task<IActionResult> UpdateLegs()
    {
        var response = await _httpClient.GetStringAsync("http://localhost:5084/api/FlightOperations/legs");
        var legs = JsonConvert.DeserializeObject<List<Leg>>(response);
        return PartialView("_LegsTable", legs);
    }
}


