using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Text.Json;
using System.IO; // Make sure you have this using statement

namespace WebApplication1.Pages.Shared;

public class SchedulingHelper : PageModel
{
    private readonly ILogger<EventsModel> _logger;

    public SchedulingHelper(ILogger<EventsModel> logger)
    {
        _logger = logger;
    }

    public List<EventData> EventsList { get; set; } = new();

    public string Message { get; set; }

    // TODO: Terrible, replace this with SQL Server logic later
    public void OnGet()
    {        

        // 'Last updated' text
        string dateTime = DateTime.Now.ToString("t", new CultureInfo("en-US"));
        ViewData["TimeStamp"] = dateTime;

        // Read events from text file
        string filePath = "events.txt";
        if (System.IO.File.Exists(filePath))
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            EventsList = lines.Select(line => JsonSerializer.Deserialize<EventData>(line)).ToList();
        }
    }
}

// Helper class to hold event data
public class EventData
{
    public string UserID { get; set; }
    public int EventID { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public string EventName { get; set; }
    public string Notes { get; set; }
}
