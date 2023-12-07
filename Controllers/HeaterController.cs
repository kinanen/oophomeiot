using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeIOT.Models;

namespace HomeIOT.Controllers;

public class HeaterController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Home _demoHome;
    public HeaterController(ILogger<HomeController> logger, Home demoHome)
    {
        _logger = logger;
        _demoHome = demoHome;
    }

    [HttpPost]
    public IActionResult AddHeater(string roomName)
    {
        Heater newHeater;

        Room room = _demoHome.Rooms.Find(r => r.Name == roomName);

        newHeater = new Heater(room);

        var status = _demoHome.GetStatus();
        return Json(status);
    }
}