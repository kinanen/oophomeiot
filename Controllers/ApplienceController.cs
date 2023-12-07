using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeIOT.Models;

namespace HomeIOT.Controllers;

public class ApplienceController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Home _demoHome;
    public ApplienceController(ILogger<HomeController> logger, Home demoHome)
    {
        _logger = logger;
        _demoHome = demoHome;
    }
    
    [HttpPost]
    public IActionResult AddAppliance(string roomName, string applianceType, string applianceName)
    {
        Applience newAppliance;
        if (roomName.Equals("HouseAppliance"))
        {
            newAppliance = new Applience(applianceName, _demoHome);
        }

        else
        {
            Room room = _demoHome.Rooms.Find(r => r.Name == roomName);

            switch (applianceType)
            {
                case "kitchen":
                    newAppliance = new KitchenApplience(applianceName, room);
                    break;
                case "cold":
                    newAppliance = new ColdApplience(applianceName, room);
                    break;
                default:
                    newAppliance = new Applience(applianceName, room);
                    break;
            }
        }
        var status = _demoHome.GetStatus();
        return Json(status);
    }

    [HttpPost]
    public IActionResult Run(string roomName, string applianceName)
    {
        Applience applience = _demoHome.Appliences.Find(a => a.Name == applianceName);
        if (applience != null)
        {
            applience.Run();
        }

        else
        {
            Room r = _demoHome.Rooms.Find(r => r.Name == roomName);
            applience = r.Appliences.Find(a => a.Name == applianceName);
            applience.Run();
        }

        var status = _demoHome.GetStatus();
        return Json(status);

    }

    [HttpPost]
    public IActionResult Stop(string roomName, string applianceName)
    {
        Applience applience = _demoHome.Appliences.Find(a => a.Name == applianceName);
        if (applience != null)
        {
            applience.Stop();
        }

        else
        {
            Room r = _demoHome.Rooms.Find(r => r.Name == roomName);
            applience = r.Appliences.Find(a => a.Name == applianceName);
            applience.Stop();
        }

        var status = _demoHome.GetStatus();
        return Json(status);

    }

    

}