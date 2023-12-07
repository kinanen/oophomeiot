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
}