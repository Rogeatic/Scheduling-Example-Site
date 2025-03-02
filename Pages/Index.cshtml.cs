using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Text.Json;
using WebApplication1.Pages.Shared; // Reference to the BasePageModel

namespace WebApplication1.Pages;

public class IndexModel : SchedulingHelper
{

    private readonly SchedulingHelper _schedulingHelper;

    public IndexModel(SchedulingHelper schedulingHelper, ILogger<EventsModel> logger) : base(logger)
    {
        _schedulingHelper = schedulingHelper;
    }

    //public void OnGet()
    //{
    //    _schedulingHelper.OnGetEvents();
    //}
}