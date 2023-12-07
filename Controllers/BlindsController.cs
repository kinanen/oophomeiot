using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeIOT.Models;

namespace HomeIOT.Controllers;

public class BlindsController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Home _demoHome;
    public BlindsController(ILogger<HomeController> logger, Home demoHome)
    {
        _logger = logger;
        _demoHome = demoHome;
    }
    
    [HttpPost]
    public IActionResult AddBlinds(string roomName,string windowName)
    {
        Blinds newBlinds;
        Room room = _demoHome.Rooms.Find(r => r.Name == roomName);
        newBlinds = new Blinds(room, windowName);
        var status = _demoHome.GetStatus();
        return Json(status);
    }
}