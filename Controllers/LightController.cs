    using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeIOT.Models;

namespace HomeIOT.Controllers;

public class LightController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Home _demoHome;
    public LightController(ILogger<HomeController> logger, Home demoHome)
    {
        _logger = logger;
        _demoHome = demoHome;
    }

    
    [HttpPost]
    [HttpPost]
    public IActionResult AddLight(string roomName, string lightType, string lightName)
    {
        Light newLight;

            Room room = _demoHome.Rooms.Find(r => r.Name == roomName);

            switch (lightType)
            {
                case "kitchen":
                    newLight = new LightDimmable(lightName, room);
                    break;
                default:
                    newLight = new Light(lightName, room);
                    break;
            }


        var status = _demoHome.GetStatus();
        return Json(status);
    }
}