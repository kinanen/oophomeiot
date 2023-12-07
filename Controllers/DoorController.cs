using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeIOT.Models;

namespace HomeIOT.Controllers;

public class DoorController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly Home _demoHome;

    [HttpPost]
    public IActionResult AddDoor(string doorName)
    {
        Door newDoor = new(doorName, _demoHome);
        var status = _demoHome.GetStatus();
        return Json(status);
    }


}