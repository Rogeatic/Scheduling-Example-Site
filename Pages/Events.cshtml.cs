using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Text.Json;
using System.IO; // Make sure you have this using statement
using WebApplication1.Pages.Shared; // Reference to the BasePageModel

namespace WebApplication1.Pages;
public class EventsModel : SchedulingHelper
{
    private readonly SchedulingHelper _schedulingHelper;

    public EventsModel(SchedulingHelper schedulingHelper, ILogger<EventsModel> logger) : base(logger)
    {
        _schedulingHelper = schedulingHelper;
    }
    private static Dictionary<string, int> userEventCounts = new();

    [BindProperty]
    public string EventName { get; set; }
    [BindProperty]
    public string EventDate { get; set; }
    [BindProperty]
    public string EventTime { get; set; }
    [BindProperty]
    public string EventNotes { get; set; }

    // TODO: Terrible, replace this with SQL Server logic later
    public void OnPostSubmit()
    {
        // Replace with actual user ID logic (e.g., from authentication)
        string userId = "User123"; 

        // Increment EventID per user
        if (!userEventCounts.ContainsKey(userId))
            userEventCounts[userId] = 0;
        int eventId = ++userEventCounts[userId];

        // Create an event object
        var eventData = new EventData
        {
            UserID = userId,
            EventID = eventId,
            EventName = EventName,
            Date = EventDate,
            Time = EventTime,
            Notes = EventNotes
        };

        // Save the event
        string filePath = "events.txt";
        string jsonData = JsonSerializer.Serialize(eventData);
        System.IO.File.AppendAllText(filePath, jsonData + Environment.NewLine);

        Message = "Event saved successfully!";
    }

    public void OnPostDelete()
    {
        // Logic for Delete button
        Console.WriteLine("Delete button clicked");
    }


    public bool ShowEventForm { get; set; } = true;
    public void ToggleForm()
    {
        ShowEventForm = !ShowEventForm; // Toggle the form visibility
    }
}